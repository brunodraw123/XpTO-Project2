using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using System.Data;
using System.Diagnostics;

namespace XpTO.Server.Data
{
    public class Database
    {
        private string ConnectionString = "Server=DESKTOP-2OKIF55;Database=XpTO;User=SA; Password=desenho2002; Encrypt=false";


        private string commandSelectOrder = "select * from  [XpTO].[dbo].[Order]";
        public string commandInsertOrder = "insert into [XpTO].[dbo].[Order] values ([CustomerName],[CustomerMail],[DrinkName],[DrinkValue],[MainFoodName],[MainFoodValue],[DessertName],[DesserValue],[AccompanimentFoodName],[AccompanimentFoodValue],[StatusName],[ReceivedDate],[StatDate],[FinishDate],[OrderType],[TotalValue])";
        public string commandUpdateOrder = "update [XpTO].[dbo].[Order] set [StatusName] = 'Finalizado',  [FinishDate] = #finishDate where OrderId = #ID";

        public DataSet getData()
        {                
            DataSet ds = new DataSet();

            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString)) { 
            
                sqlConnection.Open();
               
                SqlCommand command = new SqlCommand(commandSelectOrder, sqlConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(commandSelectOrder, sqlConnection);
                adapter.Fill(ds);

                sqlConnection.Close();
            }

            return ds;
        }

        public void setData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(commandInsertOrder, sqlConnection);
                command.CommandText = commandInsertOrder;
                command.ExecuteNonQuery();

                sqlConnection.Close();
            }

        }

        public void updateData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(commandUpdateOrder, sqlConnection);
                command.CommandText = commandUpdateOrder;
                command.ExecuteNonQuery();

                sqlConnection.Close();
            }

        }
    }
}
