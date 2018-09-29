using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHubDAL.Notifications
{
    public class ClassSources
    {
        public int Sid { get; set; }
        public String SName { get; set; }
    }
    public class ClassEvents
    {
        public int Eid { get; set; }
        public String Ename { get; set; }
        public int Sid { get; set; }
    }
    public class ClassChannels
    {
        public int Cid { get; set; }
        public String CName { get; set; }
    }



    public class DALnotifications
    {

        public List<ClassSources> GetSourceData()
        {
             List<ClassSources> SN = new List<ClassSources>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();

                string sql = "Select * From Source";

                SqlCommand myCommand = new SqlCommand(sql, connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        SN.Add(new ClassSources
                        {
                            Sid = Convert.ToInt32(myDataReader["Id"].ToString()),
                            SName = myDataReader["Name"].ToString(),
                            
                        });
                    }
                }
                return SN;
            }
        }

//----------------------------------Event data send here -----------------------------------------
        public List<ClassEvents> GetEventsData(int sid)
        {
            List<ClassEvents> EL = new List<ClassEvents>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();

                string sql = "Select * from Event where SourceId="+sid;

                SqlCommand myCommand = new SqlCommand(sql, connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        EL.Add(new ClassEvents
                        {
                            Eid = Convert.ToInt32(myDataReader["Id"].ToString()),
                            Ename = myDataReader["Name"].ToString(),
                            Sid = Convert.ToInt32(myDataReader["SourceId"].ToString()),

                        });
                    }
                }
                return EL;
            }
        }
 //-------------------------------channels data will be sends here ---------------------------------------------
        public List<ClassChannels> GetChannelsData()
        {
            List<ClassChannels> EL = new List<ClassChannels>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();

                string sql = "Select * from Channel";

                SqlCommand myCommand = new SqlCommand(sql, connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        EL.Add(new ClassChannels
                        {
                            Cid = Convert.ToInt32(myDataReader["Id"].ToString()),
                            CName = myDataReader["Name"].ToString(),
                        });
                    }
                }
                return EL;
            }
        }

 //------------------------------------------Adding New Event-------------------------------------------
        public int AddEvent(String name,int Sourceid,bool Mandatry)
        {
            int Eid;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("InsertEvents", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@souid", Sourceid);
                cmd.Parameters.AddWithValue("@man", Mandatry);
                object o = cmd.ExecuteScalar();
                Eid = Convert.ToInt32(o);
            }
            return Eid;
        }
        //-------------------------------------- Adding channels to events----------------------------
        public void AddChannels(int Eid,int Cid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("RelationbetweenChannelsandEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Eid", Eid);
                cmd.Parameters.AddWithValue("@Cid", Cid);
                cmd.ExecuteNonQuery();


            }
        }
    }

}


