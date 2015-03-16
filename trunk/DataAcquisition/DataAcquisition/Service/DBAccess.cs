using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

using DataAcquisition.Model;
using DataAcquisition.Model.Entities;
using System.Data;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using DataAcquisition.Repositories;

namespace DataAcquisition.Service
{
    public static class DBAccess
    {
        public static bool SubmitToDatabase(DataAcquisitionDbContext db)
        {
            bool res = false;
            try
            {
                db.SaveChanges();
                res = true;

            }
            catch (OptimisticConcurrencyException)
            {
                //  db.Refresh(System.Data.Objects.RefreshMode.ClientWins, db);
                //  db.SaveChanges();
            }
            catch (Exception ex)
            {
                string info = ex.Message;
                if (ex.InnerException != null)
                {
                    info += "\r\n" + ex.InnerException;
                }
                // MessageHandler.Error(info);
            }
            return res;
        }

        public static ServiceInfo GetServiceInfo()
        {
            ServiceInfo res = null;
            IRepository<ServiceInfo> service = new Repository<ServiceInfo>(new DataAcquisitionDbContext());
            res = service.Table.FirstOrDefault();
            return res;
        }
        public static int UpdateServiceInfo(string serverIP, int vdkServicePort, int opcServicePort)
        {
            int res = -1;
            IRepository<ServiceInfo> service = new Repository<ServiceInfo>(new DataAcquisitionDbContext());

            ServiceInfo info;

            if (service.Table.Count() == 0)
            {
                info = new ServiceInfo();
                info.ServerIP = serverIP;
                info.VDKServicePort = vdkServicePort;
                info.OPCServicePort = opcServicePort;
                service.Insert(info);
            }
            else
            {
                info = service.Table.FirstOrDefault();
                if(info != null)
                {
                    info.ServerIP = serverIP;
                    info.VDKServicePort = vdkServicePort;
                    info.OPCServicePort = opcServicePort;
                }
                service.Update(info);
            }
            res = service.SaveChanges();

            return res;
        }

        public static List<Port> GetPorts(DriverType type)
        {
            List<Port> res = new List<Port>();
            IRepository<Port> port = new Repository<Port>(new DataAcquisitionDbContext());
            res = port.Get(q => q.DriverType == type).ToList();
            return res;
        }

        public static Port AddPort(DriverType type, int port)
        {
            int res = -1;
            IRepository<Port> newPort = new Repository<Port>(new DataAcquisitionDbContext());

            Port p = new Port();
            p.DriverType = type;
            p.DriverPort = port;

            newPort.Insert(p);
            res = newPort.SaveChanges();
            if (res == -1)
            {
                p = null;
            }
            return p;
        }

        public static int DeletePort(int id)
        {
            int res = -1;
            IRepository<Port> newPort = new Repository<Port>(new DataAcquisitionDbContext());

            newPort.Delete(id);
            res = newPort.SaveChanges();

            return res;
        }
    }
}
