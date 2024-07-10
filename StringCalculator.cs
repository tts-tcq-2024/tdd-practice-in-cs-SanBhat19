using System;
using System.Collections.Generic;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        char[] delimiters = new char[] { ',', '\n',';','*' };
        string[] splitNumbers = numbers.Split(delimiters, StringSplitOptions.None);

        if (numbers.StartsWith("//"))
        {
            int delimiterIndex = numbers.IndexOf('\n');
            string customDelimiter = numbers.Substring(2, delimiterIndex - 2);
            splitNumbers = numbers.Substring(delimiterIndex + 1).Split(new string[] { customDelimiter }, StringSplitOptions.None);
        }

        List<int> numList = ParseNumber();       

        return numList.Sum();
    }
    public List<int> ParseNumber(string[] splitNumbers)
    {
        List<int> numList = new List<int>();
        foreach (string number in splitNumbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                numList.Add(CheckParsedNumber(parsedNumber));                
            }
        }
        return numList;
    }
    public int CheckParsedNumber(List<int> parsedNumber)
    {
        if (parsedNumber < 0)
        {
            throw new Exception("Negatives not allowed");
        }
        if (parsedNumber <= 1000)
        {
            return parsedNumber;
        }
    }
}
