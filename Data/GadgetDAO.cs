using Basic_CRUD_App_James_Bond_Gadgets_.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Basic_CRUD_App_James_Bond_Gadgets_.Data
{
    internal class GadgetDAO
    {
        private string connectionString = @"";


        public List<GadgetModel> FetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQurey ="SELECT * from dbo.Gadgets";

                SqlCommand command = new SqlCommand(sqlQurey,connection);

                connection.Open();

                SqlDataReader reader= command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel gadget = new GadgetModel() {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            AppearsIn = reader.GetString(3),
                            WithThisActor = reader.GetString(4)
                           
                        };

                        returnList.Add(gadget);
                    }
                }

            }

            return returnList;
        }

        public int Delete(int id)
        {
            GadgetModel gadget = new GadgetModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQurey = "DELETE FROM dbo.Gadgets WHERE Id = @Id";
              

                SqlCommand command = new SqlCommand(sqlQurey, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value =id;
               

                connection.Open();

                int deletedId = command.ExecuteNonQuery();


                return deletedId;

            }
        }

        internal List<GadgetModel> SearchForName(string searchPhrase)
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQurey = "SELECT * from dbo.Gadgets WHERE NAME LIKE @searchForME";

                SqlCommand command = new SqlCommand(sqlQurey, connection);

                command.Parameters.Add("@searchForME",System.Data.SqlDbType.VarChar).Value="%"+searchPhrase+"%";

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel gadget = new GadgetModel()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            AppearsIn = reader.GetString(3),
                            WithThisActor = reader.GetString(4)

                        };

                        returnList.Add(gadget);
                    }
                }
                return returnList;
            }
        }

        public GadgetModel FetchOne(int Id)
        {
            GadgetModel gadget = new GadgetModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQurey = "SELECT * from dbo.Gadgets WHERE Id=@id";
                //@id == a paraméter Id-val

                SqlCommand command = new SqlCommand(sqlQurey, connection);
                command.Parameters.Add("@id",System.Data.SqlDbType.Int).Value=Id;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
               
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                    }
                }

            }

            return gadget;
        }


        public int CreateOrUpdate(GadgetModel gadgetModel)
        {
            // ha a gadgetmodel.id <= 1 akkor create

            // ha a gadgetmodel.id > 1 akkor update
            GadgetModel gadget = new GadgetModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQurey="";
                if(gadgetModel.Id<=0)
                {
                    sqlQurey = "INSERT INTO dbo.Gadgets Values(@Name, @Description, @AppearsIn, @WithThisActor)";
                }
                else
                {
                    sqlQurey = "UPDATE dbo.Gadgets SET Name = @Name, Description = @Description, AppearsIn = @AppearsIn, WithThisActor = @WithThisActor WHERE Id = @id";
                }
               

                SqlCommand command = new SqlCommand(sqlQurey, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar,1000).Value =gadgetModel.Name ;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = gadgetModel.WithThisActor;

                connection.Open();

                int newId=command.ExecuteNonQuery();


                return newId;

            }

            
        }
    }
}