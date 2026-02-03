class MergeTwoSortedArray
{
    public static T[] Merge<T>(T[] a,T[] b)where T : IComparable<T>
    {
        T[] result=new T[a.Length+b.Length];
        if(a==null)a=Array.Empty<T>();
        if(b==null)b=Array.Empty<T>();

        int i=0,j=0,k=0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i].CompareTo(b[j]) <= 0)
            {
                result[k++]=a[i++];
            }
            else
            {
                result[k++]=b[j++];
            }
        }

        while (i < a.Length)
        {
            result[k++]=a[i++];
        }
        while (j < b.Length)
        {
            result[k++]=b[j++];
        }
        return result;
    }
    public static void Main(string[] args)
    {
        int[] a={2,4,6,23,45,73};
        int[] b={3,5,25,36,72};
        int[] merged=Merge(a,b);
        Console.WriteLine(string.Join(" ",merged));
    }
}