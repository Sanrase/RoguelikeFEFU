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
             string flag = "start";
             while (true)
             {
                 ConsoleKeyInfo key = Console.ReadKey(true);
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
                     case ConsoleKey.Enter:
                         switch (flag)
                         {
                             case "start":
                                Console.Clear();
                                Game.Run();
                                
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
