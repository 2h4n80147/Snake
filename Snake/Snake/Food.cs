using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Food:Object
	{
		public Food (string sign) : base(sign)
		{	
		}
		public void generate(List<Point> block)
		{

			Random rand = new Random();
			while (true)
			{
				int x = rand.Next() % 20 + 1;
				int y = rand.Next() % 20 + 1;
				int ok = 1;
				foreach (Point P in block)
				{
					if (P.x == x && P.y == y)
					{
						ok = 0;
						break;
					}
				}
				if (ok == 1)
				{
					body.Add(new Point(x, y));
					break;
				}
			}
		}
		public void generate(List<Point> block, List<Point> block2)
		{
			List<Point> np = new List<Point>();
			np = block.Concat( block2).ToList();
			Random rand = new Random();
			while (true)
			{
				int x = rand.Next() % 20 + 1;
				int y = rand.Next() % 20 + 1;
				int ok = 1;
				foreach (Point P in block)
				{
					if (P.x == x && P.y == y)
					{
						ok = 0;
						return;
					}
				}
				if (ok == 1)
				{
					body.Add(new Point(x, y));
					break;
				}
			}
		}
	}
}
