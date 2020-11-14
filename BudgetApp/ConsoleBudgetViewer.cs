using Microsoft.Data.Sqlite;
using System;

namespace BudgetApp
{
    public class ConsoleBudgetViewer
    {
        public ConsoleBudgetViewer()
        {
            CreateBudgetTable();
        }

        private void CreateBudgetTable()
        {
            string filePath = @"C:\Users\wheel\CS\Coding Projects\Budget App\BudgetApp\AppData\data.db";
            //Create the file if it doesn't exist
            System.IO.File.AppendText(filePath).Close();

            using (var connection = new SqliteConnection($"Data Source={filePath}"))
            {
                connection.Open();

                var createCommand = connection.CreateCommand();

                //TODO: Create the table before the user tries to view the budget
                createCommand.CommandText = @"CREATE TABLE IF NOT EXISTS budget_totals ( 
                                                budget INTEGER
                                              );";

                createCommand.ExecuteNonQuery();
            }
        }

        public void EditBudget()
        {
            Console.WriteLine("How much would you like your budget to be?");

            bool isValidInput = false;
            while (!isValidInput)
            {
                //TODO: invalid input if there are multiple dollar signs
                //TODO: Not allow too many decimal places
                //TODO: Should we allow different currencies?

                string input = Console.ReadLine().TrimStart('$');

                if (decimal.TryParse(input, out decimal newBudget))
                {
                    WriteBudget(newBudget);
                    isValidInput = true;
                    Console.WriteLine($"Your budget is {newBudget:C}.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }

        public void ViewBudget()
        {
            string filePath = @"C:\Users\wheel\CS\Coding Projects\Budget App\BudgetApp\AppData\data.db";
            System.IO.File.AppendText(filePath).Close();

            decimal budget = 0;
            using (var connection = new SqliteConnection($"Data Source={filePath}"))
            {
                connection.Open();

                var createCommand = connection.CreateCommand();

                createCommand.CommandText = @"SELECT budget
                                              FROM budget_totals";

                using (var reader = createCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        budget = reader.GetDecimal(0);
                    }
                }
            }

            Console.WriteLine($"You have {budget:C} left in your budget.");
            Console.WriteLine();
        }

        private void WriteBudget(decimal budget)
        {
            //TODO: Remove duplicate code
            //TODO: Remove hard-coded filepath
            string filePath = @"C:\Users\wheel\CS\Coding Projects\Budget App\BudgetApp\AppData\data.db";
            System.IO.File.AppendText(filePath).Close();

            using (var connection = new SqliteConnection($"Data Source={filePath}"))
            {
                connection.Open();

                var insertCommand = connection.CreateCommand();
                //TODO: We need to update a budget if it exists - how to identify which row?
                insertCommand.CommandText = @"INSERT INTO budget_totals (budget)
                                              VALUES ($budget)";
                insertCommand.Parameters.AddWithValue("$budget", budget);
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}
