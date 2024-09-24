using System.Data.SQLite;

namespace ExpenseTracker.Models
{
    public static class SeeExpensesDB
    {
        public static List<Expense> seeExpensesDB()
        {
            List<Expense> ListOfExpenses = new List<Expense>();
            string connectionString = "Data Source=C:\\Users\\Young1\\source\\repos\\ExpenseTracker\\ExpenseTracker\\DataBase\\DataBase.db;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Expenses;";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Expense expense = new Expense()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Item = reader["Item"].ToString(),
                                Value = Convert.ToDouble(reader["Value"]),
                                PaymentMethod = reader["PaymentMethod"].ToString(),
                                Description = reader["Description"].ToString()
                            };
                            ListOfExpenses.Add(expense);
                        }
                    }
                }
            }
            return ListOfExpenses;
        }

        public static List<Expense> seeSpecificExpenseDB(int Id)
        {
            List<Expense> ListOfExpenses = new List<Expense>();
            string connectionString = "Data Source=C:\\Users\\Young1\\source\\repos\\ExpenseTracker\\ExpenseTracker\\DataBase\\DataBase.db;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Expenses where Id =" + Id.ToString();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Expense expense = new Expense()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Item = reader["Item"].ToString(),
                                Value = Convert.ToDouble(reader["Value"]),
                                PaymentMethod = reader["PaymentMethod"].ToString(),
                                Description = reader["Description"].ToString()
                            };
                            ListOfExpenses.Add(expense);
                        }
                    }
                }
            }
            return ListOfExpenses;
        }
    }
}
