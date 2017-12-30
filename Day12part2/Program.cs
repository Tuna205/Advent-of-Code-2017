using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day12part2
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			HashSet<int> set = new HashSet<int>();
			Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
			HashSet<int> remaining = new HashSet<int>();


			while (!input.EndOfStream)
			{
				String line = input.ReadLine();
				String[] splitLine = line.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
				int left = int.Parse(splitLine[0]);

				int[] right = Array.ConvertAll(splitLine[1].Split(','), s => int.Parse(s));

				dict.Add(left, right);
				remaining.Add(left);
			}

			int groupCount = 0;
			while (remaining.Count > 0)
			{
				HashSet<int> pomset = Recursiuon(dict, set, remaining.First());
				set = new HashSet<int>();
				remaining = new HashSet<int>(remaining.Except(pomset));
				groupCount++;

			}

			Console.WriteLine(groupCount);
		}

		private static HashSet<int> Recursiuon(Dictionary<int, int[]> dict, HashSet<int> set, int broj)
		{
			if (!dict.ContainsKey(broj)) return null;
			if (set.Contains(broj)) return null;
			set.Add(broj);
			int[] arr = dict[broj];
			foreach (var i in arr)
				Recursiuon(dict, set, i);

			return set;
		}
	}
}
