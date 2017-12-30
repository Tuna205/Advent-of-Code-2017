using System;
using System.IO;


namespace day9part2
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			char[] charArr = input.ReadToEnd().ToCharArray();
			int score = 0;
			int layerValue = 1;
			bool isGarbage = false;
			int garbageCount = 0;
			for (int i = 0; i < charArr.Length; i++)
			{

				if (charArr[i] == '{')
				{
					if (!isGarbage)
					{
						score += layerValue;
						layerValue++;
					}
					else garbageCount++;
				}
				else if (charArr[i] == '<')
				{
					if (isGarbage) garbageCount++;
					isGarbage = true;
				}


				else if (charArr[i] == '>')
				{
					isGarbage = false;
				}
				else if (charArr[i] == '!')
				{
					i++;
					//if (isGarbage) garbageCount -= 2;
				}

				else if (charArr[i] == '}')
				{
					if (!isGarbage) layerValue--;
					else garbageCount++;
				}
				else if (isGarbage) garbageCount++;


			}

			Console.WriteLine(garbageCount);
		}
	}
}
