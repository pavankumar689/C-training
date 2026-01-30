using System;

class Swapping
{
    static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static void SwapUsingOut(int a, int b, out int x, out int y)
    {
        x = a + b;
        y = x - b;
        x = x - y;
    }

    static void Main(string[] args)
    {
        int x = 10;
        int y = 20;

        SwapUsingRef(ref x, ref y);
        Console.WriteLine($"After ref swap -> X:{x}, Y:{y}");

        int a = 30;
        int b = 40;

        SwapUsingOut(a, b, out int p, out int q);
        Console.WriteLine($"After out swap -> P:{p}, Q:{q}");
    }
}
