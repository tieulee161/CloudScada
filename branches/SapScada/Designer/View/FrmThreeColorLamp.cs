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
    public partial class FrmThreeColorLamp : UserControl
    {
        public enum LightState
        {
            OFF = 0x00,
            GREEN = 0x01,
            YELLOW = 0x02,
            RED = 0x0C,
            GREEN_ERR = 0x10,
            YELLOW_ERR = 0x20,
            RED_ERR = 0x40,
            RED_YELLOW_ERR = 0x60,
            RED_GREEN_ERR = 0x50,
            GREEN_YELLOW_ERR = 0x30,
            RED_YELLOW_GRREN_ERR = 0x70,

            RED_GREEN = 0x0D,
            GREEN_YELLOW = 0x03,
            RED_YELLOW = 0x0E,
            RED_GREEN_YELLOW = 0x0F,
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
                if ((value < -180) || (value >= 180))
                {
                    value = 0;
                }
                _Direction = value;
                Display();

            }
        }

        private int _CurrentValue = 0;

        public FrmThreeColorLamp()
        {
            InitializeComponent();
            box.Visible = false;
            this.Size = new System.Drawing.Size(37, 86);
            contextSetting.Click += contextSetting_Click;
            contextDelete.Click += contextDelete_Click;

           
        }

        private void ThreeColorLamp_Load(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    this.Size = new System.Drawing.Size(37, 86);
                    box.Size = this.Size;
                });
            }
            else
            {
                this.Size = new System.Drawing.Size(37, 86);
                box.Size = this.Size;
            }
        }

        public void InitDisplayTag()
        {
            if (Lamp != null)
            {
                DisplayTag = new IDisplayTag();
                DisplayTag.Name = Lamp.Tag; //string.Format("{0}.Line{1}", Lamp.Junction.JunctionName, Lamp.LampID);
                DisplayTag.Address = Program.GetDisplayTagAddress(DisplayTag.Name);
                DisplayTag.Value = (int)LightState.OFF;
                DisplayTag.Quality = Quality.Bad;
                DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;

                this.Location = new Point((int)Lamp.X, (int)Lamp.Y);
                this.Direction = (int)Lamp.Direction;
            }
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (_CurrentValue != (int)DisplayTag.Value)
                {
                    _CurrentValue = (int)DisplayTag.Value;
                    Display();
                }
            }
            else
            {
                DisplayTag = null;
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
                    this.Size = new Size(W * 37 / image.Width, H * 86 / image.Height);
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
                    this.Size = new Size(W * 37 / image.Width, H * 86 / image.Height);
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
            if (DisplayTag != null)
            {
                switch ((int)DisplayTag.Value & 0x0f)
                {
                    case (int)LightState.OFF:
                        bm = RotateImage(Properties.Resources.Lamp_Off, Direction);
                        break;
                    case (int)LightState.RED:
                        bm = RotateImage(Properties.Resources.Lamp_Red, Direction);
                        break;
                    case (int)LightState.GREEN:
                        bm = RotateImage(Properties.Resources.Lamp_Green, Direction);
                        break;
                    case (int)LightState.YELLOW:
                        bm = RotateImage(Properties.Resources.Lamp_Yellow, Direction);
                        break;
                    case (int)LightState.GREEN_YELLOW:
                        bm = RotateImage(Properties.Resources.Lamp_Yellow_Green, Direction);
                        break;
                    case (int)LightState.RED_GREEN:
                        bm = RotateImage(Properties.Resources.Lamp_Red_Green, Direction);
                        break;
                    case (int)LightState.RED_YELLOW:
                        bm = RotateImage(Properties.Resources.Lamp_Red_Yellow, Direction);
                        break;
                    case (int)LightState.RED_GREEN_YELLOW:
                        bm = RotateImage(Properties.Resources.Lamp_Red_Yellow_Green, Direction);
                        break;
                    default:
                        bm = RotateImage(Properties.Resources.Lamp_Off, Direction);
                        break;
                }
                this.BackColor = Color.Transparent;
                this.BackgroundImage = bm;

                int error = (int)(int)DisplayTag.Value & 0xf0;
                switch (error)
                {
                    case (int)LightState.RED_ERR:
                        bm1 = RotateImage(Properties.Resources.Lamp_Red_Error, Direction);
                        break;
                    case (int)LightState.GREEN_ERR:
                        bm1 = RotateImage(Properties.Resources.Lamp_Green_Error, Direction);
                        break;
                    case (int)LightState.YELLOW_ERR:
                        bm1 = RotateImage(Properties.Resources.Lamp_Yellow_Error, Direction);
                        break;
                    case (int)LightState.RED_GREEN_ERR:
                        bm1 = RotateImage(Properties.Resources.Lamp_Red_Green_Error, Direction);
                        break;
                    case (int)LightState.RED_YELLOW_ERR:
                        bm1 = RotateImage(Properties.Resources.Lamp_Red_Yellow_Error, Direction);
                        break;
                    case (int)LightState.GREEN_YELLOW_ERR:
                        bm1 = RotateImage(Properties.Resources.Lamp_Yellow_Green_Error, Direction);
                        break;
                    case (int)LightState.RED_YELLOW_GRREN_ERR:
                        bm1 = RotateImage(Properties.Resources.Lamp_Red_Yellow_Green_Error, Direction);
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

        }

        private void ThreeColorLamp_MouseDown(object sender, MouseEventArgs e)
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

        private void ThreeColorLamp_LocationChanged(object sender, EventArgs e)
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
                   // MessageHandler.UpdateRecordError();
                }
            }
        }


    }
}
