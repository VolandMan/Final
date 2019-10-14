
using System;

namespace PrinceofPersia
{
    class ConsolePrompt
    {
        string Cmd = "";

        public void ConsolePrmpt(Map map, Player player)
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write(@"\>");
            Cmd = Console.ReadLine();
            switch (Cmd)
            {
                case "list map":
                    map.ListMaps("save list"); // список карт
                    break;
                case "save l": // загрузится с точки добавить возможность загрузки

                    break;
                case "money": // добавить деньги
                    player.PlayerScore += 100;
                    break;
                case "health": // добавить жизни
                    player.PlayerLives++;
                    break;
            }
            Console.Clear();
        }
    }
}
