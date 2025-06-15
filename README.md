# 💸 Expense Tracker (C# Console App)

A simple and functional expense and income tracking tool built in C#. This console-based application allows users to input expenses and income, categorize entries with optional descriptions, and save everything to text files for future review.

---

## ✨ Features

- 🔹 Add multiple income or expense entries
- 🔹 Optional descriptions for each transaction
- 🔹 Writes to separate `Income.txt` and `Expenses.txt` files in your Documents folder
- 🔹 Appends each entry with a timestamp
- 🔹 Calculates and saves total income and expenses
- 🔹 View past transactions by category

---

## 📁 File Output

Transactions are automatically saved to:

- `Documents/Income.txt`
- `Documents/Expenses.txt`

Each file includes:
- Timestamp
- Amount
- Optional description
- A divider
- Total (after the final entry in the session)

---

## 🛠 Technologies Used

- C# (.NET 6+ recommended)
- Console UI
- `StreamWriter` / `StreamReader`
- `System.Environment.SpecialFolder`
- Error handling and user validation

## 📄 License

This project is licensed under the [MIT License](LICENSE).


