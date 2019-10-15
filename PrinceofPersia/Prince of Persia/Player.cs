using System;

namespace PrinceofPersia
{
    class Player
    {

        public char PlayerChar = '@';
        public int PlayerScore = 0;
        public int PlayerHealth = 0;
        public int PlayerLives = -1;  //-1 = unlimited теститровать
        public int PlayerX = 0;
        public int PlayerY = 0;
        private string LastKeyPress = "";

        public void MovePlayer(Player player, string key, Map map)
        {
            switch (key)  // Управление персонажем  по нажатию   стрелок
            {
                case "UpArrow":
                    if (map.MapChar[PlayerY - 1, PlayerX] != map.WallChar)
                    {
                        if (LastKeyPress == "DownArrow")
                        {
                            map.MapChar[PlayerY, PlayerX] = ' ';
                            map.MapChar[PlayerY - 1, PlayerX] = PlayerChar;
                            PlayerY -= 2;
                        }
                        else
                        {
                            map.MapChar[PlayerY, PlayerX] = ' ';
                            map.MapChar[PlayerY - 1, PlayerX] = PlayerChar;
                            PlayerY--;
                        }
                        LastKeyPress = "UpArrow";
                    }
                    break;
                case "DownArrow":
                    if (map.MapChar[PlayerY + 1, PlayerX] != map.WallChar)
                    {
                        if (LastKeyPress == "UpArrow")
                        {
                            map.MapChar[PlayerY, PlayerX] = ' ';
                            map.MapChar[PlayerY + 1, PlayerX] = PlayerChar;
                            PlayerY++;
                        }
                        else
                        {
                            map.MapChar[PlayerY, PlayerX] = ' ';
                            map.MapChar[PlayerY + 1, PlayerX] = PlayerChar;
                            PlayerY++;
                        }
                        LastKeyPress = "DownArrow";
                    }
                    break;
                case "LeftArrow":
                    if (map.MapChar[PlayerY, PlayerX - 1] != map.WallChar)
                    {
                        if (LastKeyPress == "RightArrow")
                        {
                            map.MapChar[PlayerY, PlayerX] = ' ';
                            map.MapChar[PlayerY, PlayerX - 1] = PlayerChar;
                            PlayerX -= 2;
                        }
                        else
                        {
                            map.MapChar[PlayerY, PlayerX] = ' ';
                            map.MapChar[PlayerY, PlayerX - 1] = PlayerChar;
                            PlayerX--;
                        }
                        LastKeyPress = "LeftArrow";
                    }
                    break;
                case "RightArrow":
                    if (map.MapChar[PlayerY, PlayerX + 1] != map.WallChar)
                    {
                        if (LastKeyPress == "LeftArrow")
                        {
                            map.MapChar[PlayerY, PlayerX + 1] = ' ';
                            map.MapChar[PlayerY, PlayerX + 2] = PlayerChar;
                            PlayerX += 2;
                        }
                        else
                        {
                            map.MapChar[PlayerY, PlayerX] = ' ';
                            map.MapChar[PlayerY, PlayerX + 1] = PlayerChar;
                            PlayerX++;
                        }
                        LastKeyPress = "RightArrow";
                    }
                    break;
            }

            if (PlayerX == map.ExitX && PlayerY == map.ExitY)
            {
                Console.Beep(3000, 50);
                Console.Beep(2500, 50);
                Console.Beep(3000, 50);
                Console.Beep(2000, 50);
                Console.Beep(3000, 50);
                Console.Beep(1500, 50);
                map.MapNo++;
                if (map.MapNo == 4)
                {
                    
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.Write(@"
╔═══╦══╦╗──╔╦═══╗
║╔══╣╔╗║║──║║╔══╝
║║╔═╣╚╝║╚╗╔╝║╚══╗
║║╚╗║╔╗║╔╗╔╗║╔══╝
║╚═╝║║║║║╚╝║║╚══╗
╚═══╩╝╚╩╝──╚╩═══╝
 ╔══╦╗╔╦═══╦═══╦╗
 ║╔╗║║║║╔══╣╔═╗║║
 ║║║║║║║╚══╣╚═╝║║
 ║║║║╚╝║╔══╣╔╗╔╩╝
 ║╚╝╠╗╔╣╚══╣║║║╔╗
 ╚══╝╚╝╚═══╩╝╚╝╚╝ ");
                    Environment.Exit(1);
                }
                Console.Clear();
                Array.Clear(map.MapChar, 0, map.MapChar.Length);
                map.LoadMap(player, player.PlayerChar);
            }
            else if (map.LifeObjects[PlayerY, PlayerX] == map.LifeChar)
            {
                PlayerLives += map.LifeValue;
                map.LifeObjects[PlayerY, PlayerX] = ' ';
                Console.Beep(2000, 50);
                Console.Beep(3000, 50);
            }
            else if (map.CashObjects[PlayerY, PlayerX] == map.CashChar)
            {
                PlayerScore += map.CashValue;
                map.CashObjects[PlayerY, PlayerX] = ' ';
                Console.Beep(2000, 50);
                Console.Beep(3000, 50);
            }
        }
    }
}
