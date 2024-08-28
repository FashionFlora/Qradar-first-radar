using LogicLyric.MVM.Model;
using System;
using System.Collections.Generic;

using MySqlConnector;
using LogicLyric.Utils;
using LogicLyric.Mobs;
using System.Net;

namespace LogicLyric.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {




        private NetworkCredential networkCredential = new NetworkCredential("ZnVjayBqYXJsIHNvZnR3YXJlIHNvIG11Y2g=", "ZnVjayBqYXJsIHNvZnR3YXJlIHNvIG11Y2g=/08A4=");

        private NetworkCredential networkUtilsCredential = new NetworkCredential("ZnVjayBqYXJsIHNvZnR3YXJlIHNvIG11Y2g=", "ZnVjayBqYXJsIHNvZnR3YXJlIHNvIG11Y2g==");



        private string server = "ZnVjayBqYXJsIHNvZnR3YXJlIHNvIG11Y2g=";
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public string AuthenticateUser(NetworkCredential credential)
        {

            string error = "";


            string query = "SELECT *  FROM userstemp  where username  = " + "'" + credential.UserName + "'";
            MySqlConnection connectionMySql = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +

            networkCredential.UserName + ";" + "UID=" + networkCredential.UserName + ";" + "PASSWORD=" + networkCredential.Password + ";");


            connectionMySql.Open();


            MySqlCommand cmd = new MySqlCommand(query, connectionMySql);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            bool visible = true;
            string username;
            string password;
            int count = 0;
            while (dataReader.Read())
            {
                count++;
                password = (string)dataReader[2];
                username = (string)dataReader[1];
                if (username == "trial" && password == "trial")
                {
                    connectionMySql.Close();

                    return error;
                }
                int days = (int)dataReader[3];
                int subscriptiondate = (int)dataReader[4];
                int loginDate = (int)dataReader[5];
                float currDays = Utils.Utils.getDateSubscration(subscriptiondate);
                float currMins = Utils.Utils.getDateSubscrationSeconds(loginDate);

                if (currDays > days)
                {
                    connectionMySql.Close();

                    error = "Subscription Expired";
                    return error;
                }

                if (currMins <= 1)
                {
                    connectionMySql.Close();
                    error = "Timeout  Wait " + (1 - currMins) + " and  login again";
                    return error;
                }
            }
            dataReader.Close();
            if (count <= 0)
            {
                connectionMySql.Close();
                error = "Invalid Username Or Passowrd";
                return error;
            }


            connectionMySql.Close();
            return error;

        }
        public void AuthenticateUserLoginTime(NetworkCredential credential)
        {



            var baseDate = new DateTime(1970, 01, 01);
            DateTime date = Utils.Utils.GetCurrentTime().DateTime;
            var numberOfSeconds = date.Subtract(baseDate).TotalSeconds;


            string query = "UPDATE userstemp SET logindate = " + "'" + numberOfSeconds + "'" + "  WHERE  username = " + "'" + credential.UserName + "'";
            MySqlConnection connectionMySql = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +
             networkCredential.UserName + ";" + "UID=" + networkCredential.UserName + ";" + "PASSWORD=" + networkCredential.Password + ";");


            connectionMySql.Open();


            MySqlCommand cmd = new MySqlCommand(query, connectionMySql);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
            }
            dataReader.Close();
            connectionMySql.Close();

        }

        public bool AuthenticateUserTimeOut(NetworkCredential credential)
        {





            string query = "SELECT *  FROM userstemp  where username  = " + "'" + credential.UserName + "'";
            MySqlConnection connectionMySql = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +
             networkCredential.UserName + ";" + "UID=" + networkCredential.UserName + ";" + "PASSWORD=" + networkCredential.Password + ";");



            connectionMySql.Open();
            MySqlCommand cmd = new MySqlCommand(query, connectionMySql);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            string username;
            string password;
            int count = 0;
            while (dataReader.Read())
            {
                count = count + 1;
                username = (string)dataReader[1];
                password = (string)dataReader[2];
                if (username == "trial" && password == "trial")
                {
                    connectionMySql.Close();
                    return true;
                }
                if (!username.ToLower().Equals(credential.UserName.ToLower()))
                {
                    connectionMySql.Close();
                    return false;

                }
                if (!password.ToLower().Equals(credential.Password.ToLower()))
                {
                    connectionMySql.Close();
                    return false;
                }
            }
            dataReader.Close();

            if (count <= 0)
            {
                connectionMySql.Close();
                return false;
            }
            connectionMySql.Close();
            return true;


        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserModel GetByUsername(string username)
        {




            string query = "SELECT *  FROM userstemp  where username  = " + "'" + username + "'";
            MySqlConnection connectionMySql = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +
            networkCredential.UserName + ";" + "UID=" + networkCredential.UserName + ";" + "PASSWORD=" + networkCredential.Password + ";");



            connectionMySql.Open();
            MySqlCommand cmd = new MySqlCommand(query, connectionMySql);
            MySqlDataReader dataReader = cmd.ExecuteReader();




            while (dataReader.Read())
            {

                UserModel userModel = new UserModel();
                int days = (int)dataReader[3];
                string username1 = (string)dataReader[1];

                int subscriptiondate = (int)dataReader[4];
                float currDays = Utils.Utils.getDateSubscration(subscriptiondate);
                currDays = days - currDays;
                currDays = (int)currDays;

                userModel.Name = currDays.ToString();
                userModel.Username = username1;
                userModel.Password = (string)dataReader[2];
                userModel.Email = (string)dataReader[1];
                connectionMySql.Close();
                return userModel;

            }

            connectionMySql.Close();
            return null;
        }



        public Dictionary<int, ItemsData> getItems()
        {


            Dictionary<int, ItemsData> keyValues = new Dictionary<int, ItemsData>();
            return keyValues;

            string query = "SELECT *  FROM items";
            MySqlConnection connectionMySql = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +
            networkUtilsCredential.UserName + ";" + "UID=" + networkUtilsCredential.UserName + ";" + "PASSWORD=" + networkUtilsCredential.Password + ";" + "Connection Timeout=120");
            connectionMySql.Open();
            MySqlCommand cmd = new MySqlCommand(query, connectionMySql);
            MySqlDataReader dataReader = cmd.ExecuteReader();



            while (dataReader.Read())
            {
                int id = (int)dataReader[0];
                string name = (string)dataReader[1];


                int dataflag = (int)dataReader[2];

                bool flag = false;

                if (dataflag == 1)
                {
                    flag = true;
                }

                ItemsData itemsData = new ItemsData();

                itemsData.isLoop = flag;
                itemsData.name = name;

                keyValues.Add(id, itemsData);




            }
            connectionMySql.Close();
            return keyValues;


        }





        public Dictionary<int, MobsInfo> getMobs()
        {


            Dictionary<int, MobsInfo> keyValues = new Dictionary<int, MobsInfo>();
            return keyValues;

            string query = "SELECT *  FROM mobs";
            MySqlConnection connectionMySql = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" +
            networkUtilsCredential.UserName + ";" + "UID=" + networkUtilsCredential.UserName + ";" + "PASSWORD=" + networkUtilsCredential.Password + ";");
            connectionMySql.Open();
            MySqlCommand cmd = new MySqlCommand(query, connectionMySql);
            MySqlDataReader dataReader = cmd.ExecuteReader();



            while (dataReader.Read())
            {
                int int0 = (int)dataReader[0];
                int int1 = (int)dataReader[1];
                int int2 = (int)dataReader[2];
                String string0 = (string)dataReader[3];

                MobsInfo itemsData = new MobsInfo();

                itemsData.tier = int1;
                itemsData.type = int2;
                itemsData.localization = string0;


                keyValues.Add(int0, itemsData);




            }
            connectionMySql.Close();
            return keyValues;


        }






        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
