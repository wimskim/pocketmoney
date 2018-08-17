using System;
using System.Data;
using System.Data.SqlClient;

namespace PocketMoney.DAL
{
    class Transactions : DAL.DALBase
    {

        public DataSet GetByAccountId(int accountId)
        {
            return ExecuteDataSet("PocketMoney", @"SELECT t.*,
                                                    a.Name as AccountName FROM Transactions t WITH (NOLOCK) 
                                                    LEFT JOIN Accounts a on a.Id = t.AccountId
                                                    WHERE t.AccountId = @AccountId ORDER BY t.TimeStamp DESC", CommandType.Text,
                CreateParameter("@AccountId", SqlDbType.Int, accountId));
        }
        public DataSet GetByDate(DateTime from, DateTime to)
        {
            return ExecuteDataSet("PocketMoney", @"SELECT t.*,
                                                    a.Name as AccountName FROM Transactions t WITH (NOLOCK) 
                                                    LEFT JOIN Accounts a on a.Id = t.AccountId
                                                    WHERE t.TimeStamp between @datefrom and @dateto ORDER BY t.TimeStamp DESC", CommandType.Text,
                CreateParameter("@datefrom", SqlDbType.Date, from),
                CreateParameter("@dateto", SqlDbType.Date, to));
        }
        public void Save(ref long id,
                             long accountId,
                             string description,
                             decimal amount,
                             DateTime timestamp
                                )
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();

            SqlCommand cmd = new SqlCommand();
            query.Append(@"BEGIN
    	                            -- Update existing row if it exists else insert new  row
    	                            IF ((SELECT Count(Id) FROM Transactions  WITH (NOLOCK) WHERE Id = @Id) > 0)
    	                            BEGIN
    
    		                            -- update existing  row
    		                            UPDATE 
    			                            [Transactions]
    		                            SET 
                                            
                                            AccountId = @AccountId,
                                            Description = @Description,
                                            Amount = @Amount,
                                            TimeStamp = @TimeStamp

    		                            WHERE 
    			                            [Id]                    = @Id
    	                            END
    	                            ELSE
    	                            BEGIN
    		                            -- insert new row
    		                            INSERT INTO [Transactions]
    			                            (   
                                                
                                                AccountId,
                                                Description,
                                                Amount,
                                                TimeStamp
                                            )
    		                             VALUES
    			                            (
                                                
                                                @AccountId,
                                                @Description,
                                                @Amount,
                                                @TimeStamp
                                            )

    			                            SELECT @Id = @@Identity FROM [Transactions] WITH (NOLOCK) 

    	                            END
                                END");

            ExecuteNonQuery("PocketMoney", out cmd, query.ToString(), CommandType.Text,
                                    CreateParameter("@Id", SqlDbType.BigInt, id, ParameterDirection.InputOutput),
                                    CreateParameter("@AccountId", SqlDbType.Int, (int)accountId, ParameterDirection.InputOutput),
                                    CreateParameter("@Description", SqlDbType.VarChar, description,50, ParameterDirection.InputOutput),
                                    CreateParameter("@Amount", SqlDbType.Decimal, amount, ParameterDirection.InputOutput),
                                    CreateParameter("@TimeStamp", SqlDbType.DateTime, timestamp, ParameterDirection.InputOutput)
                            );

            id = int.Parse(cmd.Parameters["@id"].Value.ToString());
        }


    }
}
