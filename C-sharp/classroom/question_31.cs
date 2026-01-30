class FindingLuckyNumber
{
    public bool IsLuckyNumber(int num)
    {
        int squared_num=num*num;
        int totalsumofsquarednum=0;
        while (squared_num != 0)
        {
            totalsumofsquarednum+=squared_num%10;
            squared_num/=10;
        }
        int sum=0;
        while (num != 0)
        {
            sum+=num%10;
            num/=10;
        }
        if (totalsumofsquarednum == sum * sum)
        {
            return true;
        }
        return false;
    }
    public static void Main(string[] args)
    {
        int start=Convert.ToInt32(Console.ReadLine());
        int end=Convert.ToInt32(Console.ReadLine());
        int count=0;
        FindingLuckyNumber f=new FindingLuckyNumber();
        for(int i = start; i <= end; i++)
        {
            if (f.IsLuckyNumber(i))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}