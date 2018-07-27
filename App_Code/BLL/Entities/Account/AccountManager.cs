using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PocketMoney.BLL
{ 
    public class AccountManager
    {
        public static void ManageAllowances()
        {

            AccountCollection accounts = AccountCollection.GetAll();

            foreach (Account acc in accounts)
            {
                DateTime dtTemp = new DateTime(2018, 7, 20);

                while (dtTemp <= DateTime.Now.Date)
                {
                    if (acc.Transactions.Find(delegate (Transaction t) { return t.Description == "Daily Allowance" && t.Timestamp.Date == dtTemp.Date; }) == null)
                    {
                        Transaction trans = new Transaction();
                        trans.AccountId = acc.Id;
                        trans.Description = "Daily Allowance";
                        trans.Amount = acc.DailyAllowance;
                        trans.Timestamp = dtTemp;
                        trans.Save();
                    }
                    dtTemp = dtTemp.AddDays(1);
                }
            }


            // sleep thread 
            Thread.Sleep(GetIntervalInMilliseconds(1));

            ManageAllowances();
        }

        private static int GetIntervalInMilliseconds(int minutes)
        {
            return minutes * 60 * 1000;
        }

    }
}