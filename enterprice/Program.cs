using System;
using System.Collections;
using System.Collections.Generic;

class Program10
{
    static void Main()
    {
        /* TASK 1  */
        Console.WriteLine("TASK 1: DYNAMIC PRODUCT PRICE ANALYSIS");

        int productCount;
        do
        {
            Console.Write("Enter number of products: ");
        } while (!int.TryParse(Console.ReadLine(), out productCount) || productCount <= 0);

        int[] prices = new int[productCount];
        int sum = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            int price;
            do
            {
                Console.Write($"Enter price for product {i + 1}: ");
            } while (!int.TryParse(Console.ReadLine(), out price) || price <= 0);

            prices[i] = price;
            sum += price;
        }

        int averagePrice = sum / prices.Length;
        Console.WriteLine("Average Price: " + averagePrice);

        Array.Sort(prices);

        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < averagePrice)
                prices[i] = 0;
        }

        Array.Resize(ref prices, prices.Length + 5);
        for (int i = prices.Length - 5; i < prices.Length; i++)
            prices[i] = averagePrice;

        Console.WriteLine("Final Product Prices:");
        for (int i = 0; i < prices.Length; i++)
            Console.WriteLine($"Index {i} → {prices[i]}");

        /* TASK 2 */
        Console.WriteLine("\nTASK 2: BRANCH SALES ANALYSIS");

        int branches, months;
        do
        {
            Console.Write("Enter number of branches: ");
        } while (!int.TryParse(Console.ReadLine(), out branches) || branches <= 0);

        do
        {
            Console.Write("Enter number of months: ");
        } while (!int.TryParse(Console.ReadLine(), out months) || months <= 0);

        int[,] sales = new int[branches, months];
        int highestSale = int.MinValue;

        for (int i = 0; i < branches; i++)
        {
            for (int j = 0; j < months; j++)
            {
                int sale;
                do
                {
                    Console.Write($"Enter sales for Branch {i + 1}, Month {j + 1}: ");
                } while (!int.TryParse(Console.ReadLine(), out sale) || sale < 0);

                sales[i, j] = sale;
                if (sale > highestSale)
                    highestSale = sale;
            }
        }

        for (int i = 0; i < branches; i++)
        {
            int branchTotal = 0;
            for (int j = 0; j < months; j++)
                branchTotal += sales[i, j];

            Console.WriteLine($"Total sales for Branch {i + 1}: {branchTotal}");
        }

        Console.WriteLine("Highest Monthly Sale Overall: " + highestSale);

        /* TASK 3 */
        Console.WriteLine("\nTASK 3: PERFORMANCE-BASED DATA EXTRACTION");

        int[][] jaggedSales = new int[branches][];

        for (int i = 0; i < branches; i++)
        {
            int count = 0;
            for (int j = 0; j < months; j++)
                if (sales[i, j] >= averagePrice)
                    count++;

            jaggedSales[i] = new int[count];
            int index = 0;

            for (int j = 0; j < months; j++)
            {
                if (sales[i, j] >= averagePrice)
                    jaggedSales[i][index++] = sales[i, j];
            }
        }

        for (int i = 0; i < jaggedSales.Length; i++)
        {
            Console.Write($"Branch {i + 1}: ");
            foreach (int val in jaggedSales[i])
                Console.Write(val + " ");
            Console.WriteLine();
        }

        /* TASK 4 */
        Console.WriteLine("\nTASK 4: CUSTOMER TRANSACTION CLEANING");

        int transactionCount;
        do
        {
            Console.Write("Enter number of customer transactions: ");
        } while (!int.TryParse(Console.ReadLine(), out transactionCount) || transactionCount <= 0);

        List<int> customerList = new List<int>();

        for (int i = 0; i < transactionCount; i++)
        {
            int id;
            Console.Write($"Enter Customer ID {i + 1}: ");
            int.TryParse(Console.ReadLine(), out id);
            customerList.Add(id);
        }

        HashSet<int> uniqueCustomers = new HashSet<int>(customerList);
        List<int> cleanedList = new List<int>(uniqueCustomers);

        Console.WriteLine("Cleaned Customer IDs:");
        foreach (int id in cleanedList)
            Console.Write(id + " ");

        Console.WriteLine("\nDuplicates Removed: " + (customerList.Count - cleanedList.Count));

        /* TASK 5 */
        Console.WriteLine("\nTASK 5: FINANCIAL TRANSACTION FILTERING");

        int finCount;
        do
        {
            Console.Write("Enter number of financial transactions: ");
        } while (!int.TryParse(Console.ReadLine(), out finCount) || finCount <= 0);

        Dictionary<int, double> transactions = new Dictionary<int, double>();

        for (int i = 0; i < finCount; i++)
        {
            int id;
            double amount;

            Console.Write("Enter Transaction ID: ");
            int.TryParse(Console.ReadLine(), out id);

            if (transactions.ContainsKey(id))
            {
                Console.WriteLine("Duplicate ID not allowed.");
                i--;
                continue;
            }

            Console.Write("Enter Transaction Amount: ");
            double.TryParse(Console.ReadLine(), out amount);

            transactions.Add(id, amount);
        }

        SortedList<int, double> highValueTransactions = new SortedList<int, double>();

        foreach (KeyValuePair<int, double> pair in transactions)
        {
            if (pair.Value >= averagePrice)
                highValueTransactions.Add(pair.Key, pair.Value);
        }

        Console.WriteLine("High Value Transactions:");
        foreach (KeyValuePair<int, double> pair in highValueTransactions)
            Console.WriteLine($"ID: {pair.Key}, Amount: {pair.Value}");

        /* TASK 6 */
        Console.WriteLine("\nTASK 6: PROCESS FLOW MANAGEMENT");

        int opCount;
        do
        {
            Console.Write("Enter number of operations: ");
        } while (!int.TryParse(Console.ReadLine(), out opCount) || opCount <= 0);

        Queue<string> processQueue = new Queue<string>();
        Stack<string> undoStack = new Stack<string>();

        for (int i = 0; i < opCount; i++)
        {
            Console.Write($"Enter operation {i + 1}: ");
            string op = Console.ReadLine();
            processQueue.Enqueue(op);
            undoStack.Push(op);
        }

        Console.WriteLine("Processed Operations:");
        while (processQueue.Count > 0)
            Console.WriteLine(processQueue.Dequeue());

        Console.WriteLine("Undo Operations:");
        for (int i = 0; i < 2 && undoStack.Count > 0; i++)
            Console.WriteLine(undoStack.Pop());

        /* TASK 7 */
        Console.WriteLine("\nTASK 7: LEGACY DATA RISK DEMONSTRATION");

        int userCount;
        do
        {
            Console.Write("Enter number of users: ");
        } while (!int.TryParse(Console.ReadLine(), out userCount) || userCount <= 0);

        Hashtable userTable = new Hashtable();
        ArrayList legacyList = new ArrayList();

        for (int i = 0; i < userCount; i++)
        {
            Console.Write("Enter Username: ");
            string user = Console.ReadLine();

            Console.Write("Enter Role: ");
            string role = Console.ReadLine();

            userTable[user] = role;
            legacyList.Add(user);
            legacyList.Add(role);
            legacyList.Add(100); 
        }

        Console.WriteLine("Hashtable Data:");
        foreach (DictionaryEntry entry in userTable)
            Console.WriteLine($"{entry.Key} → {entry.Value}");

        Console.WriteLine("ArrayList Data (Mixed Types):");
        foreach (object obj in legacyList)
            Console.Write(obj + " ");

        Console.WriteLine("\nRisk: ArrayList allows mixed data causing runtime casting issues.");
    }
}
