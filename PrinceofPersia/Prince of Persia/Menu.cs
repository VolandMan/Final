
using System;

namespace PrinceofPersia
{
    class Menu
    {
        UI ui = new UI();
        Game game = new Game();
        Input input = new Input();
        ConsolePrompt console = new ConsolePrompt();
        Map map = new Map();


        public bool exitMenu = false;
        //меню список
        public int mMenuListSelectedId = 0;

        public void MainMenu()
        {
            while (exitMenu == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@" 
                     ╔═══╦═══╦══╦╗─╔╦══╦═══╗╔══╦══╗
                     ║╔═╗║╔═╗╠╗╔╣╚═╝║╔═╣╔══╝║╔╗║╔═╝
                     ║╚═╝║╚═╝║║║║╔╗─║║─║╚══╗║║║║╚═╗
                     ║╔══╣╔╗╔╝║║║║╚╗║║─║╔══╝║║║║╔═╝
                     ║║──║║║║╔╝╚╣║─║║╚═╣╚══╗║╚╝║║
                     ╚╝──╚╝╚╝╚══╩╝─╚╩══╩═══╝╚══╩╝
                     ╔═══╦═══╦═══╦══╦══╦══╗
                     ║╔═╗║╔══╣╔═╗║╔═╩╗╔╣╔╗║
                     ║╚═╝║╚══╣╚═╝║╚═╗║║║╚╝║
                     ║╔══╣╔══╣╔╗╔╩═╗║║║║╔╗║ 
                     ║║──║╚══╣║║║╔═╝╠╝╚╣║║║
                     ╚╝──╚═══╩╝╚╝╚══╩══╩╝╚╝ ");


                Console.WriteLine();

                ui.MainMenuList(mMenuListSelectedId);
                input.MainMenuList(this, ui, console, map);
            }
        }
    }
}
