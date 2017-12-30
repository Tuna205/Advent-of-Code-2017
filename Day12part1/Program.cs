using System;
using System.Collections.Generic;
using System.IO;

namespace Day12part1
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			HashSet<int> set = new HashSet<int>();
			Dictionary<int,int[]> dict = new Dictionary<int, int[]>();


			while (!input.EndOfStream)
			{
				String line = input.ReadLine();
				String[] splitLine = line.Split(new[]{"<->"}, StringSplitOptions.RemoveEmptyEntries);
				int left = int.Parse(splitLine[0]);

				int[] right = Array.ConvertAll(splitLine[1].Split(','), s => int.Parse(s));

				dict.Add(left,right);
			}

			Recursiuon(dict, set, 0);

			Console.WriteLine(set.Count);
		}

		private static void Recursiuon(Dictionary<int, int[]> dict, HashSet<int> set, int broj)
		{
			if (!dict.ContainsKey(broj)) return;
			if (set.Contains(broj)) return;
			set.Add(broj);
			int[] arr = dict[broj];
			foreach (var i in arr)
				Recursiuon(dict,set,i);
		}
	}
}
