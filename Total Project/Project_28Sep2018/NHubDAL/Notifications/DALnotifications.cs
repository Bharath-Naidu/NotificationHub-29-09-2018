using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHubDAL.Notifications
{
    public class SubscribeDetails
    {
        public int id { get; set; }
        public int Eventid { get; set; }
        public int ServiceLineid { get; set; }
        public int ServiceLineManagerid { get; set; }

    }
    public class DataType
    {
        public int id { get; set; }
        public String Name { get; set; }
    }
    public class ClassSources
    {
        public int Sid { get; set; }
        public String SName { get; set; }
    }
    public class Services
    {
        public int Serid { get; set; }
        public String SerName { get; set; }
    }
    public class ServiceLineManagers
    {
        public int SLMid { get; set; }
        public int SLid { get; set; }
        public String Uid { get; set; }
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

    public class Users
    {
        public String Username { get; set; }
        public String UserId { get; set; }
    }
    public class SubscribedUsers
    {
        public int Id { get; set; }
        public String UserId { get; set; }
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
                        int value = Convert.ToInt32(myDataReader["ChannelId"]);
                        Chaid[c] = value;
                        c++;
                        //Console.WriteLine(Chaid[c]);
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
        //------------------------------------get user name----------------------------------------
        public List<Users> GetUsers()
        {
            List<Users> ListOfUsers = new List<Users>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                string sql = "Select UserName,Id from AspNetUsers";
                SqlCommand myCommand = new SqlCommand(sql, connection);
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        ListOfUsers.Add(new Users
                        {
                            UserId = myDataReader["id"].ToString(),
                            Username = myDataReader["UserName"].ToString(),

                    });
                    }
                }

            }

            return ListOfUsers;
        }
        //---------------------------------------List service Line manager -----------------------------------
        public List<ServiceLineManagers> getServiceLineManagers(String id)
        {
            List<ServiceLineManagers> EL = new List<ServiceLineManagers>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                string sql = "Select * from ServiceLineManager";
                SqlCommand myCommand = new SqlCommand(sql, connection);
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        EL.Add(new ServiceLineManagers
                        {
                            SLMid = Convert.ToInt32(myDataReader["Id"].ToString()),
                            SLid = Convert.ToInt32(myDataReader["ServiceLineId"].ToString()),
                            Uid = myDataReader["UserId"].ToString(),
                        });
                    }
                }
            }
            return EL;
        }
       // ---------------------------------------Event subscribe -----------------------------------
        public int SubscribeEvent(int Eventid,int SLId,int SLMId,bool Confidential,bool Mandatory)
        {
            int LastModifiredid;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("SubscribeEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pr = new SqlParameter();
                cmd.Parameters.AddWithValue("@Eid", Eventid);
                cmd.Parameters.AddWithValue("@Sid", SLId);
                cmd.Parameters.AddWithValue("@SMid", SLMId);
                cmd.Parameters.AddWithValue("@con", Confidential);
                cmd.Parameters.AddWithValue("@man", Mandatory);
                
                pr.Direction = ParameterDirection.Output;
                pr.SqlDbType = SqlDbType.Int;
                pr.Value = 0;
                pr.ParameterName = "@id";
                cmd.Parameters.Add(pr);
                object obj=cmd.ExecuteNonQuery();

                LastModifiredid = Convert.ToInt32(cmd.Parameters["@id"].Value.ToString());
            }
            return LastModifiredid;
        }
        //----------------------------------------Update the subscribed Event-----------------------------------
        public void UpdateSubscribedList(int id,int Eventid, int SLId, int SLMId, bool Confidential, bool Mandatory)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("SubscribeEvent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pr = new SqlParameter();
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Eid", Eventid);
                cmd.Parameters.AddWithValue("@Sid", SLId);
                cmd.Parameters.AddWithValue("@SMid", SLMId);
                cmd.Parameters.AddWithValue("@con", Confidential);
                cmd.Parameters.AddWithValue("@man", Mandatory);
                cmd.ExecuteNonQuery();
            }   
        }
        // ---------------------------------------get sources -----------------------------------
        public List<Services> getServices()
        {
            List<Services> EL = new List<Services>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                string sql = "Select * from ServiceLine";
                SqlCommand myCommand = new SqlCommand(sql, connection);
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        EL.Add(new Services
                        {
                            Serid= Convert.ToInt32(myDataReader["Id"].ToString()),
                            SerName = myDataReader["Name"].ToString()
                        });
                    }
                }
            }
            return EL;
        }
        //--------------------------------Insert in Event_slm_subscribe_channel-------------------------
        public void SubscribeChannels(int EventSubscribeID,int ChannelID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();

                SqlCommand cmd = new SqlCommand("SubscribeChannel", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ESSid", EventSubscribeID);
                cmd.Parameters.AddWithValue("@Cid", ChannelID);
                cmd.ExecuteNonQuery();
            }
        }
        //---------------------------------------insert in Event_slm_subscribe_users------------------------------
        public void SubscribeUsers(String Uname,int id)
        {
            
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                

                SqlCommand cmd = new SqlCommand("SubscribeUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Unam", Uname);
                cmd.Parameters.AddWithValue("@ESSid", id);
                cmd.ExecuteNonQuery();
            }
           
        }
        //---------------------------------------insert in Event_slm_subscribe_users------------------------------
        public void UpdateDataTypes(DataType DT)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateDatatypes", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", DT.id);
                cmd.Parameters.AddWithValue("@Name", DT.Name);
                cmd.ExecuteNonQuery();
            }

        }
        //-------------------------------------get channels from Event Subscribe data------------------------------
        public int[] GetChannelsFromSubscribedList(int EventSLMid)
        {
            int[] Chaid = new int[10];
            int c = 0;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                string sql = "Select ChannelId from Event_slm_subscribe_channel where Event_slm_subscribe_Id=" + EventSLMid;
                SqlCommand myCommand = new SqlCommand(sql, connection);
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        int value = Convert.ToInt32(myDataReader["ChannelId"]);
                        Chaid[c] = value;
                        c++;
                        //Console.WriteLine(Chaid[c]);
                    }
                }

            }

            return Chaid;
        }
        //-------------------------------------Get Subscriberd data------------------------------------
        public SubscribeDetails GetSubscribedData(int id)
        {
            SubscribeDetails details = new SubscribeDetails();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetSubscribedData", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    details.id =Convert.ToInt32( reader["Id"].ToString());
                    details.Eventid= Convert.ToInt32(reader["EventId"].ToString());
                    details.ServiceLineid = Convert.ToInt32(reader["ServiceLineId"].ToString());
                    details.ServiceLineManagerid = Convert.ToInt32(reader["ServiceLineManagerId"].ToString());
                }
            }
            return details;
        }
        //----------------------------------Get subscribed End Users------------------------------------
        public List<SubscribedUsers> GetSubscribedUsersList(int id)
        {
            List<SubscribedUsers> Users = new List<SubscribedUsers>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetSubscribedUsers", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                {
                        Users.Add(new SubscribedUsers
                        {
                            Id = Convert.ToInt32(reader["Event_slm_subscribe_Id"].ToString()),
                            UserId = reader["UserId"].ToString()
                    });
                }
            }
            return Users;
        }
        public void UpdatesEvents(int id)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=ACUPC-111;Initial Catalog=NotificationHub;Integrated Security=True";
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateSubscribed", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }

        }

    }
}



