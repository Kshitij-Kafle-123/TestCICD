using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorLib
{
    public class Calculator
    {
        
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var delimiters = new List<string> { ",", "\n" };
            var nums = numbers;

            if (numbers.StartsWith("//"))
            {
                var end = numbers.IndexOf('\n');
                if (end == -1) end = numbers.Length;
                var delimiterPart = numbers.Substring(2, end - 2);

                if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
                {
                    var temp = delimiterPart;
                    while (temp.Contains("["))
                    {
                        var s = temp.IndexOf('[');
                        var e = temp.IndexOf(']');
                        if (s == -1 || e == -1) break;
                        delimiters.Add(temp.Substring(s + 1, e - s - 1));
                        temp = temp.Substring(e + 1);
                    }
                }
                else
                {
                    delimiters.Add(delimiterPart);
                }

                if (end + 1 < numbers.Length)
                    nums = numbers.Substring(end + 1);
                else
                    nums = string.Empty;
            }

            var tokens = nums.Split(delimiters.ToArray(), StringSplitOptions.None);
            var negatives = new List<int>();
            var sum = 0;

            foreach (var t in tokens)
            {
                if (string.IsNullOrWhiteSpace(t)) continue;
                if (!int.TryParse(t, out var v)) continue;
                if (v < 0) negatives.Add(v);
                if (v > 1000) continue;
                sum += v;
            }

            if (negatives.Any())
                throw new ArgumentException("Negatives not allowed: " + string.Join(",", negatives));

            return sum;
        }
    }
}
