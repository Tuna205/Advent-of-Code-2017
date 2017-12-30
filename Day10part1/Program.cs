using System;
using System.Collections.Generic;
using System.IO;

namespace Day10part1
{
	class Program
	{
		private static List<int> listaBrojeva;
		private static int currentPosition = 0;
		private static int skipStep = 0;

		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			String[] inputArr = input.ReadLine().Split(',');
			int[] intArr = Array.ConvertAll(inputArr, s => int.Parse(s));
			listaBrojeva = new List<int>(256);
			PuniListaBrojeva();

			for (int i = 0; i < intArr.Length; i++)
			{
				int length = intArr[i];
				ReverseList(currentPosition, currentPosition + length - 1);
				currentPosition += length + skipStep++;
				if (currentPosition >= listaBrojeva.Count) currentPosition -= listaBrojeva.Count;
			}
			Console.WriteLine(listaBrojeva[0]*listaBrojeva[1]);
		}

		private static void ReverseList(int mini, int maxi)
		{
			if (maxi <= mini) return;
			List<int> pomocnaLista = new List<int>(maxi - mini + 1);
			
			{
				for (int i = mini; i <= maxi; i++)
					if(i > listaBrojeva.Count - 1)
						pomocnaLista.Add(listaBrojeva[i-listaBrojeva.Count]);
					else
						pomocnaLista.Add(listaBrojeva[i]);

				pomocnaLista.Reverse();

				for (int i = mini; i <= maxi; i++)
					if (i > listaBrojeva.Count - 1)
						listaBrojeva[i- listaBrojeva.Count] = pomocnaLista[i - mini];
					else
						listaBrojeva[i] = pomocnaLista[i - mini];
			}


		}

		private static void PuniListaBrojeva()
		{
			int len = 256;
			for (int i = 0; i < len; i++)
			{ 
				listaBrojeva.Add(i);
			}
		}
	}
}
