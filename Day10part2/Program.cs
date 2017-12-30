using System;
using System.Collections.Generic;
using System.IO;

namespace Day10part2
{
	class Program
	{
		private static List<int> listaBrojeva;
		private static int currentPosition = 0;
		private static int skipStep = 0;

		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			char[] inputArr = input.ReadLine().ToCharArray();
			char[] intArr = new char[inputArr.Length + 5];
			Array.Copy(inputArr,intArr,inputArr.Length);
			intArr[inputArr.Length] = (char)17;
			intArr[inputArr.Length + 1] = (char)31;
			intArr[inputArr.Length + 2] = (char)73;
			intArr[inputArr.Length + 3] = (char)47;
			intArr[inputArr.Length + 4] = (char)23;

			listaBrojeva = new List<int>(256);
			PuniListaBrojeva();
			for (int j = 0; j < 64; j++)
			{
				for (int i = 0; i < intArr.Length; i++)
				{
					int length = intArr[i];
					ReverseList(currentPosition, currentPosition + length - 1);
					currentPosition += length + skipStep++;
					while (currentPosition >= listaBrojeva.Count) currentPosition -= listaBrojeva.Count;
				}
			}

			int[] denseHash = ConvertToDenseHash();
			String hexadecimal = Hexadecimal(denseHash);

			Console.WriteLine(hexadecimal.ToLower());
		}

		private static string Hexadecimal(int[] denseHash)
		{
			string hex ="";
			for (int i = 0; i < 16; i++)
			{
				hex += denseHash[i].ToString("X2");
			}
			return hex;
		}

		private static int[] ConvertToDenseHash()
		{
			int[] rez = new int[16];
			for (int i = 0; i < 16; i++)
			{
				int xor = listaBrojeva[i*16];
				for (int j = 1; j < 16; j++)
				{
					xor = xor ^ listaBrojeva[j+16*i];
				}
				rez[i] = xor;
			}
			return rez;
		}

		private static void ReverseList(int mini, int maxi)
		{
			if (maxi <= mini) return;
			List<char> pomocnaLista = new List<char>(maxi - mini + 1);

			{
				for (int i = mini; i <= maxi; i++)
					if (i > listaBrojeva.Count - 1)
						pomocnaLista.Add((char)listaBrojeva[i - listaBrojeva.Count]);
					else
						pomocnaLista.Add((char)listaBrojeva[i]);

				pomocnaLista.Reverse();

				for (int i = mini; i <= maxi; i++)
					if (i > listaBrojeva.Count - 1)
						listaBrojeva[i - listaBrojeva.Count] = pomocnaLista[i - mini];
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
