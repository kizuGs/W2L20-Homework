using System;

namespace Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            //Użytkownik zostanie przywitany.
            //Dostanie możliwość wyboru akcji
            ///a. Stworzenie(dodanie) nowego zestawu tagów raportu
            ///b. Usunięcie wybranego  tagu z zestawu raportu
            ///c. Sprawdzenie tagow w zestawie raportu
            ///d. Zwrócenie listy wszystkich tagow zestawu raportu
            ///--e. Otwórz zestaw zapisanych tagow - wyswietl raport na ekranie - dane - pobranie z  bazy danych - kolejny etap 
            ///--f. Zapisz raport do pliku .CSV, .XLSX, .PDF itp. = kolejny etap

            /////a2 Zostanę poproszony o wprowadzenie wszystkich szczegółów id, tag, comment, unit
            /////b1 Zostanę poproszony o id tagu
            /////b2 Usunę ten tag z listy zestawu raportu
            /////c1 Zostanę poproszony o wprowadzenie id tagu
            /////c2 Wyswietlę wszystkie informacje związane z tym tagiem
            /////d1 Wyświetlę listę tagow zestawu raportu
            /////--e1 Zostanę poproszony o wybranie daty, godzinySTARTUraportu, rozdzielczosci, typu raportu: wartosci chwilowe lub srednie - kolejny etap 
            /////--e2 Wyswietlenie raportu tabela - kolejny etap 
            /////--f1 Mozlwiosc zapisu wyswietlonego raportu do pliku / export - kolejny etap 

            //inicjalizacja klasy MenuActionService
            MainMenuService actionService = new MainMenuService(); // --> init MenuActionService stworzenie obiektu

            TagService tagService = new TagService();
          
            //inicalizacja opcji menu
            actionService = Initialize(actionService);

            while (true)
            {
                //czyszczenie ekranu
                Console.Clear();
                //tworzenie menu programu
                Console.WriteLine("+++>> Welcome to Configurable Reports app ! <<+++\n");
                //wybierz co chcesz zrobić
                Console.WriteLine("\nPlease type number to navigate[1..5]:");

                var mainMenu = actionService.GetMenuActionsMenuName("Main"); // menu
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}, {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();


                //opcje programu
                switch (operation.KeyChar)
                {
                    case '1':
                        tagService.AddNewTag();
                        break;
                    case '2':
                        tagService.RemoveTag();
                        break;
                    case '3':
                        var detailId = tagService.TagDetailSelectionView();
                            tagService.TagDetailView(detailId);
                        break;
                    case '4':
                        tagService.ViewAllSetTag();
                        break;
                    case '5':
                        Exit();       
                        break;
                    case '6':
                        break;
                    case '7':
                        break;
                    default:
                        Console.WriteLine("\nAction you entered does not exist");
                        break;
                }
            }
        }

        

        public static void Exit()
        {
            Console.WriteLine("\nAre you sure you want exit the program");
            Console.WriteLine("\nPress the Y to exit or Any Key to back to Main Menu");
            string yesOrNo;

            yesOrNo = Console.ReadLine();

            if (yesOrNo == "Y" || yesOrNo == "y")
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("You back to main menu, press any key");
            }
            Console.ReadKey();
           
        }
        private static MainMenuService Initialize(MainMenuService actionService)
        {
            //akcje dostępne w moim menu (Id, Name, MenuLevel)
            actionService.AddNewAction(1, "Add Tag to [Set Tag]", "Main");
            actionService.AddNewAction(2, "Remove Tag from [Set Tag]", "Main");
            actionService.AddNewAction(3, "Show details of Tag", "Main");
            actionService.AddNewAction(4, "List of Tags", "Main");
            actionService.AddNewAction(5, "Exit", "Main");
            actionService.AddNewAction(6, "TODO: Open report with getting values from database with input parameters", "Main");
            actionService.AddNewAction(7, "TODO: Save data to file", "Main");
            

            return actionService;

        }


    }
}
