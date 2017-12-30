using System;

namespace Day3part1
{
	class Program
	{
		private static int i = 1;
		private static int j = 0;

		public static void Main(string[] args)
		{
			int rowLen = 3;
			int posInRow = 1;
			int rotation = 1;
			int layerLen = 8;
			int layerLenCount = 0;

			int input = int.Parse(Console.ReadLine());
			for (int broj = 2; broj <= input; broj++)
			{

				posInRow++;
				if (posInRow == rowLen)
				{
					rotation++;
					if (rotation == 5) rotation = 1;
					posInRow = 1;
				}


				if (layerLenCount == layerLen)
				{
					layerLenCount = 1;
					layerLen += 8;
					rowLen += 2;
					Right();
					continue;
				}
				layerLenCount++;

			
				if (rotation == 1)				
					Up();
				if (rotation == 2)
					Left();
				if (rotation == 3)
					Down();
				if (rotation == 4)
					Right();
			}

			int calcDist = Math.Abs(i) + Math.Abs(j)-1;
			Console.WriteLine(calcDist);
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
