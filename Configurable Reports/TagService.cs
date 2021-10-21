using System;
using System.Collections.Generic;
using System.Text;

namespace Reports
{
    public class TagService
    {
        public List<Tag> Tags { get; set; }

        //konstruktor
        public TagService()
        {
            Tags = new List<Tag>();
        }

        //Metody
        //Dodaj Tag do zestawu raportu
        public int AddNewTag()

        {
            
            Tag tag = new Tag();
            bool flag = false;
            int tagId = 0;
            int id;
            bool check; 
            //Pole 1
            do
            {
                Console.WriteLine("\nPlease enter id for new tag:");
                check = Int32.TryParse(Console.ReadLine(), out id);
                if (id <= 0 || id.ToString() == null)
                {
                    Console.WriteLine("Incorrect Id, Please enter the number");    
                }
                else
                {
                    Int32.TryParse(id.ToString(), out tagId);
                    flag = true;
                }
            }
            while (!flag);

            flag = false;
            //Pole 2
            string name;
            do
            {
                
                Console.WriteLine("Please enter name for new tag:");
                name = Console.ReadLine();
                
                if (name == "" || name == null)
                {
                    Console.WriteLine("Bad argument");
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Name OK");
                    flag = true;
                }

            }
            while (!flag);

            flag = false;
            //Pole 3
            string comment;
            do 
            { 
                Console.WriteLine("Please enter comment for new tag:");
                comment = Console.ReadLine();
                if (comment == "" || comment == null)
                {
                    Console.WriteLine("Bad argument");
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Comment OK");
                    flag = true;
                }

            }
            while (!flag);

            flag = false;
            //Pole 4
            Console.WriteLine("Please enter unit for new tag:");
                var unit = Console.ReadLine();

                tag.Id = tagId;
                tag.Name = name;
                tag.Comment = comment;
                tag.Unit = unit;

                Tags.Add(tag);

                return tagId;
        }
        //Wyswietl Zestaw Tagów raportu
        public void ViewAllSetTag()
        {
            var tmp = 0;
            Console.WriteLine($"\n      Report Set Tag     \r\n\nId | Tag | Comment            |  Unit");
            Console.WriteLine("*************************************");
            //Console.WriteLine($"1  | TT01| TEMP WODY Z KOTLA  | 'C");
            foreach (var tag in Tags)
            {
                Console.WriteLine(tag.Id + "  | " + tag.Name + " | " + tag.Comment + " | " + tag.Unit);
                if (Tags.Count == 0)
                {
                    tmp = 1;
                }
                
            }
            if (tmp==1)
            {
                Console.WriteLine("List is empty");
            }

            Console.ReadKey();
        }
        //Usuń Tag z zestawu raportu
        public void RemoveTag()
        {
            Console.WriteLine("\nPlease enter id for tag you want remove:");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);
           
            Tag tagToRemove = new Tag();

            foreach (var tag in Tags)
            {

                if (tag.Id == id)
                {
                    tagToRemove = tag;
                    break;
                }

            }
            Tags.Remove(tagToRemove);
            Console.WriteLine("\nTag with id: " + tagToRemove.Id  + " was removed" );
            Console.ReadKey();
        }
        //Wyświetl szczegóły tagu raportu
        public void TagDetailView(int detailId)
        {
            Tag tagInList = new Tag();
            foreach (var tag in Tags)
            {
                if (tag.Id == detailId)
                {
                    tagInList = tag;
                    break;
                }
            }
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"Tag id: {tagInList.Id }");
            Console.WriteLine($"Tag name: {tagInList.Name }");
            Console.WriteLine($"Tag comment: {tagInList.Comment}");
            Console.WriteLine($"Tag Unit: {tagInList.Unit }");
            Console.WriteLine("----------------------------------------");
           
            Console.WriteLine();
            //niezbedne do wyswietlenia, przed czyszczeniem ekranu
            Console.ReadKey();

        }
        public int TagDetailSelectionView()
        {
            Console.WriteLine("\nPlease enter id for item you want to show:");
            var itemId = Console.ReadKey();


            int id;

            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }

    }

    
}
