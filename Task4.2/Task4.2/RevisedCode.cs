using System;
using System.Collections.Generic;
using System.Text;

namespace Task4._2
{
    class RevisedCode
    {
        //enum
        enum MenuOption
        {
            AddCat,
            RemoveCat,
            AddTask,
            DeleteTask,
            SetPriority,
            MoveTask,
            HighLight,
            Quit
        }
        static void Main(string[] args)
        {
            //Create a list that hold all category
            CatList Category = new CatList();
            string[] Personal = { "Volvo", "BMW", "Ford", "Mazda" };
            string[] Work = new string[0];
            string[] Family = new string[0];
            Category.AddCategory(Personal, "Personal");
            Category.AddCategory(Work, "Work");
            Category.AddCategory(Family, "Family");

            bool state = true;
            while (state)
            {
                // Clear table and identify max
                Console.Clear();
                int max = 0;

                for (int i = 0; i < Category.CateList.Count; i++)
                {
                    if (Category.CateList[i].Length > max)
                    {
                        max = Category.CateList[i].Length;
                    }
                }


                //Write table
                Console.ForegroundColor = ConsoleColor.Blue;
                WriteTable(Category);

                //Write row
                WriteRow(Category, max);




                Console.ResetColor();

                MenuOption option = ReadUserOption();
                switch (option)
                {
                    case MenuOption.AddCat:
                        DoAdd(Category);
                        break;
                    case MenuOption.RemoveCat:
                        DoRemove(Category);
                        break;
                    case MenuOption.AddTask:
                        AddTask(Category);
                        break;
                    case MenuOption.DeleteTask:
                        DeleteTask(Category);
                        break;
                    case MenuOption.SetPriority:
                        SetPriority(Category);
                        break;
                    case MenuOption.MoveTask:
                        MoveTask(Category);
                        break;
                    case MenuOption.HighLight:
                        DoHighlight(Category);
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Quitting...............");
                        state = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        Console.WriteLine();
                        break;
                }
                }
        }

        //Methods
        static MenuOption ReadUserOption()
        {
            try
            {
                int option;
                do
                {
                    Console.WriteLine("Select an option: ");
                    Console.WriteLine(" -- 1. Add Category");
                    Console.WriteLine(" -- 2. Remove Category");
                    Console.WriteLine(" -- 3. Add Task");
                    Console.WriteLine(" -- 4. Delete Task");
                    Console.WriteLine(" -- 5. Set Priority");
                    Console.WriteLine(" -- 6. Move Task");
                    Console.WriteLine(" -- 7. Highlight");
                    Console.WriteLine(" -- 8. Quit");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                while (option < 1 || option > 8);
                Console.WriteLine("Option " + (option) + " selected");
                return (MenuOption)(option - 1);
            }
            catch (Exception)
            {
                Console.WriteLine("Error!Please select an option");
                return ReadUserOption();
            }
        }

        //Perform the add operation
        static void DoAdd(CatList category)
        {
            try
            {
                String name;

                Console.WriteLine("Please enter new category name: ");
                name = Console.ReadLine();
                String[] Test = new string[0];
                category.AddCategory(Test, name);
                Console.WriteLine("Category added.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter valid value");
            }
        }


        // Perform remove operation on category
        static void DoRemove(CatList category)
        {
            try
            {
                String name;
                int index;

                Console.WriteLine("Please enter the category you want to delete: ");
                name = Console.ReadLine();
                index = category.GetIndex(name);
                if (index >= 0)
                {
                    category.RemoveCategory(index, name);
                    Console.WriteLine("Category removed.");
                }
                else
                {
                    Console.WriteLine("Category you're looking for doesn't exist.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Please enter valid value");
            }
        }

        //Delete a task
        static void DeleteTask(CatList category)
        {
            int index;
            int index2;

            // Choose category
            index = ChooseCate(category);

            // Choose task
            index2 = ChooseTask(category, index);

            // Do the delete
            DoDelete(category, index, index2);
        }

        // Format to read user input
        static string ReadString (string text)
        {
            Console.WriteLine(text);
            Console.Write(">> ");
            return Console.ReadLine();
        }

        //Draw the starting table
        static void WriteTable(CatList category)
        {
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', category.rowMax));
            Console.Write("{0,10}|", "item #");
            for (int i = 0; i < category.NameList.Count; i++)
            {
                Console.Write("{0,30}|", category.NameList[i]);
            }
            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) + new string('-', category.rowMax));
        }

        //Draw all the rows
        static void WriteRow(CatList category, int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", i);

                for (int j = 0; j < category.CateList.Count; j++)
                {
                    if (category.CateList[j].Length > i)
                    {
                        //Place to print due date, default as current time for now
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0,10}", DateTime.Now.ToString("dd-MM-yyyy"));
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int k = 0; k < category.Index.Count; k++)
                        {
                            //If highlighted then change to color red then write.
                            if (category.Index[k] == j && category.Index2[k] - 1 == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                        }
                        Console.Write("{0,20}|", category.CateList[j][i]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0,10}", "N/A");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0,20}|", "N/A");
                    }
                }
                Console.WriteLine();
            }
        }

        //Add task
        static void AddTask(CatList category)
        {
            string type;
            string task;
            int index;

            //Ask for category and body content
            type = ReadString("In which category do you want to ask your task?");
            index = category.GetIndex(type);
            task = ReadString("Describe your task below (max. 20 symbols).");

            //Only display up to 30 char
            if (task.Length > 20)
            {
                task = task.Substring(0, 30);
            }

            category.CateList[index] = rowContent(category.CateList[index], task);
        }


        //Move tasks
        static void MoveTask(CatList category)
        {
            string task;
            int index;
            int index2;
            int index3;

            //Choose the task to move
            Console.WriteLine("First choose which task to transfer");
            Console.WriteLine();
            index = ChooseCate(category);
            index2 = ChooseTask(category, index);
            task = category.CateList[index][index2 - 1];

            //Choose destination category and add that task
            Console.WriteLine("Now where do you want to transfer?");
            index3 = ChooseCate(category);
            category.CateList[index3] = rowContent(category.CateList[index3], task);

            //Detele old task after move complete
            DoDelete(category, index, index2);
        }

        //Find index for category
        static int ChooseCate (CatList category)
        {
            string name;
            int index;

            name = ReadString("Which category?");
            index = category.GetIndex(name);
            return index;
        }

        //Find index for task
        static int ChooseTask(CatList category, int index)
        {
            int index2;
            //Print out Tasks available in that category
            Console.WriteLine("0: Exit");
            Console.WriteLine();
            for (int i = 0; i < category.CateList[index].Length; i++)
            {
                Console.Write(i + 1 + ": ");
                Console.WriteLine(category.CateList[index][i]);
                Console.WriteLine();
            }

            index2 = Convert.ToInt32(ReadString("Which task you want to choose?"));

            return index2;
        }

        static void DoDelete(CatList category,int index, int index2)
        {
            bool match = false;
            string[] test = null;
            test = new string[category.CateList[index].Length - 1];

            // Quit if input is 0
            if (index2 == 0)
            {
                return;
            }

            // before match, same data
            for (int i = 0; i < category.CateList[index].Length - 1; i++)
            {
                if (i != index2 - 1 && !match)
                {
                    test[i] = category.CateList[index][i];
                }
                //after match, test index is original index + 1, change match to true
                else
                {
                    test[i] = category.CateList[index][i + 1];
                    match = true;
                }
            }
            //Replace old array with new array
            category.CateList[index] = test;
        }



        //Highlight
        static void DoHighlight(CatList category)
        {
            int index;
            int index2;
            index = ChooseCate(category);
            index2 = ChooseTask(category, index);
            category.HighlightIndex(index, index2);
        }

        static void SetPriority(CatList category)
        {
            int index;
            int index2;

            index = ChooseCate(category);
            index2 = ChooseTask(category, index);

            // new string to hold
            string[] ArrNew = null;
            ArrNew = new string[category.CateList[index].Length];
            // set priority value to 1st index 
            ArrNew[0] = category.CateList[index][index2 - 1];

            //Set the other indexes
            for (int j = 1; j < category.CateList[index].Length; j++)
            {
                if (j <= index2 - 1)
                {
                    ArrNew[j] = category.CateList[index][j - 1];
                }
                else
                {
                    ArrNew[j] = category.CateList[index][j];
                }
            }
            category.CateList[index] = ArrNew;
        }



        //Replace empty array with array that contain data
        static string[] rowContent(string[] text, string task)
        {
            string[] ArrNew = null;
            ArrNew = new string[text.Length + 1];
            for (int j = 0; j < text.Length; j++)
            {
                ArrNew[j] = text[j];
            }
            ArrNew[ArrNew.Length - 1] = task;
            return ArrNew;
        }

    }
}
