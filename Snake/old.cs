using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Snake
{
    class Program
    {
        class game
        {
            public int H, W;
            public game (int h, int w)
            {
                H = h;
                W = w;
                
            }
            void init()
            {

                Console.SetWindowSize(W, H);
                string name = login();
               
            }
            void HighLightText()
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            void DefaultText()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            string login()
            {
                BinaryFormatter d = new BinaryFormatter();
                FileStream f = new FileStream("C:\Olymp\C#\PP2\Programming-Principles-2-KBTU\Week 6\Snake\Snake\users.txt");
                List<string> names = d.Deserialize(f) as List<string>;
                names.Add("New user");
                int cursor = 0;
				bool newuser = 0;
				string username = "";
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("Select a user:\n");
                    Console.WriteLine("...");
             
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (i == cursor)
                            {
                                HighLightText();
                            }
                            else
                            {
                                DefaultText();
                            }
                            Console.WriteLine(names[i]);
                        }
                        Console.ReadKey();
                        ConsoleKeyInfo last = new ConsoleKeyInfo();
                        if (last.Key == ConsoleKey.UpArrow)
                        {
                            cursor = Math.Min(cursor + 1, names.Count);
                        }
                        if (last.Key == ConsoleKey.DownArrow)
                        {
                            cursor = Math.Max(cursor - 1, 0);
                        }
						if (last.Key == ConsoleKey.Enter)
						{
							if (cursor == names.Count - 1)
							{
								DefaultText();
								Console.Clear();
								Console.WriteLine("Enter your nickname:");
								username = Console.ReadLine();
								newuser = true;
							}
							else
							{
								username = names[cursor];
							}
							break;
						}
                    }
					names.RemoveAt(names.Count - 1);
					if (newuser)
						names.Add(user);
                
            }

            public void draw()
            {
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        if (i == 0 || j == 0 || i == H - 1 || j == W - 1)
                            Console.Write("#");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            game G = new game(40, 40);
             
            while (true)
            {
                G.show();
                Thread.Sleep(1000);
            }
        }
    }
}
