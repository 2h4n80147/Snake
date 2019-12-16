using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class snake:Object
	{
		int dx, dy;
		string head;
		public snake(string sign, string head) : base(sign){
			dx = -1;
			dy = 0;
			this.head = head;
			body.Add(new Point(10, 10));
		}


		public int Filter(int x)
		{
			if (x > 20)
				x -= 20;
			if (x < 1)
				x += 20;
			return x;
		}

		public void move()
		{
			if (dx != 0 || dy != 0)
			{
				for (int i = body.Count - 1; i >= 1; i--)
				{
					body[i].x = body[i - 1].x;
					body[i].y = body[i - 1].y;
				}
				body[0].x = Filter(body[0].x + dx);
				body[0].y = Filter(body[0].y + dy);
			}
		}
		public void Eat()
		{
			int rx = body[body.Count - 1].x;
			int ry = body[body.Count - 1].y;
			
			body.Add(new Point(rx, ry));
		
		}
		public bool intersect(List<Point> body2)
		{
			foreach (Point P in body2)
			{
				if (body[0].x == P.x && body[0].y == P.y)
					return true;
			}
			return false;
		}
		public void changeDir (int x, int y) 
		{
			dx = x; dy = y;
		}
	}
}
