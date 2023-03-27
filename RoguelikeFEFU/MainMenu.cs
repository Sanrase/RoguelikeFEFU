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
            Console.Write("║      ROGUELIKE GAME       ║");
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
            Console.Write("║    ║      Exit       ║    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 19);
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
            Console.Write("║      ROGUELIKE GAME       ║");
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
            Console.Write("║           Exit            ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        public static void MainMenuRun()
         {

             DrawNewGame();
             bool flag = true;
             bool isBreak = true;
             while (isBreak)
             {
                 ConsoleKeyInfo key = Console.ReadKey(true);
                 switch (key.Key)
                 {
                     case ConsoleKey.W:
                         if (flag)
                         {
                             DrawExit();
                             flag = false;
                         }
                         else
                         {
                             DrawNewGame();
                             flag = true;
                         }
                         break;
                     case ConsoleKey.S:
                         if (!flag)
                         {
                             DrawNewGame();
                             flag = true;
                         }
                         else
                         {
                             DrawExit();
                             flag = false;
                         }
                         break;
                     case ConsoleKey.Enter:
                         switch (flag)
                         {
                             case true:
                                Console.Clear();
                                Game.Run();
                                
                                break;
                             case false:
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
