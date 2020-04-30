using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDatabase
{
    class User
    {

        public string Name { get; set; }
        public string Username {get; set;}
        public int Rights { get; }

        //constructor
        public User() { } // default



        public User(string usernames, string name, int rights)
        {
            this.Username = usernames;
            this.Name = name;
            this.Rights = rights;
            
        }

    }
}
