using System;

namespace BudgetApp
{
    public class Option
    {
        public string OptionText { get; set; }

        public Action Action { get; set; }

        public Option(string optionText, Action action)
        {
            OptionText = optionText;
            Action = action;
        }
    }
}
