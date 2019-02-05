using System;
using System.Collections.Generic;

namespace CodeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Class> myProgram = new List<Class>();
            do
            {

                Console.WriteLine("Code Maker:");
                Console.WriteLine("Press C to make a Class");
                Console.WriteLine("Press P to add a Property");
                Console.WriteLine("Press M to add a Method");
                Console.WriteLine("Press A to show ALL code");
                // NOTE: add method to print all code

                ConsoleKeyInfo menuChoice = Console.ReadKey();
                Console.Clear();
                switch (menuChoice.Key)
                {
                    case ConsoleKey.M:
                        Method newMethod = MakeMethod();
                        Console.WriteLine(newMethod.ConcatedString());
                        myProgram[selectClass(myProgram)].Methods.Add(newMethod);
                        break;
                    case ConsoleKey.P:
                        Property newProperty = MakeProperty();
                        Console.WriteLine(newProperty.ConcatedString());
                        myProgram[selectClass(myProgram)].AddProperty(newProperty);
                        break;
                    case ConsoleKey.C:
                        Class newClass = MakeClass();
                        Console.WriteLine(newClass.ConcatedString());
                        myProgram.Add(newClass);
                        break;
                    case ConsoleKey.A:
                        ShowCode(myProgram);
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        static Class MakeClass()
        {
            Console.WriteLine("Class Creation:");

            // NOTE: Make way to get definitions
            // NOTE: Verify user put correct word
            // NOTE: Get rid of spaces in names
            Console.WriteLine("What level of visibility would you like for your class?");
            Console.WriteLine("(public, protected, private, or internal)");
            string visibility = Console.ReadLine();

            Console.WriteLine("What name would you like to call your class?");
            string name = Console.ReadLine();

            return new Class(visibility, name);
        }

        static Property MakeProperty()
        {
            Console.WriteLine("Property Creation:");

            Console.WriteLine("What level of visibility would you like for your class?");
            Console.WriteLine("(public, protected, private, or internal)");
            string visibility = Console.ReadLine();

            Console.WriteLine("What is the type of information do you want your property to hold?");
            Console.WriteLine("(int, string, decimal, <classname>, List<type>, etc.)");
            string type = Console.ReadLine();

            Console.WriteLine("What name would you like to call your property?");
            string name = Console.ReadLine();

            Console.WriteLine("Would you like your property value to be retrievable?");
            Console.WriteLine("(Yes or No)");
            string get = Console.ReadLine().ToLower();
            string getsecurity = "";
            if (get.Equals("yes"))
            {
                Console.WriteLine("What level of visibility would you like for your properties retrieve-ability?");
                Console.WriteLine("(public, protected, private, or internal)");
                getsecurity = Console.ReadLine();
            }

            Console.WriteLine("Would you like the ability to save a new value for your property?");
            Console.WriteLine("(Yes or No)");
            string set = Console.ReadLine().ToLower();
            string setsecurity = "";
            if (get.Equals("yes"))
            {
                Console.WriteLine("What level of visibility would you like for your properties save-ability?");
                Console.WriteLine("(public, protected, private, or internal)");
                getsecurity = Console.ReadLine();
            }

            return new Property(visibility, type, name, getsecurity, get, setsecurity, set);
        }

        static Method MakeMethod()
        {
            Console.WriteLine("Method Creation:");
            Console.WriteLine("What level of visibility would you like for your Method?");
            Console.WriteLine("(public, protected, private, or internal)");
            string visibility = Console.ReadLine();

            Console.WriteLine("What is the type of information do you want your method to give back to your program?");
            Console.WriteLine("(void, int, string, decimal, <classname>, List<type>, etc.)");
            string output = Console.ReadLine();

            Console.WriteLine("What name would you like to call your method?");
            string name = Console.ReadLine();

            Console.WriteLine("Do you need to provide your method with outside values in order for it to work?");
            Console.WriteLine("(Yes or No)");
            string inputtype = "";
            string inputname = "";
            if (Console.ReadLine().ToLower().Equals("yes"))
            {
                // NOTE: Make input class with properties for type and name, save in List<Input> for variability
                Console.WriteLine("What is the type of information do you need your method to be given?");
                Console.WriteLine("(int, string, decimal, <classname>, List<type>, etc.)");
                inputtype = Console.ReadLine();

                Console.WriteLine("What name would you like to call your this information?");
                inputname = Console.ReadLine();
            }

            return new Method(visibility, output, name, inputtype, inputname);
        }

        static int selectClass(List<Class> myProgram)
        {
            int itemNum = 1;
            foreach (Class item in myProgram)
            {
                Console.WriteLine(itemNum + ". " + item.Name);
                itemNum++;
            }

            Console.WriteLine("Which class would you like to put it in?");
            return Convert.ToInt32(Console.ReadLine()) - 1;
        }

        static void ShowCode(List<Class> myProgram)
        {
            foreach (Class classy in myProgram)
            {
                Console.WriteLine(classy.ConcatedString());
                Console.WriteLine("{");
                foreach (Property property in classy.Properties)
                {
                    Console.WriteLine(Indentation(1) +property.ConcatedString());
                    Console.WriteLine();
                }

                foreach (Method method in classy.Methods)
                {
                    Console.WriteLine(Indentation(1) + method.ConcatedString());
                    Console.WriteLine();
                }

                Console.WriteLine("}\n");
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        static string Indentation(int howManyTabs)
        {
            string indent = "";
            for (int i = 0; i < howManyTabs; i++)
            {
                indent += "    ";
            }

            return indent;
        }
    }

    
}

