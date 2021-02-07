using System;
using System.Collections.Generic;

namespace Ex4
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()

        //1.Hur ​​fungerar ​​​stacken ​​​och ​​​heapen​ ?​​Förklara​​ gärna ​​med​​ exempel ​​eller ​​skiss ​​på​​ dess grund läggande​​ funktion.
        //1.a).Stack -LIFO- Is a data collection that acts like a stack of books, last data added will be the first data removed. Has various methds for manipulating data like Push/Pop which adds/removes data from the stack.
        //1.b).Heap - An unorganized store of data that can be accessed any time. Heap also deals with Garbage Collection, making effective use of memory.Reference types always go to Heap.

        //2. ​​Vad ​​är ​​​Value​​Types​​​ repsektive Reference ​​Types​​​ och ​​vad​​ skiljer ​​dem ​​åt?
        // Value types are "simple" data types that are not objects, like char, bool, decimal, double, int. Reference Types are more complex data types, that usually occupy more memory and are defined by 
        // Classes, INterfaces, objects, delegates, string(strint is a reference type that acts like a value type).
        // The difference is that value types are simple/prmitive types like the bricks of lego, while the reference types are the more complex type, like a finished lego project. 

        //3.Följande​​metoder​​(​se​​bild​​nedan​)​​genererar​​olika​​svar.​​Den​​ första​​ returnerar ​​3,​​den andra​​ returnerar ​​4,​​varför?
        // In the first example, x is assigned the value 3, and irrespective of y, x's value does not change. This is passed by value.
        // In the second example, x is passed by refference, hence the value that x was referencing to was changed, so x was pointing at/referencing a new value.

        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        /// 

        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             * 
             * 
            */

            List<string> theList = new List<string>();
            var input = "";
            char nav = 'c';



            void Menu()
            {
                Console.WriteLine("Please enter '+' followed by a name or '-' followed by a name and the desired word to add to the list or '0' to exit ");
                Console.WriteLine($"The number of items is {theList.Count} and the list capacity is {theList.Capacity}");
                 input = Console.ReadLine();
            }

             void AddAndRemoveNames()
            {
                Console.WriteLine("Please enter '+' followed by a name or '-' followed by a name and the desired word to add to the list or '0' to exit ");
                var newInput = Console.ReadLine();
                var newVal = newInput.Substring(1);
                char zero = newInput[0];
                if(zero.ToString() == "+")
                {
                theList.Add(newVal);
                    Console.WriteLine($"The number of items is {theList.Count} and the list capacity is {theList.Capacity}");
                }
                else if (zero.ToString() == "-")
                {
                    var findIndex = theList.IndexOf(newVal);
                    if(findIndex >= 0)
                    {
                        theList.RemoveAt(findIndex);
                        Console.WriteLine($"The number of items is {theList.Count} and the list capacity is {theList.Capacity}");
                    }else
                    {
                        Console.WriteLine("Name does not exist.");
                        Menu();
                    }
                   
                } else if(zero.ToString() == "0")
                {
                    Environment.Exit(0);
                }
               
            }

          
            do
            {
                Menu();
                

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter '+' followed by a name or '-' followed by a name and the desired word to add to the list or '0' to exit ");
                }
                else
                {
                     nav = input[0];
                    string value = input.Substring(1);

                    switch (nav)
                    {
                        case '0':
                            Environment.Exit(0);
                            break;
                        case '+':
                            theList.Add(value);
                            Console.WriteLine($"The number of items is {theList.Count} and the list capacity is {theList.Capacity}");
                            
                            while (nav != 0)
                            {
                                AddAndRemoveNames();
                               
                                foreach (var item in theList)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine($"The number of items is {theList.Count} and the list capacity is {theList.Capacity}");
                            }
                                
                            break;
                        case '-':
                            var findIndex = theList.IndexOf(value);
                            if (findIndex >= 0)
                            {
                                theList.RemoveAt(findIndex);
                                Console.WriteLine($"The number of items is {theList.Count} and the list capacity is {theList.Capacity}");
                            }
                            else
                            {
                                Console.WriteLine("Name does not exist.");
                                Menu();
                            }
                            foreach (var item in theList)
                            {
                                Console.WriteLine(item);
                            }

                           
                            break;
                        default:
                            Console.WriteLine("Please enter only '+' or '-' and the desired word to add to the list or '0' to exit ");
                            break;
                    }
                }

            } while (nav != '0') ;

        }

        //1.​​​​​​​​​​​​​​​​Skriv​​klart​​implementationen​​av​​​ExamineList-metoden​​​så​​att​​undersökningen​​blirgenomförbar.
        //Done.

        //2.​​​​​​​​​​​​​​​​När​​ökar​​listans​​kapacitet?​​(Alltså​​den​​underliggande​​arrayens​​storlek)
        //The capacity increases with every addition of elements.

        //3.​​​​​​​​​​​​​​​​Med​​hur​​mycket​​ökar​​kapaciteten?
        //For every 4 elements in increases by 4 bytes.

        //4.​​​​​​​​​​​​​​​​Varför​​ökar​​inte​​listans​​kapacitet​​i​​samma​​takt​​som​​element​​läggs​​till?
        // Because the capacity is the computer memory and is counted in bytes, while the list counts the elements.

        //5.​​​​​​​​​​​​​​​​Minskar​​kapaciteten​​när​​element​​tas​​bort​​ur​​listan?
        //Yes, for every 4 elements removed, the capacity decreases by 4.

        //6.​​​​​​​​​​​​​​​​När​​är​​det​​då​​fördelaktigt​​att​​använda​​en​​egendefinierad​​​array​​​istället​​för​​en​​lista?
        //When the length of the array is known.


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
            * Loop this method untill the user inputs something to exit to main menu.
            * Create a switch with cases to enqueue items or dequeue items
            * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
           */

            Queue<string> names = new Queue<string> { };

            var input = "";
            var userInput = "";
      
            void Menu()
            {
                Console.WriteLine("1.Press 1 to add a name to the queue");
                Console.WriteLine("2.Press 2 to remove a name from the queue");
                Console.WriteLine("3.Press 0 to exit the program");
                Console.WriteLine($"The number of items is {names.Count}");
                input = Console.ReadLine();
            }

            do
            {
                Menu();

                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid number!");
                    Menu();
                }
                else
                {
                    switch (input)
                    {
                        case "0":
                            Environment.Exit(0);
                            break;
                        case "1":

                            Console.WriteLine("Please enter names to be added to Queue below.");
                          
                            while (userInput != "0")
                            { 
                                userInput = Console.ReadLine();
                                if(userInput == "0")
                                {
                                    Environment.Exit(0);
                                } else if(userInput == "2")
                                {
                                    if(names.Count > 0)
                                    {
                                         names.Dequeue();
                                        foreach (var item in names)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine($"The number of items is {names.Count}");
                                    }else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Queus is empty!");
                                        Menu();
                                    }
                                   
                                }else 
                                {
                                    names.Enqueue(userInput);

                                    foreach (var item in names)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.WriteLine($"The number of items is {names.Count} ");
                                }
                               
                            }

                            break;
                        case "2":
                            if (names.Count > 0)
                            {
                                names.Dequeue();
                                foreach (var item in names)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine($"The number of items is {names.Count}");
                            }else
                            {
                                Console.Clear();
                                Console.WriteLine("Queue is empty!");
                                Menu();
                            }

                            break;
                        default:
                            Console.WriteLine("Please enter only '1' to add names to Queue or '2' to delete names from queue or '0' to exit ");

                            break;
                    }
                }

                
            } while (input != "0");
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Console.WriteLine("1.Press 1 to add a name to the stack");
            Console.WriteLine("2.Press 0 to exit the program");

            Stack<string> myStack = new Stack<string>();
            string input = Console.ReadLine();




            switch (input)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    var newInput = Console.ReadLine();
                    myStack.Push(input);
                    Console.WriteLine(myStack);
                    Console.WriteLine(myStack.Count);
                    ReverseText(newInput);
                    break;

                default:
                    Console.WriteLine("Please enter only '1' to add names to stack or '0' to exit ");

                    break;
            }

            static string ReverseText(string str)
            {
                return str;
            }

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


        }

        static void  CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            //var list = new List<int>;
            //var qu = new Queue<char>;
            //var st = new Stack<char>;
            //var newList = List<char>;

            //foreach (var num in list)
            //{
                
               
            //    if (num == "(" || item == ")" || item == "{" || item == "}" || item == "[" || item == "]")
            //    {
            //        qu.Enqueue(item);
            //        st.Push(item);
            //    }
            //}


            //if (qu.Count != st.Count)
            //{
            //    Console.WriteLine( "Pharanteses don't macth");
            //}
            //else
            //{
            //    char left = qu.Dequeue();
            //    char right = st.Pop();
            //    if (left == right)
            //    {
            //        return "Pharantheses match";
            //    }
            //    else
            //    {
            //        return "Pharantheses don't macth";
            //    }
            //}
         

        }

    }
}

