using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    internal class Todo
    {
        static void Main(string[] args)
        {
            string optionSelect;
            Console.WriteLine("Hello");
            List<string> AddToDO = new List<string>();


            do
            {
                Console.WriteLine("What do you want to do ?");
                Console.WriteLine("[S]ee all todos");
                Console.WriteLine("[A]dd a todo");
                Console.WriteLine("[R]emove a todo");
                Console.WriteLine("[E]xit");

               optionSelect = Console.ReadLine().ToUpper();

                switch (optionSelect)
                {
                    case "S":
                        SeeAllTodo();
                        break;
                    case "A":
                        AddTodo();
                        break;
                    case "R":
                        RemoveTodo();
                        break;
                    case "E":
                        Console.WriteLine("Press any key to exit");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while(optionSelect != "E");

            Console.ReadKey();


            void SeeAllTodo()
            {
                if(AddToDO.Count == 0)
                                {
                    Console.WriteLine("Your list is empty!!");
                }
                else
                                {
                    //for (int i = 0; i < AddToDO.Count; i++)
                    //{
                    //    Console.WriteLine($"{i + 1}. {AddToDO[i]}");
                    //}
                    var index = 1;
                    foreach (var item in AddToDO)
                    {
                        Console.WriteLine($"{index}. {item}");
                        index++;
                    }
                }
            }
            
            void AddTodo()
            {
                var isTrue = true;
                var addTOdo = "";
                do
                {
                    Console.WriteLine("Enter the Todo Description");
                    addTOdo = Console.ReadLine();

                    if (addTOdo.Length > 0)
                    {
                        if (AddToDO.Contains(addTOdo))
                        {
                            Console.WriteLine("Descriptions must be unique");
                        }
                        else
                        {
                            AddToDO.Add(addTOdo);
                            isTrue = false;

                        }
                    }
                    else
                    {
                        Console.WriteLine("the description cannot be empty");

                    }

                } while (isTrue);
                Console.WriteLine("TODO Successfully Added: " + addTOdo);
            }

            void RemoveTodo()
            {
                var isFalse = true;
                do
                {
                    Console.WriteLine("Select the Index of the TODO you want to Remove");
                    SeeAllTodo();
                    var acceptIndex = Console.ReadLine();
                    var convertIndex = int.Parse(acceptIndex);

                    if (convertIndex == 0)
                    {
                        Console.WriteLine("Selected Index cannot be empty.");
                    }
                    else
                    {
                        if (convertIndex != AddToDO.Count)
                        {
                            Console.WriteLine("The given Index is not valid!!.");
                        }
                        else
                        {
                            AddToDO.RemoveAt(convertIndex - 1);
                            SeeAllTodo();
                            isFalse = false;
                        }
                    }


                }while (isFalse);
            }
        }
    }
}
