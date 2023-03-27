using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeFEFU
{
    internal static class MainMenu
    {

        public static void DrawExit()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║       ROGUELIKE GAME      ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║        Main Menu:         ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║         New Game          ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║         Settings          ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║    ║      Exit       ║    ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        public static void DrawNewGame()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║       ROGUELIKE GAME      ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║        Main Menu:         ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ║    New Game     ║    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║         Settings          ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║           Exit            ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        public static void DrawSettings()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║       ROGUELIKE GAME      ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║        Main Menu:         ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║         New Game          ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ║    Settings     ║    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║           Exit            ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        public static void MainMenuRun()
         {
            DrawNewGame();
            bool isBreak = true;
            int count = 0;
            while (isBreak)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        if (count > 0) { count--; }
                        switch (count)
                        {
                            case 0:
                                DrawNewGame();
                                break;
                            case 1:
                                DrawSettings();
                                break;
                            case 2:
                                DrawExit();
                                break;
                        }
                        break;
                    case ConsoleKey.S:
                        if (count < 2) { count++; }
                        switch (count)
                        {
                            case 0:
                                DrawNewGame();
                                break;
                            case 1:
                                DrawSettings();
                                break;
                            case 2:
                                DrawExit();
                                break;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (count)
                        {
                            case 0:
                                Console.Clear();
                                Game.Run();
                                break;
                            case 1:
                                break;
                            case 2:
                                isBreak = false;
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
             Console.Clear();
         }
    }
}
