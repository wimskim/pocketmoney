using System;
using System.Data;

namespace PocketMoney.BLL
{
    public class TransactionCollection : BLLBaseCollection<Transaction>
    {
        public static TransactionCollection GetByAccount(int accountId)
        {
            TransactionCollection obj = new TransactionCollection();
            DataSet ds = new DAL.Transactions().GetByAccountId(accountId);
            obj.MapObjects(ds);
            return obj;
        }
        public static TransactionCollection GetByDate(DateTime from, DateTime to)
        {
            TransactionCollection obj = new TransactionCollection();
            DataSet ds = new DAL.Transactions().GetByDate(from, to);
            obj.MapObjects(ds);
            return obj;
        }
    }
}
