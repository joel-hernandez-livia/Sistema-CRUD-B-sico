﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace Crud_WF_AdoNet
{
    public class PeopleDB
    {
        private string connectionString
            = "Data Source=DESKTOP-FUU6UJ3\\SQLEXPRESS;" +
            "Initial Catalog=CrudWinForm;Integrated Security=True";

        public bool Ok()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch {
                return false;
            }
            return true;
        }

        public List<People> Get()
        {
            List<People> people = new List<People>();

            string query = "select id, name, age from people";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        People oPeople = new People();
                        oPeople.Id = reader.GetInt32(0);
                        oPeople.Name = reader.GetString(1);
                        oPeople.Age = reader.GetInt32(2);

                        people.Add(oPeople);
                    }
                    reader.Close();
                    connection.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la BD " + ex.Message);
                }
            }

                return people;
        }

        public People Get(int? Id)
        {
            

            string query = "select id,name,age from people" +
                " where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                   
                    reader.Read();
                        People oPeople = new People();
                        oPeople.Id = reader.GetInt32(0);
                        oPeople.Name = reader.GetString(1);
                        oPeople.Age = reader.GetInt32(2);

                    reader.Close();
                    connection.Close();
                    return oPeople;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la BD " + ex.Message);
                }
            }

        }

        public void Add(string Name, int Age)
        {
            string query = "insert into people(name, age) values" +
                "(@name, @age)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@age", Age);
                
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                   
                    connection.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la BD " + ex.Message);
                }
            }

        }

        public void Update(string Name, int Age, int Id)
        {
            string query = "update people set name=@name, age=@age" +
                " where id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@age", Age);
                cmd.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    connection.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la BD " + ex.Message);
                }
            }

        }

        public void Delete(int Id)
        {
            string query = "delete from people " +
                " where id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    connection.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la BD " + ex.Message);
                }
            }

        }


    }


    


    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
