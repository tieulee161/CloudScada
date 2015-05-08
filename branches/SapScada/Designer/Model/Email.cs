using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace Designer.Model
{
    public class Email
    {
        private static string _server = "smtp.gmail.com";   // SMTP Server
        private static string _user = "sapulico.thgt@gmail.com";          // user's name of this server
        private static string _password = "121chauvanliem";           // password
        public static string Receiver = "quynhnguyen.cscc@gmail.com";      // receiver's email
        public static List<string> CC = new List<string>() {"quynhnguyen.cscc@gmail.com" };
        private System.Net.Mail.Attachment _attachment;

        private MailMessage mail;// = new MailMessage();
        private SmtpClient SmtpServer;//= new SmtpClient(_server);

        public string Status = "";
        public Email(string Subject, string Body, string AttachFilePath)
        {
            // init the server
            SmtpInit();

            // add subject and body to the email
            mail.Subject = Subject;
            mail.Body = Body;

            // attach file
            try
            {
                _attachment = new System.Net.Mail.Attachment(AttachFilePath);
                mail.Attachments.Add(_attachment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // if the file's path is wrong
            }

            // send it
            new Thread(new ThreadStart(SendEmail)).Start();

        }
        public Email(string receiver, string AttachFilePath, int i)
        {
            // init the server
            Receiver = receiver;
            SmtpInit();

            // add subject and body to the email  
            mail.Subject = "DATA BACKUP " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            mail.Body = "";

            // attach file
            try
            {
                _attachment = new System.Net.Mail.Attachment(AttachFilePath);
                mail.Attachments.Add(_attachment);
            }
            catch (Exception ex)
            {
                //  if(ex.Message != "Illegal characters in path.")
                MessageBox.Show(ex.Message); // if the file's path is wrong
            }

            // send it
            Thread t = new Thread(new ThreadStart(SendEmail));
            t.Start();


        }
        public Email(string Subject, string Body)
        {
            // init the server
            SmtpInit();

            // add subject and body to the email
            mail.Subject = Subject;
            mail.Body = Body;
           

            // send it
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            SendEmail();
        }

        public Email(string Body)
        {
            // init the server
            SmtpInit();

            // add subject and body to the email
            mail.Subject = "SPA BILL   " + DateTime.Now.ToString();
            mail.Body = Body;

            // send it
            Thread t = new Thread(new ThreadStart(SendEmail));
            t.Start();

        }
        private void SmtpInit()
        {
            mail = new MailMessage();
            SmtpServer = new SmtpClient(_server);

            // init sender's mail and receiver's mail
            mail.From = new MailAddress(_user);
            mail.To.Add(Receiver);
            mail.IsBodyHtml = true;

            // init some informations to interact with SMTP Server
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_user, _password);
            SmtpServer.EnableSsl = true;
        }
        private void SendEmail()
        {
            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Status = "Failure to sending email";
                // MessageBox.Show(ex.Message); // if something wrong occur, maybe errors form network
                //  SPA_Prototype.Program.f1.SendingEmailStatus(Status);
                return;
            }
            Status = "Sending email successful";
            //   SPA_Prototype.Program.f1.SendingEmailStatus(Status);
        }
    }


}

