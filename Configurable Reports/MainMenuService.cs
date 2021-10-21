using System;
using System.Collections.Generic;
using System.Text;

namespace Reports
{
    public class MainMenuService
    {
        //deklaracja listy MainMenu       
        private List<MainMenu> MainMenu;

        //prosty konstruktor, ponieważ lista ma modyfikator private potrzebny jest konstruktor
        //kazda klasa ma konstruktor, jesli nie utworzysz zostanie utworzony automatycznie
        public MainMenuService()
        {
            MainMenu = new List<MainMenu>();
        }
        //metody klasy MenuActionService
        public void AddNewAction(int id, string name, string menuName)
        {

            //konstruktor
            MainMenu menuAction = new MainMenu() 
            { 
                Id = id, 
                Name = name, 
                MenuLevel = menuName 
            };

            MainMenu.Add(menuAction);
        }

        public List<MainMenu> GetMenuActionsMenuName(string menuName)
        {
            List<MainMenu> result = new List<MainMenu>();

            foreach (var menuAction in MainMenu)
            {
                if (menuAction.MenuLevel == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
    }
}
