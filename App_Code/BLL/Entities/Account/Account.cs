using System;
using System.Data;
using System.Threading;

namespace PocketMoney.BLL
{
    [Serializable]
    public class Account : BLL.BLLBaseObject
    {


        #region Fields
        private int _id = Constants.NullInt;
        private string _name = Constants.NullString;
        private decimal _dailyAllowance = Constants.NullDecimal;
        private decimal _balance = Constants.NullInt;
        private TransactionCollection _transactions = null;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public decimal DailyAllowance
        {
            get
            {
                return _dailyAllowance;
            }

            set
            {
                _dailyAllowance = value;
            }
        }

        public decimal Balance
        {
            get
            {
                decimal decBal = 0;

                foreach (Transaction t in Transactions)
                    decBal += t.Amount;

                return decBal;
            }
        }

        public TransactionCollection Transactions
        {
            get
            {
                if (_transactions == null)
                    _transactions = TransactionCollection.GetByAccount(_id);

                return _transactions;
            }
            
        }

        #endregion


        #region Methods
        public override bool MapData(DataRow row)
        {
            _id = GetInt(row, "Id");
            _name = GetString(row, "Name");
            _dailyAllowance = GetDecimal(row, "DailyAllowance");

            return base.MapData(row);
        }

        public static Account GetById(int id)
        {
            
            Account obj = new Account();
            DataSet ds = new DAL.Accounts().GetById(id);

            if (obj.MapData(ds) == false)
                obj = null;

            return obj;
        }

       

        //public void Save()
        //{

        //    System.Data.SqlClient.SqlConnection txnConn = DAL.ProfitRecordings.GetOpenConnection("CryptoTrades");
        //    IDbTransaction Txn = txnConn.BeginTransaction();

        //    try
        //    {
        //        // save alert row changes.
        //        DAL.ProfitRecordings profitRecordings = new DAL.ProfitRecordings();
        //        profitRecordings.Txn = Txn;
        //        profitRecordings.Save(ref _id, _exchange, _currency, _lunoBid, _exchangeAsk, _currencyToZARExchangeRate, _profitPerc,_arbSymblol);

        //        // commit transaction
        //        Txn.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        Txn.Rollback();

        //        throw ex;
        //    }
        //    finally
        //    {
        //        txnConn.Close();
        //        txnConn.Dispose();
        //        Txn.Dispose();
        //    }


        //}


        #endregion
    }
}
