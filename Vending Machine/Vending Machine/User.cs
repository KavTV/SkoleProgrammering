using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class User
    {
        int money;


        public int Money { get { return money; } set { money = value; } }

        public User(int money)
        {
            Money = money;
        }

        List<Product> UserProducts = new List<Product>();



    }
}
