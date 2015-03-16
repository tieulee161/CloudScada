using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Telerik.WinControls;

namespace HDSComponent
{
    public static class MessageHandler
    {
        public static DialogResult Question(string message)
        {
            try
            {
                var m = RadMessageBox.Show(message, " Cảnh báo", System.Windows.Forms.MessageBoxButtons.YesNo, RadMessageIcon.Question);
                return m;
            }
            catch (Exception)
            {
                return DialogResult.No;
            }
        }

        public static void Inform(string message)
        {
            try
            {
                var m = RadMessageBox.Show(message, " Thông tin", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception)
            { }
        }

        public static void Error(string message)
        {
            try
            {
                var m = RadMessageBox.Show(message, " Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            catch (Exception)
            { }
        }

        public static void AddRecordError()
        {
            MessageHandler.Error("Add new record fail !");
        }

        public static void UpdateRecordError()
        {
            MessageHandler.Error("Update information fail !");
        }

        public static void DeleteRecordError()
        {
            MessageHandler.Error("Fail to delete !");
        }

        public static void NetworkError()
        {
            MessageHandler.Error("Network Error !");
        }

        public static void AskToFullFillInfo()
        {
            MessageHandler.Inform("Please full fill all information !");
        }

        public static bool AskForDeleteRecord()
        {
            bool res = false;
            if (Question("Do you really want to delete ?") == DialogResult.Yes)
            {
                res = true;
            }
            return res;
        }

        public static void AskForValidFilePath()
        {
            Error("Please choose the correct file path !");
        }

        public static DialogResult AskForConfirm()
        {
            return Question("Are you sure ?");
        }

        public static DialogResult AskForConfirmAlarm()
        {
            return Question("Xác nhận cảnh báo này ?");
        }
    }
}
