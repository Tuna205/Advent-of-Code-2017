using System;
using System.IO;

namespace Day1part2
{
	class InverseCaptcha2
	{
		static void Main(string[] args)
		{
			int sum = 0;
			StreamReader file = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			String input = file.ReadLine();
			
			int[] intArray = Array.ConvertAll(input.ToCharArray(), c => (int)Char.GetNumericValue(c));
			int step = intArray.Length / 2;
			for (int i = 0; i < intArray.Length; i++)
			{
				if (i + step <= intArray.Length - 1)  //ako moramo gledati preko len
					if (intArray[i] == intArray[i + step])
						sum += intArray[i];
					else;
				else
				{
					if (intArray[i] == intArray[i + step - intArray.Length])
						sum += intArray[i];
				}						
			}
			Console.WriteLine(sum);
		}
	}
}
