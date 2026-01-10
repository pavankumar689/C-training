﻿using System;
using System.Collections.Generic;

namespace DialingCodesApp
{
    public static class DialingCodes
    {
        // Task 1
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        // Task 2
        public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>
            {
                { 1, "United States of America" },
                { 55, "Brazil" },
                { 91, "India" }
            };
        }

        // Task 3
        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            return new Dictionary<int, string> { { countryCode, countryName } };
        }

        // Task 4
        public static Dictionary<int, string> AddCountryToExistingDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode,
            string countryName)
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        // Task 5
        public static string GetCountryNameFromDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                return existingDictionary[countryCode];
            }
            return string.Empty;
        }

        // Task 6
        public static bool CheckCodeExists(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }

        // Task 7
        public static Dictionary<int, string> UpdateDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode,
            string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode] = countryName;
            }
            return existingDictionary;
        }

        // Task 8
        public static Dictionary<int, string> RemoveCountryFromDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Remove(countryCode);
            }
            return existingDictionary;
        }

        // Task 9
        public static string FindLongestCountryName(
            Dictionary<int, string> existingDictionary)
        {
            if (existingDictionary.Count == 0)
            {
                return string.Empty;
            }

            string longest = "";
            foreach (var c in existingDictionary.Values)
            {
                if (c.Length > longest.Length)
                {
                    longest = c;
                }
            }
            return longest;
        }
    }
    class Program
    {
        static void Main()
        {
            var emptyDict = DialingCodes.GetEmptyDictionary();
            Console.WriteLine("Task 1 Count: " + emptyDict.Count);

            var existingDict = DialingCodes.GetExistingDictionary();
            Console.WriteLine("\nTask 2:");
            PrintDictionary(existingDict);

            var japanDict = DialingCodes.AddCountryToEmptyDictionary(81, "Japan");
            Console.WriteLine("\nTask 3:");
            PrintDictionary(japanDict);

            DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");
            Console.WriteLine("\nTask 4:");
            PrintDictionary(existingDict);

            Console.WriteLine("\nTask 5:");
            string country = DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
            Console.WriteLine(country);

            Console.WriteLine("\nTask 6:");
            Console.WriteLine(DialingCodes.CheckCodeExists(existingDict, 91));
            Console.WriteLine(DialingCodes.CheckCodeExists(existingDict, 99));

            DialingCodes.UpdateDictionary(existingDict, 91, "Republic of India");
            Console.WriteLine("\nTask 7:");
            PrintDictionary(existingDict);

            DialingCodes.RemoveCountryFromDictionary(existingDict, 55);
            Console.WriteLine("\nTask 8:");
            PrintDictionary(existingDict);

            Console.WriteLine("\nTask 9:");
            Console.WriteLine(DialingCodes.FindLongestCountryName(existingDict));
        }

        static void PrintDictionary(Dictionary<int, string> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}