using System;
using System.IO;

namespace Day1
{
	class InverseCaptcha1
	{
		static void Main(string[] args)
		{

			int sum = 0;
			StreamReader file = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			String input = file.ReadLine();
			int[] intArray = Array.ConvertAll(input.ToCharArray(), c => (int) Char.GetNumericValue(c));
			
			for (int i = 0; i < intArray.Length; i++)
			{
				if (intArray[i] == intArray[i + 1])
				{
					sum += intArray[i];
				}
			}
			if (intArray[intArray.Length - 1] == intArray[0]) sum += intArray[0];
			
			Console.WriteLine(sum);
		}
	}
}
