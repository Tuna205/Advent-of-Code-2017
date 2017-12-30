using System;
using System.IO;

namespace Day5part1
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			String inputString = input.ReadToEnd();
			char[] splitter = {'\r', '\n'};
			String[] array = inputString.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
			int[] workingArray = Array.ConvertAll(array, s => int.Parse(s));
			int i = 0;
			int count = 0;
			while (i < workingArray.Length)
			{
				workingArray[i]++;
				i += workingArray[i] - 1;
				count++;
			}
			Console.WriteLine(count);

		}
	}
}
