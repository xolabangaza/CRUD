using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1_ADO.NET
{
    internal class Program
    {
        public static string connectionString = @"Data Source=DESKTOP-6RT5AA5;Initial Catalog=Company101;Integrated Security=True;Encrypt=False";
        static void Main(string[] args)
        {
            GetAll_Department();
            Update_Department_ById();
            //Delete_Department_ById();
            //GetAll_Department_ById();
            ////Insert_Department();
        }

        private static void Login()
        {
            Console.Write("Enter your PIN: ");
            string pin = Console.ReadLine();
        }
        private static void Update_Department_ById()
        {
            Console.WriteLine("Enter DepartmentID to update");
            int DepId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new DepartmentName of the given DepartmentID");
            string DepartmentName = Console.ReadLine();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE Department SET DepartmentName = @DepartmentName WHERE DepID = @DepId", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@DepId", DepId);
            cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);

            con.Open();
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("One record is updated");
                Console.WriteLine("*****************************************");

            }
            else
            {
                Console.WriteLine("No record updated");
                Console.WriteLine("*****************************************");
            }
            GetAll_Department();
            con.Close();
        }
        private static void Delete_Department_ById()
        {
            Console.WriteLine("ENTER DepId to delete");
            int DepId = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Department WHERE DepId= @DepId", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@DepId", DepId);
            con.Open();
             int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("One record is deleted");
                Console.WriteLine("*****************************************");
                GetAll_Department();

            }
            else
            {
                Console.WriteLine("No record deleted");
                Console.WriteLine("*****************************************");
            }
            con.Close();
        }
        private static void GetAll_Department_ById()
        {
            Console.WriteLine("ENTER DepId");
            int DepId = int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Department WHERE DepId= @DepId", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@DepId",DepId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Console.WriteLine("Dep Id " + dr[0].ToString());
                    //Console.WriteLine("DepartmentName " + dr[1].ToString());
                    //Console.WriteLine("CreateDate " + dr[2].ToString());
                    //Console.WriteLine("********************************************");

                    Console.WriteLine("Dep Id " + dr["DepId"].ToString());
                    Console.WriteLine("DepartmentName " + dr["DepartmentName"].ToString());
                    Console.WriteLine("CreateDate " + dr["CreateDate"].ToString());
                    Console.WriteLine("********************************************");

                }
            }
            else
            {
                Console.WriteLine("No records found");
            }
            con.Close();
        }

        private static void GetAll_Department()
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Department", con);
         
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Console.WriteLine("Dep Id " + dr[0].ToString());
                    //Console.WriteLine("DepartmentName " + dr[1].ToString());
                    //Console.WriteLine("CreateDate " + dr[2].ToString());
                    //Console.WriteLine("********************************************");

                    Console.WriteLine("Dep Id: " + dr["DepId"].ToString());
                    Console.WriteLine("DepartmentName: " + dr["DepartmentName"].ToString());
                    Console.WriteLine("CreateDate: " + dr["CreateDate"].ToString());
                    Console.WriteLine("********************************************");

                }
            }
            con.Close();
        }
        private static void Insert_Department()
        {
            Console.WriteLine("Enter the department name ");
            string DepartmentName = Console.ReadLine();
            Console.WriteLine();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO Department (DepartmentName) VALUES (@DepartmentName)", conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
            {
                Console.WriteLine("One record inserted");
            }
        }
    }
}
