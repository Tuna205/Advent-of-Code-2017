using System;
using System.Collections.Generic;

namespace Day3part2
{
	class Program
	{
		private static int i = 1;
		private static int j = 0;

		private static Dictionary<Tuple<int,int>, int> kordinate;

		public static void Main(string[] args)
		{
			int rowLen = 3;
			int posInRow = 2;
			int rotation = 1;
			int layerLen = 8;
			int layerLenCount = 1;

			

			int input = int.Parse(Console.ReadLine());

			kordinate = new Dictionary<Tuple<int, int>, int>();
			kordinate.Add(new Tuple<int, int>(0, 0), 1);
			int vrijednost;
			while (true)
			{
				vrijednost = Izracunaj(i, j);
				if (vrijednost > input) break;
				kordinate.Add(new Tuple<int, int>(i, j), vrijednost);

				if (rotation == 1)
					Up();
				if (rotation == 2)
					Left();
				if (rotation == 3)
					Down();
				if (rotation == 4)
					Right();

				posInRow++;
				if (posInRow == rowLen)
				{
					rotation++;
					if (rotation == 5) rotation = 1;
					posInRow = 1;
				}

				layerLenCount++;
				if (layerLenCount == layerLen)
				{
					layerLenCount = 1;
					layerLen += 8;
					rowLen += 2;
					posInRow = 2;
					
					vrijednost = Izracunaj(i, j);
					if (vrijednost > input) break;
					kordinate.Add(new Tuple<int, int>(i, j), vrijednost);
					Right();
				}	
			}
			Console.WriteLine(vrijednost);

		}

		private static int Izracunaj(int i1, int i2)
		{
			int sum = 0;
			if(kordinate.ContainsKey(new Tuple<int, int>(i1 + 1, i2)))
				sum += kordinate[new Tuple<int, int>(i1 + 1, i2)];

			if (kordinate.ContainsKey(new Tuple<int, int>(i1, i2 + 1)))
				sum += kordinate[new Tuple<int, int>(i1, i2 + 1)];

			if (kordinate.ContainsKey(new Tuple<int, int>(i1 + 1, i2 + 1)))
				sum += kordinate[new Tuple<int, int>(i1 + 1, i2 + 1)];

			if (kordinate.ContainsKey(new Tuple<int, int>(i1 + 1, i2 - 1)))
				sum += kordinate[new Tuple<int, int>(i1 + 1, i2 - 1)];

			if (kordinate.ContainsKey(new Tuple<int, int>(i1, i2 - 1)))
				sum += kordinate[new Tuple<int, int>(i1, i2 - 1)];

			if (kordinate.ContainsKey(new Tuple<int, int>(i1 - 1, i2)))
				sum += kordinate[new Tuple<int, int>(i1 - 1, i2)];

			if (kordinate.ContainsKey(new Tuple<int, int>(i1 - 1, i2 + 1)))
				sum += kordinate[new Tuple<int, int>(i1 - 1, i2 + 1)];

			if (kordinate.ContainsKey(new Tuple<int, int>(i1 - 1, i2 - 1)))
				sum += kordinate[new Tuple<int, int>(i1 - 1, i2 - 1)];

			return sum;

		}


		private static void Up()
		{
			j++;
		}

		private static void Down()
		{
			j--;
		}

		private static void Left()
		{
			i--;
		}

		private static void Right()
		{
			i++;
		}
	}
}

