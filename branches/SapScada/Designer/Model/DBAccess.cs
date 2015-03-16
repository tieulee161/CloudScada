using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;
using System.Data;
using HDSComponent;
using Designer.Core;
using Common;

namespace Designer.Model
{
    public partial class IOTag
    {
        public Task Parent;

    }

    public static class DBAccess
    {

        #region Create database by using C# command
        private static bool CreateSqlDatabase(string fileName)
        {
            bool res = false;
            if (!System.IO.File.Exists(fileName))
            {
                string databaseName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                using (var connection = new System.Data.SqlClient.SqlConnection(
                    "Data Source=.\\sqlexpress;Initial Catalog=tempdb; Integrated Security=true;User Instance=True;"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        // create database file
                        command.CommandText =
                            String.Format("CREATE DATABASE {0} ON PRIMARY (NAME={0}, FILENAME='{1}')", databaseName, fileName);
                        command.ExecuteNonQuery();

                        // create datatable
                        string scriptFile = string.Format(@"{0}\..\..\Model\Model1.edmx.sql", System.Windows.Forms.Application.StartupPath);
                        if (File.Exists(scriptFile))
                        {
                            string script = File.OpenText(scriptFile).ReadToEnd();
                            Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(new ServerConnection(connection));
                            server.ConnectionContext.ExecuteNonQuery(script);

                            // detach file from sql server
                            server.DetachDatabase(databaseName, true);
                        }

                        //command.CommandText = String.Format("EXEC sp_detach_db '{0}', 'true'", databaseName);
                        //command.ExecuteNonQuery();
                    }
                }
                res = true;
            }
            return res;
        }

        public static bool CreateSystemDatabase()
        {
            bool res = false;
            string fileName = string.Format(@"{0}\..\..\Model\database_2_0.mdf", System.Windows.Forms.Application.StartupPath);
            res = CreateSqlDatabase(fileName);
            return res;
        }
        #endregion

        public static bool CreateDatabaseForProject(string path)
        {
            bool res = false;
            if (Directory.Exists(path))
            {
                string dbSourceFile = string.Format(@"{0}\Model\SapScadaDatabase.mdf", Application.StartupPath);
                string dbSourceFile_Log = string.Format(@"{0}\Model\SapScadaDatabase_log.ldf", Application.StartupPath);
                string dbDestinationFile = path + "Database.mdf";
                string dbDestinationFile_log = path + "Database_log.ldf";

                File.Copy(dbSourceFile, dbDestinationFile);
                File.Copy(dbSourceFile_Log, dbDestinationFile_log);
                CreateConnectionStringForProject(dbDestinationFile);
                res = true;
            }
            return res;
        }

        public static string CreateConnectionStringForProject(string dbFilePath)
        {
            string res = string.Format("Data Source=.\\sqlexpress; Integrated Security=true;User Instance=True;attachdbfilename={0}", dbFilePath);
            return res;
        }

        public static bool SubmitToDatabase(SapScadaDatabaseEntities db)
        {
            bool res = false;
            try
            {
                db.SaveChanges();
                res = true;
            }
            catch (OptimisticConcurrencyException)
            {

                db.Refresh(System.Data.Objects.RefreshMode.ClientWins, db);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                string info = ex.Message;
                if (ex.InnerException != null)
                {
                    info += "\r\n" + ex.InnerException;
                }
                //  MessageHandler.Error(info);
            }
            return res;
        }

        public static void WarmUpDatabase()
        {
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                db.Servers.ToList();
            }
        }

        #region server
        public static bool AddServer(string name, string ip, int type, int priority, string note)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Server server = new Server();
                server.Name = name;
                server.IP = ip;
                server.Type = type;
                server.Priority = priority;
                server.Note = note;
                db.Servers.AddObject(server);
                res = SubmitToDatabase(db);
            }
            return res;
        }

        public static bool UpdateServer(string oldName, string newName, string ip, int type, int priority, string note)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Server server = (from q in db.Servers
                                 where q.Name == oldName
                                 select q).FirstOrDefault();
                if (server != null)
                {
                    server.Name = newName;
                    server.IP = ip;
                    server.Type = type;
                    server.Priority = priority;
                    server.Note = note;
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool DeleteServer(string name)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Server server = (from q in db.Servers
                                 where q.Name == name
                                 select q).FirstOrDefault();
                if (server != null)
                {
                    db.Servers.DeleteObject(server);
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static List<Server> GetServers()
        {
            List<Server> res = new List<Server>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                res = db.Servers.ToList();
            }
            return res;
        }

        public static Server GetServer(string name)
        {
            Server res = null;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.Servers
                             where q.Name == name
                             select q).FirstOrDefault();
                res = query;
            }
            return res;
        }

        public static string GetIOServerIP()
        {
            string res = "";
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.Servers
                             where q.Type == (int)Common.ServerType.IO
                             select q).FirstOrDefault();
                if (query != null)
                {
                    res = query.IP;
                }
            }
            return res;
        }
        #endregion

        #region device
        public static bool AddDevice(string name, int port, string driver, string note, string address)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Device dev = new Device();
                dev.Name = name;
                dev.Port = port;
                dev.Driver = driver;
                dev.Note = note;
                dev.Address = address;
                db.Devices.AddObject(dev);

                if (dev.Driver == Common.DriverType.VDK.ToString())
                {
                    #region add default tags for VDK
                    IOTag t1 = new IOTag();
                    t1.Name = string.Format("{0}.Connection", name);
                    t1.Type = (int)Common.TagType.Internal;
                    t1.DataType = (int)Common.DataType.Int32;
                    t1.Address = string.Format("Connection");
                    t1.UpdateRating = 0;
                    t1.IsStoreToLog = false;
                    dev.IOTags.Add(t1);

                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            IOTag t2 = new IOTag();
                            t2.Name = string.Format("{0}.OutputControl.{1}.{2}", name, j, i);
                            t2.Type = (int)Common.TagType.Internal;
                            t2.DataType = (int)Common.DataType.Bool;
                            t2.Address = string.Format("OutputControl.{0}.{1}", j, i);
                            t2.UpdateRating = 1000;
                            t2.IsStoreToLog = true;
                            dev.IOTags.Add(t2);
                        }
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            IOTag t3 = new IOTag();
                            t3.Name = string.Format("{0}.OutputFeedback.{1}.{2}", name, j, i);
                            t3.Type = (int)Common.TagType.Internal;
                            t3.DataType = (int)Common.DataType.Bool;
                            t3.Address = string.Format("OutputFeedback.{0}.{1}", j, i);
                            t3.UpdateRating = 0;
                            t3.IsStoreToLog = false;
                            dev.IOTags.Add(t3);
                        }
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            IOTag t3_1 = new IOTag();
                            t3_1.Name = string.Format("{0}.LightError.{1}.{2}", name, j, i);
                            t3_1.Type = (int)Common.TagType.Internal;
                            t3_1.DataType = (int)Common.DataType.Int32;
                            t3_1.Address = string.Format("LightError.{0}.{1}", j, i);
                            t3_1.UpdateRating = 0;
                            t3_1.IsStoreToLog = false;

                            AlarmTag alarm1 = new AlarmTag();
                            alarm1.Name = string.Format("{0}.LightError.{1}.{2}", name, j, i); // DeviceName.Light.CardIndex.LightIndex
                            alarm1.Type = (int)AlarmType.Digital;
                            alarm1.AlarmOnWhen = (int)AlarmOnWhen.True;
                            alarm1.IsActive = true;
                            alarm1.UpdateRating = 1000;
                            alarm1.Value = (int)AlarmValue.Null;
                            alarm1.IOTag = t3_1;

                            dev.IOTags.Add(t3_1);

                            for (int k = 0; k < 8; k++)
                            {
                                IOTag t3 = new IOTag();
                                t3.Name = string.Format("{0}.LightError.{1}.{2}.{3}", name, j, i, k);
                                t3.Type = (int)Common.TagType.Internal;
                                t3.DataType = (int)Common.DataType.Bool;
                                t3.Address = string.Format("LightError.{0}.{1}.{2}", j, i, k);
                                t3.UpdateRating = 0;
                                t3.IsStoreToLog = false;
                                dev.IOTags.Add(t3);
                            }

                        }
                    }




                    for (int j = 0; j < 16; j++)
                    {
                        IOTag t4 = new IOTag();
                        t4.Name = string.Format("{0}.Input.{1}", name, j);
                        t4.Type = (int)Common.TagType.Internal;
                        t4.DataType = (int)Common.DataType.Bool;
                        t4.Address = string.Format("Input.{0}", j);
                        t4.UpdateRating = 0;
                        t4.IsStoreToLog = false;
                        dev.IOTags.Add(t4);
                    }

                    for (int j = 0; j < 16; j++)
                    {
                        IOTag t5 = new IOTag();
                        t5.Name = string.Format("{0}.Output.{1}", name, j);
                        t5.Type = (int)Common.TagType.Internal;
                        t5.DataType = (int)Common.DataType.Bool;
                        t5.Address = string.Format("Output.{0}", j);
                        t5.UpdateRating = 0;
                        t5.IsStoreToLog = false;
                        dev.IOTags.Add(t5);
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        IOTag t6 = new IOTag();
                        t6.Name = string.Format("{0}.ManualError.{1}", name, j);
                        t6.Type = (int)Common.TagType.Internal;
                        t6.DataType = (int)Common.DataType.Bool;
                        t6.Address = string.Format("ManualError.{0}", j);
                        t6.UpdateRating = 0;
                        t6.IsStoreToLog = false;
                        dev.IOTags.Add(t6);
                    }

                    IOTag t7 = new IOTag();
                    t7.Name = string.Format("{0}.SetTime", name);
                    t7.Type = (int)Common.TagType.Internal;
                    t7.DataType = (int)Common.DataType.Bool;
                    t7.Address = string.Format("SetTime");
                    t7.UpdateRating = 0;
                    t7.IsStoreToLog = false;
                    dev.IOTags.Add(t7);

                    IOTag t8 = new IOTag();
                    t8.Name = string.Format("{0}.Flash", name);
                    t8.Type = (int)Common.TagType.Internal;
                    t8.DataType = (int)Common.DataType.Bool;
                    t8.Address = string.Format("Flash");
                    t8.UpdateRating = 0;
                    t8.IsStoreToLog = false;
                    dev.IOTags.Add(t8);

                    IOTag t9 = new IOTag();
                    t9.Name = string.Format("{0}.OffController", name);
                    t9.Type = (int)Common.TagType.Internal;
                    t9.DataType = (int)Common.DataType.Bool;
                    t9.Address = string.Format("OffController");
                    t9.UpdateRating = 0;
                    t9.IsStoreToLog = false;
                    dev.IOTags.Add(t9);

                    IOTag t10 = new IOTag();
                    t10.Name = string.Format("{0}.ChangePhase", name);
                    t10.Type = (int)Common.TagType.Internal;
                    t10.DataType = (int)Common.DataType.Bool;
                    t10.Address = string.Format("ChangePhase");
                    t10.UpdateRating = 0;
                    t10.IsStoreToLog = false;
                    dev.IOTags.Add(t10);

                    IOTag t11 = new IOTag();
                    t11.Name = string.Format("{0}.Auto", name);
                    t11.Type = (int)Common.TagType.Internal;
                    t11.DataType = (int)Common.DataType.Bool;
                    t11.Address = string.Format("Auto");
                    t11.UpdateRating = 0;
                    t11.IsStoreToLog = false;
                    dev.IOTags.Add(t11);

                    IOTag t12 = new IOTag();
                    t12.Name = string.Format("{0}.Calib", name);
                    t12.Type = (int)Common.TagType.Internal;
                    t12.DataType = (int)Common.DataType.Bool;
                    t12.Address = string.Format("Calib");
                    t12.UpdateRating = 0;
                    t12.IsStoreToLog = false;
                    dev.IOTags.Add(t12);

                    IOTag t13 = new IOTag();
                    t13.Name = string.Format("{0}.ChangeTODConfig", name);
                    t13.Type = (int)Common.TagType.Internal;
                    t13.DataType = (int)Common.DataType.Bool;
                    t13.Address = string.Format("ChangeTODConfig");
                    t13.UpdateRating = 0;
                    t13.IsStoreToLog = false;
                    dev.IOTags.Add(t13);

                    for (int j = 0; j < 8; j++)
                    {
                        IOTag t14 = new IOTag();
                        t14.Name = string.Format("{0}.CardAlive.{1}", name, j);
                        t14.Type = (int)Common.TagType.Internal;
                        t14.DataType = (int)Common.DataType.Int32;
                        t14.Address = string.Format("CardAlive.{0}", j);
                        t14.UpdateRating = 0;
                        t14.IsStoreToLog = false;
                        dev.IOTags.Add(t14);
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        IOTag t15 = new IOTag();
                        t15.Name = string.Format("{0}.CardStatus.{1}", name, j);
                        t15.Type = (int)Common.TagType.Internal;
                        t15.DataType = (int)Common.DataType.Int32;
                        t15.Address = string.Format("CardStatus.{0}", j);
                        t15.UpdateRating = 0;
                        t15.IsStoreToLog = false;
                        dev.IOTags.Add(t15);
                    }

                    IOTag t16 = new IOTag();
                    t16.Name = string.Format("{0}.ManualButton", name);
                    t16.Type = (int)Common.TagType.Internal;
                    t16.DataType = (int)Common.DataType.Int32;
                    t16.Address = string.Format("ManualButton");
                    t16.UpdateRating = 0;
                    t16.IsStoreToLog = false;
                    dev.IOTags.Add(t16);

                    IOTag t17 = new IOTag();
                    t17.Name = string.Format("{0}.HMIConnection", name);
                    t17.Type = (int)Common.TagType.Internal;
                    t17.DataType = (int)Common.DataType.Int32;
                    t17.Address = string.Format("HMIConnection");
                    t17.UpdateRating = 0;
                    t17.IsStoreToLog = false;
                    dev.IOTags.Add(t17);

                    IOTag t18 = new IOTag();
                    t18.Name = string.Format("{0}.SDConnection", name);
                    t18.Type = (int)Common.TagType.Internal;
                    t18.DataType = (int)Common.DataType.Int32;
                    t18.Address = string.Format("SDConnection");
                    t18.UpdateRating = 0;
                    t18.IsStoreToLog = false;
                    dev.IOTags.Add(t18);

                    IOTag t19 = new IOTag();
                    t19.Name = string.Format("{0}.ControlMode", name);
                    t19.Type = (int)Common.TagType.Internal;
                    t19.DataType = (int)Common.DataType.Int32;
                    t19.Address = string.Format("ControlMode");
                    t19.UpdateRating = 0;
                    t19.IsStoreToLog = false;
                    dev.IOTags.Add(t19);

                    IOTag t20 = new IOTag();
                    t20.Name = string.Format("{0}.ControlType", name);
                    t20.Type = (int)Common.TagType.Internal;
                    t20.DataType = (int)Common.DataType.Int32;
                    t20.Address = string.Format("ControlType");
                    t20.UpdateRating = 0;
                    t20.IsStoreToLog = false;
                    dev.IOTags.Add(t20);

                    IOTag t21 = new IOTag();
                    t21.Name = string.Format("{0}.Day", name);
                    t21.Type = (int)Common.TagType.Internal;
                    t21.DataType = (int)Common.DataType.Int32;
                    t21.Address = string.Format("Day");
                    t21.UpdateRating = 0;
                    t21.IsStoreToLog = false;
                    dev.IOTags.Add(t21);

                    IOTag t22 = new IOTag();
                    t22.Name = string.Format("{0}.Month", name);
                    t22.Type = (int)Common.TagType.Internal;
                    t22.DataType = (int)Common.DataType.Int32;
                    t22.Address = string.Format("Month");
                    t22.UpdateRating = 0;
                    t22.IsStoreToLog = false;
                    dev.IOTags.Add(t22);

                    IOTag t23 = new IOTag();
                    t23.Name = string.Format("{0}.Year", name);
                    t23.Type = (int)Common.TagType.Internal;
                    t23.DataType = (int)Common.DataType.Int32;
                    t23.Address = string.Format("Year");
                    t23.UpdateRating = 0;
                    t23.IsStoreToLog = false;
                    dev.IOTags.Add(t23);

                    IOTag t24 = new IOTag();
                    t24.Name = string.Format("{0}.Hour", name);
                    t24.Type = (int)Common.TagType.Internal;
                    t24.DataType = (int)Common.DataType.Int32;
                    t24.Address = string.Format("Hour");
                    t24.UpdateRating = 0;
                    t24.IsStoreToLog = false;
                    dev.IOTags.Add(t24);

                    IOTag t25 = new IOTag();
                    t25.Name = string.Format("{0}.Minute", name);
                    t25.Type = (int)Common.TagType.Internal;
                    t25.DataType = (int)Common.DataType.Int32;
                    t25.Address = string.Format("Minute");
                    t25.UpdateRating = 0;
                    t25.IsStoreToLog = false;
                    dev.IOTags.Add(t25);

                    IOTag t26 = new IOTag();
                    t26.Name = string.Format("{0}.Second", name);
                    t26.Type = (int)Common.TagType.Internal;
                    t26.DataType = (int)Common.DataType.Int32;
                    t26.Address = string.Format("Second");
                    t26.UpdateRating = 0;
                    t26.IsStoreToLog = false;
                    dev.IOTags.Add(t26);

                    IOTag t27 = new IOTag();
                    t27.Name = string.Format("{0}.ControllerId", name);
                    t27.Type = (int)Common.TagType.Internal;
                    t27.DataType = (int)Common.DataType.Int32;
                    t27.Address = string.Format("ControllerId");
                    t27.UpdateRating = 0;
                    t27.IsStoreToLog = false;
                    dev.IOTags.Add(t27);

                    IOTag t28 = new IOTag();
                    t28.Name = string.Format("{0}.HardwareVersion", name);
                    t28.Type = (int)Common.TagType.Internal;
                    t28.DataType = (int)Common.DataType.String;
                    t28.Address = string.Format("HardwareVersion");
                    t28.UpdateRating = 0;
                    t28.IsStoreToLog = false;
                    dev.IOTags.Add(t28);

                    IOTag t29 = new IOTag();
                    t29.Name = string.Format("{0}.FirmwareVersion", name);
                    t29.Type = (int)Common.TagType.Internal;
                    t29.DataType = (int)Common.DataType.String;
                    t29.Address = string.Format("FirmwareVersion");
                    t29.UpdateRating = 0;
                    t29.IsStoreToLog = false;
                    dev.IOTags.Add(t29);

                    IOTag t30 = new IOTag();
                    t30.Name = string.Format("{0}.DownloadTime", name);
                    t30.Type = (int)Common.TagType.Internal;
                    t30.DataType = (int)Common.DataType.Datetime;
                    t30.Address = string.Format("DownloadTime");
                    t30.UpdateRating = 0;
                    t30.IsStoreToLog = false;
                    dev.IOTags.Add(t30);

                    IOTag t31 = new IOTag();
                    t31.Name = string.Format("{0}.OffTime", name);
                    t31.Type = (int)Common.TagType.Internal;
                    t31.DataType = (int)Common.DataType.Datetime;
                    t31.Address = string.Format("OffTime");
                    t31.UpdateRating = 0;
                    t31.IsStoreToLog = false;
                    dev.IOTags.Add(t31);

                    IOTag t32 = new IOTag();
                    t32.Name = string.Format("{0}.OnTime", name);
                    t32.Type = (int)Common.TagType.Internal;
                    t32.DataType = (int)Common.DataType.Datetime;
                    t32.Address = string.Format("OnTime");
                    t32.UpdateRating = 0;
                    t32.IsStoreToLog = false;
                    dev.IOTags.Add(t32);

                    IOTag t33 = new IOTag();
                    t33.Name = string.Format("{0}.CurrentTODId", name);
                    t33.Type = (int)Common.TagType.Internal;
                    t33.DataType = (int)Common.DataType.Int32;
                    t33.Address = string.Format("CurrentTODId");
                    t33.UpdateRating = 0;
                    t33.IsStoreToLog = false;
                    dev.IOTags.Add(t33);

                    IOTag t34 = new IOTag();
                    t34.Name = string.Format("{0}.CotrollerTime", name);
                    t34.Type = (int)Common.TagType.External;
                    t34.DataType = (int)Common.DataType.Datetime;
                    t34.Address = string.Format("CotrollerTime");
                    t34.UpdateRating = 1000;
                    t34.IsStoreToLog = false;
                    dev.IOTags.Add(t34);

                    IOTag t35 = new IOTag();
                    t35.Name = string.Format("{0}.PowerTimeStamp", name);
                    t35.Type = (int)Common.TagType.External;
                    t35.DataType = (int)Common.DataType.Object;
                    t35.Address = string.Format("PowerTimeStamp");
                    t35.UpdateRating = 0;
                    t35.IsStoreToLog = false;
                    dev.IOTags.Add(t35);

                    IOTag t36 = new IOTag();
                    t36.Name = string.Format("{0}.ModeControl", name);
                    t36.Type = (int)Common.TagType.External;
                    t36.DataType = (int)Common.DataType.Object;
                    t36.Address = string.Format("ModeControl");
                    t36.UpdateRating = 1000;
                    t36.IsStoreToLog = false;
                    dev.IOTags.Add(t36);

                    IOTag t37 = new IOTag();
                    t37.Name = string.Format("{0}.CotrollerInfo", name);
                    t37.Type = (int)Common.TagType.External;
                    t37.DataType = (int)Common.DataType.Object;
                    t37.Address = string.Format("CotrollerInfo");
                    t37.UpdateRating = 0;
                    t37.IsStoreToLog = false;
                    dev.IOTags.Add(t37);

                    IOTag t38 = new IOTag();
                    t38.Name = string.Format("{0}.SourceVoltage", name);
                    t38.Type = (int)Common.TagType.External;
                    t38.DataType = (int)Common.DataType.Double;
                    t38.Address = string.Format("SourceVoltage");
                    t38.UpdateRating = 0;
                    t38.IsStoreToLog = false;
                    dev.IOTags.Add(t38);

                    IOTag t39 = new IOTag();
                    t39.Name = string.Format("{0}.BatteryVoltage", name);
                    t39.Type = (int)Common.TagType.External;
                    t39.DataType = (int)Common.DataType.Double;
                    t39.Address = string.Format("BatteryVoltage");
                    t39.UpdateRating = 0;
                    t39.IsStoreToLog = false;
                    dev.IOTags.Add(t39);

                    IOTag t40 = new IOTag();
                    t40.Name = string.Format("{0}.Temperature", name);
                    t40.Type = (int)Common.TagType.External;
                    t40.DataType = (int)Common.DataType.Double;
                    t40.Address = string.Format("Temperature");
                    t40.UpdateRating = 0;
                    t40.IsStoreToLog = false;
                    dev.IOTags.Add(t40);

                    IOTag t41 = new IOTag();
                    t41.Name = string.Format("{0}.IOStatus", name);
                    t41.Type = (int)Common.TagType.External;
                    t41.DataType = (int)Common.DataType.Object;
                    t41.Address = string.Format("IOStatus");
                    t41.UpdateRating = 0;
                    t41.IsStoreToLog = false;
                    dev.IOTags.Add(t41);

                    IOTag t42 = new IOTag();
                    t42.Name = string.Format("{0}.SDCardStatus", name);
                    t42.Type = (int)Common.TagType.External;
                    t42.DataType = (int)Common.DataType.Object;
                    t42.Address = string.Format("SDCardStatus");
                    t42.UpdateRating = 0;
                    t42.IsStoreToLog = false;
                    dev.IOTags.Add(t42);

                    IOTag t43 = new IOTag();
                    t43.Name = string.Format("{0}.HMIStatus", name);
                    t43.Type = (int)Common.TagType.External;
                    t43.DataType = (int)Common.DataType.Object;
                    t43.Address = string.Format("HMIStatus");
                    t43.UpdateRating = 0;
                    t43.IsStoreToLog = false;
                    dev.IOTags.Add(t43);

                    for (int j = 0; j < 8; j++)
                    {
                        IOTag t44 = new IOTag();
                        t44.Name = string.Format("{0}.PLCStatus.{1}", name, j);
                        t44.Type = (int)Common.TagType.External;
                        t44.DataType = (int)Common.DataType.Object;
                        t44.Address = string.Format("PLCStatus.{0}", j);
                        t44.UpdateRating = 1000;
                        t44.IsStoreToLog = false;
                        dev.IOTags.Add(t44);
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            IOTag t45 = new IOTag();
                            t45.Name = string.Format("{0}.Current.{1}.{2}", name, j, i);
                            t45.Type = (int)Common.TagType.External;
                            t45.DataType = (int)Common.DataType.Double;
                            t45.Address = string.Format("Current.{0}.{1}", j, i);
                            t45.UpdateRating = 0;
                            t45.IsStoreToLog = false;
                            dev.IOTags.Add(t45);
                        }
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            IOTag t46 = new IOTag();
                            t46.Name = string.Format("{0}.Threshold.{1}.{2}", name, j, i);
                            t46.Type = (int)Common.TagType.External;
                            t46.DataType = (int)Common.DataType.Double;
                            t46.Address = string.Format("Threshold.{0}.{1}", j, i);
                            t46.UpdateRating = 0;
                            t46.IsStoreToLog = false;
                            dev.IOTags.Add(t46);
                        }
                    }

                    IOTag t47 = new IOTag();
                    t47.Name = string.Format("{0}.CurrentScenarioId", name);
                    t47.Type = (int)Common.TagType.External;
                    t47.DataType = (int)Common.DataType.Int32;
                    t47.Address = string.Format("CurrentScenarioId");
                    t47.UpdateRating = 0;
                    t47.IsStoreToLog = false;
                    dev.IOTags.Add(t47);

                    IOTag t48 = new IOTag();
                    t48.Name = string.Format("{0}.CurrentTOD", name);
                    t48.Type = (int)Common.TagType.External;
                    t48.DataType = (int)Common.DataType.Int32;
                    t48.Address = string.Format("CurrentTOD");
                    t48.UpdateRating = 0;
                    t48.IsStoreToLog = false;
                    dev.IOTags.Add(t48);

                    for (int j = 0; j < 8; j++)
                    {
                        IOTag t49 = new IOTag();
                        t49.Name = string.Format("{0}.CurrentTOD.{1}", name, j);
                        t49.Type = (int)Common.TagType.External;
                        t49.DataType = (int)Common.DataType.Object;
                        t49.Address = string.Format("CurrentTOD.{0}", j);
                        t49.UpdateRating = 0;
                        t49.IsStoreToLog = false;
                        dev.IOTags.Add(t49);
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        IOTag t50_1 = new IOTag();
                        t50_1.Name = string.Format("{0}.CardError.{1}", name, j);
                        t50_1.Type = (int)Common.TagType.Internal;
                        t50_1.DataType = (int)Common.DataType.Int32;
                        t50_1.Address = string.Format("CardError.{0}", j);
                        t50_1.UpdateRating = 0;
                        t50_1.IsStoreToLog = false;


                        AlarmTag alarm1 = new AlarmTag();
                        alarm1.Name = string.Format("{0}.CardError.{1}", name, j); // DeviceName.Light.CardIndex.LightIndex
                        alarm1.Type = (int)AlarmType.Digital;
                        alarm1.AlarmOnWhen = (int)AlarmOnWhen.True;
                        alarm1.IsActive = true;
                        alarm1.UpdateRating = 1000;
                        alarm1.Value = (int)AlarmValue.Null;
                        alarm1.IOTag = t50_1;

                        dev.IOTags.Add(t50_1);

                        for (int i = 0; i < 8; i++)
                        {
                            IOTag t50 = new IOTag();
                            t50.Name = string.Format("{0}.CardError.{1}.{2}", name, j, i);
                            t50.Type = (int)Common.TagType.Internal;
                            t50.DataType = (int)Common.DataType.Bool;
                            t50.Address = string.Format("CardError.{0}.{1}", j, i);
                            t50.UpdateRating = 0;
                            t50.IsStoreToLog = false;
                            dev.IOTags.Add(t50);
                        }

                    }

                    for (int j = 0; j < 8; j++)
                    {
                        IOTag t51 = new IOTag();
                        t51.Name = string.Format("{0}.Eeprom.{1}", name, j);
                        t51.Type = (int)Common.TagType.External;
                        t51.DataType = (int)Common.DataType.Object;
                        t51.Address = string.Format("Eeprom.{0}", j);
                        t51.UpdateRating = 0;
                        t51.IsStoreToLog = false;
                        dev.IOTags.Add(t51);
                    }

                    IOTag t52 = new IOTag();
                    t52.Name = string.Format("{0}.JunctionStatus", name);
                    t52.Type = (int)Common.TagType.Internal;
                    t52.DataType = (int)Common.DataType.Int32;
                    t52.Address = string.Format("JunctionStatus");
                    t52.UpdateRating = 0;
                    t52.IsStoreToLog = false;
                    dev.IOTags.Add(t52);
                    #endregion
                }
                else if (dev.Driver == Common.DriverType.OPC.ToString())
                {
                    #region add default tag for PLC junction
                    IOTag t1 = new IOTag();
                    t1.Name = string.Format("{0}.TIME_SET", name);
                    t1.Type = (int)Common.TagType.External;
                    t1.DataType = (int)Common.DataType.Int32;
                    t1.Address = string.Format("{0}.D135", address);
                    t1.UpdateRating = 0;
                    t1.IsStoreToLog = false;
                    dev.IOTags.Add(t1);

                    #region control form
                    // 1: thong so, 2: chop vang, 3 :lan song xanh, 4: tat tu
                    IOTag t2 = new IOTag();
                    t2.Name = string.Format("{0}.MODE", name);
                    t2.Type = (int)Common.TagType.External;
                    t2.DataType = (int)Common.DataType.Int32;
                    t2.Address = string.Format("{0}.D136", address);
                    t2.UpdateRating = 1000;
                    t2.IsStoreToLog = false;
                    dev.IOTags.Add(t2);

                    IOTag t3 = new IOTag();
                    t3.Name = string.Format("{0}.X_A_R", name);
                    t3.Type = (int)Common.TagType.External;
                    t3.DataType = (int)Common.DataType.Int32;
                    t3.Address = string.Format("{0}.D7", address);
                    t3.UpdateRating = 0;
                    t3.IsStoreToLog = false;
                    dev.IOTags.Add(t3);

                    IOTag t4 = new IOTag();
                    t4.Name = string.Format("{0}.V_A_R", name);
                    t4.Type = (int)Common.TagType.External;
                    t4.DataType = (int)Common.DataType.Int32;
                    t4.Address = string.Format("{0}.D8", address);
                    t4.UpdateRating = 0;
                    t4.IsStoreToLog = false;
                    dev.IOTags.Add(t4);

                    IOTag t5 = new IOTag();
                    t5.Name = string.Format("{0}.GT_A_R", name);
                    t5.Type = (int)Common.TagType.External;
                    t5.DataType = (int)Common.DataType.Int32;
                    t5.Address = string.Format("{0}.D9", address);
                    t5.UpdateRating = 0;
                    t5.IsStoreToLog = false;
                    dev.IOTags.Add(t5);

                    IOTag t6 = new IOTag();
                    t6.Name = string.Format("{0}.X_B_R", name);
                    t6.Type = (int)Common.TagType.External;
                    t6.DataType = (int)Common.DataType.Int32;
                    t6.Address = string.Format("{0}.D10", address);
                    t6.UpdateRating = 0;
                    t6.IsStoreToLog = false;
                    dev.IOTags.Add(t6);

                    IOTag t7 = new IOTag();
                    t7.Name = string.Format("{0}.V_B_R", name);
                    t7.Type = (int)Common.TagType.External;
                    t7.DataType = (int)Common.DataType.Int32;
                    t7.Address = string.Format("{0}.D11", address);
                    t7.UpdateRating = 0;
                    t7.IsStoreToLog = false;
                    dev.IOTags.Add(t7);

                    IOTag t8 = new IOTag();
                    t8.Name = string.Format("{0}.GT_B_R", name);
                    t8.Type = (int)Common.TagType.External;
                    t8.DataType = (int)Common.DataType.Int32;
                    t8.Address = string.Format("{0}.D12", address);
                    t8.UpdateRating = 0;
                    t8.IsStoreToLog = false;
                    dev.IOTags.Add(t8);

                    IOTag t13 = new IOTag();
                    t13.Name = string.Format("{0}.X_A_MAN", name);
                    t13.Type = (int)Common.TagType.External;
                    t13.DataType = (int)Common.DataType.Int32;
                    t13.Address = string.Format("{0}.D147", address);
                    t13.UpdateRating = 0;
                    t13.IsStoreToLog = false;
                    dev.IOTags.Add(t13);

                    IOTag t14 = new IOTag();
                    t14.Name = string.Format("{0}.V_A_MAN", name);
                    t14.Type = (int)Common.TagType.External;
                    t14.DataType = (int)Common.DataType.Int32;
                    t14.Address = string.Format("{0}.D148", address);
                    t14.UpdateRating = 0;
                    t14.IsStoreToLog = false;
                    dev.IOTags.Add(t14);

                    IOTag t15 = new IOTag();
                    t15.Name = string.Format("{0}.GT_A_MAN", name);
                    t15.Type = (int)Common.TagType.External;
                    t15.DataType = (int)Common.DataType.Int32;
                    t15.Address = string.Format("{0}.D149", address);
                    t15.UpdateRating = 0;
                    t15.IsStoreToLog = false;
                    dev.IOTags.Add(t15);

                    IOTag t16 = new IOTag();
                    t16.Name = string.Format("{0}.X_B_MAN", name);
                    t16.Type = (int)Common.TagType.External;
                    t16.DataType = (int)Common.DataType.Int32;
                    t16.Address = string.Format("{0}.D150", address);
                    t16.UpdateRating = 0;
                    t16.IsStoreToLog = false;
                    dev.IOTags.Add(t16);

                    IOTag t17 = new IOTag();
                    t17.Name = string.Format("{0}.V_B_MAN", name);
                    t17.Type = (int)Common.TagType.External;
                    t17.DataType = (int)Common.DataType.Int32;
                    t17.Address = string.Format("{0}.D151", address);
                    t17.UpdateRating = 0;
                    t17.IsStoreToLog = false;
                    dev.IOTags.Add(t17);

                    IOTag t18 = new IOTag();
                    t18.Name = string.Format("{0}.GT_B_MAN", name);
                    t18.Type = (int)Common.TagType.External;
                    t18.DataType = (int)Common.DataType.Int32;
                    t18.Address = string.Format("{0}.D152", address);
                    t18.UpdateRating = 0;
                    t18.IsStoreToLog = false;
                    dev.IOTags.Add(t18);


                    IOTag t25 = new IOTag();
                    t25.Name = string.Format("{0}.XA_Q", name);
                    t25.Type = (int)Common.TagType.External;
                    t25.DataType = (int)Common.DataType.Bool;
                    t25.Address = string.Format("{0}.S44", address);
                    t25.UpdateRating = 1000;
                    t25.IsStoreToLog = true;
                    dev.IOTags.Add(t25);

                    IOTag t26 = new IOTag();
                    t26.Name = string.Format("{0}.VA_Q", name);
                    t26.Type = (int)Common.TagType.External;
                    t26.DataType = (int)Common.DataType.Bool;
                    t26.Address = string.Format("{0}.S45", address);
                    t26.UpdateRating = 1000;
                    t26.IsStoreToLog = true;
                    dev.IOTags.Add(t26);

                    IOTag t27 = new IOTag();
                    t27.Name = string.Format("{0}.DA_Q", name);
                    t27.Type = (int)Common.TagType.External;
                    t27.DataType = (int)Common.DataType.Bool;
                    t27.Address = string.Format("{0}.S52", address);
                    t27.UpdateRating = 1000;
                    t27.IsStoreToLog = true;
                    dev.IOTags.Add(t27);

                    IOTag t28 = new IOTag();
                    t28.Name = string.Format("{0}.XB_Q", name);
                    t28.Type = (int)Common.TagType.External;
                    t28.DataType = (int)Common.DataType.Bool;
                    t28.Address = string.Format("{0}.S47", address);
                    t28.UpdateRating = 1000;
                    t28.IsStoreToLog = true;
                    dev.IOTags.Add(t28);

                    IOTag t29 = new IOTag();
                    t29.Name = string.Format("{0}.VB_Q", name);
                    t29.Type = (int)Common.TagType.External;
                    t29.DataType = (int)Common.DataType.Bool;
                    t29.Address = string.Format("{0}.S48", address);
                    t29.UpdateRating = 1000;
                    t29.IsStoreToLog = true;
                    dev.IOTags.Add(t29);

                    IOTag t30 = new IOTag();
                    t30.Name = string.Format("{0}.DB_Q", name);
                    t30.Type = (int)Common.TagType.External;
                    t30.DataType = (int)Common.DataType.Bool;
                    t30.Address = string.Format("{0}.S53", address);
                    t30.UpdateRating = 1000;
                    t30.IsStoreToLog = true;
                    dev.IOTags.Add(t30);

                    IOTag t31 = new IOTag();
                    t31.Name = string.Format("{0}.DB_A", name);
                    t31.Type = (int)Common.TagType.External;
                    t31.DataType = (int)Common.DataType.Bool;
                    t31.Address = string.Format("{0}.S4", address);
                    t31.UpdateRating = 0;
                    t31.IsStoreToLog = false;
                    dev.IOTags.Add(t31);

                    IOTag t31_1 = new IOTag();
                    t31_1.Name = string.Format("{0}.DB_B", name);
                    t31_1.Type = (int)Common.TagType.External;
                    t31_1.DataType = (int)Common.DataType.Bool;
                    t31_1.Address = string.Format("{0}.S5", address);
                    t31_1.UpdateRating = 0;
                    t31_1.IsStoreToLog = false;
                    dev.IOTags.Add(t31_1);

                    IOTag t32 = new IOTag();
                    t32.Name = string.Format("{0}.MAN", name);
                    t32.Type = (int)Common.TagType.External;
                    t32.DataType = (int)Common.DataType.Bool;
                    t32.Address = string.Format("{0}.M0", address);
                    t32.UpdateRating = 0;
                    t32.IsStoreToLog = false;
                    dev.IOTags.Add(t32);

                    IOTag t33 = new IOTag();
                    t33.Name = string.Format("{0}.PAR_R", name);
                    t33.Type = (int)Common.TagType.External;
                    t33.DataType = (int)Common.DataType.Int32;
                    t33.Address = string.Format("{0}.D24", address);
                    t33.UpdateRating = 0;
                    t33.IsStoreToLog = false;
                    dev.IOTags.Add(t33);

                    IOTag t34 = new IOTag();
                    t34.Name = string.Format("{0}.MOV_P1", name);
                    t34.Type = (int)Common.TagType.External;
                    t34.DataType = (int)Common.DataType.Bool;
                    t34.Address = string.Format("{0}.M3", address);
                    t34.UpdateRating = 0;
                    t34.IsStoreToLog = false;
                    dev.IOTags.Add(t34);

                    IOTag t35 = new IOTag();
                    t35.Name = string.Format("{0}.MOV_P2", name);
                    t35.Type = (int)Common.TagType.External;
                    t35.DataType = (int)Common.DataType.Bool;
                    t35.Address = string.Format("{0}.M4", address);
                    t35.UpdateRating = 0;
                    t35.IsStoreToLog = false;
                    dev.IOTags.Add(t35);

                    IOTag t36 = new IOTag();
                    t36.Name = string.Format("{0}.MOV_P3", name);
                    t36.Type = (int)Common.TagType.External;
                    t36.DataType = (int)Common.DataType.Bool;
                    t36.Address = string.Format("{0}.M5", address);
                    t36.UpdateRating = 0;
                    t36.IsStoreToLog = false;
                    dev.IOTags.Add(t36);

                    IOTag t37 = new IOTag();
                    t37.Name = string.Format("{0}.MOV_P4", name);
                    t37.Type = (int)Common.TagType.External;
                    t37.DataType = (int)Common.DataType.Bool;
                    t37.Address = string.Format("{0}.M6", address);
                    t37.UpdateRating = 0;
                    t37.IsStoreToLog = false;
                    dev.IOTags.Add(t37);

                    IOTag t38 = new IOTag();
                    t38.Name = string.Format("{0}.SETUP", name);
                    t38.Type = (int)Common.TagType.External;
                    t38.DataType = (int)Common.DataType.Bool;
                    t38.Address = string.Format("{0}.M50", address);
                    t38.UpdateRating = 0;
                    t38.IsStoreToLog = false;
                    dev.IOTags.Add(t38);

                    //IOTag t39 = new IOTag();
                    //t39.Name = string.Format("{0}.SETUP", name);
                    //t39.Type = (int)Common.TagType.External;
                    //t39.DataType = (int)Common.DataType.Int32;
                    //t39.Address = string.Format("Q01_001.Device1.M50");
                    //t39.UpdateRating = 0;
                    //dev.IOTags.Add(t39);

                    IOTag t40 = new IOTag();
                    t40.Name = string.Format("{0}.SET_T_M", name);
                    t40.Type = (int)Common.TagType.External;
                    t40.DataType = (int)Common.DataType.Bool;
                    t40.Address = string.Format("{0}.S1", address);
                    t40.UpdateRating = 0;
                    t40.IsStoreToLog = false;
                    dev.IOTags.Add(t40);

                    #endregion

                    #region Normal day setting

                    IOTag t41 = new IOTag();
                    t41.Name = string.Format("{0}.CONNECTION", name);
                    t41.Type = (int)Common.TagType.External;
                    t41.DataType = (int)Common.DataType.Int32;
                    int thousand = port / 1000;
                    int temp = port - thousand * 1000;
                    t41.Address = string.Format("KETNOI_THGT.Device1.Chot{0}", temp);
                    t41.UpdateRating = 0;
                    t41.IsStoreToLog = false;
                    dev.IOTags.Add(t41);

                    IOTag t42 = new IOTag();
                    t42.Name = string.Format("{0}.OPT_N1", name);
                    t42.Type = (int)Common.TagType.External;
                    t42.DataType = (int)Common.DataType.Bool;
                    t42.Address = string.Format("{0}.S60", address);
                    t42.UpdateRating = 0;
                    t42.IsStoreToLog = false;
                    dev.IOTags.Add(t42);

                    IOTag t43 = new IOTag();
                    t43.Name = string.Format("{0}.OPT_N2", name);
                    t43.Type = (int)Common.TagType.External;
                    t43.DataType = (int)Common.DataType.Bool;
                    t43.Address = string.Format("{0}.S61", address);
                    t43.UpdateRating = 0;
                    t43.IsStoreToLog = false;
                    dev.IOTags.Add(t43);

                    IOTag t44 = new IOTag();
                    t44.Name = string.Format("{0}.OPT_N3", name);
                    t44.Type = (int)Common.TagType.External;
                    t44.DataType = (int)Common.DataType.Bool;
                    t44.Address = string.Format("{0}.S62", address);
                    t44.UpdateRating = 0;
                    t44.IsStoreToLog = false;
                    dev.IOTags.Add(t44);

                    IOTag t45 = new IOTag();
                    t45.Name = string.Format("{0}.OPT_N4", name);
                    t45.Type = (int)Common.TagType.External;
                    t45.DataType = (int)Common.DataType.Bool;
                    t45.Address = string.Format("{0}.S63", address);
                    t45.UpdateRating = 0;
                    t45.IsStoreToLog = false;
                    dev.IOTags.Add(t45);

                    IOTag t46 = new IOTag();
                    t46.Name = string.Format("{0}.OPT_N5", name);
                    t46.Type = (int)Common.TagType.External;
                    t46.DataType = (int)Common.DataType.Bool;
                    t46.Address = string.Format("{0}.S64", address);
                    t46.UpdateRating = 0;
                    t46.IsStoreToLog = false;
                    dev.IOTags.Add(t46);

                    IOTag t47 = new IOTag();
                    t47.Name = string.Format("{0}.OPT_N6", name);
                    t47.Type = (int)Common.TagType.External;
                    t47.DataType = (int)Common.DataType.Bool;
                    t47.Address = string.Format("{0}.S65", address);
                    t47.UpdateRating = 0;
                    t47.IsStoreToLog = false;
                    dev.IOTags.Add(t47);

                    IOTag t48 = new IOTag();
                    t48.Name = string.Format("{0}.OPT_N7", name);
                    t48.Type = (int)Common.TagType.External;
                    t48.DataType = (int)Common.DataType.Bool;
                    t48.Address = string.Format("{0}.S66", address);
                    t48.UpdateRating = 0;
                    t48.IsStoreToLog = false;
                    dev.IOTags.Add(t48);

                    IOTag t49 = new IOTag();
                    t49.Name = string.Format("{0}.N1_MODE", name);
                    t49.Type = (int)Common.TagType.External;
                    t49.DataType = (int)Common.DataType.Int32;
                    t49.Address = string.Format("{0}.D177", address);
                    t49.UpdateRating = 0;
                    t49.IsStoreToLog = false;
                    dev.IOTags.Add(t49);

                    IOTag t50 = new IOTag();
                    t50.Name = string.Format("{0}.N1_HOUR", name);
                    t50.Type = (int)Common.TagType.External;
                    t50.DataType = (int)Common.DataType.Int32;
                    t50.Address = string.Format("{0}.D178", address);
                    t50.UpdateRating = 0;
                    t50.IsStoreToLog = false;
                    dev.IOTags.Add(t50);

                    IOTag t51 = new IOTag();
                    t51.Name = string.Format("{0}.N1_MIN", name);
                    t51.Type = (int)Common.TagType.External;
                    t51.DataType = (int)Common.DataType.Int32;
                    t51.Address = string.Format("{0}.D179", address);
                    t51.UpdateRating = 0;
                    t51.IsStoreToLog = false;
                    dev.IOTags.Add(t51);

                    IOTag t52 = new IOTag();
                    t52.Name = string.Format("{0}.N1_PAR", name);
                    t52.Type = (int)Common.TagType.External;
                    t52.DataType = (int)Common.DataType.Int32;
                    t52.Address = string.Format("{0}.D180", address);
                    t52.UpdateRating = 0;
                    t52.IsStoreToLog = false;
                    dev.IOTags.Add(t52);

                    IOTag t53 = new IOTag();
                    t53.Name = string.Format("{0}.N1_OFFSET", name);
                    t53.Type = (int)Common.TagType.External;
                    t53.DataType = (int)Common.DataType.Int32;
                    t53.Address = string.Format("{0}.D181", address);
                    t53.UpdateRating = 0;
                    t53.IsStoreToLog = false;
                    dev.IOTags.Add(t53);

                    IOTag t54 = new IOTag();
                    t54.Name = string.Format("{0}.N2_MODE", name);
                    t54.Type = (int)Common.TagType.External;
                    t54.DataType = (int)Common.DataType.Int32;
                    t54.Address = string.Format("{0}.D182", address);
                    t54.UpdateRating = 0;
                    t54.IsStoreToLog = false;
                    dev.IOTags.Add(t54);

                    IOTag t55 = new IOTag();
                    t55.Name = string.Format("{0}.N2_HOUR", name);
                    t55.Type = (int)Common.TagType.External;
                    t55.DataType = (int)Common.DataType.Int32;
                    t55.Address = string.Format("{0}.D183", address);
                    t55.UpdateRating = 0;
                    t55.IsStoreToLog = false;
                    dev.IOTags.Add(t55);

                    IOTag t56 = new IOTag();
                    t56.Name = string.Format("{0}.N2_MIN", name);
                    t56.Type = (int)Common.TagType.External;
                    t56.DataType = (int)Common.DataType.Int32;
                    t56.Address = string.Format("{0}.D184", address);
                    t56.UpdateRating = 0;
                    t56.IsStoreToLog = false;
                    dev.IOTags.Add(t56);

                    IOTag t57 = new IOTag();
                    t57.Name = string.Format("{0}.N2_PAR", name);
                    t57.Type = (int)Common.TagType.External;
                    t57.DataType = (int)Common.DataType.Int32;
                    t57.Address = string.Format("{0}.D185", address);
                    t57.UpdateRating = 0;
                    t57.IsStoreToLog = false;
                    dev.IOTags.Add(t57);

                    IOTag t58 = new IOTag();
                    t58.Name = string.Format("{0}.N2_OFFSET", name);
                    t58.Type = (int)Common.TagType.External;
                    t58.DataType = (int)Common.DataType.Int32;
                    t58.Address = string.Format("{0}.D186", address);
                    t58.UpdateRating = 0;
                    t58.IsStoreToLog = false;
                    dev.IOTags.Add(t58);

                    IOTag t59 = new IOTag();
                    t59.Name = string.Format("{0}.N3_MODE", name);
                    t59.Type = (int)Common.TagType.External;
                    t59.DataType = (int)Common.DataType.Int32;
                    t59.Address = string.Format("{0}.D187", address);
                    t59.UpdateRating = 0;
                    t59.IsStoreToLog = false;
                    dev.IOTags.Add(t59);

                    IOTag t60 = new IOTag();
                    t60.Name = string.Format("{0}.N3_HOUR", name);
                    t60.Type = (int)Common.TagType.External;
                    t60.DataType = (int)Common.DataType.Int32;
                    t60.Address = string.Format("{0}.D188", address);
                    t60.UpdateRating = 0;
                    t60.IsStoreToLog = false;
                    dev.IOTags.Add(t60);

                    IOTag t61 = new IOTag();
                    t61.Name = string.Format("{0}.N3_MIN", name);
                    t61.Type = (int)Common.TagType.External;
                    t61.DataType = (int)Common.DataType.Int32;
                    t61.Address = string.Format("{0}.D189", address);
                    t61.UpdateRating = 0;
                    t61.IsStoreToLog = false;
                    dev.IOTags.Add(t61);

                    IOTag t62 = new IOTag();
                    t62.Name = string.Format("{0}.N3_PAR", name);
                    t62.Type = (int)Common.TagType.External;
                    t62.DataType = (int)Common.DataType.Int32;
                    t62.Address = string.Format("{0}.D190", address);
                    t62.UpdateRating = 0;
                    t62.IsStoreToLog = false;
                    dev.IOTags.Add(t62);

                    IOTag t63 = new IOTag();
                    t63.Name = string.Format("{0}.N3_OFFSET", name);
                    t63.Type = (int)Common.TagType.External;
                    t63.DataType = (int)Common.DataType.Int32;
                    t63.Address = string.Format("{0}.D191", address);
                    t63.UpdateRating = 0;
                    t63.IsStoreToLog = false;
                    dev.IOTags.Add(t63);

                    IOTag t64 = new IOTag();
                    t64.Name = string.Format("{0}.N4_MODE", name);
                    t64.Type = (int)Common.TagType.External;
                    t64.DataType = (int)Common.DataType.Int32;
                    t64.Address = string.Format("{0}.D192", address);
                    t64.UpdateRating = 0;
                    t64.IsStoreToLog = false;
                    dev.IOTags.Add(t64);

                    IOTag t65 = new IOTag();
                    t65.Name = string.Format("{0}.N4_HOUR", name);
                    t65.Type = (int)Common.TagType.External;
                    t65.DataType = (int)Common.DataType.Int32;
                    t65.Address = string.Format("{0}.D193", address);
                    t65.UpdateRating = 0;
                    t65.IsStoreToLog = false;
                    dev.IOTags.Add(t65);

                    IOTag t66 = new IOTag();
                    t66.Name = string.Format("{0}.N4_MIN", name);
                    t66.Type = (int)Common.TagType.External;
                    t66.DataType = (int)Common.DataType.Int32;
                    t66.Address = string.Format("{0}.D194", address);
                    t66.UpdateRating = 0;
                    t66.IsStoreToLog = false;
                    dev.IOTags.Add(t66);

                    IOTag t67 = new IOTag();
                    t67.Name = string.Format("{0}.N4_PAR", name);
                    t67.Type = (int)Common.TagType.External;
                    t67.DataType = (int)Common.DataType.Int32;
                    t67.Address = string.Format("{0}.D195", address);
                    t67.UpdateRating = 0;
                    t67.IsStoreToLog = false;
                    dev.IOTags.Add(t67);

                    IOTag t68 = new IOTag();
                    t68.Name = string.Format("{0}.N4_OFFSET", name);
                    t68.Type = (int)Common.TagType.External;
                    t68.DataType = (int)Common.DataType.Int32;
                    t68.Address = string.Format("{0}.D196", address);
                    t68.UpdateRating = 0;
                    t68.IsStoreToLog = false;
                    dev.IOTags.Add(t68);

                    IOTag t69 = new IOTag();
                    t69.Name = string.Format("{0}.N5_MODE", name);
                    t69.Type = (int)Common.TagType.External;
                    t69.DataType = (int)Common.DataType.Int32;
                    t69.Address = string.Format("{0}.D197", address);
                    t69.UpdateRating = 0;
                    t69.IsStoreToLog = false;
                    dev.IOTags.Add(t69);

                    IOTag t70 = new IOTag();
                    t70.Name = string.Format("{0}.N5_HOUR", name);
                    t70.Type = (int)Common.TagType.External;
                    t70.DataType = (int)Common.DataType.Int32;
                    t70.Address = string.Format("{0}.D198", address);
                    t70.UpdateRating = 0;
                    t70.IsStoreToLog = false;
                    dev.IOTags.Add(t70);

                    IOTag t71 = new IOTag();
                    t71.Name = string.Format("{0}.N5_MIN", name);
                    t71.Type = (int)Common.TagType.External;
                    t71.DataType = (int)Common.DataType.Int32;
                    t71.Address = string.Format("{0}.D199", address);
                    t71.UpdateRating = 0;
                    t71.IsStoreToLog = false;
                    dev.IOTags.Add(t71);

                    IOTag t72 = new IOTag();
                    t72.Name = string.Format("{0}.N5_PAR", name);
                    t72.Type = (int)Common.TagType.External;
                    t72.DataType = (int)Common.DataType.Int32;
                    t72.Address = string.Format("{0}.D200", address);
                    t72.UpdateRating = 0;
                    t72.IsStoreToLog = false;
                    dev.IOTags.Add(t72);

                    IOTag t73 = new IOTag();
                    t73.Name = string.Format("{0}.N5_OFFSET", name);
                    t73.Type = (int)Common.TagType.External;
                    t73.DataType = (int)Common.DataType.Int32;
                    t73.Address = string.Format("{0}.D201", address);
                    t73.UpdateRating = 0;
                    t73.IsStoreToLog = false;
                    dev.IOTags.Add(t73);

                    IOTag t74 = new IOTag();
                    t74.Name = string.Format("{0}.N6_MODE", name);
                    t74.Type = (int)Common.TagType.External;
                    t74.DataType = (int)Common.DataType.Int32;
                    t74.Address = string.Format("{0}.D202", address);
                    t74.UpdateRating = 0;
                    t74.IsStoreToLog = false;
                    dev.IOTags.Add(t74);

                    IOTag t75 = new IOTag();
                    t75.Name = string.Format("{0}.N6_HOUR", name);
                    t75.Type = (int)Common.TagType.External;
                    t75.DataType = (int)Common.DataType.Int32;
                    t75.Address = string.Format("{0}.D203", address);
                    t75.UpdateRating = 0;
                    t75.IsStoreToLog = false;
                    dev.IOTags.Add(t75);

                    IOTag t76 = new IOTag();
                    t76.Name = string.Format("{0}.N6_MIN", name);
                    t76.Type = (int)Common.TagType.External;
                    t76.DataType = (int)Common.DataType.Int32;
                    t76.Address = string.Format("{0}.D204", address);
                    t76.UpdateRating = 0;
                    t76.IsStoreToLog = false;
                    dev.IOTags.Add(t76);

                    IOTag t77 = new IOTag();
                    t77.Name = string.Format("{0}.N6_PAR", name, address);
                    t77.Type = (int)Common.TagType.External;
                    t77.DataType = (int)Common.DataType.Int32;
                    t77.Address = string.Format("{0}.D205", address);
                    t77.UpdateRating = 0;
                    t77.IsStoreToLog = false;
                    dev.IOTags.Add(t72);

                    IOTag t78 = new IOTag();
                    t78.Name = string.Format("{0}.N6_OFFSET", name);
                    t78.Type = (int)Common.TagType.External;
                    t78.DataType = (int)Common.DataType.Int32;
                    t78.Address = string.Format("{0}.D206", address);
                    t78.UpdateRating = 0;
                    t78.IsStoreToLog = false;
                    dev.IOTags.Add(t78);

                    IOTag t79 = new IOTag();
                    t79.Name = string.Format("{0}.N7_MODE", name);
                    t79.Type = (int)Common.TagType.External;
                    t79.DataType = (int)Common.DataType.Int32;
                    t79.Address = string.Format("{0}.D207", address);
                    t79.UpdateRating = 0;
                    t79.IsStoreToLog = false;
                    dev.IOTags.Add(t79);

                    IOTag t80 = new IOTag();
                    t80.Name = string.Format("{0}.N7_HOUR", name);
                    t80.Type = (int)Common.TagType.External;
                    t80.DataType = (int)Common.DataType.Int32;
                    t80.Address = string.Format("{0}.D208", address);
                    t80.UpdateRating = 0;
                    t80.IsStoreToLog = false;
                    dev.IOTags.Add(t80);

                    IOTag t81 = new IOTag();
                    t81.Name = string.Format("{0}.N7_MIN", name);
                    t81.Type = (int)Common.TagType.External;
                    t81.DataType = (int)Common.DataType.Int32;
                    t81.Address = string.Format("{0}.D209", address);
                    t81.UpdateRating = 0;
                    t81.IsStoreToLog = false;
                    dev.IOTags.Add(t81);

                    IOTag t82 = new IOTag();
                    t82.Name = string.Format("{0}.N7_PAR", name);
                    t82.Type = (int)Common.TagType.External;
                    t82.DataType = (int)Common.DataType.Int32;
                    t82.Address = string.Format("{0}.D210", address);
                    t82.UpdateRating = 0;
                    t82.IsStoreToLog = false;
                    dev.IOTags.Add(t82);

                    IOTag t83 = new IOTag();
                    t83.Name = string.Format("{0}.N7_OFFSET", name);
                    t83.Type = (int)Common.TagType.External;
                    t83.DataType = (int)Common.DataType.Int32;
                    t83.Address = string.Format("{0}.D211", address);
                    t83.UpdateRating = 0;
                    t83.IsStoreToLog = false;
                    dev.IOTags.Add(t83);

                    #endregion

                    #region Special Day setting

                    IOTag t84 = new IOTag();
                    t84.Name = string.Format("{0}.OPT_S1", name);
                    t84.Type = (int)Common.TagType.External;
                    t84.DataType = (int)Common.DataType.Bool;
                    t84.Address = string.Format("{0}.S68", address);
                    t84.UpdateRating = 0;
                    t84.IsStoreToLog = false;
                    dev.IOTags.Add(t84);

                    IOTag t85 = new IOTag();
                    t85.Name = string.Format("{0}.OPT_S2", name);
                    t85.Type = (int)Common.TagType.External;
                    t85.DataType = (int)Common.DataType.Bool;
                    t85.Address = string.Format("{0}.S69", address);
                    t85.UpdateRating = 0;
                    t85.IsStoreToLog = false;
                    dev.IOTags.Add(t85);

                    IOTag t86 = new IOTag();
                    t86.Name = string.Format("{0}.OPT_S3", name);
                    t86.Type = (int)Common.TagType.External;
                    t86.DataType = (int)Common.DataType.Bool;
                    t86.Address = string.Format("{0}.S70", address);
                    t86.UpdateRating = 0;
                    t86.IsStoreToLog = false;
                    dev.IOTags.Add(t86);

                    IOTag t87 = new IOTag();
                    t87.Name = string.Format("{0}.OPT_S4", name);
                    t87.Type = (int)Common.TagType.External;
                    t87.DataType = (int)Common.DataType.Bool;
                    t87.Address = string.Format("{0}.S71", address);
                    t87.UpdateRating = 0;
                    t87.IsStoreToLog = false;
                    dev.IOTags.Add(t87);

                    IOTag t88 = new IOTag();
                    t88.Name = string.Format("{0}.OPT_S5", name);
                    t88.Type = (int)Common.TagType.External;
                    t88.DataType = (int)Common.DataType.Bool;
                    t88.Address = string.Format("{0}.S72", address);
                    t88.UpdateRating = 0;
                    t88.IsStoreToLog = false;
                    dev.IOTags.Add(t88);

                    IOTag t89 = new IOTag();
                    t89.Name = string.Format("{0}.OPT_S6", name);
                    t89.Type = (int)Common.TagType.External;
                    t89.DataType = (int)Common.DataType.Bool;
                    t89.Address = string.Format("{0}.S73", address);
                    t89.UpdateRating = 0;
                    t89.IsStoreToLog = false;
                    dev.IOTags.Add(t89);

                    IOTag t90 = new IOTag();
                    t90.Name = string.Format("{0}.OPT_S7", name);
                    t90.Type = (int)Common.TagType.External;
                    t90.DataType = (int)Common.DataType.Bool;
                    t90.Address = string.Format("{0}.S74", address);
                    t90.UpdateRating = 0;
                    t90.IsStoreToLog = false;
                    dev.IOTags.Add(t90);

                    IOTag t91 = new IOTag();
                    t91.Name = string.Format("{0}.S1_MODE", name);
                    t91.Type = (int)Common.TagType.External;
                    t91.DataType = (int)Common.DataType.Int32;
                    t91.Address = string.Format("{0}.D212", address);
                    t91.UpdateRating = 0;
                    t91.IsStoreToLog = false;
                    dev.IOTags.Add(t91);

                    IOTag t92 = new IOTag();
                    t92.Name = string.Format("{0}.S1_HOUR", name);
                    t92.Type = (int)Common.TagType.External;
                    t92.DataType = (int)Common.DataType.Int32;
                    t92.Address = string.Format("{0}.D213", address);
                    t92.UpdateRating = 0;
                    t92.IsStoreToLog = false;
                    dev.IOTags.Add(t92);

                    IOTag t93 = new IOTag();
                    t93.Name = string.Format("{0}.S1_MIN", name);
                    t93.Type = (int)Common.TagType.External;
                    t93.DataType = (int)Common.DataType.Int32;
                    t93.Address = string.Format("{0}.D214", address);
                    t93.UpdateRating = 0;
                    t93.IsStoreToLog = false;
                    dev.IOTags.Add(t93);

                    IOTag t94 = new IOTag();
                    t94.Name = string.Format("{0}.S1_PAR", name);
                    t94.Type = (int)Common.TagType.External;
                    t94.DataType = (int)Common.DataType.Int32;
                    t94.Address = string.Format("{0}.D215", address);
                    t94.UpdateRating = 0;
                    t94.IsStoreToLog = false;
                    dev.IOTags.Add(t94);

                    IOTag t95 = new IOTag();
                    t95.Name = string.Format("{0}.S1_OFFSET", name);
                    t95.Type = (int)Common.TagType.External;
                    t95.DataType = (int)Common.DataType.Int32;
                    t95.Address = string.Format("{0}.D216", address);
                    t95.UpdateRating = 0;
                    t95.IsStoreToLog = false;
                    dev.IOTags.Add(t95);

                    IOTag t96 = new IOTag();
                    t96.Name = string.Format("{0}.S2_MODE", name);
                    t96.Type = (int)Common.TagType.External;
                    t96.DataType = (int)Common.DataType.Int32;
                    t96.Address = string.Format("{0}.D217", address);
                    t96.UpdateRating = 0;
                    t96.IsStoreToLog = false;
                    dev.IOTags.Add(t96);

                    IOTag t97 = new IOTag();
                    t97.Name = string.Format("{0}.S2_HOUR", name);
                    t97.Type = (int)Common.TagType.External;
                    t97.DataType = (int)Common.DataType.Int32;
                    t97.Address = string.Format("{0}.D218", address);
                    t97.UpdateRating = 0;
                    t97.IsStoreToLog = false;
                    dev.IOTags.Add(t97);

                    IOTag t98 = new IOTag();
                    t98.Name = string.Format("{0}.S2_MIN", name);
                    t98.Type = (int)Common.TagType.External;
                    t98.DataType = (int)Common.DataType.Int32;
                    t98.Address = string.Format("{0}.D219", address);
                    t98.UpdateRating = 0;
                    t98.IsStoreToLog = false;
                    dev.IOTags.Add(t98);

                    IOTag t99 = new IOTag();
                    t99.Name = string.Format("{0}.S2_PAR", name);
                    t99.Type = (int)Common.TagType.External;
                    t99.DataType = (int)Common.DataType.Int32;
                    t99.Address = string.Format("{0}.D220", address);
                    t99.UpdateRating = 0;
                    t99.IsStoreToLog = false;
                    dev.IOTags.Add(t99);

                    IOTag t100 = new IOTag();
                    t100.Name = string.Format("{0}.S2_OFFSET", name);
                    t100.Type = (int)Common.TagType.External;
                    t100.DataType = (int)Common.DataType.Int32;
                    t100.Address = string.Format("{0}.D221", address);
                    t100.UpdateRating = 0;
                    t100.IsStoreToLog = false;
                    dev.IOTags.Add(t100);

                    IOTag t101 = new IOTag();
                    t101.Name = string.Format("{0}.S3_MODE", name);
                    t101.Type = (int)Common.TagType.External;
                    t101.DataType = (int)Common.DataType.Int32;
                    t101.Address = string.Format("{0}.D222", address);
                    t101.UpdateRating = 0;
                    t101.IsStoreToLog = false;
                    dev.IOTags.Add(t101);

                    IOTag t102 = new IOTag();
                    t102.Name = string.Format("{0}.S3_HOUR", name);
                    t102.Type = (int)Common.TagType.External;
                    t102.DataType = (int)Common.DataType.Int32;
                    t102.Address = string.Format("{0}.D223", address);
                    t102.UpdateRating = 0;
                    t102.IsStoreToLog = false;
                    dev.IOTags.Add(t102);

                    IOTag t103 = new IOTag();
                    t103.Name = string.Format("{0}.S3_MIN", name);
                    t103.Type = (int)Common.TagType.External;
                    t103.DataType = (int)Common.DataType.Int32;
                    t103.Address = string.Format("{0}.D224", address);
                    t103.UpdateRating = 0;
                    t103.IsStoreToLog = false;
                    dev.IOTags.Add(t103);

                    IOTag t104 = new IOTag();
                    t104.Name = string.Format("{0}.S3_PAR", name);
                    t104.Type = (int)Common.TagType.External;
                    t104.DataType = (int)Common.DataType.Int32;
                    t104.Address = string.Format("{0}.D225", address);
                    t104.UpdateRating = 0;
                    t104.IsStoreToLog = false;
                    dev.IOTags.Add(t104);

                    IOTag t105 = new IOTag();
                    t105.Name = string.Format("{0}.S3_OFFSET", name);
                    t105.Type = (int)Common.TagType.External;
                    t105.DataType = (int)Common.DataType.Int32;
                    t105.Address = string.Format("{0}.D226", address);
                    t105.UpdateRating = 0;
                    t105.IsStoreToLog = false;
                    dev.IOTags.Add(t105);

                    IOTag t106 = new IOTag();
                    t106.Name = string.Format("{0}.S4_MODE", name);
                    t106.Type = (int)Common.TagType.External;
                    t106.DataType = (int)Common.DataType.Int32;
                    t106.Address = string.Format("{0}.D227", address);
                    t106.UpdateRating = 0;
                    t106.IsStoreToLog = false;
                    dev.IOTags.Add(t106);

                    IOTag t107 = new IOTag();
                    t107.Name = string.Format("{0}.S4_HOUR", name);
                    t107.Type = (int)Common.TagType.External;
                    t107.DataType = (int)Common.DataType.Int32;
                    t107.Address = string.Format("{0}.D228", address);
                    t107.UpdateRating = 0;
                    t107.IsStoreToLog = false;
                    dev.IOTags.Add(t107);

                    IOTag t108 = new IOTag();
                    t108.Name = string.Format("{0}.S4_MIN", name);
                    t108.Type = (int)Common.TagType.External;
                    t108.DataType = (int)Common.DataType.Int32;
                    t108.Address = string.Format("{0}.D229", address);
                    t108.UpdateRating = 0;
                    t108.IsStoreToLog = false;
                    dev.IOTags.Add(t108);

                    IOTag t109 = new IOTag();
                    t109.Name = string.Format("{0}.S4_PAR", name);
                    t109.Type = (int)Common.TagType.External;
                    t109.DataType = (int)Common.DataType.Int32;
                    t109.Address = string.Format("{0}.D230", address);
                    t109.UpdateRating = 0;
                    t109.IsStoreToLog = false;
                    dev.IOTags.Add(t109);

                    IOTag t110 = new IOTag();
                    t110.Name = string.Format("{0}.S4_OFFSET", name);
                    t110.Type = (int)Common.TagType.External;
                    t110.DataType = (int)Common.DataType.Int32;
                    t110.Address = string.Format("{0}.D231", address);
                    t110.UpdateRating = 0;
                    t110.IsStoreToLog = false;
                    dev.IOTags.Add(t110);

                    IOTag t111 = new IOTag();
                    t111.Name = string.Format("{0}.S5_MODE", name);
                    t111.Type = (int)Common.TagType.External;
                    t111.DataType = (int)Common.DataType.Int32;
                    t111.Address = string.Format("{0}.D232", address);
                    t111.UpdateRating = 0;
                    t111.IsStoreToLog = false;
                    dev.IOTags.Add(t111);

                    IOTag t112 = new IOTag();
                    t112.Name = string.Format("{0}.S5_HOUR", name);
                    t112.Type = (int)Common.TagType.External;
                    t112.DataType = (int)Common.DataType.Int32;
                    t112.Address = string.Format("{0}.D233", address);
                    t112.UpdateRating = 0;
                    t112.IsStoreToLog = false;
                    dev.IOTags.Add(t112);

                    IOTag t113 = new IOTag();
                    t113.Name = string.Format("{0}.S5_MIN", name);
                    t113.Type = (int)Common.TagType.External;
                    t113.DataType = (int)Common.DataType.Int32;
                    t113.Address = string.Format("{0}.D234", address);
                    t113.UpdateRating = 0;
                    t113.IsStoreToLog = false;
                    dev.IOTags.Add(t113);

                    IOTag t114 = new IOTag();
                    t114.Name = string.Format("{0}.S5_PAR", name);
                    t114.Type = (int)Common.TagType.External;
                    t114.DataType = (int)Common.DataType.Int32;
                    t114.Address = string.Format("{0}.D235", address);
                    t114.UpdateRating = 0;
                    t114.IsStoreToLog = false;
                    dev.IOTags.Add(t114);

                    IOTag t115 = new IOTag();
                    t115.Name = string.Format("{0}.S5_OFFSET", name);
                    t115.Type = (int)Common.TagType.External;
                    t115.DataType = (int)Common.DataType.Int32;
                    t115.Address = string.Format("{0}.D236", address);
                    t115.UpdateRating = 0;
                    t115.IsStoreToLog = false;
                    dev.IOTags.Add(t115);

                    IOTag t116 = new IOTag();
                    t116.Name = string.Format("{0}.S6_MODE", name);
                    t116.Type = (int)Common.TagType.External;
                    t116.DataType = (int)Common.DataType.Int32;
                    t116.Address = string.Format("{0}.D237", address);
                    t116.UpdateRating = 0;
                    t116.IsStoreToLog = false;
                    dev.IOTags.Add(t116);

                    IOTag t117 = new IOTag();
                    t117.Name = string.Format("{0}.S6_HOUR", name);
                    t117.Type = (int)Common.TagType.External;
                    t117.DataType = (int)Common.DataType.Int32;
                    t117.Address = string.Format("{0}.D238", address);
                    t117.UpdateRating = 0;
                    t117.IsStoreToLog = false;
                    dev.IOTags.Add(t117);

                    IOTag t118 = new IOTag();
                    t118.Name = string.Format("{0}.S6_MIN", name);
                    t118.Type = (int)Common.TagType.External;
                    t118.DataType = (int)Common.DataType.Int32;
                    t118.Address = string.Format("{0}.D239", address);
                    t118.UpdateRating = 0;
                    t118.IsStoreToLog = false;
                    dev.IOTags.Add(t118);

                    IOTag t119 = new IOTag();
                    t119.Name = string.Format("{0}.S6_PAR", name);
                    t119.Type = (int)Common.TagType.External;
                    t119.DataType = (int)Common.DataType.Int32;
                    t119.Address = string.Format("{0}.D240", address);
                    t119.UpdateRating = 0;
                    t119.IsStoreToLog = false;
                    dev.IOTags.Add(t119);

                    IOTag t120 = new IOTag();
                    t120.Name = string.Format("{0}.S6_OFFSET", name);
                    t120.Type = (int)Common.TagType.External;
                    t120.DataType = (int)Common.DataType.Int32;
                    t120.Address = string.Format("{0}.D241", address);
                    t120.UpdateRating = 0;
                    t120.IsStoreToLog = false;
                    dev.IOTags.Add(t120);

                    IOTag t130 = new IOTag();
                    t130.Name = string.Format("{0}.S7_MODE", name);
                    t130.Type = (int)Common.TagType.External;
                    t130.DataType = (int)Common.DataType.Int32;
                    t130.Address = string.Format("{0}.D242", address);
                    t130.UpdateRating = 0;
                    t130.IsStoreToLog = false;
                    dev.IOTags.Add(t130);

                    IOTag t131 = new IOTag();
                    t131.Name = string.Format("{0}.S7_HOUR", name);
                    t131.Type = (int)Common.TagType.External;
                    t131.DataType = (int)Common.DataType.Int32;
                    t131.Address = string.Format("{0}.D243", address);
                    t131.UpdateRating = 0;
                    t131.IsStoreToLog = false;
                    dev.IOTags.Add(t131);

                    IOTag t132 = new IOTag();
                    t132.Name = string.Format("{0}.S7_MIN", name);
                    t132.Type = (int)Common.TagType.External;
                    t132.DataType = (int)Common.DataType.Int32;
                    t132.Address = string.Format("{0}.D244", address);
                    t132.UpdateRating = 0;
                    t132.IsStoreToLog = false;
                    dev.IOTags.Add(t132);

                    IOTag t133 = new IOTag();
                    t133.Name = string.Format("{0}.S7_PAR", name);
                    t133.Type = (int)Common.TagType.External;
                    t133.DataType = (int)Common.DataType.Int32;
                    t133.Address = string.Format("{0}.D245", address);
                    t133.UpdateRating = 0;
                    t133.IsStoreToLog = false;
                    dev.IOTags.Add(t133);

                    IOTag t134 = new IOTag();
                    t134.Name = string.Format("{0}.S7_OFFSET", name);
                    t134.Type = (int)Common.TagType.External;
                    t134.DataType = (int)Common.DataType.Int32;
                    t134.Address = string.Format("{0}.D246", address);
                    t134.UpdateRating = 0;
                    t134.IsStoreToLog = false;
                    dev.IOTags.Add(t134);

                    #endregion

                    #region Parameter

                    IOTag t19 = new IOTag();
                    t19.Name = string.Format("{0}.TG_X_A1", name);
                    t19.Type = (int)Common.TagType.External;
                    t19.DataType = (int)Common.DataType.Int32;
                    t19.Address = string.Format("{0}.D153", address);
                    t19.UpdateRating = 0;
                    t19.IsStoreToLog = false;
                    dev.IOTags.Add(t19);

                    IOTag t20 = new IOTag();
                    t20.Name = string.Format("{0}.TG_V_A1", name);
                    t20.Type = (int)Common.TagType.External;
                    t20.DataType = (int)Common.DataType.Int32;
                    t20.Address = string.Format("{0}.D154", address);
                    t20.UpdateRating = 0;
                    t20.IsStoreToLog = false;
                    dev.IOTags.Add(t20);

                    IOTag t21 = new IOTag();
                    t21.Name = string.Format("{0}.TG_GT_A1", name);
                    t21.Type = (int)Common.TagType.External;
                    t21.DataType = (int)Common.DataType.Int32;
                    t21.Address = string.Format("{0}.D155", address);
                    t21.UpdateRating = 0;
                    t21.IsStoreToLog = false;
                    dev.IOTags.Add(t21);

                    IOTag t22 = new IOTag();
                    t22.Name = string.Format("{0}.TG_X_B1", name);
                    t22.Type = (int)Common.TagType.External;
                    t22.DataType = (int)Common.DataType.Int32;
                    t22.Address = string.Format("{0}.D156", address);
                    t22.UpdateRating = 0;
                    t22.IsStoreToLog = false;
                    dev.IOTags.Add(t22);

                    IOTag t23 = new IOTag();
                    t23.Name = string.Format("{0}.TG_V_B1", name);
                    t23.Type = (int)Common.TagType.External;
                    t23.DataType = (int)Common.DataType.Int32;
                    t23.Address = string.Format("{0}.D157", address);
                    t23.UpdateRating = 0;
                    t23.IsStoreToLog = false;
                    dev.IOTags.Add(t23);

                    IOTag t24 = new IOTag();
                    t24.Name = string.Format("{0}.TG_GT_B1", name);
                    t24.Type = (int)Common.TagType.External;
                    t24.DataType = (int)Common.DataType.Int32;
                    t24.Address = string.Format("{0}.D158", address);
                    t24.UpdateRating = 0;
                    t24.IsStoreToLog = false;
                    dev.IOTags.Add(t24);

                    IOTag t135 = new IOTag();
                    t135.Name = string.Format("{0}.TG_X_A2", name);
                    t135.Type = (int)Common.TagType.External;
                    t135.DataType = (int)Common.DataType.Int32;
                    t135.Address = string.Format("{0}.D159", address);
                    t135.UpdateRating = 0;
                    t135.IsStoreToLog = false;
                    dev.IOTags.Add(t135);

                    IOTag t136 = new IOTag();
                    t136.Name = string.Format("{0}.TG_V_A2", name);
                    t136.Type = (int)Common.TagType.External;
                    t136.DataType = (int)Common.DataType.Int32;
                    t136.Address = string.Format("{0}.D160", address);
                    t136.UpdateRating = 0;
                    t136.IsStoreToLog = false;
                    dev.IOTags.Add(t136);

                    IOTag t137 = new IOTag();
                    t137.Name = string.Format("{0}.TG_GT_A2", name);
                    t137.Type = (int)Common.TagType.External;
                    t137.DataType = (int)Common.DataType.Int32;
                    t137.Address = string.Format("{0}.D161", address);
                    t137.UpdateRating = 0;
                    t137.IsStoreToLog = false;
                    dev.IOTags.Add(t137);

                    IOTag t138 = new IOTag();
                    t138.Name = string.Format("{0}.TG_X_B2", name);
                    t138.Type = (int)Common.TagType.External;
                    t138.DataType = (int)Common.DataType.Int32;
                    t138.Address = string.Format("{0}.D162", address);
                    t138.UpdateRating = 0;
                    t138.IsStoreToLog = false;
                    dev.IOTags.Add(t138);

                    IOTag t139 = new IOTag();
                    t139.Name = string.Format("{0}.TG_V_B2", name);
                    t139.Type = (int)Common.TagType.External;
                    t139.DataType = (int)Common.DataType.Int32;
                    t139.Address = string.Format("{0}.D163", address);
                    t139.UpdateRating = 0;
                    t139.IsStoreToLog = false;
                    dev.IOTags.Add(t139);

                    IOTag t140 = new IOTag();
                    t140.Name = string.Format("{0}.TG_GT_B2", name);
                    t140.Type = (int)Common.TagType.External;
                    t140.DataType = (int)Common.DataType.Int32;
                    t140.Address = string.Format("{0}.D164", address);
                    t140.UpdateRating = 0;
                    t140.IsStoreToLog = false;
                    dev.IOTags.Add(t140);

                    IOTag t141 = new IOTag();
                    t141.Name = string.Format("{0}.TG_X_A3", name);
                    t141.Type = (int)Common.TagType.External;
                    t141.DataType = (int)Common.DataType.Int32;
                    t141.Address = string.Format("{0}.D165", address);
                    t141.UpdateRating = 0;
                    t141.IsStoreToLog = false;
                    dev.IOTags.Add(t141);

                    IOTag t142 = new IOTag();
                    t142.Name = string.Format("{0}.TG_V_A3", name);
                    t142.Type = (int)Common.TagType.External;
                    t142.DataType = (int)Common.DataType.Int32;
                    t142.Address = string.Format("{0}.D166", address);
                    t142.UpdateRating = 0;
                    t142.IsStoreToLog = false;
                    dev.IOTags.Add(t142);

                    IOTag t143 = new IOTag();
                    t143.Name = string.Format("{0}.TG_GT_A3", name);
                    t143.Type = (int)Common.TagType.External;
                    t143.DataType = (int)Common.DataType.Int32;
                    t143.Address = string.Format("{0}.D167", address);
                    t143.UpdateRating = 0;
                    t143.IsStoreToLog = false;
                    dev.IOTags.Add(t143);

                    IOTag t144 = new IOTag();
                    t144.Name = string.Format("{0}.TG_X_B3", name);
                    t144.Type = (int)Common.TagType.External;
                    t144.DataType = (int)Common.DataType.Int32;
                    t144.Address = string.Format("{0}.D168", address);
                    t144.UpdateRating = 0;
                    t144.IsStoreToLog = false;
                    dev.IOTags.Add(t144);

                    IOTag t145 = new IOTag();
                    t145.Name = string.Format("{0}.TG_V_B3", name);
                    t145.Type = (int)Common.TagType.External;
                    t145.DataType = (int)Common.DataType.Int32;
                    t145.Address = string.Format("{0}.D169", address);
                    t145.UpdateRating = 0;
                    t145.IsStoreToLog = false;
                    dev.IOTags.Add(t145);

                    IOTag t146 = new IOTag();
                    t146.Name = string.Format("{0}.TG_GT_B3", name);
                    t146.Type = (int)Common.TagType.External;
                    t146.DataType = (int)Common.DataType.Int32;
                    t146.Address = string.Format("{0}.D170", address);
                    t146.UpdateRating = 0;
                    t146.IsStoreToLog = false;
                    dev.IOTags.Add(t146);

                    IOTag t147 = new IOTag();
                    t147.Name = string.Format("{0}.TG_X_A4", name);
                    t147.Type = (int)Common.TagType.External;
                    t147.DataType = (int)Common.DataType.Int32;
                    t147.Address = string.Format("{0}.D171", address);
                    t147.UpdateRating = 0;
                    t147.IsStoreToLog = false;
                    dev.IOTags.Add(t147);

                    IOTag t148 = new IOTag();
                    t148.Name = string.Format("{0}.TG_V_A4", name);
                    t148.Type = (int)Common.TagType.External;
                    t148.DataType = (int)Common.DataType.Int32;
                    t148.Address = string.Format("{0}.D172", address);
                    t148.UpdateRating = 0;
                    t148.IsStoreToLog = false;
                    dev.IOTags.Add(t148);

                    IOTag t149 = new IOTag();
                    t149.Name = string.Format("{0}.TG_GT_A4", name);
                    t149.Type = (int)Common.TagType.External;
                    t149.DataType = (int)Common.DataType.Int32;
                    t149.Address = string.Format("{0}.D173", address);
                    t149.UpdateRating = 0;
                    t149.IsStoreToLog = false;
                    dev.IOTags.Add(t149);

                    IOTag t150 = new IOTag();
                    t150.Name = string.Format("{0}.TG_X_B4", name);
                    t150.Type = (int)Common.TagType.External;
                    t150.DataType = (int)Common.DataType.Int32;
                    t150.Address = string.Format("{0}.D174", address);
                    t150.UpdateRating = 0;
                    t150.IsStoreToLog = false;
                    dev.IOTags.Add(t150);

                    IOTag t151 = new IOTag();
                    t151.Name = string.Format("{0}.TG_V_B4", name);
                    t151.Type = (int)Common.TagType.External;
                    t151.DataType = (int)Common.DataType.Int32;
                    t151.Address = string.Format("{0}.D175", address);
                    t151.UpdateRating = 0;
                    t151.IsStoreToLog = false;
                    dev.IOTags.Add(t151);

                    IOTag t152 = new IOTag();
                    t152.Name = string.Format("{0}.TG_GT_B4", name);
                    t152.Type = (int)Common.TagType.External;
                    t152.DataType = (int)Common.DataType.Int32;
                    t152.Address = string.Format("{0}.D176", address);
                    t152.UpdateRating = 0;
                    t152.IsStoreToLog = false;
                    dev.IOTags.Add(t152);

                    IOTag t153 = new IOTag();
                    t153.Name = string.Format("{0}.CK1", name);
                    t153.Type = (int)Common.TagType.External;
                    t153.DataType = (int)Common.DataType.Int32;
                    t153.Address = string.Format("{0}.D73", address);
                    t153.UpdateRating = 0;
                    t153.IsStoreToLog = false;
                    dev.IOTags.Add(t153);

                    IOTag t154 = new IOTag();
                    t154.Name = string.Format("{0}.CK2", name);
                    t154.Type = (int)Common.TagType.External;
                    t154.DataType = (int)Common.DataType.Int32;
                    t154.Address = string.Format("{0}.D74", address);
                    t154.UpdateRating = 0;
                    t154.IsStoreToLog = false;
                    dev.IOTags.Add(t154);

                    IOTag t155 = new IOTag();
                    t155.Name = string.Format("{0}.CK3", name);
                    t155.Type = (int)Common.TagType.External;
                    t155.DataType = (int)Common.DataType.Int32;
                    t155.Address = string.Format("{0}.D75", address);
                    t155.UpdateRating = 0;
                    t155.IsStoreToLog = false;
                    dev.IOTags.Add(t155);

                    IOTag t156 = new IOTag();
                    t156.Name = string.Format("{0}.CK4", name);
                    t156.Type = (int)Common.TagType.External;
                    t156.DataType = (int)Common.DataType.Int32;
                    t156.Address = string.Format("{0}.D76", address);
                    t156.UpdateRating = 0;
                    t156.IsStoreToLog = false;
                    dev.IOTags.Add(t156);

                    IOTag t157 = new IOTag();
                    t157.Name = string.Format("{0}.S_T2", name);
                    t157.Type = (int)Common.TagType.External;
                    t157.DataType = (int)Common.DataType.Bool;
                    t157.Address = string.Format("{0}.S80", address);
                    t157.UpdateRating = 0;
                    t157.IsStoreToLog = false;
                    dev.IOTags.Add(t157);

                    IOTag t158 = new IOTag();
                    t158.Name = string.Format("{0}.S_T3", name);
                    t158.Type = (int)Common.TagType.External;
                    t158.DataType = (int)Common.DataType.Bool;
                    t158.Address = string.Format("{0}.S81", address);
                    t158.UpdateRating = 0;
                    t158.IsStoreToLog = false;
                    dev.IOTags.Add(t158);

                    IOTag t159 = new IOTag();
                    t159.Name = string.Format("{0}.S_T4", name);
                    t159.Type = (int)Common.TagType.External;
                    t159.DataType = (int)Common.DataType.Bool;
                    t159.Address = string.Format("{0}.S82", address);
                    t159.UpdateRating = 0;
                    t159.IsStoreToLog = false;
                    dev.IOTags.Add(t159);

                    IOTag t160 = new IOTag();
                    t160.Name = string.Format("{0}.S_T5", name);
                    t160.Type = (int)Common.TagType.External;
                    t160.DataType = (int)Common.DataType.Bool;
                    t160.Address = string.Format("{0}.S83", address);
                    t160.UpdateRating = 0;
                    t160.IsStoreToLog = false;
                    dev.IOTags.Add(t160);

                    IOTag t161 = new IOTag();
                    t161.Name = string.Format("{0}.S_T6", name);
                    t161.Type = (int)Common.TagType.External;
                    t161.DataType = (int)Common.DataType.Bool;
                    t161.Address = string.Format("{0}.S84", address);
                    t161.UpdateRating = 0;
                    t161.IsStoreToLog = false;
                    dev.IOTags.Add(t161);

                    IOTag t162 = new IOTag();
                    t162.Name = string.Format("{0}.S_T7", name);
                    t162.Type = (int)Common.TagType.External;
                    t162.DataType = (int)Common.DataType.Bool;
                    t162.Address = string.Format("{0}.S85", address);
                    t162.UpdateRating = 0;
                    t162.IsStoreToLog = false;
                    dev.IOTags.Add(t162);

                    IOTag t163 = new IOTag();
                    t163.Name = string.Format("{0}.S_CN", name);
                    t163.Type = (int)Common.TagType.External;
                    t163.DataType = (int)Common.DataType.Bool;
                    t163.Address = string.Format("{0}.S86", address);
                    t163.UpdateRating = 0;
                    t163.IsStoreToLog = false;
                    dev.IOTags.Add(t163);

                    IOTag t164 = new IOTag();
                    t164.Name = string.Format("{0}.S_LE", name);
                    t164.Type = (int)Common.TagType.External;
                    t164.DataType = (int)Common.DataType.Bool;
                    t164.Address = string.Format("{0}.S87", address);
                    t164.UpdateRating = 0;
                    t164.IsStoreToLog = false;
                    dev.IOTags.Add(t164);

                    #endregion

                    #region Alarm

                    IOTag t165 = new IOTag();
                    t165.Name = string.Format("{0}.XA_FB", name);
                    t165.Type = (int)Common.TagType.External;
                    t165.DataType = (int)Common.DataType.Bool;
                    t165.Address = string.Format("{0}.M51", address);
                    t165.UpdateRating = 1000;
                    t165.IsStoreToLog = true;
                    dev.IOTags.Add(t165);

                    IOTag t166 = new IOTag();
                    t166.Name = string.Format("{0}.VA_FB", name);
                    t166.Type = (int)Common.TagType.External;
                    t166.DataType = (int)Common.DataType.Bool;
                    t166.Address = string.Format("{0}.M52", address);
                    t166.UpdateRating = 1000;
                    t166.IsStoreToLog = true;
                    dev.IOTags.Add(t166);

                    IOTag t167 = new IOTag();
                    t167.Name = string.Format("{0}.DA_FB", name);
                    t167.Type = (int)Common.TagType.External;
                    t167.DataType = (int)Common.DataType.Bool;
                    t167.Address = string.Format("{0}.M53", address);
                    t167.UpdateRating = 1000;
                    t167.IsStoreToLog = true;
                    dev.IOTags.Add(t167);

                    IOTag t168 = new IOTag();
                    t168.Name = string.Format("{0}.XB_FB", name);
                    t168.Type = (int)Common.TagType.External;
                    t168.DataType = (int)Common.DataType.Bool;
                    t168.Address = string.Format("{0}.M54", address);
                    t168.UpdateRating = 1000;
                    t168.IsStoreToLog = true;
                    dev.IOTags.Add(t168);

                    IOTag t169 = new IOTag();
                    t169.Name = string.Format("{0}.VB_FB", name);
                    t169.Type = (int)Common.TagType.External;
                    t169.DataType = (int)Common.DataType.Bool;
                    t169.Address = string.Format("{0}.M55", address);
                    t169.UpdateRating = 1000;
                    t169.IsStoreToLog = true;
                    dev.IOTags.Add(t169);

                    IOTag t170 = new IOTag();
                    t170.Name = string.Format("{0}.DB_FB", name);
                    t170.Type = (int)Common.TagType.External;
                    t170.DataType = (int)Common.DataType.Bool;
                    t170.Address = string.Format("{0}.M56", address);
                    t170.UpdateRating = 1000;
                    t170.IsStoreToLog = true;
                    dev.IOTags.Add(t170);

                    IOTag t171 = new IOTag();
                    t171.Name = string.Format("{0}.OP_E_XA", name);
                    t171.Type = (int)Common.TagType.External;
                    t171.DataType = (int)Common.DataType.Bool;
                    t171.Address = string.Format("{0}.S90", address);
                    t171.UpdateRating = 0;
                    t171.IsStoreToLog = false;
                    dev.IOTags.Add(t171);

                    IOTag t172 = new IOTag();
                    t172.Name = string.Format("{0}.OP_E_VA", name);
                    t172.Type = (int)Common.TagType.External;
                    t172.DataType = (int)Common.DataType.Bool;
                    t172.Address = string.Format("{0}.S91", address);
                    t172.UpdateRating = 0;
                    t172.IsStoreToLog = false;
                    dev.IOTags.Add(t172);

                    IOTag t173 = new IOTag();
                    t173.Name = string.Format("{0}.OP_E_DA", name);
                    t173.Type = (int)Common.TagType.External;
                    t173.DataType = (int)Common.DataType.Bool;
                    t173.Address = string.Format("{0}.S92", address);
                    t173.UpdateRating = 0;
                    t173.IsStoreToLog = false;
                    dev.IOTags.Add(t173);

                    IOTag t174 = new IOTag();
                    t174.Name = string.Format("{0}.OP_E_CDA", name);
                    t174.Type = (int)Common.TagType.External;
                    t174.DataType = (int)Common.DataType.Bool;
                    t174.Address = string.Format("{0}.S93", address);
                    t174.UpdateRating = 0;
                    t174.IsStoreToLog = false;
                    dev.IOTags.Add(t174);

                    IOTag t175 = new IOTag();
                    t175.Name = string.Format("{0}.OP_E_CTA", name);
                    t175.Type = (int)Common.TagType.External;
                    t175.DataType = (int)Common.DataType.Bool;
                    t175.Address = string.Format("{0}.S94", address);
                    t175.UpdateRating = 0;
                    t175.IsStoreToLog = false;
                    dev.IOTags.Add(t175);

                    IOTag t176 = new IOTag();
                    t176.Name = string.Format("{0}.OP_E_XB", name);
                    t176.Type = (int)Common.TagType.External;
                    t176.DataType = (int)Common.DataType.Bool;
                    t176.Address = string.Format("{0}.S95", address);
                    t176.UpdateRating = 0;
                    t176.IsStoreToLog = false;
                    dev.IOTags.Add(t176);

                    IOTag t177 = new IOTag();
                    t177.Name = string.Format("{0}.OP_E_VB", name);
                    t177.Type = (int)Common.TagType.External;
                    t177.DataType = (int)Common.DataType.Bool;
                    t177.Address = string.Format("{0}.S96", address);
                    t177.UpdateRating = 0;
                    t177.IsStoreToLog = false;
                    dev.IOTags.Add(t177);

                    IOTag t178 = new IOTag();
                    t178.Name = string.Format("{0}.OP_E_DB", name);
                    t178.Type = (int)Common.TagType.External;
                    t178.DataType = (int)Common.DataType.Bool;
                    t178.Address = string.Format("{0}.S97", address);
                    t178.UpdateRating = 0;
                    t178.IsStoreToLog = false;
                    dev.IOTags.Add(t178);

                    IOTag t179 = new IOTag();
                    t179.Name = string.Format("{0}.OP_E_CDB", name);
                    t179.Type = (int)Common.TagType.External;
                    t179.DataType = (int)Common.DataType.Bool;
                    t179.Address = string.Format("{0}.S98", address);
                    t179.UpdateRating = 0;
                    t179.IsStoreToLog = false;
                    dev.IOTags.Add(t179);

                    IOTag t180 = new IOTag();
                    t180.Name = string.Format("{0}.OP_E_CTB", name);
                    t180.Type = (int)Common.TagType.External;
                    t180.DataType = (int)Common.DataType.Bool;
                    t180.Address = string.Format("{0}.S99", address);
                    t180.UpdateRating = 0;
                    t180.IsStoreToLog = false;
                    dev.IOTags.Add(t180);

                    IOTag t181 = new IOTag();
                    t181.Name = string.Format("{0}.AC_MAT_X", name);
                    t181.Type = (int)Common.TagType.External;
                    t181.DataType = (int)Common.DataType.Int32;
                    t181.Address = string.Format("{0}.D248", address);
                    t181.UpdateRating = 0;
                    t181.IsStoreToLog = false;
                    dev.IOTags.Add(t181);

                    IOTag t182 = new IOTag();
                    t182.Name = string.Format("{0}.AC_MAT_V", name);
                    t182.Type = (int)Common.TagType.External;
                    t182.DataType = (int)Common.DataType.Int32;
                    t182.Address = string.Format("{0}.D249", address);
                    t182.UpdateRating = 0;
                    t182.IsStoreToLog = false;
                    dev.IOTags.Add(t182);

                    IOTag t183 = new IOTag();
                    t183.Name = string.Format("{0}.AC_MAT_D", name);
                    t183.Type = (int)Common.TagType.External;
                    t183.DataType = (int)Common.DataType.Int32;
                    t183.Address = string.Format("{0}.D250", address);
                    t183.UpdateRating = 0;
                    t183.IsStoreToLog = false;
                    dev.IOTags.Add(t183);

                    IOTag t184 = new IOTag();
                    t184.Name = string.Format("{0}.AC_CD", name);
                    t184.Type = (int)Common.TagType.External;
                    t184.DataType = (int)Common.DataType.Int32;
                    t184.Address = string.Format("{0}.D251", address);
                    t184.UpdateRating = 0;
                    t184.IsStoreToLog = false;
                    dev.IOTags.Add(t184);

                    IOTag t185 = new IOTag();
                    t185.Name = string.Format("{0}.AC_CT", name);
                    t185.Type = (int)Common.TagType.External;
                    t185.DataType = (int)Common.DataType.Int32;
                    t185.Address = string.Format("{0}.D252", address);
                    t185.UpdateRating = 0;
                    t185.IsStoreToLog = false;
                    dev.IOTags.Add(t185);

                    IOTag t9 = new IOTag();
                    t9.Name = string.Format("{0}.F_XBA", name);
                    t9.Type = (int)Common.TagType.External;
                    t9.DataType = (int)Common.DataType.Int32;
                    t9.Address = string.Format("{0}.D143", address);
                    t9.UpdateRating = 0;
                    t9.IsStoreToLog = false;
                    dev.IOTags.Add(t9);

                    IOTag t10 = new IOTag();
                    t10.Name = string.Format("{0}.O_XBA", name);
                    t10.Type = (int)Common.TagType.External;
                    t10.DataType = (int)Common.DataType.Int32;
                    t10.Address = string.Format("{0}.D144", address);
                    t10.UpdateRating = 0;
                    t10.IsStoreToLog = false;
                    dev.IOTags.Add(t10);

                    IOTag t11 = new IOTag();
                    t11.Name = string.Format("{0}.F_XBB", name);
                    t11.Type = (int)Common.TagType.External;
                    t11.DataType = (int)Common.DataType.Int32;
                    t11.Address = string.Format("{0}.D145", address);
                    t11.UpdateRating = 0;
                    t11.IsStoreToLog = false;
                    dev.IOTags.Add(t11);

                    IOTag t12 = new IOTag();
                    t12.Name = string.Format("{0}.O_XBB", name);
                    t12.Type = (int)Common.TagType.External;
                    t12.DataType = (int)Common.DataType.Int32;
                    t12.Address = string.Format("{0}.D146", address);
                    t12.UpdateRating = 0;
                    t12.IsStoreToLog = false;
                    dev.IOTags.Add(t12);

                    #endregion

                    #region Time

                    IOTag t186 = new IOTag();
                    t186.Name = string.Format("{0}.YEAR_PV", name);
                    t186.Type = (int)Common.TagType.External;
                    t186.DataType = (int)Common.DataType.Int32;
                    t186.Address = string.Format("{0}.D0", address);
                    t186.UpdateRating = 0;
                    t186.IsStoreToLog = false;
                    dev.IOTags.Add(t186);

                    IOTag t187 = new IOTag();
                    t187.Name = string.Format("{0}.MONTH_PV", name);
                    t187.Type = (int)Common.TagType.External;
                    t187.DataType = (int)Common.DataType.Int32;
                    t187.Address = string.Format("{0}.D1", address);
                    t187.UpdateRating = 0;
                    t187.IsStoreToLog = false;
                    dev.IOTags.Add(t187);

                    IOTag t188 = new IOTag();
                    t188.Name = string.Format("{0}.DAY_PV", name);
                    t188.Type = (int)Common.TagType.External;
                    t188.DataType = (int)Common.DataType.Int32;
                    t188.Address = string.Format("{0}.D2", address);
                    t188.UpdateRating = 0;
                    t188.IsStoreToLog = false;
                    dev.IOTags.Add(t188);

                    IOTag t189 = new IOTag();
                    t189.Name = string.Format("{0}.HOUR_PV", name);
                    t189.Type = (int)Common.TagType.External;
                    t189.DataType = (int)Common.DataType.Int32;
                    t189.Address = string.Format("{0}.D3", address);
                    t189.UpdateRating = 0;
                    t189.IsStoreToLog = false;
                    dev.IOTags.Add(t189);

                    IOTag t190 = new IOTag();
                    t190.Name = string.Format("{0}.MIN_PV", name);
                    t190.Type = (int)Common.TagType.External;
                    t190.DataType = (int)Common.DataType.Int32;
                    t190.Address = string.Format("{0}.D4", address);
                    t190.UpdateRating = 0;
                    t190.IsStoreToLog = false;
                    dev.IOTags.Add(t190);

                    IOTag t191 = new IOTag();
                    t191.Name = string.Format("{0}.SEC_PV", name);
                    t191.Type = (int)Common.TagType.External;
                    t191.DataType = (int)Common.DataType.Int32;
                    t191.Address = string.Format("{0}.D5", address);
                    t191.UpdateRating = 0;
                    t191.IsStoreToLog = false;
                    dev.IOTags.Add(t191);

                    IOTag t192 = new IOTag();
                    t192.Name = string.Format("{0}.MAN_TA", name);
                    t192.Type = (int)Common.TagType.External;
                    t192.DataType = (int)Common.DataType.Bool;
                    t192.Address = string.Format("{0}.M30", address);
                    t192.UpdateRating = 0;
                    t192.IsStoreToLog = false;
                    dev.IOTags.Add(t192);

                    IOTag t193 = new IOTag();
                    t193.Name = string.Format("{0}.MAN_TB", name);
                    t193.Type = (int)Common.TagType.External;
                    t193.DataType = (int)Common.DataType.Bool;
                    t193.Address = string.Format("{0}.M31", address);
                    t193.UpdateRating = 0;
                    t193.IsStoreToLog = false;
                    dev.IOTags.Add(t193);

                    IOTag t194 = new IOTag();
                    t194.Name = string.Format("{0}.MAN_YEL", name);
                    t194.Type = (int)Common.TagType.External;
                    t194.DataType = (int)Common.DataType.Bool;
                    t194.Address = string.Format("{0}.M32", address);
                    t194.UpdateRating = 0;
                    t194.IsStoreToLog = false;
                    dev.IOTags.Add(t194);

                    IOTag t195 = new IOTag();
                    t195.Name = string.Format("{0}.SETTIME", name);
                    t195.Type = (int)Common.TagType.External;
                    t195.DataType = (int)Common.DataType.Bool;
                    t195.Address = string.Format("SETTIME_THGT.Device1.Chot{0}", temp);
                    t195.UpdateRating = 0;
                    t195.IsStoreToLog = false;
                    dev.IOTags.Add(t195);

                    #endregion

                    #region event error
                    IOTag t196 = new IOTag();
                    t196.Name = string.Format("{0}.E_MAT_XA", name);
                    t196.Type = (int)Common.TagType.External;
                    t196.DataType = (int)Common.DataType.Bool;
                    t196.Address = string.Format("{0}.M60", address);
                    t196.UpdateRating = 1000;
                    t196.IsStoreToLog = false;
                    AlarmTag alarm1 = new AlarmTag();
                    alarm1.Name = string.Format("{0}.E_MAT_XA", name);
                    alarm1.Type = (int)AlarmType.Digital;
                    alarm1.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm1.IsActive = true;
                    alarm1.UpdateRating = 1000;
                    alarm1.Value = (int)AlarmValue.Null;
                    alarm1.IOTag = t196;
                    dev.IOTags.Add(t196);

                    IOTag t197 = new IOTag();
                    t197.Name = string.Format("{0}.E_MAT_VA", name);
                    t197.Type = (int)Common.TagType.External;
                    t197.DataType = (int)Common.DataType.Bool;
                    t197.Address = string.Format("{0}.M61", address);
                    t197.UpdateRating = 1000;
                    t197.IsStoreToLog = false;
                    AlarmTag alarm2 = new AlarmTag();
                    alarm2.Name = string.Format("{0}.E_MAT_VA", name);
                    alarm2.Type = (int)AlarmType.Digital;
                    alarm2.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm2.IsActive = true;
                    alarm2.UpdateRating = 1000;
                    alarm2.Value = (int)AlarmValue.Null;
                    alarm2.IOTag = t197;
                    dev.IOTags.Add(t197);

                    IOTag t198 = new IOTag();
                    t198.Name = string.Format("{0}.E_MAT_DA", name);
                    t198.Type = (int)Common.TagType.External;
                    t198.DataType = (int)Common.DataType.Bool;
                    t198.Address = string.Format("{0}.M62", address);
                    t198.UpdateRating = 1000;
                    t198.IsStoreToLog = false;
                    AlarmTag alarm3 = new AlarmTag();
                    alarm3.Name = string.Format("{0}.E_MAT_DA", name);
                    alarm3.Type = (int)AlarmType.Digital;
                    alarm3.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm3.IsActive = true;
                    alarm3.UpdateRating = 1000;
                    alarm3.Value = (int)AlarmValue.Null;
                    alarm3.IOTag = t198;
                    dev.IOTags.Add(t198);

                    IOTag t199 = new IOTag();
                    t199.Name = string.Format("{0}.E_CD_A", name);
                    t199.Type = (int)Common.TagType.External;
                    t199.DataType = (int)Common.DataType.Bool;
                    t199.Address = string.Format("{0}.M63", address);
                    t199.UpdateRating = 1000;
                    t199.IsStoreToLog = false;
                    AlarmTag alarm4 = new AlarmTag();
                    alarm4.Name = string.Format("{0}.E_CD_A", name);
                    alarm4.Type = (int)AlarmType.Digital;
                    alarm4.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm4.IsActive = true;
                    alarm4.UpdateRating = 1000;
                    alarm4.Value = (int)AlarmValue.Null;
                    alarm4.IOTag = t199;
                    dev.IOTags.Add(t199);

                    IOTag t200 = new IOTag();
                    t200.Name = string.Format("{0}.E_CT_A", name);
                    t200.Type = (int)Common.TagType.External;
                    t200.DataType = (int)Common.DataType.Bool;
                    t200.Address = string.Format("{0}.M64", address);
                    t200.UpdateRating = 1000;
                    t200.IsStoreToLog = false;
                    AlarmTag alarm5 = new AlarmTag();
                    alarm5.Name = string.Format("{0}.E_CT_A", name);
                    alarm5.Type = (int)AlarmType.Digital;
                    alarm5.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm5.IsActive = true;
                    alarm5.UpdateRating = 1000;
                    alarm5.Value = (int)AlarmValue.Null;
                    alarm5.IOTag = t200;
                    dev.IOTags.Add(t200);

                    IOTag t201 = new IOTag();
                    t201.Name = string.Format("{0}.E_MAT_XB", name);
                    t201.Type = (int)Common.TagType.External;
                    t201.DataType = (int)Common.DataType.Bool;
                    t201.Address = string.Format("{0}.M65", address);
                    t201.UpdateRating = 1000;
                    t201.IsStoreToLog = false;
                    AlarmTag alarm6 = new AlarmTag();
                    alarm6.Name = string.Format("{0}.E_MAT_XB", name);
                    alarm6.Type = (int)AlarmType.Digital;
                    alarm6.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm6.IsActive = true;
                    alarm6.UpdateRating = 1000;
                    alarm6.Value = (int)AlarmValue.Null;
                    alarm6.IOTag = t201;
                    dev.IOTags.Add(t201);

                    IOTag t202 = new IOTag();
                    t202.Name = string.Format("{0}.E_MAT_VB", name);
                    t202.Type = (int)Common.TagType.External;
                    t202.DataType = (int)Common.DataType.Bool;
                    t202.Address = string.Format("{0}.M66", address);
                    t202.UpdateRating = 1000;
                    t202.IsStoreToLog = false;
                    AlarmTag alarm7 = new AlarmTag();
                    alarm7.Name = string.Format("{0}.E_MAT_VB", name);
                    alarm7.Type = (int)AlarmType.Digital;
                    alarm7.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm7.IsActive = true;
                    alarm7.UpdateRating = 1000;
                    alarm7.Value = (int)AlarmValue.Null;
                    alarm7.IOTag = t202;
                    dev.IOTags.Add(t202);

                    IOTag t203 = new IOTag();
                    t203.Name = string.Format("{0}.E_MAT_DB", name);
                    t203.Type = (int)Common.TagType.External;
                    t203.DataType = (int)Common.DataType.Bool;
                    t203.Address = string.Format("{0}.M67", address);
                    t203.UpdateRating = 1000;
                    t203.IsStoreToLog = false;
                    AlarmTag alarm8 = new AlarmTag();
                    alarm8.Name = string.Format("{0}.E_MAT_DB", name);
                    alarm8.Type = (int)AlarmType.Digital;
                    alarm8.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm8.IsActive = true;
                    alarm8.UpdateRating = 1000;
                    alarm8.Value = (int)AlarmValue.Null;
                    alarm8.IOTag = t203;
                    dev.IOTags.Add(t203);

                    IOTag t204 = new IOTag();
                    t204.Name = string.Format("{0}.E_CD_B", name);
                    t204.Type = (int)Common.TagType.External;
                    t204.DataType = (int)Common.DataType.Bool;
                    t204.Address = string.Format("{0}.M68", address);
                    t204.UpdateRating = 1000;
                    t204.IsStoreToLog = false;
                    AlarmTag alarm9 = new AlarmTag();
                    alarm9.Name = string.Format("{0}.E_CD_B", name);
                    alarm9.Type = (int)AlarmType.Digital;
                    alarm9.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm9.IsActive = true;
                    alarm9.UpdateRating = 1000;
                    alarm9.Value = (int)AlarmValue.Null;
                    alarm9.IOTag = t204;
                    dev.IOTags.Add(t204);

                    IOTag t205 = new IOTag();
                    t205.Name = string.Format("{0}.E_CT_B", name);
                    t205.Type = (int)Common.TagType.External;
                    t205.DataType = (int)Common.DataType.Bool;
                    t205.Address = string.Format("{0}.M69", address);
                    t205.UpdateRating = 1000;
                    t205.IsStoreToLog = false;
                    AlarmTag alarm10 = new AlarmTag();
                    alarm10.Name = string.Format("{0}.E_CT_B", name);
                    alarm10.Type = (int)AlarmType.Digital;
                    alarm10.AlarmOnWhen = (int)AlarmOnWhen.True;
                    alarm10.IsActive = true;
                    alarm10.UpdateRating = 1000;
                    alarm10.Value = (int)AlarmValue.Null;
                    alarm10.IOTag = t205;
                    dev.IOTags.Add(t205);

                    IOTag t206 = new IOTag();
                    t206.Name = string.Format("{0}.ERR", name);
                    t206.Type = (int)Common.TagType.External;
                    t206.DataType = (int)Common.DataType.Bool;
                    t206.Address = string.Format("{0}.M70", address);
                    t206.UpdateRating = 1000;
                    t206.IsStoreToLog = false;
                    dev.IOTags.Add(t206);

                    IOTag t207 = new IOTag();
                    t207.Name = string.Format("{0}.ERR_CODE", name);
                    t207.Type = (int)Common.TagType.External;
                    t207.DataType = (int)Common.DataType.Int32;
                    t207.Address = string.Format("{0}.D72", address);
                    t207.UpdateRating = 1000;
                    t207.IsStoreToLog = false;
                    dev.IOTags.Add(t207);


                    #endregion

                    #endregion
                }

                res = SubmitToDatabase(db);
            }
            return res;
        }

        public static bool UpdateDevice(string oldName, string name, int port, string driver, string note, string address)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Device dev = (from q in db.Devices
                              where q.Name == oldName
                              select q).FirstOrDefault();
                if (dev != null)
                {
                    dev.Name = name;
                    dev.Port = port;
                    dev.Driver = driver;
                    dev.Note = note;

                    #region modify tagName
                    if (name != oldName)
                    {
                        foreach (IOTag tag in dev.IOTags.ToList())
                        {
                            int index = tag.Name.IndexOf(".");
                            if (index > -1)
                            {
                                tag.Name = name + tag.Name.Substring(index);
                            }
                        }
                    }
                    #endregion

                    #region modify tagAddress
                    if (dev.Address != address)
                    {
                        dev.Address = address;
                        if (dev.Driver == Common.DriverType.OPC.ToString())
                        {
                            foreach (IOTag tag in dev.IOTags.ToList())
                            {
                                int index = tag.Address.LastIndexOf(".");
                                if (index > -1)
                                {
                                    tag.Address = address + tag.Address.Substring(index);
                                }
                            }
                        }
                    }
                    #endregion

                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool DeleteDevice(string name)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Device dev = (from q in db.Devices
                              where q.Name == name
                              select q).FirstOrDefault();
                if (dev != null)
                {
                    db.Devices.DeleteObject(dev);
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static List<Device> GetDevices()
        {
            List<Device> res = new List<Device>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                res = db.Devices.Include("IOTags").ToList();
            }
            return res;
        }

        public static List<Device> GetDevices(bool isVDKDevice)
        {
            List<Device> res = new List<Device>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                if (isVDKDevice == true)
                {
                    string vdk = Common.DriverType.VDK.ToString();
                    var query = from q in db.Devices
                                where q.Driver == vdk
                                select q;
                    res = query.ToList();
                }
                else
                {
                    string opc = Common.DriverType.OPC.ToString();
                    var query = from q in db.Devices
                                where q.Driver == opc
                                select q;
                    res = query.ToList();
                }
            }
            return res;
        }

        public static Device GetDevice(string name)
        {
            Device res = null;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.Devices
                             where q.Name == name
                             select q).FirstOrDefault();
                res = query;
            }
            return res;

        }

        public static List<int> GetPortListForVDK()
        {
            List<int> res = new List<int>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                foreach (Device dev in db.Devices.ToList())
                {
                    if ((dev.Driver == Common.DriverType.VDK.ToString()) && (!res.Contains((int)dev.Port)))
                    {
                        res.Add((int)dev.Port);
                    }
                }
            }
            return res;
        }
        #endregion

        #region IO Tag
        public static bool AddCommonTag()
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {

            }
            return res;
        }

        private static bool CheckIsExistingTagName(string ioTagName)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.IOTags
                             where q.Name == ioTagName
                             select q).FirstOrDefault();
                if (query != null)
                {
                    res = true;
                }
            }
            return res;
        }

        public static bool AddIOTag(string name, int type, int dataType, string addr, int updateRate, string deviceName, string note, bool isStoreToLog)
        {
            bool res = false;
            if (CheckIsExistingTagName(name) == false)
            {
                using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
                {
                    Device dev = (from q in db.Devices
                                  where q.Name == deviceName
                                  select q).FirstOrDefault();
                    if (dev != null)
                    {
                        IOTag ioTag = new IOTag();
                        ioTag.Name = name;
                        ioTag.Type = type;
                        ioTag.DataType = dataType;
                        ioTag.Address = addr;
                        ioTag.UpdateRating = updateRate;
                        ioTag.Note = note;
                        ioTag.IsStoreToLog = isStoreToLog;
                        dev.IOTags.Add(ioTag);
                        res = SubmitToDatabase(db);
                    }
                }
            }
            return res;
        }

        public static bool UpdateIOTag(string oldName, string name, int type, int dataType, string addr, int updateRate, string deviceName, string note, bool isStoreToLog)
        {
            bool res = false;
            if ((oldName == name) || (CheckIsExistingTagName(name) == false))
            {
                using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
                {
                    IOTag ioTag = (from q in db.IOTags
                                   where q.Name == oldName
                                   select q).FirstOrDefault();
                    if (ioTag != null)
                    {
                        ioTag.Name = name;
                        ioTag.Type = type;
                        ioTag.DataType = dataType;
                        ioTag.Address = addr;
                        ioTag.UpdateRating = updateRate;
                        ioTag.Note = note;
                        ioTag.IsStoreToLog = isStoreToLog;

                        Device dev = (from q in db.Devices
                                      where q.Name == deviceName
                                      select q).FirstOrDefault();
                        if (dev != null)
                        {
                            if (!dev.IOTags.Contains(ioTag))
                            {
                                dev.IOTags.Add(ioTag);
                            }
                        }
                        res = SubmitToDatabase(db);
                    }
                }
            }
            return res;
        }

        public static bool DeleteIOTag(string name)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                IOTag ioTag = (from q in db.IOTags
                               where q.Name == name
                               select q).FirstOrDefault();
                if (ioTag != null)
                {
                    db.IOTags.DeleteObject(ioTag);
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static List<IOTag> GetIOTags()
        {
            List<IOTag> res = new List<IOTag>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = db.IOTags.Include("Device");
                query.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                //   db.Detach(query);
                res = query.ToList();
            }
            return res;
        }

        public static List<IOTag> GetIOTags(string deviceName)
        {
            List<IOTag> res = new List<IOTag>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.IOTags.Include("Device")
                            where q.Device.Name == deviceName
                            select q;

                res = query.ToList();
            }
            return res;
        }

        public static IOTag GetIOTag(string ioTagName)
        {
            IOTag res = null;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.IOTags.Include("Device")
                             where q.Name == ioTagName
                             select q).FirstOrDefault();
                res = query;
            }
            return res;
        }

        public static List<IOTagValue> GetIOTagValue(string ioTagName, DateTime dateFrom, DateTime dateTo)
        {
            List<IOTagValue> res = new List<IOTagValue>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.IOTagValues
                            where (q.IOTag.Name == ioTagName) && (q.TimeStamp >= dateFrom) && (q.TimeStamp <= dateTo)
                            select q;

                res = query.ToList();
            }
            return res;
        }

        public static bool UpdateValueForIOTag(string deviceName, string ioTagName, object value, DateTime timeStamp, int quality)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                IOTag iotag = (from q in db.IOTags
                               where (q.Name == ioTagName) && (q.Device.Name == deviceName)
                               select q).FirstOrDefault();
                if ((iotag != null) && (value != null))
                {
                    if (iotag.IsStoreToLog == true)
                    {
                        if (iotag.Value != value.ToString())
                        {
                            timeStamp = DateTime.Now;
                            iotag.Value = value.ToString();
                            iotag.TimeStamp = timeStamp;
                            iotag.Quality = quality;

                            IOTagValue newValue = new IOTagValue();
                            newValue.Value = value.ToString();
                            newValue.TimeStamp = timeStamp;
                            newValue.Quality = quality;
                            iotag.IOTagValues.Add(newValue);

                            res = SubmitToDatabase(db);
                        }
                    }
                }
            }
            return res;
        }

        public static Dictionary<string, List<IOTag>> GetTagGroups()
        {
            Dictionary<string, List<IOTag>> res = new Dictionary<string, List<IOTag>>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                db.IOTags.MergeOption = System.Data.Objects.MergeOption.OverwriteChanges;
                foreach (Device dev in db.Devices.ToList())
                {
                    List<IOTag> tags = dev.IOTags.ToList();
                    foreach (IOTag tag in tags)
                    {
                        string groupName = string.Format("{0}.{1}", dev.Name, tag.UpdateRating);
                        if (!res.ContainsKey(groupName))
                        {
                            res.Add(groupName, new List<IOTag>());
                        }
                        res[groupName].Add(tag);

                    }
                }
            }
            return res;
        }

        public static List<string> GetLineTags()
        {
            List<string> res = new List<string>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.IOTags
                            where (q.Address.Contains("line") && !q.Address.Contains("linedata"))
                            select q;
                foreach (IOTag tag in query.ToList())
                {
                    res.Add(tag.Name);
                }
            }
            return res;
        }
        #endregion

        #region event
        public static bool AddEvent(string deviceName, int ID, int SubID, DateTime time, int parameter, string description, string detail, string priority)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Device dev = (from q in db.Devices
                              where q.Name == deviceName
                              select q).FirstOrDefault();
                if (dev != null)
                {
                    SystemEvent evt = new SystemEvent();
                    evt.EventID = ID;
                    evt.EventSubID = SubID;
                    evt.Time = time;
                    evt.Parameter = parameter;
                    evt.Description = description;
                    evt.Detail = detail;
                    evt.Priority = priority;
                    evt.IsConfirm = false;
                    dev.SystemEvents.Add(evt);
                    res = SubmitToDatabase(db);
                }

            }
            return res;
        }

        public static bool ConfirmEvent(int ID)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.SystemEvents
                             where q.ID == ID
                             select q).FirstOrDefault();
                if (query != null)
                {
                    query.IsConfirm = true;
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        static public bool ConfirmEvent(BindingSource bs)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                for (int j = 0; j < bs.Count; j++)
                {
                    SystemEvent sys = bs[j] as SystemEvent;
                    if (sys != null)
                    {
                        if (sys.IsConfirm == true)
                        {
                            SystemEvent query = (from q in db.SystemEvents
                                                 where (q.ID == sys.ID)
                                                 select q).FirstOrDefault();
                            query.IsConfirm = true;
                        }
                    }
                }
                res = SubmitToDatabase(db);
            }
            return res;
        }

        public static BindingSource GetDeviceEvent(string deviceName, bool[] condition, DateTime fromDate, DateTime toDate)
        {
            // condition byte : 
            // confirm | not confirm | warning | less critical | critical
            BindingSource res = new BindingSource();
            bool confirm = condition[0];
            bool notConfirm = condition[1];
            bool warning = condition[2];
            bool lessCritical = condition[3];
            bool Critical = condition[4];
            bool isIncludeTime = condition[5];

            bool checkConfirm = true;
            if ((confirm == false) && (notConfirm == false)) checkConfirm = false;

            bool checkPriority = true;
            if ((warning == false) && (lessCritical == false) && (Critical == false)) checkPriority = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.SystemEvents
                            where ((q.Device.Name == deviceName)
                            && (checkConfirm ? (q.IsConfirm == confirm) || (q.IsConfirm != notConfirm) : true)
                            && (isIncludeTime ? ((q.Time >= fromDate) && (q.Time <= toDate)) : true)
                            && (checkPriority ? ((warning ? q.Priority == "Lỗi không nghiêm trọng" : false) ||
                                 (lessCritical ? q.Priority == "Lỗi ít nghiêm trọng" : false) ||
                                 (Critical ? q.Priority == "Lỗi nghiêm trọng" : false)) : true)
                            && (q.Priority != ""))
                            select q;
                res.DataSource = query.ToList();
            }
            return res;
        }

        static public BindingSource GetDeviceEvent(string deviceName, bool[] condition)
        {
            // condition byte : 
            // confirm | not confirm | warning | less critical | critical
            BindingSource res = new BindingSource();
            bool confirm = condition[0];
            bool notConfirm = condition[1];
            bool warning = condition[2];
            bool lessCritical = condition[3];
            bool Critical = condition[4];

            bool checkConfirm = true;
            if ((confirm == false) && (notConfirm == false)) checkConfirm = false;

            bool checkPriority = true;
            if ((warning == false) && (lessCritical == false) && (Critical == false)) checkPriority = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.SystemEvents
                            where ((q.Device.Name == deviceName)
                            && (checkConfirm ? (q.IsConfirm == confirm) || (q.IsConfirm != notConfirm) : true)
                            && (checkPriority ? ((warning ? q.Priority == "Lỗi không nghiêm trọng" : false) ||
                                 (lessCritical ? q.Priority == "Lỗi ít nghiêm trọng" : false) ||
                                 (Critical ? q.Priority == "Lỗi nghiêm trọng" : false)) : true))
                            select q;
                res.DataSource = query.ToList();
            }
            return res;
        }
        #endregion

        #region user
        private static string _CurrentUser = "";

        public static User Login(string userName, string pass)
        {
            User res = null;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                User query = (from q in db.Users.Include("UserRights")
                              where (q.Name == userName) && (q.Password == pass)
                              select q).FirstOrDefault();
                if (query != null)
                {
                    res = query;
                    _CurrentUser = query.Name;
                }
            }
            return res;
        }
        public static bool AddNewUser(string userName, string pass, List<int> userRight)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                User user = new User();
                user.Name = userName;
                user.Password = pass;

                for (int j = 0; j < userRight.Count; j++)
                {
                    UserRight right = new UserRight();
                    right.Privilege = userRight[j];
                    user.UserRights.Add(right);
                }

                db.Users.AddObject(user);
                res = SubmitToDatabase(db);
            }
            return res;
        }
        public static bool ChangePassword(string userName, string oldPass, string newPass)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                User query = (from q in db.Users
                              where q.Name == userName
                              select q).FirstOrDefault();
                if (query != null)
                {
                    if (query.Password == oldPass)
                    {
                        query.Password = newPass;
                        res = SubmitToDatabase(db);
                    }
                }
            }
            return res;
        }
        public static bool DeleteUser(string userName)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                User query = (from q in db.Users
                              where q.Name == userName
                              select q).FirstOrDefault();
                if (query != null)
                {
                    db.Users.DeleteObject(query);
                    res = SubmitToDatabase(db);
                }
            }

            return res;
        }
        public static List<int> GetUserRight(string userName, string pass)
        {
            List<int> res = new List<int>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                User query = (from q in db.Users
                              where (q.Name == userName) && (q.Password == pass)
                              select q).FirstOrDefault();
                if (query != null)
                {
                    foreach (UserRight right in query.UserRights.ToList())
                    {
                        res.Add((int)right.Privilege);
                    }
                }
            }
            return res;
        }
        public static bool UpdateUserRights(string userName, List<int> rights)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.UserRights
                             where q.User.Name == userName
                             select q);
                foreach (UserRight right in query.ToList())
                {
                    db.UserRights.DeleteObject(right);
                }

                var query1 = (from q in db.Users
                              where q.Name == userName
                              select q).FirstOrDefault();
                if (query1 != null)
                {
                    for (int j = 0; j < rights.Count; j++)
                    {
                        UserRight rite = new UserRight();
                        rite.Privilege = rights[j];
                        query1.UserRights.Add(rite);
                    }
                }
                res = SubmitToDatabase(db);
            }
            return res;
        }

        public static List<User> GetUserList()
        {
            List<User> res = new List<User>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                res = db.Users.ToList();
            }
            return res;
        }

        private static bool AddUserAction(string action, string description)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = (from q in db.Users
                             where q.Name == _CurrentUser
                             select q).FirstOrDefault();
                if (query != null)
                {
                    //UserAction ua = new UserAction();
                    //ua.Action = action;
                    //ua.Description = description;
                    //ua.Time = DateTime.Now;
                    //query.UserActions.Add(ua);
                    //res = SubmitToDatabase(db);
                }
            }

            return res;
        }
        //public static List<UserAction> GetUserActionList()
        //{
        //    List<UserAction> res = new List<UserAction>();
        //    using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
        //    {
        //        res = db.UserActions.Include("User").ToList();
        //    }
        //    return res;
        //}


        #endregion

        #region alarm
        public static bool AddAlarmTag(string name, AlarmType type, AlarmOnWhen alarmOnWhen, int updateRating)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                AlarmTag tag = new AlarmTag();
                tag.Name = name;
                tag.Type = (int)type;
                tag.AlarmOnWhen = (int)alarmOnWhen;
                tag.UpdateRating = updateRating;
                db.AlarmTags.AddObject(tag);
                res = SubmitToDatabase(db);

            }
            return res;
        }

        public static bool UpdateAlarmTag(int id, string name, AlarmType type, AlarmOnWhen alarmOnWhen, int updateRating)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                AlarmTag tag = (from q in db.AlarmTags
                                where q.Id == id
                                select q).FirstOrDefault();
                if (tag != null)
                {
                    tag.Name = name;
                    tag.Type = (int)type;
                    tag.AlarmOnWhen = (int)alarmOnWhen;
                    tag.UpdateRating = updateRating;
                    db.AlarmTags.AddObject(tag);
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool DeleteAlarmTag(int id)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                AlarmTag tag = (from q in db.AlarmTags
                                where q.Id == id
                                select q).FirstOrDefault();
                if (tag != null)
                {
                    db.AlarmTags.DeleteObject(tag);
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static AlarmTag GetAlarmTag(int id)
        {
            AlarmTag res = null;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                res = (from q in db.AlarmTags.Include("IOTag.Device")
                       where q.Id == id
                       select q).FirstOrDefault();

            }
            return res;
        }

        public static List<AlarmTag> GetAlarmTags()
        {
            List<AlarmTag> res = new List<AlarmTag>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                res = db.AlarmTags.ToList();
            }
            return res;
        }

        public static Dictionary<string, List<AlarmTag>> GetAlarmTagGroups()
        {
            Dictionary<string, List<AlarmTag>> res = new Dictionary<string, List<AlarmTag>>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                foreach (Device dev in db.Devices.ToList())
                {
                    List<AlarmTag> tags = (from q in db.AlarmTags.Include("IOTag.Device").Include("AlarmTagValues")
                                           where q.IOTag.Device.Name == dev.Name
                                           select q).ToList();
                    foreach (AlarmTag tag in tags)
                    {
                        string groupName = string.Format("{0}.{1}", dev.Name, tag.UpdateRating);
                        if (!res.ContainsKey(groupName))
                        {
                            res.Add(groupName, new List<AlarmTag>());
                        }
                        res[groupName].Add(tag);
                    }
                }
            }
            return res;
        }

        public static bool UpdateAlarmTagValue(int id, AlarmValue data, DateTime timeStamp, AlarmStatus status)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                AlarmTag tag = (from q in db.AlarmTags
                                where q.Id == id
                                select q).FirstOrDefault();
                if (tag != null)
                {
                    tag.TimeStamp = timeStamp;
                    tag.Value = (int)data;

                    if (status == AlarmStatus.Incomming) // incoming alarm
                    {
                        AlarmTagValue newAlarm = new AlarmTagValue();
                        newAlarm.Value = (int)data;
                        newAlarm.TimeStampOn = timeStamp;
                        newAlarm.Status = (int)AlarmStatus.Incomming;
                        tag.AlarmTagValues.Add(newAlarm);
                    }
                    else if (status == AlarmStatus.Confirmed) // confirmed alarm
                    {
                        AlarmTagValue current = tag.AlarmTagValues.LastOrDefault();
                        if (current != null)
                        {
                            current.Status = (int)status;
                        }
                    }
                    else // outgoing alarm
                    {
                        AlarmTagValue current = tag.AlarmTagValues.LastOrDefault();
                        if (current != null)
                        {
                            current.Value = (int)data;
                            current.TimeStampOff = (DateTime)tag.TimeStamp;
                            current.Status = (int)status;
                        }
                    }

                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool ConfirmAlarm(int id)
        {
            bool res = false;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                AlarmTag tag = (from q in db.AlarmTags
                                where q.Id == id
                                select q).FirstOrDefault();
                if (tag != null)
                {
                    AlarmTagValue current = tag.AlarmTagValues.LastOrDefault();
                    if (current != null)
                    {
                        current.Status = (int)AlarmStatus.Confirmed;
                        res = SubmitToDatabase(db);
                    }
                }
            }
            return res;
        }

        public static List<AlarmTagValue> GetIncomingAlarms()
        {
            List<AlarmTagValue> res = new List<AlarmTagValue>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.AlarmTagValues.Include("AlarmTag.IOTag.Device")
                            where (q.Status == (int)AlarmStatus.Incomming)
                            select q;
                res = query.ToList();
            }
            return res;
        }

        public static List<AlarmTagValue> GetConfirmedAlarms()
        {
            List<AlarmTagValue> res = new List<AlarmTagValue>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.AlarmTagValues.Include("AlarmTag.IOTag.Device")
                            where (q.Status == (int)AlarmStatus.Confirmed)
                            select q;
                res = query.ToList();
            }
            return res;
        }

        public static List<AlarmTagValue> GetAlarms(DateTime fromDate, DateTime toDate, string deviceName = "")
        {
            List<AlarmTagValue> res = new List<AlarmTagValue>();
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                var query = from q in db.AlarmTagValues.Include("AlarmTag.IOTag.Device")
                            where (q.TimeStampOn >= fromDate.Date) && (q.TimeStampOn <= toDate.Date)
                            select q;
                if (deviceName != null)
                {
                    var query1 = from q in query
                                 where q.AlarmTag.IOTag.Device.Name == deviceName
                                 select q;
                    res = query1.ToList();
                }
                else // get all
                {
                    res = query.ToList();
                }

            }
            return res;
        }

        public static AlarmTagValue GetCurrentAlarm()
        {
            AlarmTagValue res = null;
            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                res = db.AlarmTagValues.Include("AlarmTag.IOTag.Device").OrderByDescending(q => q.Id).FirstOrDefault();
                if (res != null)
                {
                    if (res.Status != (int)AlarmStatus.Incomming) res = null;
                }
            }
            return res;
        }

        #endregion

        #region trend
        private static List<byte> ReadDataFromFile(string path)
        {
            List<byte> res = new List<byte>();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    res.Add((byte)sr.Read());
                }
            }
            return res;
        }

        private static void WriteDataToFile(string path, List<byte> data)
        {
            StreamWriter sw = new StreamWriter(path, false);
            for (int j = 0; j < data.Count; j++)
            {
                sw.Write((char)data[j]);
            }
            sw.Close();
        }

        private static void ReadLineFile(string deviceName)
        {
            object data = null;
            string tagName = string.Format("{0}.Eeprom.4", deviceName);
            string tagAddress = Program.GetDisplayTagAddress(tagName);
            if (Program.GetIOTag(tagName, tagAddress, null, out data))
            {
                List<byte> rawData = ((List<byte>)data);
                if (rawData != null)
                {
                    string path = string.Format(@"{0}\{1}\line.cfg", Application.StartupPath, deviceName);
                    WriteDataToFile(path, rawData);
                }
            }

        }

        private static Dictionary<int, IODriver.LineHardware> GetVDKHardwareLines(string deviceName)
        {
            Dictionary<int, IODriver.LineHardware> res = new Dictionary<int, IODriver.LineHardware>();

            string path = string.Format(@"{0}\{1}\line.cfg", Application.StartupPath, deviceName);
            if (!File.Exists(path))
            {
                ReadLineFile(deviceName);
            }

            if (File.Exists(path))
            {
                List<byte> rawData = ReadDataFromFile(path);
                if ((rawData != null) && (rawData.Count > 0))
                {
                    int numberOfline = rawData[0];
                    int offset = 1;
                    for (int j = 0; j < numberOfline; j++)
                    {
                        IODriver.LineHardware line = new IODriver.LineHardware();
                        line.LineID = rawData[offset];
                        line.Type = (IODriver.LightType)rawData[offset + 1];
                        line.CardID = rawData[offset + 2];
                        line.GreenLightPositionInPowerCard = rawData[offset + 3];
                        line.MonitorState = rawData[offset + 4];
                        line.LenthOfYellowTime = (int)BitConverter.ToInt16(rawData.ToArray(), offset + 6);
                        if (!res.ContainsKey(line.LineID))
                        {
                            res.Add(line.LineID, null);
                        }
                        res[line.LineID] = line;
                        offset += 8;
                    }
                }
            }

            return res;
        }

        public static Dictionary<int, List<IOTag>> GetLines(string deviceName)
        {
            Dictionary<int, List<IOTag>> res = new Dictionary<int, List<IOTag>>();


            using (SapScadaDatabaseEntities db = new SapScadaDatabaseEntities())
            {
                Device dev = (from q in db.Devices
                              where q.Name == deviceName
                              select q).FirstOrDefault();
                if (dev != null)
                {
                    if (dev.Driver == "VDK")
                    {
                        Dictionary<int, IODriver.LineHardware> hardwareLines = GetVDKHardwareLines(deviceName);
                        foreach (int id in hardwareLines.Keys)
                        {

                            switch (hardwareLines[id].Type)
                            {
                                case IODriver.LightType.FullLine:
                                case IODriver.LightType.ThreeColorLight:
                                    res.Add(hardwareLines[id].LineID, new List<IOTag>());
                                    for (int j = 0; j < 3; j++)
                                    {
                                        string ioTagName = string.Format("{0}.OutputControl.{1}.{2}", deviceName, hardwareLines[id].CardID, hardwareLines[id].GreenLightPositionInPowerCard + j);
                                        IOTag ioTag = DBAccess.GetIOTag(ioTagName);
                                        res[hardwareLines[id].LineID].Add(ioTag);
                                    }
                                    break;
                                case IODriver.LightType.PedestrianLight:
                                    res.Add(hardwareLines[id].LineID, new List<IOTag>());
                                    for (int j = 0; j < 2; j++)
                                    {
                                        string ioTagName = string.Format("{0}.OutputControl.{1}.{2}", deviceName, hardwareLines[id].CardID, hardwareLines[id].GreenLightPositionInPowerCard + j);
                                        IOTag ioTag = DBAccess.GetIOTag(ioTagName);
                                        res[hardwareLines[id].LineID].Add(ioTag);
                                    }
                                    break;
                            }
                        }
                    }
                    else // OPC
                    {
                        string ioTagName = string.Format("{0}.XA_Q", deviceName);
                        IOTag green1 = DBAccess.GetIOTag(ioTagName);

                        ioTagName = string.Format("{0}.VA_Q", deviceName);
                        IOTag yellow1 = DBAccess.GetIOTag(ioTagName);

                        ioTagName = string.Format("{0}.DA_Q", deviceName);
                        IOTag red1 = DBAccess.GetIOTag(ioTagName);

                        ioTagName = string.Format("{0}.XB_Q", deviceName);
                        IOTag green2 = DBAccess.GetIOTag(ioTagName);

                        ioTagName = string.Format("{0}.VB_Q", deviceName);
                        IOTag yellow2 = DBAccess.GetIOTag(ioTagName);

                        ioTagName = string.Format("{0}.DB_Q", deviceName);
                        IOTag red2 = DBAccess.GetIOTag(ioTagName);

                        res.Add(0, new List<IOTag>() { green1, yellow1, red1 });
                        res.Add(1, new List<IOTag>() { green2, yellow2, red2 });
                    }
                }

            }

            return res;
        }


        #endregion
    }
}
