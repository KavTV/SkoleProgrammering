using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace LoginDatabase
{
    class Logic //Logik klasse
    {

        public User Login(string username, string pws)
        {
            bool access = CheckLogin(username, pws);
            if (access == true)
            {
                return GetUserObject(username);
            }
            else
            {
                return null;
            }

        }

        public void CreateUser(string username, string pws, string name)
        {
            //DoStuff

            RegisterUser(username, pws, name);
        }

        public void CreateTable(string tableName, int columns, string[] columnName, string[] columnType)
        {
            var conn = GetConnectionString();
            conn.Open();
            string command = $"CREATE TABLE {tableName}("; // Make start of command string

            SqlCommand cmd = new SqlCommand("", conn);

            for (int i = 0; i < columns; i++)
            {
                command += "[" + columnName[i] + "] " + columnType[i] + ", ";
            }
            command += ")"; // close the CREATE TABLE()
            cmd.CommandText = command;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            conn.Close();
        }

        public void GetTables()
        {
            var conn = GetConnectionString();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", conn);

            SqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
            }
        }

        public void UpdateUserRights(string username, string rights)
        {
            var conn = GetConnectionString();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE User_Table SET Rights = @rights WHERE Username = @username", conn);
            SqlParameter usernameParam = new SqlParameter("@username", username);
            SqlParameter rightsParam = new SqlParameter("@rights", rights);
            cmd.Parameters.Add(usernameParam);
            cmd.Parameters.Add(rightsParam);
            cmd.ExecuteNonQuery();
        }


        private void RegisterUser(string username, string pws, string name) // Puts user info into sql database
        {

            var conn = GetConnectionString();
            conn.Open();
            //Get random id
            SqlCommand cmd = new SqlCommand("select NEWID()", conn);
            var specialId = cmd.ExecuteScalar();

            SqlParameter usernameParam = new SqlParameter();
            SqlParameter passwordParam = new SqlParameter();
            SqlParameter nameParam = new SqlParameter();

            cmd.CommandText = $"INSERT INTO User_Table(Username, Name, GUID, Rights) VALUES(@username, @name,'{specialId}', 3); INSERT INTO Password_Table(GUID, Password) VALUES('{specialId}', @password)";
            //Parameter virker ikke
            usernameParam.ParameterName = "@username";
            usernameParam.Value = username;

            passwordParam.ParameterName = "@password";
            passwordParam.Value = pws;

            nameParam.ParameterName = "@name";
            nameParam.Value = name;
            cmd.Parameters.Add(usernameParam);
            cmd.Parameters.Add(passwordParam);
            cmd.Parameters.Add(nameParam);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        private bool CheckLogin(string username, string pws) // Check credentials
        {
            bool validUsername = IsUsernameTaken(username);
            if (validUsername == true)
            {
                string guid = GetUsernameGuid(username);
                if (guid != null)
                {
                    bool access = CheckPassword(pws, guid);
                    if (access == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string GetUsernameGuid(string username) // Returns a username GUID
        {

            var conn = GetConnectionString();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT GUID from User_Table WHERE Username = @username", conn);
            SqlParameter usernameParam = new SqlParameter();

            usernameParam.ParameterName = "@username";
            usernameParam.Value = username;

            cmd.Parameters.Add(usernameParam);

            var guid = cmd.ExecuteScalar();
            conn.Close();

            return guid.ToString();

        }

        private bool CheckPassword(string pws, string guid) // Check if password matches 
        {
            var conn = GetConnectionString();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(GUID) FROM Password_Table WHERE GUID = @guid AND Password = @password", conn);
            SqlParameter passwordParam = new SqlParameter();
            SqlParameter guidParam = new SqlParameter();

            passwordParam.ParameterName = "@password";
            passwordParam.Value = pws;

            guidParam.ParameterName = "@guid";
            guidParam.Value = guid;

            cmd.Parameters.Add(passwordParam);
            cmd.Parameters.Add(guidParam);

            int answer = (int)cmd.ExecuteScalar();
            conn.Close();
            if (answer == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUsernameTaken(string username) // Check if username is taken
        {
            var conn = GetConnectionString();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(Username) from User_Table WHERE Username = @username", conn);
            SqlParameter usernameParam = new SqlParameter();

            usernameParam.ParameterName = "@username";
            usernameParam.Value = username;

            cmd.Parameters.Add(usernameParam);

            int answer = (int)cmd.ExecuteScalar();
            conn.Close();
            if (answer == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private User GetUserObject(string username)
        {
            var conn = GetConnectionString();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from User_Table WHERE Username = @username", conn);
            SqlParameter usernameParam = new SqlParameter();

            usernameParam.ParameterName = "@username";
            usernameParam.Value = username;

            cmd.Parameters.Add(usernameParam);

            SqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            User user = new User(rdr["Username"].ToString(), rdr["Name"].ToString(), (int)rdr["Rights"]);

            conn.Close();
            return user;
        }






        private SqlConnection GetConnectionString() // Get SqlConnection
        {
            return new SqlConnection("Data Source=(local); Initial Catalog=LoginData;  Integrated Security=SSPI");
        }


        // 1 administrator C - R- W --> C=insert/update/delete/create exec, R = select W, insert 
        // 2 mod R- W
        //3 Guest R
    }
}
