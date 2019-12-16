using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
	abstract class FileLocations
	{
		public static string UserInfo = @"C:\Olymp\C#\PP2\Programming-Principles-2-KBTU\Week 6\Snake\UserInfo.xml";
	}
	class Program
    {
		static void test()
		{
			Random rand = new Random();
			while (true) { 
				Console.Write(rand.Next() % 20);
				Console.WriteLine(rand.Next() % 20);
				Thread.Sleep(100);
			}
			//Console.ReadKey();
		}
		static void init()
		{
			XmlSerializer X = new XmlSerializer(typeof(List<player>));
			List<player> d = new List<player>();
			FileStream file = new FileStream(FileLocations.UserInfo, FileMode.OpenOrCreate, FileAccess.Write);
			X.Serialize(file, d);
			file.Close();
		}
		void test2()
		{
			Console.WriteLine(Console.LargestWindowHeight);
			Console.WriteLine(Console.LargestWindowWidth);
			Console.Read();
			return;
		}
		static void Main(string[] args)
		{
	
		begin:
			Game g = new Game();
			g.start();
			while (g.On)
			{
				Console.SetCursorPosition(30, 30);
				ConsoleKeyInfo button = Console.ReadKey();
				g.pressed (button);
				g.run();
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Clear();
			Console.WriteLine("Game over.\n Try again ?[Y \\ N]");

			//Console.SetCursorPosition(30, 30);
			ConsoleKeyInfo last = Console.ReadKey();
			if (last.Key == ConsoleKey.Y)
			{
				goto begin;
			}
        }

    }
}
