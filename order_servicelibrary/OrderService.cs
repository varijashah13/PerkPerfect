using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace order_servicelibrary
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class OrderService:Iorder
    {
        public void AddOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Order] (oId,foodName,cId,total) VALUES (@oId,@foodName,@cId,@total)", conn);
                cmd.Parameters.AddWithValue("@oId", order.oId);
                cmd.Parameters.AddWithValue("@foodName", order.foodName);
                cmd.Parameters.AddWithValue("@cId", order.cId);
                cmd.Parameters.AddWithValue("@total", order.total);
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveOrder(int oId)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VARIJA\SQLEXPRESS;Initial Catalog=PerkPerfect;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Order] WHERE oId = @oId", conn);

                cmd.Parameters.AddWithValue("@oId", oId);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
