using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

namespace Identity.Models
{
    public class Navbar
    {
        public int Id { get; set; }
        public string name { get; set; }

        public List<Navbar> navbar { get; set; }

        //public List<Navbar> ListFun()
        //{
        //    string query = "SELECT * FROM navbar";
        //    using (SqlConnection connection = new SqlConnection("Data Source=ZEESHANN-LAP\\SQLEXPRESS;Initial Catalog=Identity; Integrated Security=True;TrustServerCertificate=True"))
        //    {
        //        // Create a SqlDataAdapter object
        //        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

        //        // Create a DataTable to hold the data
        //        DataTable dataTable = new DataTable();

        //        try
        //        {
        //            // Fill the DataTable with data from the database
        //            adapter.Fill(dataTable);

        //            // Check if the DataTable has any rows
        //            if (dataTable.Rows.Count > 0)
        //            {
        //                // Process the data (e.g., print it to the console)
        //                foreach (DataRow row in dataTable.Rows)
        //                {
        //                    int id = (int)row["Id"];
        //                    string name = (string)row["Name"];

        //                    Console.WriteLine($"Id: {id}, Name: {name}");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("No rows found.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle any errors that may have occurred
        //            Console.WriteLine(ex.Message);
        //        }
        //    }

        //}
    }
}
