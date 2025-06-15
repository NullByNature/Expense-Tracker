using System.IO;

namespace Expense_Tracker
{
    class Program
    {
        List<double> Expenses = new List<double>();
        List<double> Income = new List<double>();
        static void Main()
        {
            Program program = new Program();
            bool run_program = true;
            // Run program while bool stays true 
            do
            {
                Console.WriteLine("1. Add Income\n" +
                    "2. Add Expense\n" +
                    "3. View Transactions\n" +
                    "4. Exit\n" +
                    "Input: ");
                string user_choice = Console.ReadLine();
                // Make sure user input is not empty
                while (string.IsNullOrEmpty(user_choice))
                {
                    Console.WriteLine("Your input can not be blank");
                    user_choice = Console.ReadLine();
                }
                // Switch case for controlling user input 
                switch (user_choice)
                {
                    case "1":
                        program.Add_Income();
                        break;
                    case "2":
                        program.Add_Expense();
                        break;
                    case "3":
                        program.View_transactions();
                        break;
                    case "4":
                        Console.WriteLine("Program closing....");
                        run_program = false;
                        break;
                }
            }while (run_program);
        }
        // Does exactly as it says 
        void Add_Expense()
        {
            string file_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string file_name = "Expenses.txt";
            string combined_location = Path.Combine(file_location, file_name);
            bool keep_adding = true;
            while (keep_adding)
            {
                Console.WriteLine("Enter your expense one expense at a time, if you have more to add you will be able to do so at the end");
                // Expense as a string
                string expense_s = Console.ReadLine();
                // Make sure user input is not blank 
                while (string.IsNullOrEmpty(expense_s))
                {
                    Console.WriteLine("User input can not be blank");
                    expense_s = Console.ReadLine();
                }
                // Conveting user answer to a double for list
                double expense_d = 0;
                // Try statement for catching possible incorrect user input
                try
                {
                    expense_d = Convert.ToDouble(expense_s);
                }
                catch (FormatException e )
                {
                    Console.WriteLine($"Invalid input: {e.Message}");
                }
                // adding expense to expense list 
                Expenses.Add(expense_d);
                Console.WriteLine("Enter the expense description:");
                // Allowing there to be no description 
                string expense_desc = Console.ReadLine();
                Console.WriteLine("Expense added to your list");
                // Check if file already exist, if not then create it 
                if (!File.Exists(combined_location))
                {
                    File.CreateText(combined_location).Close();
                }
                // IO Writing to file 
                using StreamWriter writer = new StreamWriter(combined_location, true);
                writer.WriteLine($"{DateTime.Now.ToString()}");
                writer.WriteLine($"Expense in the amount of {expense_d:$0.00}");
                writer.WriteLine($"Expense description: {expense_desc}");
                writer.WriteLine("---------------------------------------------------");

                Console.WriteLine("Do you have anymore expenses to add? Y/N");
                string user_answer = Console.ReadLine();
                // Make sure user input is not blank 
                while (string.IsNullOrEmpty(user_answer))
                {
                    Console.WriteLine("Answer can not be blank");
                    user_answer = Console.ReadLine();
                }
                if (user_answer.ToLower() == "y")
                {
                    keep_adding = true;
                }
                else
                {
                    keep_adding= false;
                }
                // Adding expenses total 
                double expense_total = 0;
                if (keep_adding == false)
                {
                    foreach (var expense in Expenses)
                    {
                        expense_total += expense;
                    }
                    writer.WriteLine($"Total Expenses {expense_total:$0.00}");
                }
            }
        }
        // Method to add income 
        void Add_Income()
        {
            bool keep_adding = true;
            double income_D = 0;
            // Keep adding income as long as bool stays true
            while (keep_adding)
            {
                Console.WriteLine("Enter your income one job or amount at a time, if you have more to add you will be able to do so when you see this message again");
                string user_income = Console.ReadLine();
                // Make sure user income is not blank 
                while (string.IsNullOrEmpty(user_income))
                {
                    Console.WriteLine("Income can not be left blank");
                    user_income = Console.ReadLine();
                }
                // Statements for catching possible invalid input from user 
                try
                {
                    income_D = Convert.ToDouble(user_income);
                }
                catch (FormatException e )
                {
                    Console.WriteLine($"Invalid input {e.Message}");
                }
                Income.Add(income_D);
                Console.WriteLine("Enter income description:");
                // Income desc can stay blank
                string income_desc = Console.ReadLine();
                Console.WriteLine("Income has been added");
                // File information for file
                string folder_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string file_name = "Income.txt";
                string combined = Path.Combine(folder_location, file_name);
                // Checking if file alraedy exist 
                if (!File.Exists(combined))
                {
                    File.Create(combined).Close();
                }
                // Writing to file 
                using StreamWriter writer = new StreamWriter(combined, true);
                writer.WriteLine($"{DateTime.Now.ToString()}");
                writer.WriteLine($"{income_D:$0.00}");
                writer.WriteLine($"Income Description: {income_desc}");
                writer.WriteLine("---------------------------------------------------");
                Console.WriteLine("Do you have another income to add? Y/N");
                string user_answer = Console.ReadLine();
                // Make sure answer is not blank 
                while ( string.IsNullOrEmpty(user_answer))
                {
                    Console.WriteLine("Your answer can not be blank");
                    user_answer = Console.ReadLine();
                }
                // keep adding or terminate loop
                if (user_answer.ToLower() == "y")
                {
                    keep_adding = true;
                }
                else
                {
                    keep_adding = false;
                }
                double total_income = 0;
                if (keep_adding == false)
                {
                    // Add all new income together for a total number
                    foreach(var income in Income)
                    {
                        total_income += income;
                    }
                    writer.WriteLine($"Total Income: {total_income:$0.00}");
                }
 
            }
        }
        // View all transactions of current file 
        void View_transactions()
        {
            // Handling file reading
            string folder_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string file_expenses = "Expenses.txt";
            string expenses_combined = Path.Combine(folder_path, file_expenses);
            // Income file
            string file_income = "Income.txt";
            string income_combined = Path.Combine(folder_path, file_income);
            // Asking user if they want income or expenses transactions 
            Console.WriteLine("What type of transactions do you want to see?\n" +
                "1. Income\n" +
                "2. Expenses\n");
            string user_answer = Console.ReadLine();
            // Make sure user input is not empty
            while (string.IsNullOrEmpty(user_answer))
            {
                Console.WriteLine("Your input can not be left blank");
                user_answer = Console.ReadLine();
            } 
            
            if (user_answer == "1")
            {
                using StreamReader reader = new StreamReader(income_combined);
                string income = reader.ReadToEnd();
                Console.WriteLine($"{income}");
            }
            else
            {
               using StreamReader expenses_reader = new StreamReader(expenses_combined);
               string expense = expenses_reader.ReadToEnd();
               Console.WriteLine($"{expense}");
            }
        }
    }
}