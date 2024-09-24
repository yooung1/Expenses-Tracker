using System.Data.SQLite;

namespace ExpenseTracker.Models
{
    public static class SaveExpensesDB
    {
        public static void saveExpensesDB(string Item, double Value, string PaymentMethod, string Description)
        {
            string connectionString = "Data Source=C:\\Users\\Young1\\source\\repos\\ExpenseTracker\\ExpenseTracker\\DataBase\\DataBase.db;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Expenses (Item, Value, PaymentMethod, Description) VALUES (@Item, @Value, @PaymentMethod, @Description);";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Item", Item);
                    cmd.Parameters.AddWithValue("@Value", Value);
                    cmd.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
