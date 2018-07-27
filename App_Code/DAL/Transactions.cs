using System;
using System.Data;
using System.Data.SqlClient;

namespace PocketMoney.DAL
{
    class Transactions : DAL.DALBase
    {


        //public DataSet GetAll()
        //{
        //    return ExecuteDataSet("PocketMoney", @"Select 
        //                                         a.Id,
        //                                         a.Name,
        //                                         a.DailyAllowance,
        //                                         Sum(t.amount) as Balance
        //                                        From Accounts a
        //                                        LEFT OUTER JOIN Transactions t on t.AccountId = a.id
        //                                        GROUP BY a.Id,a.Name,a.DailyAllowance
        //                                        ORDER BY a.Id", CommandType.Text);
        //}

        public DataSet GetByAccountId(int accountId)
        {
            return ExecuteDataSet("PocketMoney", "SELECT * FROM Transactions WITH (NOLOCK) WHERE AccountId = @AccountId ORDER BY TimeStamp DESC", CommandType.Text,
                CreateParameter("@AccountId", SqlDbType.Int, accountId));
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

            ExecuteNonQuery("CryptoTrades", out cmd, query.ToString(), CommandType.Text,
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
