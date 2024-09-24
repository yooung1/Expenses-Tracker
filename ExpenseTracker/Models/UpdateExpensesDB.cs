using System.Data.SQLite;

namespace ExpenseTracker.Models
{
    public class UpdateExpensesDB
    {
        public static void UpdateExpenseDB(Expense expense)
        {
            string connectionString = "Data Source=C:\\Users\\Young1\\source\\repos\\ExpenseTracker\\ExpenseTracker\\DataBase\\DataBase.db;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Expenses SET Item = @Item, Value = @Value, PaymentMethod = @PaymentMethod, Description = @Description WHERE Id = @Id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Item", expense.Item);
                    cmd.Parameters.AddWithValue("@Value", expense.Value);
                    cmd.Parameters.AddWithValue("@PaymentMethod", expense.PaymentMethod);
                    cmd.Parameters.AddWithValue("@Description", expense.Description);
                    cmd.Parameters.AddWithValue("@Id", expense.Id);

                    cmd.ExecuteNonQuery(); // Executa o comando
                }
            }
        }
    }
}
