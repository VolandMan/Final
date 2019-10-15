using System;
using System.Threading;

namespace PrinceofPersia
{
    class UI
    {
        public string[] mMenuList = new string[]
       {
            "В путь!",   "Загрузить игру", "Кредиты", "Выход" //  ввод с консоли ConsolePrompt
       };
        static Timer timer = new Timer();

        public Thread Timer = new Thread(timer.ReduceTime);

        public void GameUI(Player player)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Золото:    |   Жизни: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(6, 0);
            Console.Write("£{0}", player.PlayerScore);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 0);
            Console.Write("♥{0}", player.PlayerLives);
            Console.SetCursorPosition(30, 0);
            Console.Write("Кол-во: {0}", timer.Time);
        }
        public void MainMenuList(int selectedID)
        {
            for (int i = 0; i < mMenuList.Length; i++)
            {
                if (i == selectedID)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.SetCursorPosition(0, 4 + i);
                Console.WriteLine(mMenuList[i]);
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}