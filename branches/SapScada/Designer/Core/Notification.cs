using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Designer.Model;


namespace Designer.Core
{
    public class EmailNotification : INotification
    {
        public void Notify(IOTag tag, object oldValue, object newValue)
        {
            if (tag.Name.Contains("JunctionStatus"))
            {
                if ((oldValue != null) && (newValue != null))
                {
                    if (((int)oldValue != 0) && ((int)newValue == 0))
                    {
                        List<Junction> juncs = DesignerAccess.GetJunctions(tag.Device.Name);
                        string junctions = "";
                        string device = "";
                        string port = "";
                        string date = "";
                        string time = "";

                        List<string> temp = new List<string>();
                        foreach (Junction junc in juncs)
                        {
                            temp.Add(junc.JunctionName);
                        }
                        junctions = string.Join(",", temp);

                        device = tag.Device.Name;
                        port = tag.Device.Port.ToString();
                        date = DateTime.Now.ToString("dd/MM/yyyy");
                        time = DateTime.Now.ToString("HH:mm");

                        string title = "TỦ THGT BỊ MẤT KẾT NỐI";
                        string content = string.Format("- Giao lộ: {0}\r\n- Tủ: {1}\r\n- Port: {2}\r\n- Ngày: {3}\r\n- Thời gian: {4}", junctions, device, port, date, time);

                        Email mail = new Email(title, content);
                    }
                }
            }
            else if (tag.Name.Contains("LightError.") && tag.Name.EndsWith(".0"))
            {
                if ((oldValue != null) && (newValue != null))
                {
                    if (((bool)oldValue == true) && ((bool)newValue == false))
                    {
                        List<Junction> juncs = DesignerAccess.GetJunctions(tag.Device.Name);
                        string junctions = "";
                        string device = "";
                        string port = "";
                        string date = "";
                        string time = "";
                        string info = "";

                        List<string> temp = new List<string>();
                        foreach (Junction junc in juncs)
                        {
                            temp.Add(junc.JunctionName);
                        }
                        junctions = string.Join(",", temp);

                        device = tag.Device.Name;
                        port = tag.Device.Port.ToString();
                        date = DateTime.Now.ToString("dd/MM/yyyy");
                        time = DateTime.Now.ToString("HH:mm");
                        info = string.Format("{0} \\ JunctionName.LightError.CardId.LightId.ErrorId - Lỗi 0 là lỗi mất đèn", tag.Name);

                        string title = "LỖI MẤT ĐÈN";
                        string content = string.Format("- Giao lộ: {0}\r\n- Tủ: {1}\r\n- Port: {2}\r\n- Ngày: {3}\r\n- Thời gian: {4}\r\n- Info", junctions, device, port, date, time);

                        Email mail = new Email(title, content);
                    }
                }

            }

        }
    }

    public interface INotification
    {
        void Notify(IOTag tag, object oldValue, object newValue);
    }
}
