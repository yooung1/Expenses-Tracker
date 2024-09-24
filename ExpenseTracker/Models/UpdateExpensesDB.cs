using System.Data.SQLite;

namespace ExpenseTracker.Models
{
    public class UpdateExpensesDB
    {
        public void updateExpensesDB()
        {
            string connectionString = "Data Source=C:\\Users\\Young1\\source\\repos\\ExpenseTracker\\ExpenseTracker\\DataBase\\DataBase.db;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                UPDATE Expenses 
                SET Pin = @Pin 
                WHERE CardNum = @CardNum;";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Pin", 123456);
                    cmd.Parameters.AddWithValue("@CardNum", "33333");
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
