using System;
using System.IO;
using System.Linq;


namespace Day2part1
{
	class CoruptionChecksum
	{
		//input nacin nevalja
		static void Main(string[] args)
		{
			int sum = 0;
			StreamReader file = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");

			while (!file.EndOfStream)
			{

				String input = file.ReadLine();
				String[] inputArray = input.Split(null);
				int[] intArray = Array.ConvertAll(inputArray, s => int.Parse(s));


				int max = intArray.Max();
				int min = intArray.Min();
				int diff = max - min;
				sum += diff;


			}
			Console.WriteLine(sum);
		}
	}
}
