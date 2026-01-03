// using System.Collections;
// using System.Collections.Generic;
// class Program7
// {
//     public static void Main(String[] args)
//     {
//         Initialization of array with size
//         int[] numbers=new int[5];
//         for(int i = 0; i < numbers.Length; i++)
//         {
//             numbers[i]=Convert.ToInt32(Console.ReadLine());
//         }

//         int[,] matrix=new int[2,3];
//         int[,] matrix =
//         {
//             {1,2,5},
//             {4,6,5}
//         };
//         for(int i = 0; i < matrix.GetLength(0); i++)
//         {
//             for(int j = 0; j < matrix.GetLength(1); j++)
//             {
//                 Console.Write(matrix[i,j]+" ");
//             }
//             Console.WriteLine();
//         }

//         jagged arrays
//         int[][] jagged=new int[2][];
//         jagged[0]=new int[]{1,2};
//         jagged[1]=new int[]{3,4,5};
//         // Console.WriteLine(jagged[1][2]);
//         for(int i = 0; i < jagged.Length; i++)
//         {
//             for(int j = 0; j < jagged[i].Length; j++)
//             {
//                 Console.Write(jagged[i][j]+" ");
//             }
//             Console.WriteLine();
//         }


//         int[] data={10,30,50};
//         Array.Reverse(data);
//         Console.WriteLine($"{data[0]} {data[1]} {data[2]}");
//         Array.Clear(data,0,2);
//         Console.WriteLine($"{data[0]} {data[1]} {data[2]}");

//         int[] src={1,2,4};
//         int[] copied=new int[3];
//         Array.Copy(src,copied,2);
//         Console.WriteLine($"{copied[0]} {copied[1]} {copied[2]}");
//         Array.Copy(src,copied,3);
//         Console.WriteLine($"{copied[0]} {copied[1]} {copied[2]}");

//         int[] nums={1,2};
//         Array.Resize(ref nums,4);
//         foreach(int i in nums)
//         {
//             Console.Write(i+" ");
//         }
//         Console.WriteLine();
//         Array.Resize(ref nums,1);
//         foreach(int i in nums)
//         {
//             Console.Write(i+" ");
//         }
//         Console.WriteLine();
//         Array.Resize(ref nums,2);
//         foreach(int i in nums)
//         {
//             Console.Write(i+" ");
//         }

//         int[] arr={1,3,5,2,5,7,3};
//         bool a=Array.Exists(arr,x => x > 3);
//         Console.WriteLine(a);

//         List<int> list=new List<int>();
//         list.Add(4);
//         list.Add(6);
//         list.Add(14);
//         ArrayList l=new ArrayList();
//         l.Add(50);
//         l.Add(60);
//         l.Add(100);

//         Hashtable h=new Hashtable();
//         h.Add(1,"Admin");
//         h.Add(2,"people");
//         Console.WriteLine(h[1].GetHashCode());

//         Stack s=new Stack();
//         s.Push(20);
//         s.Push(40);
//         s.Push(50);

//         Queue q=new Queue();
//         q.Enqueue(10);
//         q.Enqueue(60);
//         while (q.Count > 0)
//         {
//             Console.WriteLine(q.Dequeue());
//         }

//         Dictionary<int,string> users=new Dictionary<int,string>();
//         users.Add(4,"People");
//         users.Add(6,"childred");
//         foreach(int i in users.Keys)
//         {
//             Console.WriteLine($"{i}:{users[i]}");
//         }

//         HashSet<int> h=new HashSet<int>();
//         h.Add(460000);
//         h.Add(10);
//         h.Add(10);
//         h.Add(40);
//         h.Add(30);
//         h.Add(170000);
//         h.Add(460000);
//         Console.WriteLine(h.Average());
//         foreach(int i in h)
//         {
//             Console.WriteLine(i);
//         }

//         SortedList<string,string> sl=new SortedList<string, string>();
//         sl.Add("b","B");
//         sl.Add("a","c");
//         foreach(string s in sl.Keys)
//         {
//             Console.WriteLine($"{s} : {sl[s]}");
//         }

//         sl.TryGetValue("b",out string? result);
//         Console.WriteLine(result);

//         for (int i = 0; i < sl.Count; i++)
//         {
//             Console.WriteLine($"{sl.Keys[i]} : {sl.Values[i]}");
//         }

//         foreach(KeyValuePair<string,string> e in sl)
//         {
//             Console.WriteLine($"{e.Key}");
//         }

//         foreach (var item in sl.Reverse())
//         {
//             Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
//         }

//         int[] arr = {1, 2, 3, 2, 1, 4, 2};
//         Dictionary<int,int>d=new Dictionary<int, int>();
//         for(int i = 0; i < arr.Length; i++)
//         {
//             if (d.ContainsKey(arr[i]))
//             {
//                 d[arr[i]]+=1;
//             }
//             else
//             {
//                 d[arr[i]]=1;
//             }
//         }

//         foreach(int i in d.Keys)
//         {
//             Console.WriteLine($"{i} : {d[i]}");
//         }

//         int[] arr1 = {1, 3, 5,11};
//         int[] arr2 = {2, 4, 6,7,9};

//         int start1=0;
//         int start2=0;
//         int[] arr=new int[arr1.Length+arr2.Length];
//         int i=0;
//         while(start1<arr1.Length && start2 < arr2.Length)
//         {
//             if (arr1[start1] < arr2[start2])
//             {
//                 arr[i++]=arr1[start1++];
//             }
//             else
//             {
//                 arr[i++]=arr2[start2++];
//             }
//         }
//         while (start1 < arr1.Length)
//         {
//             arr[i++]=arr1[start1++];
//         }
//         while (start2 < arr2.Length)
//         {
//             arr[i++]=arr2[start2++];
//         }
//         foreach(int num in arr)
//         {
//             Console.Write(num+" ");
//         }

        
//     }
// }

