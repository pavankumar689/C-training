// class Password
// {
//     public static void Main(string[] args)
//     {
//         Console.Write("Enter the input string: ");
//         string? input1 = Console.ReadLine();
//         if (string.IsNullOrEmpty(input1))
//         {
//             Console.WriteLine("Invalid Input");
//             return;
//         }
//         string? input = input1.ToLower();
//         if (!string.IsNullOrEmpty(input))
//         {
//             for (int i = 0; i < input.Length; i++)
//             {
//                 if ((int)input[i] < 97 || (int)input[i] > 122)
//                 {
//                     Console.WriteLine("Invalid Input");
//                     return;
//                 }
//             }
//         }
//         if (!string.IsNullOrEmpty(input) && input.Length >= 6)
//         {
//             CleanseAndInvert c = new CleanseAndInvert(input);
//             Console.WriteLine($"The generated key is - {c.GeneratePassword(input)}");
//         }
//         else
//         {
//             if (!string.IsNullOrEmpty(input) && input.Length < 6)
//             {
//                 Console.WriteLine("Invalid Input");
//             }
//         }
//     }
// }