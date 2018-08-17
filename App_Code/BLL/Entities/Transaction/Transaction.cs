using System;
using System.Data;
using System.Threading;

namespace PocketMoney.BLL
{
    [Serializable]
    public class Transaction : BLL.BLLBaseObject
    {
        #region Fields
        private long _id = Constants.NullLong;
        private int _accountId = Constants.NullInt;
        private string _accountName = Constants.NullString;
        private string _description = Constants.NullString;
        private decimal _amount = Constants.NullDecimal;
        private DateTime _timestamp = Constants.NullDateTime;
        public long Id
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

        public int AccountId
        {
            get
            {
                return _accountId;
            }

            set
            {
                _accountId = value;
            }
        }
        public string AccountName
        {
            get
            {
                return _accountName;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                _timestamp = value;
            }
        }

        #endregion

        #region Methods
        public override bool MapData(DataRow row)
        {
            _id = GetLong(row, "Id");
            _accountId = GetInt(row, "AccountId");
            _accountName = GetString(row, "AccountName");
            _description = GetString(row, "Description");
            _amount = GetDecimal(row, "Amount");
            _timestamp = GetDateTime(row, "TimeStamp");

            return base.MapData(row);
        }

        public static Transaction GetById(int id)
        {
            Transaction obj = new Transaction();
            DataSet ds = new DAL.Accounts().GetById(id);

            if (obj.MapData(ds) == false)
                obj = null;

            return obj;
        }



        public void Save()
        {

       
            // save alert row changes.
            DAL.Transactions trans = new DAL.Transactions();

            trans.Save(ref _id, _accountId, _description, _amount, _timestamp);



        }


        #endregion
    }
}
