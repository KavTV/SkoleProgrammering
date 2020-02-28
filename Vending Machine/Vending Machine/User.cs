using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class User
    {
        int money; // users money to spend on the machine

        private List<Product> userProducts = new List<Product>(); // users inventory
        #region get/set
        public int Money { get { return money; } set { money = value; } }
        internal List<Product> UserProducts { get => userProducts; set => userProducts = value; }
        #endregion

        public User(int money) //Constructor
        {
            Money = money;
        }

        public void GetUserInventory() // shows what is in the users inventory
        {
            Console.WriteLine("------------------");
            if (userProducts.Count == 0)
            {
                Console.WriteLine("Du har ikke købt nogen ting");
            }
            else
            {

                foreach (var item in userProducts)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.WriteLine("------------------");
        }


    }
}
