using System;
using System.IO;
using Microsoft.Win32;

namespace Day13part2
{
	class Program
	{
		// ne radi pravi rezultat je 3903378, a meni ispadne 29509
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");


			String inputAll = input.ReadToEnd();
			String[] lines = inputAll.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

			int[] listLenght = new int[100];
			int[] curPos = new int[100];
			bool[] reverseArr = new bool[100];

			

			for (int i = 0; i < lines.Length; i++)
			{
				String[] line = lines[i].Split(':');
				int pos = int.Parse(line[0]);
				int len = int.Parse(line[1]);

				listLenght[pos] = len - 1;
				curPos[pos] = 0;
			}
			int endSum = 1;
			int clock = 0;

			
			while (endSum != 0)
			{

				int[] savecurPos = (int[])curPos.Clone();
				bool[] savereverseArr = (bool[])reverseArr.Clone();

				int sum = 0;
				int myPosition = -1;
				for (int i = 0; i < 100; i++)
				{
					myPosition++;
					
					if (savecurPos[myPosition] == 0)
						sum += i * (listLenght[i] + 1); //caught

					//move Security
					for (int j = 0; j < savecurPos.Length; j++)
					{
						if (savecurPos[j] == listLenght[j]) savereverseArr[j] = true;
						if (savecurPos[j] == 0) savereverseArr[j] = false;
						if (!savereverseArr[j])
							savecurPos[j]++;
						else savecurPos[j]--;
					}
				}

				clock++;

				for (int j = 0; j < curPos.Length; j++)
				{
					if (curPos[j] == listLenght[j]) reverseArr[j] = true;
					if (curPos[j] == 0) reverseArr[j] = false;
					if (!reverseArr[j])
						curPos[j]++;
					else curPos[j]--;
				}

				endSum = sum;
				//if (clock > 20000) break;
			}

			Console.WriteLine(endSum);

			Console.WriteLine(clock);
		}


	}
}
