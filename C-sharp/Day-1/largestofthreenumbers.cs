class l3n
{
    public static int largestof3numbers(int a,int b,int c)
    {
        if(a > b && a > c)
        {
            return a;
        }
        else if(b > c)
        {
            return b;
        }
        else
        {
            return c;
        }
    }
}