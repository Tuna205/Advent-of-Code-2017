using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6part2
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			int[] intArray = Array.ConvertAll(input.ReadLine().Split(null), s => int.Parse(s));
			int i = 0;
			Dictionary<int[],int> set = new Dictionary<int[], int>();
			bool kraj = false;
			int broj = 0;
			while (true)
			{
				int max = intArray.Max();
				int index = Array.IndexOf(intArray, max);
				intArray[index] = 0;
				while (max > 0)
				{
					index++;
					if (index >= intArray.Length) index = 0;
					intArray[index]++;
					max--;
				}
				int[] check = (int[])intArray.Clone();

				foreach (var j in set.Keys)
				{
					if (check.SequenceEqual(j))
					{
						kraj = true;
						broj = set[j];
					}
				}

				set.Add(check, i);

				i++;
				if (kraj) break;
			}
			Console.WriteLine(i-broj-1);

		}
	}
}

