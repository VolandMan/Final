using System;

namespace PrinceofPersia
{
    class Game
    {

        static Map map = new Map();
        static Input input = new Input();
        static Player player = new Player();
        static UI ui = new UI();
        static Menu menu = new Menu();
        static ConsolePrompt console = new ConsolePrompt();

        //Thread UI = new Thread(ui.GameUI); // временно
        

        public static bool GameOver = false;
        public static int WindowWidth = 100;
        public static int WindowHeight = 100;
        public static int WindowBufferWidth = WindowWidth;
        public static int WindowBufferHeight = WindowHeight;
      //  public static string PlayerName = "nonname"; // если игрок не пнаписал имя

      //  private static string SaveFileDir = @"Data\Save\" + PlayerName + ".sav"; //сохраняем файлы результыты ... до конца не работает
        public static string WindowTitle = "Prince of Persia";


             public void GameLoop()
        {
            Console.Title = WindowTitle;
            WindowInitalize(70, 30, 0, 0);
            menu.MainMenu();
            //создаем  карту
            player.PlayerLives = 3;
            map.LoadMap(player, player.PlayerChar);
            Console.Clear();
            ui.Timer.Start();

            while (GameOver == false)
            {
                ui.GameUI(player);
                map.DrawMap(player.PlayerChar);
                input.GetInput(player, console, map);
            }
        }
        public static bool WindowInitalize(int width, int height, int backBufferWidth, int backBufferHeight)
        {
            WindowWidth = width;
            Console.WindowWidth = WindowWidth;
            WindowHeight = height;
            Console.WindowHeight = WindowHeight;
            if (backBufferWidth == 0 && backBufferHeight == 0)
            {
                WindowBufferWidth = WindowWidth;
                WindowBufferHeight = WindowHeight;
            }
            else
            {
                WindowBufferWidth = backBufferWidth;
                WindowBufferHeight = backBufferHeight;
            }
            Console.SetBufferSize(WindowBufferWidth, WindowBufferHeight);
            return true;
        }
    }
}
