using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'steadyGene' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING gene as parameter.
     */

    public static int steadyGene(string gene)
    {
        int n = gene.Length;
        int target = n / 4;

        
        Dictionary<char, int> count = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 }
        };

        foreach (char c in gene)
            count[c]++;

        
        if (count['A'] == target && count['C'] == target && count['G'] == target && count['T'] == target)
            return 0;

        int minLength = n;
        int left = 0;

        for (int right = 0; right < n; right++)
        {
            count[gene[right]]--;

            
            while (left <= right &&
                   count['A'] <= target &&
                   count['C'] <= target &&
                   count['G'] <= target &&
                   count['T'] <= target)
            {
                minLength = Math.Min(minLength, right - left + 1);
                count[gene[left]]++;
                left++;
            }
        }

        return minLength;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string gene = Console.ReadLine();

        int result = Result.steadyGene(gene);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
