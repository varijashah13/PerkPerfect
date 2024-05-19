using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chef_servicelibrary
{
    public class ChefService: Ichefservice
    {
        
        DataSet Ichefservice.GetChefs(int chefId)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Chef", @"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void AddChef(Chef chef)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Chef (chefId, Name) VALUES (@chefId, @Name)", conn);
                cmd.Parameters.AddWithValue("@Name", chef.Name);
                cmd.Parameters.AddWithValue("@chefId", chef.chefId);
                cmd.ExecuteNonQuery();
            }



        }

        public Chef GetChef(int chefId)
        {

            

            SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();

            cmd.Connection= conn;
            cmd.CommandText = "SELECT chefId,Name FROM Chef WHERE chefId=@chefId";
            SqlParameter p = new SqlParameter("@chefId", chefId);
            cmd.Parameters.Add(p);
            conn.Open();
            SqlDataReader reader= cmd.ExecuteReader();
            Chef chef= new Chef();
            while(reader.Read())
            {
                chef.chefId = reader.GetInt32(0);
                chef.Name=reader.GetString(1);
            }
            reader.Close();
            conn.Close();
            return chef;




        }

        public void UpdateChef(Chef chef)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Chef SET Name = @Name WHERE chefId = @chefId", conn);
                cmd.Parameters.AddWithValue("@Name", chef.Name);
                cmd.Parameters.AddWithValue("@chefId", chef.chefId);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteChef(int chefId)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Chef WHERE chefId = @chefId", conn);
                cmd.Parameters.AddWithValue("@chefId", chefId);
                cmd.ExecuteNonQuery();
            }

        }



    }
}
