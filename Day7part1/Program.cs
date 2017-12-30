using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7part1
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			Dictionary<String,String[]> dict= new Dictionary<String, String[]>();
			HashSet < String > set = new HashSet<String>();
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
			}

			//HashSet<String> set2 = new HashSet<string>(dict.Keys);
			List<String> ans =dict.Keys.Except(set).ToList();
			Console.WriteLine(ans[0]);

		}
	}
}
