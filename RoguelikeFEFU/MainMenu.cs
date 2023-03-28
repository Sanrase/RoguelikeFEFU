using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace RoguelikeFEFU
{
    internal static class MainMenu
    {
        public static bool MainMenuRunInGame(Person hero)
        {
            DrawMenuInGameContinue();
            bool isBreak = true;
            bool isContinue = true;
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
                                DrawMenuInGameContinue();
                                break;
                            case 1:
                                DrawMenuInGameSettings();
                                break;
                            case 2:
                                DrawMenuInGameExit();
                                break;
                        }
                        break;
                    case ConsoleKey.S:
                        if (count < 2) { count++; }
                        switch (count)
                        {
                            case 0:
                                DrawMenuInGameContinue();
                                break;
                            case 1:
                                DrawMenuInGameSettings();
                                break;
                            case 2:
                                DrawMenuInGameExit();
                                break;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (count)
                        {
                            case 0:
                                Console.Clear();
                                isBreak = false;
                                isContinue = false;
                                break;
                            case 1:
                                Interface.DynamicLineMenuSettingsButton(hero);
                                break;
                            case 2:
                                Console.Clear();
                                isBreak = false;
                                break;
                        }
                        break;
                }
            }
            if (isContinue)
            {
                return false;
            }
            else
            {
                Interface.Statistics(30, hero);
                return true;
            }
        }

       public static void MainMenuRun(Settings settings)
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
                                DrawMenuSettings();
                                break;
                            case 2:
                                DrawMenuRecord();
                                break;
                            case 3:
                                DrawExit();
                                break;
                        }
                        break;
                    case ConsoleKey.S:
                        if (count < 3) { count++; }
                        switch (count)
                        {
                            case 0:
                                DrawNewGame();
                                break;
                            case 1:
                                DrawMenuSettings();
                                break;
                            case 2:
                                DrawMenuRecord();
                                break;
                            case 3:
                                DrawExit();
                                break;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (count)
                        {
                            case 0:
                                Console.Clear();
                                string fullPath = Path.GetFullPath("SettingsGame.json");
                                File.WriteAllText(fullPath, JsonConvert.SerializeObject(settings));
                                Game.Run(settings);
                                File.WriteAllText(fullPath, JsonConvert.SerializeObject(settings));
                                isBreak = false;
                                break;
                            case 1:
                                int countSettings = 0;
                                bool isBreakSettings = true;
                                DrawSettingsPerson();
                                while (isBreakSettings)
                                {
                                    ConsoleKeyInfo keySettings = Console.ReadKey(true);
                                    switch (keySettings.Key)
                                    {
                                        case ConsoleKey.W:
                                            if (countSettings > 0) { countSettings--; }
                                            switch (countSettings)
                                            {
                                                case 0:
                                                    DrawSettingsPerson();
                                                    break;
                                                case 1:
                                                    DrawSettingsMap();
                                                    break;
                                                case 2:
                                                    DrawSettingsEnemy();
                                                    break;
                                            }
                                            break;
                                        case ConsoleKey.S:
                                            if (countSettings < 2) { countSettings++; }
                                            switch (countSettings)
                                            {
                                                case 0:
                                                    DrawSettingsPerson();
                                                    break;
                                                case 1:
                                                    DrawSettingsMap();
                                                    break;
                                                case 2:
                                                    DrawSettingsEnemy();
                                                    break;
                                            }
                                            break;
                                        case ConsoleKey.Enter:
                                            switch (countSettings)
                                            {
                                                case 0:
                                                    int countPerson = 0;
                                                    bool isBreakPerson = true;
                                                    int countName = 0;
                                                    int countSymbol = 0;
                                                    int countColor = 1;
                                                    DrawPersonName();
                                                    DrawDynamicStandardPerson(settings);
                                                    while (isBreakPerson)
                                                    {
                                                        ConsoleKeyInfo keyPerson = Console.ReadKey(true);
                                                        switch (keyPerson.Key)
                                                        {
                                                            case ConsoleKey.W:
                                                                if (countPerson > 0) { countPerson--; }
                                                                switch (countPerson)
                                                                {
                                                                    case 0:
                                                                        DrawPersonName();
                                                                        DrawDynamicStandardPerson(settings);
                                                                        break;
                                                                    case 1:
                                                                        DrawPersonSymbol();
                                                                        DrawDynamicStandardPerson(settings);
                                                                        break;
                                                                    case 2:
                                                                        DrawPersonColor();
                                                                        DrawDynamicStandardPerson(settings);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.S:
                                                                if (countPerson < 2) { countPerson++; }
                                                                switch (countPerson)
                                                                {
                                                                    case 0:
                                                                        DrawPersonName();
                                                                        DrawDynamicStandardPerson(settings);
                                                                        break;
                                                                    case 1:
                                                                        DrawPersonSymbol();
                                                                        DrawDynamicStandardPerson(settings);
                                                                        break;
                                                                    case 2:
                                                                        DrawPersonColor();
                                                                        DrawDynamicStandardPerson(settings);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.A:
                                                                switch (countPerson)
                                                                {
                                                                    case 0:
                                                                        if (countName > 0) { countName--; }
                                                                        DrawDynamicChangePerson(settings, countPerson, countName);
                                                                        break;
                                                                    case 1:
                                                                        if (countSymbol > 0) { countSymbol--; }
                                                                        DrawDynamicChangePerson(settings, countPerson, countSymbol);
                                                                        break;
                                                                    case 2:
                                                                        if (countColor > 1) { countColor--; }
                                                                        DrawDynamicChangePerson(settings, countPerson, countColor);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.D:
                                                                switch (countPerson)
                                                                {
                                                                    case 0:
                                                                        if (countName < 9) { countName++; }
                                                                        DrawDynamicChangePerson(settings, countPerson, countName);
                                                                        break;
                                                                    case 1:
                                                                        if (countSymbol < 5) { countSymbol++; }
                                                                        DrawDynamicChangePerson(settings, countPerson, countSymbol);
                                                                        break;
                                                                    case 2:
                                                                        if (countColor < 14) { countColor++; }
                                                                        DrawDynamicChangePerson(settings, countPerson, countColor);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.Escape:
                                                                isBreakPerson = false;
                                                                countSettings = 0;
                                                                DrawSettingsPerson();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case 1:
                                                    int countMap = 0;
                                                    bool isBreakMap = true;
                                                    int countWidth = settings.Width;
                                                    int countHeight = settings.Height;
                                                    int countRooms = settings.CountRooms;
                                                    DrawMapWidth();
                                                    DrawDynamicStandardMap(settings);
                                                    while (isBreakMap)
                                                    {
                                                        ConsoleKeyInfo keyMap = Console.ReadKey(true);
                                                        switch (keyMap.Key)
                                                        {
                                                            case ConsoleKey.W:
                                                                if (countMap > 0) { countMap--; }
                                                                switch (countMap)
                                                                {
                                                                    case 0:
                                                                        DrawMapWidth();
                                                                        DrawDynamicStandardMap(settings);
                                                                        break;
                                                                    case 1:
                                                                        DrawMapHeight();
                                                                        DrawDynamicStandardMap(settings);
                                                                        break;
                                                                    case 2:
                                                                        DrawMapCountRooms();
                                                                        DrawDynamicStandardMap(settings);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.S:
                                                                if (countMap < 2) { countMap++; }
                                                                switch (countMap)
                                                                {
                                                                    case 0:
                                                                        DrawMapWidth();
                                                                        DrawDynamicStandardMap(settings);
                                                                        break;
                                                                    case 1:
                                                                        DrawMapHeight();
                                                                        DrawDynamicStandardMap(settings);
                                                                        break;
                                                                    case 2:
                                                                        DrawMapCountRooms();
                                                                        DrawDynamicStandardMap(settings);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.A:
                                                                switch (countMap)
                                                                {
                                                                    case 0:
                                                                        if (countWidth > settings.minWidth) { countWidth -= 5; }
                                                                        DrawDynamicChangeMap(settings, countMap, countWidth);
                                                                        break;
                                                                    case 1:
                                                                        if (countHeight > settings.minHeight) { countHeight -= 5; }
                                                                        DrawDynamicChangeMap(settings, countMap, countHeight);
                                                                        break;
                                                                    case 2:
                                                                        if (countRooms > settings.minRooms) { countRooms--; }
                                                                        DrawDynamicChangeMap(settings, countMap, countRooms);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.D:
                                                                switch (countMap)
                                                                {
                                                                    case 0:
                                                                        if (countWidth < settings.maxWidth) { countWidth += 5; }
                                                                        DrawDynamicChangeMap(settings, countMap, countWidth);
                                                                        break;
                                                                    case 1:
                                                                        if (countHeight < settings.maxHeight) { countHeight += 5; }
                                                                        DrawDynamicChangeMap(settings, countMap, countHeight);
                                                                        break;
                                                                    case 2:
                                                                        if (countRooms < settings.maxRooms) { countRooms++; }
                                                                        DrawDynamicChangeMap(settings, countMap, countRooms);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.Escape:
                                                                isBreakMap = false;
                                                                countSettings = 1;
                                                                DrawSettingsMap();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    int countEnemy = 0;
                                                    bool isBreakEnemy = true;
                                                    int colorBoss = 1;
                                                    int colorSnake = 1;
                                                    int colorKobalt = 1;
                                                    DrawPersonName();
                                                    DrawDynamicStandardEnemy(settings);
                                                    while (isBreakEnemy)
                                                    {
                                                        ConsoleKeyInfo keyEnemy = Console.ReadKey(true);
                                                        switch (keyEnemy.Key)
                                                        {
                                                            case ConsoleKey.W:
                                                                if (countEnemy > 0) { countEnemy--; }
                                                                switch (countEnemy)
                                                                {
                                                                    case 0:
                                                                        DrawPersonName();
                                                                        DrawDynamicStandardEnemy(settings);
                                                                        break;
                                                                    case 1:
                                                                        DrawPersonSymbol();
                                                                        DrawDynamicStandardEnemy(settings);
                                                                        break;
                                                                    case 2:
                                                                        DrawPersonColor();
                                                                        DrawDynamicStandardEnemy(settings);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.S:
                                                                if (countEnemy < 2) { countEnemy++; }
                                                                switch (countEnemy)
                                                                {
                                                                    case 0:
                                                                        DrawPersonName();
                                                                        DrawDynamicStandardEnemy(settings);
                                                                        break;
                                                                    case 1:
                                                                        DrawPersonSymbol();
                                                                        DrawDynamicStandardEnemy(settings);
                                                                        break;
                                                                    case 2:
                                                                        DrawPersonColor();
                                                                        DrawDynamicStandardEnemy(settings);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.A:
                                                                switch (countEnemy)
                                                                {
                                                                    case 0:
                                                                        if (colorBoss > 1) { colorBoss--; }
                                                                        DrawDynamicChangeEnemy(settings, countEnemy, colorBoss);
                                                                        break;
                                                                    case 1:
                                                                        if (colorSnake > 1) { colorSnake--; }
                                                                        DrawDynamicChangeEnemy(settings, countEnemy, colorSnake);
                                                                        break;
                                                                    case 2:
                                                                        if (colorKobalt > 1) { colorKobalt--; }
                                                                        DrawDynamicChangeEnemy(settings, countEnemy, colorKobalt);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.D:
                                                                switch (countEnemy)
                                                                {
                                                                    case 0:
                                                                        if (colorBoss < 14) { colorBoss++; }
                                                                        DrawDynamicChangeEnemy(settings, countEnemy, colorBoss);
                                                                        break;
                                                                    case 1:
                                                                        if (colorSnake < 14) { colorSnake++; }
                                                                        DrawDynamicChangeEnemy(settings, countEnemy, colorSnake);
                                                                        break;
                                                                    case 2:
                                                                        if (colorKobalt < 14) { colorKobalt++; }
                                                                        DrawDynamicChangeEnemy(settings, countEnemy, colorKobalt);
                                                                        break;
                                                                }
                                                                break;
                                                            case ConsoleKey.Escape:
                                                                isBreakEnemy = false;
                                                                countSettings = 2;
                                                                DrawSettingsEnemy();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }
                                            break;
                                        case ConsoleKey.Escape:
                                            isBreakSettings = false;
                                            count = 1;
                                            DrawMenuSettings();
                                            break;
                                    }
                                }

                                break;
                            case 2:
                                Record record;
                                fullPath = Path.GetFullPath("RecordGame.json");

                                if (File.Exists(fullPath))
                                {
                                    string json = File.ReadAllText(fullPath);
                                    record = JsonConvert.DeserializeObject<Record>(json);
                                }
                                else
                                {
                                    record = new Record();
                                }

                                if(record != null)
                                {
                                    DrawRecord(record);
                                    ConsoleKey keyInfo = Console.ReadKey(true).Key;

                                    switch(keyInfo)
                                    {
                                        default:
                                            break;
                                    }
                                }
                                count = 2;
                                DrawMenuRecord();
                                break;
                            case 3:
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

        private static void DrawDynamicStandardPerson(Settings settings)
        {
            Console.SetCursorPosition(57, 14);
            Console.Write(settings.PlayerName);
            Console.SetCursorPosition(59, 16);
            Console.Write(settings.PlayerSymbol);
            Console.SetCursorPosition(58, 18);
            Console.ForegroundColor = settings.PlayerColor;
            Console.Write(settings.PlayerSymbol);
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawDynamicChangePerson(Settings settings, int key, int index)
        {
            if (key == 0)
            {
                Console.SetCursorPosition(57, 14);
                Console.Write(settings.PlayerNames[index]);
                settings.PlayerName = settings.PlayerNames[index];
                Console.SetCursorPosition(0, 0);
            }
            else if (key == 1)
            {
                Console.SetCursorPosition(59, 16);
                Console.Write(settings.PlayerSymbols[index]);
                settings.PlayerSymbol = settings.PlayerSymbols[index];
                Console.SetCursorPosition(0, 0);
            }
            else if (key == 2)
            {
                Console.SetCursorPosition(58, 18);
                Console.ForegroundColor = (ConsoleColor)index;
                Console.Write(settings.PlayerSymbol);
                Console.ResetColor();
                settings.PlayerColor = (ConsoleColor)index;
                Console.SetCursorPosition(0, 0);
            }
        }

        private static void DrawDynamicStandardMap(Settings settings)
        {
            Console.SetCursorPosition(57, 14);
            Console.Write(settings.Width);
            Console.SetCursorPosition(58, 16);
            Console.Write(settings.Height);
            Console.SetCursorPosition(61, 18);
            Console.Write(settings.CountRooms);
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawDynamicStandardEnemy(Settings settings)
        {
            Console.SetCursorPosition(57, 14);
            Console.ForegroundColor = settings.ColorBoss;
            Console.Write('B');
            Console.ResetColor();
            Console.SetCursorPosition(59, 16);
            Console.ForegroundColor = settings.ColorSnake;
            Console.Write('S');
            Console.ResetColor();
            Console.SetCursorPosition(58, 18);
            Console.ForegroundColor = settings.ColorKobalt;
            Console.Write('K');
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawDynamicChangeEnemy(Settings settings, int key, int color)
        {
            if (key == 0)
            {
                Console.SetCursorPosition(57, 14);
                Console.ForegroundColor = (ConsoleColor)color;
                settings.ColorBoss = (ConsoleColor)color;
                Console.Write('B');
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
            }
            else if (key == 1)
            {
                Console.SetCursorPosition(59, 16);
                Console.ForegroundColor = (ConsoleColor)color;
                settings.ColorSnake = (ConsoleColor)color;
                Console.Write('S');
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
            }
            else if (key == 2)
            {
                Console.SetCursorPosition(58, 18);
                Console.ForegroundColor = (ConsoleColor)color;
                settings.ColorKobalt = (ConsoleColor)color;
                Console.Write('K');
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
            }
        }

        private static void DrawDynamicChangeMap(Settings settings, int key, int changedData)
        {
            if (key == 0)
            {
                Console.SetCursorPosition(59, 14);
                Console.Write(' ');
                Console.SetCursorPosition(57, 14);
                Console.Write(changedData);
                settings.Width = changedData;
                Console.SetCursorPosition(0, 0);
            }
            else if (key == 1)
            {
                Console.SetCursorPosition(60, 16);
                Console.Write(' ');
                Console.SetCursorPosition(58, 16);
                Console.Write(changedData);
                settings.Height = changedData;
                Console.SetCursorPosition(0, 0);
            }
            else if (key == 2)
            {
                Console.SetCursorPosition(62, 18);
                Console.Write(' ');
                Console.SetCursorPosition(61, 18);
                Console.Write(changedData);
                settings.CountRooms = changedData;
                Console.SetCursorPosition(0, 0);
            }
        }
        private static void DrawExit()
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
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║          Record           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("║    ║      Exit       ║    ║");
            Console.SetCursorPosition(set_x, 22);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 23);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawNewGame()
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
            Console.Write("║          Record           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("║           Exit            ║");
            Console.SetCursorPosition(set_x, 22);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 23);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawMenuSettings()
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
            Console.Write("║          Record           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("║           Exit            ║");
            Console.SetCursorPosition(set_x, 22);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 23);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawMenuRecord()
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
            Console.Write("║    ║     Record      ║    ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("║           Exit            ║");
            Console.SetCursorPosition(set_x, 22);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 23);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawSettingsPerson()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║          Settings         ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║    ║     Person      ║    ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║          Map              ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║          Enemy            ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawSettingsMap()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║          Settings         ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║          Person           ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ║     Map         ║    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║          Enemy            ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawSettingsEnemy()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║          Settings         ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║          Person           ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║          Map              ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ║     Enemy       ║    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawPersonName()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║          Person           ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║    ║     Name:       ║    ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║          Symbol:          ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║          Color:           ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }



        private static void DrawPersonSymbol()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║          Person           ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║          Name:            ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ║     Symbol:     ║    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║          Color:           ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawPersonColor()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║          Person           ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║          Name:            ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║          Symbol:          ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ║     Color:      ║    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawMapWidth()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║            Map            ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║    ║    Width:       ║    ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║         Height:           ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║       Count rooms:        ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawMapHeight()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║            Map            ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║         Width:            ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ║    Height:      ║    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║       Count rooms:        ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawMapCountRooms()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║            Map            ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║         Width:            ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║         Height:           ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ║  Count rooms:   ║    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawEnemyBoss()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║           Enemy           ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║    ║      Boss:      ║    ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║          Snake:           ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║          Kobalt:          ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawEnemySnake()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║           Enemy           ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║           Boss:           ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ║     Snake:      ║    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║          Kobalt:          ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawEnemyKobalt()
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║           Enemy           ║");
            Console.SetCursorPosition(set_x, 12);
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║           Boss:           ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║          Snake:           ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ║     Kobalt:     ║    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawMenuInGameExit()
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
            Console.Write("║         Continue          ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║         Settings          ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║    ║   Close Game    ║    ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawRecord(Record record)
        {
            int set_x = 40;
            Console.Clear();
            Console.SetCursorPosition(set_x, 10);
            Console.Write("╔═══════════════════════════╗");
            Console.SetCursorPosition(set_x, 11);
            Console.Write("║          Record           ║");
            Console.SetCursorPosition(set_x, 12); 
            Console.Write("╠═══════════════════════════╣");
            Console.SetCursorPosition(set_x, 13);
            Console.Write("║          Name:            ║");
            Console.SetCursorPosition(set_x, 14);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 15);
            Console.Write("║          MapLevel:        ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║          Kills:           ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(57, 13);
            Console.Write(record.Name);
            Console.SetCursorPosition(61, 15);
            Console.Write(record.Level);
            Console.SetCursorPosition(58, 17);
            Console.Write(record.CountKills);
            Console.SetCursorPosition(0, 0);

        }

        private static void DrawMenuInGameContinue()
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
            Console.Write("║    ║    Continue     ║    ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║         Settings          ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║        Close Game         ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawMenuInGameSettings()
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
            Console.Write("║         Continue          ║");
            Console.SetCursorPosition(set_x, 16);
            Console.Write("║    ╔═════════════════╗    ║");
            Console.SetCursorPosition(set_x, 17);
            Console.Write("║    ║    Settings     ║    ║");
            Console.SetCursorPosition(set_x, 18);
            Console.Write("║    ╚═════════════════╝    ║");
            Console.SetCursorPosition(set_x, 19);
            Console.Write("║        Close Game         ║");
            Console.SetCursorPosition(set_x, 20);
            Console.Write("║                           ║");
            Console.SetCursorPosition(set_x, 21);
            Console.Write("╚═══════════════════════════╝");
            Console.SetCursorPosition(0, 0);
        }
    }
}
