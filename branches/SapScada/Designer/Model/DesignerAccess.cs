using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;

using System.Windows.Forms;
using System.Data;
using HDSComponent;


namespace Designer.Model
{
    public enum LightType
    {
        VehicleGreen,
        VehicleYellow,
        VehicleRed,
        PedestrianRed,
        PedestrianGreen,
        ArrowRedAhead,
        ArrowRedBack,
        ArrowRedLeft,
        ArrowRedRight,
        ArrowYellowAhead,
        ArrowYellowBack,
        ArrowYellowLeft,
        ArrowYellowRight,
        ArrowGreenAhead,
        ArrowGreenBack,
        ArrowGreenLeft,
        ArrowGreenRight
    }

    public static class DesignerAccess
    {
        private static string _JunctionPath = @"Model\Junction.xml";

        public static void CreateJunctionDoc()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lee's xml"),
                new XElement("Junctions")
                );
            doc.Save(_JunctionPath);
        }

        public static bool SubmitToDatabase(DesignerDatabaseEntities db)
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
                res = true;
            }
            catch (Exception ex)
            {
                string info = ex.Message;
                if (ex.InnerException != null)
                {
                    info += "\r\n" + ex.InnerException;
                }
                MessageHandler.Error(info);
            }
            return res;
        }

        #region junction
        public static bool AddJunction(string name, double lat, double lng, string tag, string expression, string map, string note)
        {
            bool res = false;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Junction junc = new Junction();
                junc.JunctionName = name;
                junc.Lat = lat;
                junc.Lng = lng;
                junc.Tag = tag;
                junc.Expression = expression;
                junc.Map = map;
                junc.Note = note;
                db.Junctions.AddObject(junc);
                res = SubmitToDatabase(db);
            }
            return res;
        }

        public static bool UpdateJunction(string name, Junction junc)
        {
            bool res = false;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Junction query = (from q in db.Junctions
                                  where q.JunctionName == name
                                  select q).FirstOrDefault();
                if (junc != null)
                {
                    query.JunctionName = junc.JunctionName;
                    query.Lat = junc.Lat;
                    query.Lng = junc.Lng;
                    query.Tag = junc.Tag;
                    query.Expression = junc.Expression;
                    query.Map = junc.Map;
                    query.Note = junc.Note;
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool SetMap(string name, string map)
        {
            bool res = false;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Junction junc = (from q in db.Junctions
                                 where q.JunctionName == name
                                 select q).FirstOrDefault();
                if (junc != null)
                {
                    junc.Map = map;
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool DeleteJunction(string name)
        {
            bool res = false;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Junction junc = (from q in db.Junctions
                                 where q.JunctionName == name
                                 select q).FirstOrDefault();
                if (junc != null)
                {
                    db.Junctions.DeleteObject(junc);
                    res = SubmitToDatabase(db);
                }
            }
            return res;

        }

        public static Junction GetJunction(string name)
        {
            Junction res = null;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Junction junc = (from q in db.Junctions.Include("Lamps")
                                 where q.JunctionName == name
                                 select q).FirstOrDefault();
                res = junc;
            }
            return res;
        }

        public static List<Junction> GetJunctions()
        {
            List<Junction> res = new List<Junction>();
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                res = db.Junctions.Include("Lamps").ToList();
            }
            return res;
        }
        #endregion

        #region lamp
        public static bool AddLamp(string junctionName, int lampID, int x, int y, int direction, string tag, string expression, int type, string note, out Lamp lamp)
        {
            bool res = false;
            lamp = null;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Junction junc = (from q in db.Junctions
                                 where q.JunctionName == junctionName
                                 select q).FirstOrDefault();
                if (junc != null)
                {
                    lamp = new Lamp();
                    lamp.LampID = lampID;
                    lamp.X = x;
                    lamp.Y = y;
                    lamp.Direction = direction;
                    lamp.Tag = tag;
                    lamp.Expression = expression;
                    lamp.Type = type;
                    lamp.Note = note;
                    junc.Lamps.Add(lamp);
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool UpdateLamp(int ID, Lamp lamp)
        {
            bool res = false;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Lamp query = (from q in db.Lamps
                              where q.ID == ID
                              select q).FirstOrDefault();
                if ((lamp != null) && (query != null))
                {
                    query.LampID = lamp.LampID;
                    query.X = lamp.X;
                    query.Y = lamp.Y;
                    query.Direction = lamp.Direction;
                    query.Tag = lamp.Tag;
                    query.Expression = lamp.Expression;
                    query.Type = lamp.Type;
                    query.Note = lamp.Note;
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool UpdateLamp(int Id, int X, int Y)
        {
            bool res = false;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Lamp query = (from q in db.Lamps
                              where q.ID == Id
                              select q).FirstOrDefault();
                if (query != null)
                {
                    query.X = X;
                    query.Y = Y;
                    res = SubmitToDatabase(db);
                }
            }
            return res;
        }

        public static bool DeleteLamp(int ID)
        {
            bool res = false;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Lamp query = (from q in db.Lamps
                              where (q.ID == ID)
                              select q).FirstOrDefault();
                if (query != null)
                {
                    db.Lamps.DeleteObject(query);
                    res = SubmitToDatabase(db);
                }
            }
            return res;

        }

        public static Lamp GetLamp(string junctionName, int lampID)
        {
            Lamp res = null;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Lamp query = (from q in db.Lamps.Include("Junction")
                              where (q.LampID == lampID) && (q.Junction.JunctionName == junctionName)
                              select q).FirstOrDefault();
                res = query;
            }
            return res;
        }

        public static Lamp GetLamp(int Id)
        {
            Lamp res = null;
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                Lamp query = (from q in db.Lamps.Include("Junction")
                              where (q.ID == Id)
                              select q).FirstOrDefault();
                res = query;
            }
            return res;
        }


        public static List<Lamp> GetLamps(string junctionName)
        {
            List<Lamp> res = new List<Lamp>();
            using (DesignerDatabaseEntities db = new DesignerDatabaseEntities())
            {
                var query = from q in db.Lamps.Include("Junction")
                            where q.Junction.JunctionName == junctionName
                            select q;
                res = query.ToList();
            }
            return res;
        }
        #endregion
    }
}
