using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Score : Object
	{
		public int points;
		public Score(string text, int x, int y) : base(text)
		{
			points = 0;
			body.Add(new Point(x, y));
		}
		public void draw_num()
		{
			Console.Write(points);
		}
		public void inc()
		{
			points++;
		}
		public void clear_num()
		{
			Point x = body[body.Count - 1];
			Console.SetCursorPosition(x.y + sign.Length - 1, x.x);
			for (int i = 0; i < points.ToString().Length; i++)
				Console.Write(' ');
		}
	}
}
