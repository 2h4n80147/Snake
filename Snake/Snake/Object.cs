using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Object
	{
		public List<Point> body;
		public string sign;
		public Object (string sign)
		{
			this.sign = sign;
			body = new List<Point>();
		}

		public void addchar (int x, int y)
		{
			body.Add(new Point(x, y));
			//charbody.Add(new Point(x, y));
		}

		public void draw()
		{
			clear();
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.y, p.x);
				Console.Write(sign);
			}
		}
		public void clear()
		{
			foreach (Point p in body)
			{
				Console.SetCursorPosition(p.y, p.x);
				for (int i = 0; i < sign.Length; i++)
					Console.Write(' ');
			}
		}
	}
}
