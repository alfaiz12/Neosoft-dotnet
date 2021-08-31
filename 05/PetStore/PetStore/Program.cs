﻿using System;
using PetLib;
using System.Data.SqlClient;
using PetDataADO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;

namespace PetStore
{
    class Program
    {
        static void Main(string[] args) // entry point
        {
            /*var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appSettings.json")
                .Build();

            string conString = config.GetConnectionString("PetDb");
            GetCatsDisconnected(conString);*/
            /*
             GetCats(conString);

             Console.Write("PLease enter the Id of the cat whose name is to be changed ");
             int id = Int32.Parse(Console.ReadLine());
             Console.Write("Please enter the updated name of the cat ");
             string name = Console.ReadLine();
             UpdatCatName(conString, id, name);
             GetCats(conString);*/

            Console.Write("PLease enter the Id of the cat which you want to delete ");
            int id = Int32.Parse(Console.ReadLine());
            string s = @"Data Source=DESKTOP-NOPJF0S\SQLEXPRESS;Initial Catalog=petDB;Integrated Security=True";
            DeleteCatId(s,id);

            // delete by cat name 
            Console.WriteLine("Enter Cat name which you want to delete");
            string conn = "Server=tcp:nspdatabase.database.windows.net,1433;Initial Catalog=PetDb;Persist Security Info=False;User ID=nomaan;Password=Computers123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            string name = Console.ReadLine();
            deleteCatName(conn, name);
        }

        private static void GetCats(string conString, string query= "SELECT Id, Name from Cats")
        {
            SqlConnection connection;
            //2. Fire Sql Command
            SqlCommand command;
            //3. Execute command and get results
            SqlDataReader reader;
            try
            {
                ConnectedArchitecture.GetAllCats(conString, query, out connection, out command, out reader);
            }
            catch (SqlException)
            {
                throw;
            }
        }
        private static void UpdatCatName(string conStr, int id, string name)
        {
            SqlConnection connection;
            SqlCommand command;
            ConnectedArchitecture.UpdateCatNameById(conStr, out connection, out command, id, name);

        }

        private static void DeleteCatId(string conStr, int id)
        {
            SqlConnection connection;
            SqlCommand command;
            ConnectedArchitecture.DeleteCatById(conStr, out connection, out command, id);

        }
         
        // delete cat by name
        private static void deleteCatName(string conStr, string name)
        {
            SqlConnection connection;
            SqlCommand command;
            ConnectedArchitecture.deleteCatByName(conStr, out connection, out command, name);

        }

        private static void GetCatsDisconnected(string conStr, string query="select Id, Name from Cats") {
            SqlConnection connection;
            SqlDataAdapter adapter;
            DataSet ds;
            var cats=DisconnectedArchitecture.GetCats(conStr, query, out connection, out adapter, out ds);
            foreach (DataRow cat in cats)
            {
                Console.WriteLine($"{cat["Id"]} {cat[1]}");
            }
        }
        /// <summary>
        /// This function takes input from user and print those details in the formatted way
        /// </summary>
        private static PetLib.Cat AddCat()
        {
            Cat pet1=new Cat();            
            Console.Write("Please enter your pet's Id: ");
            pet1.Id = int.Parse(Console.ReadLine());
            Console.Write("\nPlease enter your pet's name: ");
            pet1.Name = Console.ReadLine();
            Console.Write("\nPlease enter your pet's birthday (yyyy/mm/dd): ");
            pet1.Dob = DateTime.Parse(Console.ReadLine());
            Console.Write("\nPlease enter you pet's Gender - press <0> for male and press <1> for female: ");
            byte gender = byte.Parse(Console.ReadLine());
            if (gender == 0)
                pet1.Gender = Gender.Male;
            else if (gender == 1)
                pet1.Gender = Gender.Female;
            else
                Console.Write("Incorrect gender press <0> for male and press <1> for female");
            Console.Write(" Please enter the weight of your cat in pounds ");
            pet1.Weight=Convert.ToDouble(Console.ReadLine());
            pet1.CatType = CatType.Himalayan;
            return pet1;
        }
    }
}
