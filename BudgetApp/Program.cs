using System;
using System.Collections.Generic;

namespace BudgetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Greeting the user
            Console.WriteLine("Welcome to your budget.");

            var viewer = new ConsoleBudgetViewer(new NonsenseBudgetRepository());

            bool isRunning = true;

            while (isRunning)
            {
                var otherOptions = new List<Option>
                {
                    new Option("Other option 1", () => Console.WriteLine("You selected other option 1")),
                    new Option("other option 2", () => Console.WriteLine("You selected other option 2"))
                };

                var otherOptionList = new OptionsList(otherOptions);

                var options = new List<Option>()
                {
                    new Option("View your budget", () => viewer.ViewBudget()),
                    new Option("Edit your budget", () => viewer.EditBudget()),
                    new Option("See more options", () => otherOptionList.ListOptions()),
                    new Option("Quit", () => isRunning = false)
                };

                var optionList = new OptionsList(options);

                optionList.ListOptions();
            }
        }
    }
}
