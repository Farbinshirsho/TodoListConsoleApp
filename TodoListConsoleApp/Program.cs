using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TodoListConsoleApp
{   
    internal class Program
    {
        static List<string> todos = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine();
            Console.WriteLine("what do you want to do?");
            Option();

        }
        public static void Option()
        {
            bool shallExit = false;
            while (!shallExit)
            {
                Console.WriteLine();
                Console.WriteLine("[S]ee all todos");
                Console.WriteLine("[A]dd a todos");
                Console.WriteLine("[R]emove a todos");
                Console.WriteLine("[E]xit todos");
                string UserChoice = Console.ReadLine().ToUpper();
                //List<string> UserInput = new List<string>();
                //string input;      
                switch (UserChoice)
                {
                    case "S":
                        SeeAllTodos();
                        break;
                    case "A":                       
                        AddTodos();                  
                        break;
                    case "R":
                        RemoveTodos();
                        break;
                    case "E":
                        shallExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
        }
        public static void AddTodos()
        {
            bool isValidDescription = false;
            while (!isValidDescription)
            {
                Console.WriteLine("Enter the todos description");
                string description = Console.ReadLine();

                if (description == "")
                {
                    Console.WriteLine("The description can not be empty");
                }
                else if (todos.Contains(description))
                {
                    Console.WriteLine("The description must be unique");
                }
                else
                {
                    isValidDescription = true;
                    todos.Add(description);
                }
            }
        }
        public static void SeeAllTodos()
        {
            if (todos.Count == 0)
            {
                Console.WriteLine("No TODOs have been added yet");
            }
            else
            {
                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine($"{i+1}.{todos[i]}"); //string interpolation
                }
            }
        }
        public static void RemoveTodos()
        {
            if (todos.Count == 0)
            {
                Console.WriteLine("No TODOs have been added yet");
                return;
            }
            bool isIndexValid = false;
            while (!isIndexValid)
            {
                //isIndexValid = true;
                Console.WriteLine("Select The Index of the todo you want to delete");
                SeeAllTodos();
                var userInput = Console.ReadLine();
                if(userInput == "")
                {
                    Console.WriteLine("selected index can not be empty");
                    continue;
                }
                if(int.TryParse(userInput , out int index) && index >=1 
                    && index <= todos.Count)
                {
                    var indexOfTodo = index - 1;
                    var todoToBeRemoved = todos[indexOfTodo];
                    todos.RemoveAt(indexOfTodo);
                    isIndexValid = true;
                    Console.WriteLine("TODO removed: {0}",todoToBeRemoved);
                }
                else
                {
                    Console.WriteLine("The Given Index is not valid");
                }

            }

        }
    }
}
