using System;

class TransactionService
{
    static Transaction LastTransaction;
    static bool HasLastTransaction = false;

    public static void CreateTransaction()
    {
        Console.Write("Enter Invoice No: ");
        string invoiceNo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(invoiceNo))
        {
            Console.WriteLine("Invoice No cannot be empty.\n");
            return;
        }

        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        string itemName = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Quantity must be greater than zero.\n");
            return;
        }

        Console.Write("Enter Purchase Amount (total): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal purchaseAmount) || purchaseAmount <= 0)
        {
            Console.WriteLine("Purchase amount must be greater than zero.\n");
            return;
        }

        Console.Write("Enter Selling Amount (total): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal sellingAmount) || sellingAmount < 0)
        {
            Console.WriteLine("Selling amount must be zero or positive.\n");
            return;
        }

        Transaction tx = new Transaction
        {
            InvoiceNo = invoiceNo,
            CustomerName = customerName,
            ItemName = itemName,
            Quantity = quantity,
            PurchaseAmount = purchaseAmount,
            SellingAmount = sellingAmount
        };

        ComputeProfitLoss(tx);

        LastTransaction = tx;
        HasLastTransaction = true;

        Console.WriteLine("\nTransaction saved successfully.");
        PrintProfitLoss(tx);
        Console.WriteLine("------------------------------------------------------\n");
    }

    public static void ViewLastTransaction()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.\n");
            return;
        }

        Console.WriteLine("\n-------------- Last Transaction --------------");
        Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
        Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
        Console.WriteLine($"Item: {LastTransaction.ItemName}");
        Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
        Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
        Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------------------------\n");
    }

    public static void CalculateProfitLoss()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.\n");
            return;
        }

        ComputeProfitLoss(LastTransaction);
        PrintProfitLoss(LastTransaction);
        Console.WriteLine("------------------------------------------------------\n");
    }

    static void ComputeProfitLoss(Transaction tx)
    {
        if (tx.SellingAmount > tx.PurchaseAmount)
        {
            tx.ProfitOrLossStatus = "PROFIT";
            tx.ProfitOrLossAmount = tx.SellingAmount - tx.PurchaseAmount;
        }
        else if (tx.SellingAmount < tx.PurchaseAmount)
        {
            tx.ProfitOrLossStatus = "LOSS";
            tx.ProfitOrLossAmount = tx.PurchaseAmount - tx.SellingAmount;
        }
        else
        {
            tx.ProfitOrLossStatus = "BREAK-EVEN";
            tx.ProfitOrLossAmount = 0;
        }

        tx.ProfitMarginPercent =
            (tx.PurchaseAmount > 0)
            ? (tx.ProfitOrLossAmount / tx.PurchaseAmount) * 100
            : 0;
    }

    static void PrintProfitLoss(Transaction tx)
    {
        Console.WriteLine($"Status: {tx.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {tx.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {tx.ProfitMarginPercent:F2}");
    }
}
