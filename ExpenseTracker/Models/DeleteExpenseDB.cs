using System.Data.SQLite;

namespace ExpenseTracker.Models
{
    public static class DeleteExpenseDB
    {
        public static void deleteExpenseDB(int Id)
        {
            string connectionString = "Data Source=C:\\Users\\Young1\\source\\repos\\ExpenseTracker\\ExpenseTracker\\DataBase\\DataBase.db;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"DELETE FROM Expenses WHERE Id = @Id;";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
