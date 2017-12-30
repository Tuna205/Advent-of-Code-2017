using System;
using System.Collections.Generic;
using System.IO;

namespace Day4part1
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader file = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			String[] inputLine;
			HashSet<String> set = new HashSet<String>();
			int count = 0;
			using (file)
			{
				while (!file.EndOfStream)
				{
					inputLine = file.ReadLine().Split(' ');
					set = new HashSet<String>();
					bool check = true;
					foreach (String s in inputLine)
					{
						if (!set.Add(s)) check = false;
					}
					if (check) count++;
				}
			}
			Console.WriteLine(count);
		}
	}
}
