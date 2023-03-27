using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    internal class MainMenu
    {

        static void DrawExit()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════╗");
            Console.WriteLine("║      ROGUELIKE GAME       ║");
            Console.WriteLine("╠═══════════════════════════╣");
            Console.WriteLine("║        Main Menu:         ║");
            Console.WriteLine("║                           ║");
            Console.WriteLine("║         New Game          ║");
            Console.WriteLine("║    ╔═════════════════╗    ║");
            Console.WriteLine("║    ║      Exit       ║    ║");
            Console.WriteLine("║    ╚═════════════════╝    ║");
            Console.WriteLine("╚═══════════════════════════╝");
        }

        static void DrawNewGame()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════╗");
            Console.WriteLine("║      ROGUELIKE GAME       ║");
            Console.WriteLine("╠═══════════════════════════╣");
            Console.WriteLine("║        Main Menu:         ║");
            Console.WriteLine("║    ╔═════════════════╗    ║");
            Console.WriteLine("║    ║    New Game     ║    ║");
            Console.WriteLine("║    ╚═════════════════╝    ║");
            Console.WriteLine("║           Exit            ║");
            Console.WriteLine("║                           ║");
            Console.WriteLine("╚═══════════════════════════╝");
        }

        static void Main(string[] args)
        {

            DrawNewGame();
            string flag = "start";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        if (flag == "start")
                        {
                            DrawExit();
                            flag = "end";
                        }
                        else
                        {
                            DrawNewGame();
                            flag = "start";
                        }
                        break;
                    case ConsoleKey.S:
                        if (flag == "end")
                        {
                            DrawNewGame();
                            flag = "start";
                        }
                        else
                        {
                            DrawExit();
                            flag = "end";
                        }
                        break;
                    case ConsoleKey.E:
                        switch (flag)
                        {
                            case "start":
                                //игра
                                break;
                            case "end":
                                goto while_end;
                        }
                        break;
                    default:
                        break;
                }
            }
while_end:
            Console.Clear();
            Console.WriteLine("Иди нахуй");
        }
    }
}
