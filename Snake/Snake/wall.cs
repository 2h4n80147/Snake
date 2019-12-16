using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class wall: Object
	{
		public wall(string sign) : base(sign)
		{
			Random rand = new Random();
			for (int i = 0; i < 5; i++)
			{
				int x = rand.Next() % 20 + 1;
				int y = rand.Next() % 20 + 1;
				if (x != 10 && y != 10)
					body.Add(new Point(x, y));
			}
				//body.Clear();
		}
		void read_level()
		{
		}
	}
}
