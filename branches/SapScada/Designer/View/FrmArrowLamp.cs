using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Common;
using Designer.Model;
using HDSComponent;

namespace Designer.View
{
    public partial class FrmArrowLamp : UserControl
    {
        public enum LightState
        {
            OFF = 0x00,
            GREEN = 0x01,
            YELLOW = 0x02,
            RED = 0x04,
            ERR = 0x10,
        }

        public IDisplayTag DisplayTag;
        public Lamp Lamp;

        private int _Direction;
        public int Direction
        {
            get
            {
                return _Direction;
            }
            set
            {
                if ((value <= -180) || (value > 180))
                {
                    value = 0;
                }
                _Direction = value;
                Display();
            }
        }

        private int _CurrentValue = 0;

        public FrmArrowLamp()
        {
            InitializeComponent();
            box.Visible = false;
            contextSetting.Click += contextSetting_Click;
            contextDelete.Click += contextDelete_Click;

        }

        private void FrmArrowLamp_Load(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    this.Size = new System.Drawing.Size(37, 37);
                    box.Size = this.Size;
                });
            }
            else
            {
                this.Size = new System.Drawing.Size(37, 37);
                box.Size = this.Size;
            }
        }

        public void InitDisplayTag()
        {
            if (Lamp != null)
            {
                DisplayTag = new IDisplayTag();
                DisplayTag.Name = Lamp.Tag;// string.Format("{0}.{1}", Lamp.Junction.JunctionName, Lamp.LampID);
                DisplayTag.Address = Program.GetDisplayTagAddress(Lamp.Tag);
                DisplayTag.Value = (int)LightState.OFF;
                DisplayTag.Quality = Quality.Bad;
                DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;

                this.Location = new Point((int)Lamp.X, (int)Lamp.Y);
                this.Direction = (int)Lamp.Direction;
            }
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            if (_CurrentValue != (int)DisplayTag.Value)
            {
                _CurrentValue = (int)DisplayTag.Value;
                Display();
            }
        }

        private void contextDelete_Click(object sender, EventArgs e)
        {
            if (MessageHandler.AskForDeleteRecord())
            {
                if (DesignerAccess.DeleteLamp(Lamp.ID))
                {
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageHandler.DeleteRecordError();
                }
            }
        }

        private void contextSetting_Click(object sender, EventArgs e)
        {
            //FrmDisplayTagSetting f = new FrmDisplayTagSetting();
            //f.Lamp = this.Lamp;
            //f.ShowDialog();
            //this.Direction = (int)Lamp.Direction;
        }

        private Bitmap RotateImage(Image image, float angle)
        {
            return RotateImage(image, (float)image.Width / 2, (float)image.Height / 2, angle, true);
        }

        private Bitmap RotateImage(Image image, float rotateAtX, float rotateAtY, float angle, bool bNoClip)
        {
            int W, H, X, Y;
            if (bNoClip)
            {
                double dW = (double)image.Width;
                double dH = (double)image.Height;

                double degrees = Math.Abs(angle);
                if (degrees <= 90)
                {
                    double radians = 0.0174532925 * degrees;
                    double dSin = Math.Sin(radians);
                    double dCos = Math.Cos(radians);
                    W = (int)(dH * dSin + dW * dCos);
                    H = (int)(dW * dSin + dH * dCos);
                    X = (W - image.Width) / 2;
                    Y = (H - image.Height) / 2;
                    this.Size = new Size(W * 37 / image.Width, H * 37 / image.Height);
                }
                else
                {
                    degrees -= 90;
                    double radians = 0.0174532925 * degrees;
                    double dSin = Math.Sin(radians);
                    double dCos = Math.Cos(radians);
                    W = (int)(dW * dSin + dH * dCos);
                    H = (int)(dH * dSin + dW * dCos);
                    X = (W - image.Width) / 2;
                    Y = (H - image.Height) / 2;
                    this.Size = new Size(W * 37 / image.Width, H * 37 / image.Height);
                }
            }
            else
            {
                W = image.Width;
                H = image.Height;
                X = 0;
                Y = 0;
            }

            //create a new empty bitmap to hold rotated image
            Bitmap bmpRet = new Bitmap(W, H);
            bmpRet.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            bmpRet.MakeTransparent();

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(bmpRet);

            //Put the rotation point in the "center" of the image
            g.TranslateTransform(rotateAtX + X, rotateAtY + Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-rotateAtX - X, -rotateAtY - Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0 + X, 0 + Y));

            this.BackColor = Color.Transparent;
            return bmpRet;
        }

        private void Display()
        {
            Bitmap bm, bm1 = null;
            switch ((int)DisplayTag.Value & 0x0f)
            {
                case (int)LightState.OFF:
                    bm = RotateImage(Properties.Resources.Lamp_Arrow_Off, Direction);
                    break;
                case (int)LightState.RED:
                    bm = RotateImage(Properties.Resources.Lamp_Arrow_Red_Straight, Direction);
                    break;
                case (int)LightState.GREEN:
                    bm = RotateImage(Properties.Resources.Lamp_Arrow_Green_Straight, Direction);
                    break;
                case (int)LightState.YELLOW:
                    bm = RotateImage(Properties.Resources.Lamp_Arrow_Yellow_Straight, Direction);
                    break;
                default:
                    bm = RotateImage(Properties.Resources.Lamp_Arrow_Off, Direction);
                    break;
            }
            this.BackColor = Color.Transparent;
            this.BackgroundImage = bm;

            int error = (int)(int)DisplayTag.Value & 0xf0;
            switch (error)
            {
                case (int)LightState.ERR:
                    bm1 = RotateImage(Properties.Resources.Lamp_Arrow_Error, Direction);
                    break;
            }
            if (bm1 != null)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        box.BackgroundImage = bm1;
                        box.BackgroundImageLayout = ImageLayout.Stretch;
                        box.Size = this.Size;
                        box.BackColor = Color.Transparent;
                        box.Visible = true;
                        box.BringToFront();
                        box.Location = new Point(0, 0);
                    });
                }
                else
                {
                    PictureBox box = new PictureBox();
                    box.BackgroundImage = bm1;
                    box.BackgroundImageLayout = ImageLayout.Stretch;
                    box.Size = this.Size;
                    box.BackColor = Color.Transparent;
                    box.Visible = true;
                    box.BringToFront();
                    box.Location = new Point(0, 0);
                }

            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        box.Visible = false;
                    });
                }
                else
                {
                    box.Visible = false;
                }
            }


        }

        private void FrmArrowLamp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DoDragDrop(e.X, e.Y);
            }
        }

        public void DoDragDrop(int XAxis, int YAxis)
        {
            this.DoDragDrop(new object[] { this, XAxis, YAxis }, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void FrmArrowLamp_LocationChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                if (Lamp != null)
                {
                    Lamp.X = this.Location.X;
                    Lamp.Y = this.Location.Y;
                    if (!DesignerAccess.UpdateLamp(Lamp.ID, Lamp))
                    {
                        MessageHandler.UpdateRecordError();
                    }
                }
                else
                {
                    MessageHandler.UpdateRecordError();
                }
            }
        }


    }
}
