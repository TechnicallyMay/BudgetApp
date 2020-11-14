using System;

namespace BudgetApp
{
    public class ConsoleBudgetViewer
    {
        private IBudgetRepository m_budgetRepository;

        public ConsoleBudgetViewer(IBudgetRepository budgetRepository)
        {
            m_budgetRepository = budgetRepository;
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
                    m_budgetRepository.Add(newBudget);
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
            decimal budget = m_budgetRepository.Get();

            Console.WriteLine($"You have {budget:C} left in your budget.");
            Console.WriteLine();
        }
    }
}
