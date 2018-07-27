using System;
using System.Data;

namespace PocketMoney.BLL
{
    public class AccountCollection : BLLBaseCollection<Account>
    {
        public static AccountCollection GetAll()
        {
            AccountCollection obj = new AccountCollection();
            DataSet ds = new DAL.Accounts().GetAll();
            obj.MapObjects(ds);
            return obj;
        }
    }
}
