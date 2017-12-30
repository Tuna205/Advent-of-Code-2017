using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7part2
{
	//NE RADI TREBALO JE GLEDAT DEBUGGER DA SE NAĐE PRAVI REZULTAT
	class Program
	{
		private static int rez;

		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			Dictionary<String, String[]> dict = new Dictionary<String, String[]>();
			HashSet<String> set = new HashSet<String>();
			Dictionary<String, int> weightDict = new Dictionary<string, int>();
			while (!input.EndOfStream)
			{
				String inputString = input.ReadLine();
				String[] inpArr = inputString.Split(null);
				String[] nextStrings = null;
				if (inpArr.Length > 2)
				{
					nextStrings = new String[inpArr.Length - 3];
					for (int i = 3; i < inpArr.Length; i++)
					{
						if (inpArr[i].EndsWith(",")) inpArr[i] = inpArr[i].Substring(0, inpArr[i].Length - 1);

						nextStrings[i - 3] = inpArr[i];
						set.Add(inpArr[i]);
					}
				}

				if (nextStrings != null) dict.Add(inpArr[0], nextStrings);//pazi na zareze
				else dict.Add(inpArr[0], null);
				string nes = inpArr[1].Substring(1, inpArr[1].Length - 2);
				weightDict.Add(inpArr[0], int.Parse(nes));

			}

			

			//HashSet<String> set2 = new HashSet<string>(dict.Keys);
			List<String> ans = dict.Keys.Except(set).ToList();
			//Console.WriteLine(ans[0]);

			List<int> rezList = new List<int>();
			foreach (String v in dict["boropxd"])
			{
				int rez2 = Recurzion(weightDict, dict, v);
				rezList.Add(rez2);
			}

			//int rez2 = rezList.Max() - rezList.Min();
			Console.WriteLine(rez);
		}
		// REKURZIJA NEVALJA POPRAVI
		private static int Recurzion(Dictionary<string, int> weightDict, Dictionary<string, string[]> dict, string v)
		{
			if (v == null) return 0;
			if (dict[v] == null) return weightDict[v];
			int suma = 0;
			HashSet<int> set = new HashSet<int>();
			foreach (String s in dict[v])
			{
				int r = Recurzion(weightDict, dict, s);
				suma += r;
				set.Add(r);
			}

			if (set.Count > 1)
			{
				if (rez == 0)
				{
					rez = weightDict[v];
					Console.WriteLine(v);
				}
			}



			return weightDict[v] + suma;
		}
	}

	
}
