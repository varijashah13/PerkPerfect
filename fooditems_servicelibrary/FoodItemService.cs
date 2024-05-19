using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fooditems_servicelibrary
{
    public class FoodItemService: Ifooditemsservice
    {

        //DataSet Ifooditemsservice.GetFoodItems() { 
        DataSet Ifooditemsservice.GetFoodItems() { 
        
            SqlDataAdapter da= new SqlDataAdapter("Select * from FoodItem", @"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;
        
        }
        
        public void AddFoodItem(FoodItem foodItem)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO FoodItem (foodName,price) VALUES (@foodName,@price)", conn);
                cmd.Parameters.AddWithValue("@foodName", foodItem.foodName);
                cmd.Parameters.AddWithValue("@price", foodItem.price);
                cmd.ExecuteNonQuery();
            }
        }

        public FoodItem GetFoodItem(string foodName)
        {



            SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "SELECT foodName,price FROM FoodItem WHERE foodName=@foodName";
            SqlParameter p = new SqlParameter("@foodName", foodName);
            cmd.Parameters.Add(p);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            FoodItem foodItem = new FoodItem();
            while (reader.Read())
            {
                foodItem.foodName = reader.GetString(0);
                foodItem.price = reader.GetString(1);
            }
            reader.Close();
            conn.Close();
            return foodItem;




        }

        public void UpdateFoodItem(FoodItem foodItem)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE FoodItem SET price = @price WHERE foodName = @foodName", conn);
                cmd.Parameters.AddWithValue("@foodName", foodItem.foodName);
                cmd.Parameters.AddWithValue("@price", foodItem.price);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteFoodItem(string foodName)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM FoodItem WHERE foodName = @foodName", conn);
                cmd.Parameters.AddWithValue("@foodName", foodName);
                cmd.ExecuteNonQuery();
            }

        }

        public DataSet GetFoodItems()
        {
            throw new NotImplementedException();
        }
    }
}
