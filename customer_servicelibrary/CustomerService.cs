using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace customer_servicelibrary
{
    public class CustomerService:Icustomerservice
    {

        DataSet Icustomerservice.GetCustomerIds()
        {
            SqlDataAdapter da= new SqlDataAdapter("Select cId from Customer", @"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer (cId,cName,cPhone) VALUES (@cId,@cName,@cPhone)", conn);
                cmd.Parameters.AddWithValue("@cId", customer.cId);
                cmd.Parameters.AddWithValue("@cName", customer.cName);
                cmd.Parameters.AddWithValue("@cPhone", customer.cPhone);
                cmd.ExecuteNonQuery();
            }
        }

        public Customer GetCustomer(int cId)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "SELECT cId,cName,cPhone FROM Customer WHERE cId=@cId";
            SqlParameter p = new SqlParameter("@cId", cId);
            cmd.Parameters.Add(p);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Customer customer = new Customer();
            while (reader.Read())
            {
                customer.cId = reader.GetInt32(0);
                customer.cName = reader.GetString(1);
                customer.cPhone = reader.GetString(2);
            }
            reader.Close();
            conn.Close();
            return customer;



        }

    }
}
