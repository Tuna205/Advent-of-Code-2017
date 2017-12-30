using System;
using System.IO;


namespace Day2part2
{
	class CoruptionChecksum2
	{
		static void Main(string[] args)
		{
			int sum = 0;
			StreamReader file = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");

			while (!file.EndOfStream)
			{

				String input = file.ReadLine();
				String[] inputArray = input.Split(null);
				int[] intArray = Array.ConvertAll(inputArray, s => int.Parse(s));


				
				int diff = FindDivisible(intArray);
				sum += diff;


			}
			Console.WriteLine(sum);
		}

		private static int FindDivisible(int[] intArray)
		{
			for (int i = 0; i < intArray.Length; i++)
			{
				for (int j = 0; j < intArray.Length && j != i; j++)
				{
					int greater = Math.Max(intArray[i], intArray[j]);
					int smaller = Math.Min(intArray[i], intArray[j]);

					if (greater % smaller == 0)
						return greater / smaller;
				}
			}
			return 0;
		}
	}
}