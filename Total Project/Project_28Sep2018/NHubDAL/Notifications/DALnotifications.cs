﻿using System;
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

                string sql = "Select * from Event where SourceId=" + sid;

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
        public int AddEvent(String name, int Sourceid, bool Mandatry)
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
        public void AddChannels(int Eid, int Cid)
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
        //---------------------------------------reading event data based on eid--------------------------
        public List<ClassEvents> GetOneEventdata(int Eid)
        {
            List<ClassEvents> CE = new List<ClassEvents>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                string sql = "Select Name,SourceId from Event where id=" + Eid;
                SqlCommand myCommand = new SqlCommand(sql, connection);
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        CE.Add(new ClassEvents
                        {
                            //Eid=
                            Ename = myDataReader["Name"].ToString(),
                            Sid = Convert.ToInt32(myDataReader["SourceId"].ToString()),

                        });
                    }
                }
                return CE;
            }
        }

        //----------------------------------------get Selected channels data---------------------
        public int[] GetChannelsAndEventData(int Eventid)
        {
            int[] Chaid = new int[10];
                int c=0;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                string sql = "Select ChannelId from EventChannel where EventId=" + Eventid;
                SqlCommand myCommand = new SqlCommand(sql, connection);
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        Chaid[c++] = Convert.ToInt32(myDataReader["ChannelId"]);
                        
                    }
                }

            }
            
            return Chaid;
        }
        //--------------------------------------------Delete an Event ----------------------------------
        public void DeleteEvent(int Eventid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("deleteEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Eid", Eventid);
                cmd.ExecuteNonQuery();
            }
        }
        //--------------------------------------------Update an Event ----------------------------------
        public void UpdateEvent(int Eventid,String name,int Sid,bool b)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
               
                SqlCommand cmd = new SqlCommand("UpdateEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Eventid);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@souid", Sid);
                cmd.Parameters.AddWithValue("@man", b);
                cmd.ExecuteNonQuery();
            }
        }
        //-------------------------------------Update Channels---------------------------------
        public void DeleteChannels(int Eventid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();

                SqlCommand cmd = new SqlCommand("deleteChannels", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Eventid);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateChannels(int Eventid,int Cid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();

                SqlCommand cmd = new SqlCommand("UpdateChannels", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Eventid);
                cmd.Parameters.AddWithValue("@Cid", Cid);
                cmd.ExecuteNonQuery();
            }
        }
    }
}



