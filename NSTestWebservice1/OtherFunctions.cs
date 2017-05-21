using NSTestWebservice1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NSTestWebservice1
{
    public class OtherFunctions
    {

        public void Save(User aUser)
        {

            //CusConnection
            SqlConnection sqlConnection1 =
                new SqlConnection("Data Source=JAHAN;Initial Catalog=temp01DB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [dbo].[User_tb]([Username],[Address],[Email],[Age]) VALUES ('" + aUser.Username + "', '" + aUser.Address + "', '" + aUser.Email + "', '" + aUser.Age + "')";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();



            

        }

        public List<User> GetAll(string aUser)
        {



            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=temp01DB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM [temp01DB].[dbo].[User_tb] where [Username] = '"+aUser+"'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            List<User> userlist = new List<User>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                        User aUserData = new User();
                        aUserData.Username = reader["Username"].ToString();
                        aUserData.Address = reader["Address"].ToString();
                        aUserData.Email = reader["Email"].ToString();
                        aUserData.Age = reader["Age"].ToString();
                        userlist.Add(aUserData);

                    //abc = abc+"-> "+ Convert.ToString(reader["Username"])+"--"+ Convert.ToString(reader["Address"])+" \n";
                    
                    
                }
            }
            
            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();

            return userlist;

        }

        



    }
}