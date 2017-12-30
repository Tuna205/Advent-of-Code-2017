using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6part1
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			int[] intArray = Array.ConvertAll(input.ReadLine().Split(null), s => int.Parse(s));
			int i = 0;
			List<int[]> set = new List<int[]>();
			bool kraj = false;
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

				foreach (var j in set)
				{
					if (check.SequenceEqual(j)) kraj = true;
				}

				set.Add(check);

				i++;
				if(kraj) break;
			}
			Console.WriteLine(i);
			
		}
	}
}
