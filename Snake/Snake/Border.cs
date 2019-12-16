using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Border:Object
	{
		public Border(string sign) : base(sign)
		{
			generate();
		}
		void generate()
		{
			for (int i = 0; i <= 21; i ++)
				for (int j = 0; j <= 21; j ++)
					if (i == 0 || j == 0 || i == 21  || j == 21)
						body.Add(new Point(i, j));
		}
		
	}
}
