using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADOmodServer
{
    class Program
    {
        static SqlConnection conn = new SqlConnection("Data Source=(local); Initial Catalog=Northwind;  Integrated Security=SSPI");
        static void Main(string[] args)
        {
            //AdoOevelse1();
            //AdoOevelse2();
            //AdoOevelse3();
            RunStoredProc();
            Console.ReadLine();
        }

         static void AdoOevelse1() // Lær hvordan man læser fra database
        {
            
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from Customers", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                //Man kan både bruge index og navnet på colonnen i []
                Console.WriteLine("{0} , {1}",rdr["Customerid"], rdr[1]);
            }
            conn.Close();
        }
        
        static void AdoOevelse2() // Lær at læse,indsætte,opdatere,slette og se hvor mange rows der er.
        {
            ReadData();
            InserData();
            UpdateData();
            DeleteData();
            GetNumberOfRecords();
        }

        static void AdoOevelse3() // SqlParameter
        {
            Console.WriteLine("Skriv byen du vil søge efter");
            string cityinput = Console.ReadLine();

            ParameterTest(cityinput);
        }



        static void ReadData()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select CategoryName from Categories", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("{0} ", rdr[0]);
            }

            conn.Close();
        }

        static void InserData()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Categories(CategoryName, Description) VALUES ('Miscellaneous', 'Whatever')", conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        static void UpdateData()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Categories set CategoryName = 'Other' WHERE CategoryName = 'Miscellaneous'", conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        static void DeleteData()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE from Categories WHERE CategoryName = 'Other'", conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        static void GetNumberOfRecords()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select count(*) from Categories", conn);

            int count = (int)cmd.ExecuteScalar();
            Console.WriteLine("Der er " + count + " Records");
            conn.Close();
        }

        static void ParameterTest(string city)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from Customers WHERE city = @City", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@City";
            param.Value = city;
            cmd.Parameters.Add(param);

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("{0}, {1}", rdr["CompanyName"], rdr["ContactName"]);
            }
            conn.Close();
        }


        // run a simple stored procedure
        public static void RunStoredProc()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            Console.WriteLine("\nTop 10 Most Expensive Products:\n");

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    "Ten Most Expensive Products", conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Console.WriteLine(
                        "Product: {0,-25} Price: ${1,6:####.00}",
                        rdr["TenMostExpensiveProducts"],
                        rdr["UnitPrice"]);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }

        // run a stored procedure that takes a parameter
        public static void RunStoredProcParams()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            // typically obtained from user
            // input, but we take a short cut
            string custId = "FURIB";

            Console.WriteLine("\nCustomer Order History:\n");

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    "CustOrderHist", conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which
                // will be passed to the stored procedure
                cmd.Parameters.Add(
                    new SqlParameter("@CustomerID", custId));

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Console.WriteLine(
                        "Product: {0,-35} Total: {1,2}",
                        rdr["ProductName"],
                        rdr["Total"]);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }



    }
}
