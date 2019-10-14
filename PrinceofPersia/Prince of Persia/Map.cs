
using System;
using System.IO;
//using System.Windows.Forms;

namespace PrinceofPersia
{
    class Map
    {
        public int MapNo = 1;
        public char[,] MapChar;
        private char CurrentReadChar;
        private char CharToDraw;
        public char ExitChar = '%';
        public char CashChar = '£';
        public char LifeChar = '♥';
        public char WallChar = '#';
        public char[,] LifeObjects;
        public char[,] CashObjects;
        public string[] MapValues;
        private string[] MapList;
        private string MapListCmd;
        public int ExitX = 0;
        public int ExitY = 0;
        public int LifeValue = 1;
        public int CashValue = 5;
        private int MapX = 5;
        private int MapY = 5;

        public void LoadMap(Player player, char PlayerChar)
        {
            StreamReader fileLoader = new StreamReader(@"Data\Maps\Campaign\cmap" + MapNo + ".map");
            int lineCount = File.ReadAllLines(@"Data\Maps\Campaign\cmap" + MapNo + ".map").Length;
            int colsCount = fileLoader.ReadLine().Length;
            MapChar = new char[lineCount, colsCount];
            LifeObjects = new char[lineCount, colsCount];
            CashObjects = new char[lineCount, colsCount];
            //загружаем карту в масив из файла
            MapValues = File.ReadAllLines(@"Data\Maps\Campaign\cmap" + MapNo + ".map");
            //проверяем пресонажа
            for (int row = 0; row < MapChar.GetUpperBound(0) + 1; row++)  // парсим карту  из файла
            {
                for (int coll = 0; coll < MapChar.GetUpperBound(1) + 1; coll++)
                {
                    CurrentReadChar = MapValues[row][coll]; 
                    switch (CurrentReadChar)//1 = стенка, P = игрок, F = финиш, L = жихни, C = деньги
                    {
                        case '1':
                            MapChar[row, coll] = WallChar;
                            break;
                        case 'P':
                            MapChar[row, coll] = PlayerChar;
                            player.PlayerX = coll;
                            player.PlayerY = row;
                            break;
                        case 'F':
                            MapChar[row, coll] = ExitChar;
                            ExitX = coll;
                            ExitY = row;
                            break;
                        case 'L':
                            MapChar[row, coll] = LifeChar;
                            LifeObjects[row, coll] = LifeChar;
                            break;
                        case 'C':
                            MapChar[row, coll] = CashChar;
                            CashObjects[row, coll] = CashChar;
                            break;
                    }
                }
            }
        }
        /*
         *рисуем карту 
         */
        public void DrawMap(char PlayerChar)
        {
            for (int row = 0; row < MapChar.GetUpperBound(0) + 1; row++)
            {
                for (int coll = 0; coll < MapChar.GetUpperBound(1) + 1; coll++)
                {
                    // передаелать... 
                    //Console.SetCursorPosition(Console.WindowWidth / 2 - MapChar.GetUpperBound(0)+coll, Console.WindowHeight /2 - MapChar.GetUpperBound(1)+row);

                    Console.SetCursorPosition(MapX + coll, MapY + row);
                    CharToDraw = MapChar[row, coll];
                    if (CharToDraw == PlayerChar)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (CharToDraw == WallChar)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    else if (CharToDraw == ExitChar)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (CharToDraw == LifeChar)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (CharToDraw == CashChar)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(CharToDraw);
                }
                Console.WriteLine();
            }
        }
        /*
         * карта 
         */
        public void ListMaps(string type)
        {
            if (type == "компания")
            {
                Console.Clear();
                MapList = Directory.GetFiles(@"Data\Maps\Campaign\");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < MapList.Length; i++)
                {
                    Console.WriteLine(MapList[i]);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Загружаем карту) или 'Выход'");
                MapListCmd = Console.ReadLine();
                if (MapListCmd != "Выход")
                {
                    try
                    {
                        MapNo = int.Parse(MapListCmd);
                    }
                    catch { }
                }
            }
        }

    }
}
