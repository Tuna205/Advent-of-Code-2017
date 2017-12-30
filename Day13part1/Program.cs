using System;
using System.IO;

namespace Day13part1
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			

			String inputAll = input.ReadToEnd();
			String[] lines = inputAll.Split(new[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

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
			int myPosition = -1;
			int sum = 0;
			for (int i = 0; i < 100; i++)
			{
				myPosition++;
				if (curPos[myPosition] == 0)
					sum += i * (listLenght[i]+1); //caught
				
				//move Security
				for (int j = 0; j < curPos.Length; j++)
				{
					if (curPos[j] == listLenght[j]) reverseArr[j] = true;
					if (curPos[j] == 0) reverseArr[j] = false;
					if(!reverseArr[j])
						curPos[j]++;
					else curPos[j]--;
				}
			}
			Console.WriteLine(sum);
		}


	}
}
