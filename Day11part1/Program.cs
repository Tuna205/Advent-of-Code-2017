using System;
using System.IO;

namespace Day11part1
{
	class Program
	{
		static void Main(string[] args)
		{
			StreamReader input = new StreamReader(@"C:\Users\tuna2\Desktop\input.txt");
			String[] inpArray = input.ReadToEnd().Split(',');
			int up=0, upWest=0, upEast=0;

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
			}
			int dist=0;
			
			if (upEast > 0 && upWest < 0) //b
			{

				if (up >= 0)
				{
					upEast = Math.Abs(upEast) + up;
					upWest = Math.Abs(upWest) - up;
					dist = upEast + upWest;
				}

				if (up < 0)
				{
					upEast = Math.Abs(upEast) - up;
					upWest = Math.Abs(upWest) + up;
					dist = upEast + upWest;
				}

			}
			
			else if(upEast < 0 && upWest > 0)//a
			{
				if (up >= 0)
				{
					upEast = Math.Abs(upEast) - up;
					upWest = Math.Abs(upWest) + up;
					dist = upEast + upWest;
				}

				if (up < 0)
				{
					upEast = Math.Abs(upEast) + up;
					upWest = Math.Abs(upWest) - up;
					dist = upEast + upWest;
				}

			}
			else if (upEast > 0 && upWest > 0)
			{
				int up1 = Math.Max(Math.Abs(upEast), Math.Abs(upWest));
				if(up>=0)
					dist = up + up1;
				if (up < 0)
					dist = up - up1;
			}
			else
			{
				int down = Math.Max(Math.Abs(upEast), Math.Abs(upWest));
				if (up >= 0)
					dist = up - down;
				if (up < 0)
					dist = up + down;
			}


			Console.WriteLine(Math.Abs(dist));
		}
	}
}
