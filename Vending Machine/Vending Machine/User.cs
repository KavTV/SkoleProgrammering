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

        private List<Product> userProducts = new List<Product>();
        #region get/set
        public int Money { get { return money; } set { money = value; } }
        internal List<Product> UserProducts { get => userProducts; set => userProducts = value; }
        #endregion

        public User(int money)
        {
            Money = money;
        }




    }
}
