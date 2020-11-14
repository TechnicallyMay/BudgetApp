using System;
using System.Collections.Generic;

namespace BudgetApp
{
    public class OptionsList
    {
        private List<Option> m_options;

        public OptionsList(List<Option> options)
        {
            m_options = options;
        }

        public void ListOptions()
        {
            for (int i = 1; i <= m_options.Count; i++)
            {
                Console.WriteLine($"Option {i}. {m_options[i - 1].OptionText}");
            }

            string input = Console.ReadLine();

            if (int.TryParse(input, out int intInput) && intInput < m_options.Count && intInput > 0)
            {
                    
                var selectedOption = m_options[intInput - 1];
                selectedOption.Action();
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }
    }
}
