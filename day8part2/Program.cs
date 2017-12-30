using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day8part2
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			Dictionary<String, int> set = new Dictionary<String, int>();
			HashSet<int> maxSet = new HashSet<int>();
			while (!input.EndOfStream)
			{
				String line = input.ReadLine();
				String[] inputArr = line.Split(null);

				if (!set.ContainsKey(inputArr[0]))
					set.Add(inputArr[0], 0);

				bool check = CheckIf(inputArr, set);
				if (check)
				{
					if (inputArr[1].Equals("inc"))
						set[inputArr[0]] += int.Parse(inputArr[2]);
					else set[inputArr[0]] -= int.Parse(inputArr[2]);
					maxSet.Add(set.Values.Max());
				}
			}

			Console.WriteLine(maxSet.Max());
		}

		private static bool CheckIf(string[] inputArr, Dictionary<String, int> set)
		{
			if (!set.ContainsKey(inputArr[4]))
				set.Add(inputArr[4], 0);

			switch (inputArr[5])
			{
				case (">"):
					return (set[inputArr[4]] > int.Parse(inputArr[6]));
				case ("<"):
					return (set[inputArr[4]] < int.Parse(inputArr[6]));
				case ("<="):
					return (set[inputArr[4]] <= int.Parse(inputArr[6]));
				case (">="):
					return (set[inputArr[4]] >= int.Parse(inputArr[6]));
				case ("!="):
					return (set[inputArr[4]] != int.Parse(inputArr[6]));
				case ("=="):
					return (set[inputArr[4]] == int.Parse(inputArr[6]));
				default:
					return false;
			}
		}
	}
}
