using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Snake
{
	class Game
	{
		int Width = 50;
		int Height = 40;
		public bool On;
		snake S = new snake("@", "@");
		Food F = new Food("o");
		wall W = new wall("#");
		Border border = new Border("x");
		Score Highest = new Score("Highest Score: ", 10, 23);
		Score Current = new Score("Current Score: ", 12, 23);
		Score Last = new Score("Last Score: ", 14, 23);
		player CurrentPlayer;
		List<player> players;

		public Game()
		{

			Console.SetWindowSize(Width, Height);
			Console.SetBufferSize(Width, Height);
		}

		public void start()
		{
			On = true;

			int cursor = 0;
			XmlSerializer X = new XmlSerializer(typeof(List<player>));

			FileStream file = new FileStream(FileLocations.UserInfo, FileMode.OpenOrCreate, FileAccess.Read);
			players = X.Deserialize(file) as List<player>;
			file.Close();
			List <string> usernames = new List<string>();
			usernames.Add("New Player?");
			for (int i = 0; i < players.Count; i++)
				usernames.Add(players[i].getInfo());
			while (true)
			{
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Clear();
				for (int i = 0; i < usernames.Count; i++)
				{
					if (i == cursor)
					{
						Console.BackgroundColor = ConsoleColor.White;
						Console.ForegroundColor = ConsoleColor.Black;
					}
					else
					{

						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.White;
					}
					Console.WriteLine(usernames[i]);
				}
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				ConsoleKeyInfo but = Console.ReadKey();
				if (but.Key == ConsoleKey.Enter)
				{
					Console.Clear();
					if (cursor == 0)
					{
						Console.WriteLine("Enter a name:");
						string newname = Console.ReadLine();
						players.Add(new player(newname, 0));
						CurrentPlayer = players[players.Count - 1];
					}
					else
					{
						CurrentPlayer = players[cursor - 1];
					}
					break;
				}
				if (but.Key == ConsoleKey.UpArrow)
					cursor--;
				if (but.Key == ConsoleKey.DownArrow)
					cursor++;
			}

			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			Console.SetWindowSize(Width, Height);
			Console.SetBufferSize(Width, Height);
			Console.CursorVisible = false;
			Current.draw();
			Current.draw_num();
			border.draw();
			//W.draw();
			S.draw();
			W.draw();
			F.generate(W.body, S.body);
			F.draw();
		}
		void saveResults()
		{
			CurrentPlayer.score = Math.Max(CurrentPlayer.score, Current.points);
			XmlSerializer X = new XmlSerializer(typeof(List<player>));
			FileStream file = new FileStream(FileLocations.UserInfo, FileMode.OpenOrCreate, FileAccess.Write);
			X.Serialize(file, players);
			file.Close();
		}
		void Stop()
		{
			On = false;
			saveResults();
		}
		void CheckCollision()
		{
			if (S.body.Count > 1 && S.intersect(S.body.GetRange(1, S.body.Count - 1)))
			{
				Stop();
				return;
			}
			if (S.intersect(W.body))
			{
				Stop();
				//console.clear();
				//for (int i = 0; i < w.body.count; i++)
				//{
				//	console.writeline(w.body[i].x + " " + w.body[i].y.tostring());
				//}
				//console.read();
				return;
			}
			if (S.intersect(F.body))
			{
				Current.clear_num();
				Current.inc();
				Current.draw_num();
				S.Eat();
				F.body.Clear();
				F.generate(W.body, S.body);
				F.draw();
			}

		}
		public void run()
		{
			S.clear();
			S.move();
			CheckCollision();
			S.draw();
		}
		public void pressed(ConsoleKeyInfo B) {
			if (B.Key == ConsoleKey.UpArrow)
			{
				S.changeDir(-1, 0);
			}	
			if (B.Key == ConsoleKey.DownArrow)
			{
				S.changeDir(1, 0);
			}
			if (B.Key == ConsoleKey.LeftArrow)
			{
				S.changeDir(0, -1);
			}
			if (B.Key == ConsoleKey.RightArrow)
			{
				S.changeDir(0, 1);
			}
			if (B.Key == ConsoleKey.Backspace)
			{
				On = false;
			}
		}

	}
}
