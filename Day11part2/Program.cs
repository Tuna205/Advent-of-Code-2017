using System;
using System.IO;

namespace Day11part2
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			String[] inpArray = input.ReadToEnd().Split(',');
			int up = 0, upWest = 0, upEast = 0;
			int maxDist = 0;
			int dist = 0;
			foreach (var str in inpArray)
			{
				switch (str)
				{
					case ("n"):
						up++;
						break;
					case ("ne"):
						upEast++;
						break;
					case ("se"):
						upWest--;
						break;
					case ("s"):
						up--;
						break;
					case ("sw"):
						upEast--;
						break;
					case ("nw"):
						upWest++;
						break;
				}
				dist = 0;

				if (upEast > 0 && upWest < 0) //b
				{

					if (up >= 0)
					{
						int upEast1 = Math.Abs(upEast) + up;
						int upWest1 = Math.Abs(upWest) - up;
						dist = upEast1 + upWest1;
					}

					if (up < 0)
					{
						int upEast1 = Math.Abs(upEast) - up;
						int upWest1 = Math.Abs(upWest) + up;
						dist = upEast1 + upWest1;
					}

				}

				else if (upEast < 0 && upWest > 0)//a
				{
					if (up >= 0)
					{
						int upEast1 = Math.Abs(upEast) - up;
						int upWest1 = Math.Abs(upWest) + up;
						dist = upEast1 + upWest1;
					}

					if (up < 0)
					{
						int upEast1 = Math.Abs(upEast) + up;
						int upWest1 = Math.Abs(upWest) - up;
						dist = upEast1 + upWest1;
					}

				}
				else if (upEast > 0 && upWest > 0)//c
				{
					int up1 = Math.Max(Math.Abs(upEast), Math.Abs(upWest));
					if (up >= 0)
						dist = Math.Abs(up + up1);
					if (up < 0)
						dist = Math.Abs(up - up1);
				}
				else//d
				{
					int down = Math.Max(Math.Abs(upEast), Math.Abs(upWest));
					if (up >= 0)
						dist = Math.Abs(up - down);
					if (up < 0)
						dist = Math.Abs(up + down);
				}
				if (dist > maxDist) maxDist = dist;
				if (dist > 10000)
				{
					int a = 1;
				}
			}
			


			Console.WriteLine(Math.Abs(maxDist));
		}
	}
}
