using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleRESTServer.Models;
using MySql.Data;

namespace SimpleRESTServer
{ 
     public class PersonPersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection con;

        public PersonPersistence()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=8A7b6c5d!;database=restfuldb";
            try
            {
                con = new MySql.Data.MySqlClient.MySqlConnection();
                con.ConnectionString = myConnectionString;
                con.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }

        public Person getPerson(long ID)
        {
            Person p = new Person();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM employeetb WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, con);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                p.ID = mySqlReader.GetInt32(0);
                p.firstName = mySqlReader.GetString(1);
                p.lastName = mySqlReader.GetString(2);
                p.payRate = mySqlReader.GetFloat(3);
                p.startDate = mySqlReader.GetDateTime(4);
                p.endDate = mySqlReader.GetDateTime(5);
                return p;
            }
            else return null;
        }

        public long savePerson(Person personToSave)
        {
            String sqlString = "INSERT INTO employeetb (firstName, lastName, payRate, startDate, endDate) VALUES ('" + personToSave.firstName + "','" + personToSave.lastName + "'," + personToSave.payRate + ",'" + personToSave.startDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + personToSave.endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, con);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }
    }
}