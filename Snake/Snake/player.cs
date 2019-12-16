using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	[Serializable]
	public class player
	{
	
			public int score;
			public string name;
			public player() { }
			public player(string name, int score)
			{
				this.name = name;
				this.score = score;
			}
			public string getInfo()
			{
				return name + " " + score;
			}
		
	}
}
