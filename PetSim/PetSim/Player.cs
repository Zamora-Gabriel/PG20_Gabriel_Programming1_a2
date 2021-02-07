using System;
using System.Collections.Generic;
using System.Text;

namespace PetSim
{
    class Player
    {
        //Variables
        public string Name { get; private set; }
        public int Money;
        public int petcount;

        //Constructor
        public Player()
        {
            //Starting money
            Name = " ";
            Money = 20;
            petcount = 0;
        }

        /*Public Methods*/
        public bool YourName(bool done)
        {
            while (!done)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Welcome to Pinata Island! Please type your name: ");
                Name = Console.ReadLine();

                Console.WriteLine("So... your name is {0}. Is that right? (Type yes or y if it is correct)", Name);
                string option = Console.ReadLine();

                if(option.ToLower() == "y" || option.ToLower() == "yes")
                {
                    Console.WriteLine("Well {0}, It is time for you to meet your new partner", Name);
                    return true;
                }
            }
            return true;
        }

        public void ChooseEgg(Egg myEgg)
        {
            bool error = false;
            Console.WriteLine("\n Please select the color of the egg you would like: ");
            
            //Change text color to white
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 - White");
            
            //Change text color to red
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2 - Red");
            
            //Change text color to blue
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3 - Blue");
            
            //Change text color to Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4 - Green");

            //Change text color to yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("5 - Yellow \n");

            //Cycle until a valid option is typed
            do
            {
                //Protect code from exceptions
                try
                {
                    int option = int.Parse(Console.ReadLine());

                    //call private validation function
                    error = ValidateEggOp(option, myEgg);
                }
                //If user types a non integer
                catch (FormatException)
                {
                    Console.WriteLine("Error: Typed an unrecognized symbol, please type a valid number");
                    error = true;
                }
                //protecting code if any other exception is found
                catch (Exception except)
                {
                    Console.WriteLine(except.Message);
                    error = true;
                }
            } while (error == true);

            Console.WriteLine("\n Your selected color was: {0} \n", myEgg.Color);

        }

        public void PetNaming(Pet p)
        {
            //Pet naming
            Console.WriteLine("\n Please choose a name for your new {0} buddy: ", p.Species);
            p.Name = Console.ReadLine();
            Console.WriteLine("Your pet's name is: {0} \n", p.Name);
        }

        //Do something ith pet
        public void Action(Pet mascot, int daytime)
        {
            bool err = false;
            string MsgMorning = "\n Time to get up! ";
            string MsgEvening = "\n Now is evening, ";

            
            do
            {
                //Morning
                if (daytime == 0)
                {
                    Console.Write(MsgMorning);
                }
                //Evening
                else
                {
                    Console.Write(MsgEvening);
                }

                //if pet is tired tired - 20 and jump the action
                if (mascot.Tired >= 80)
                {
                    Console.WriteLine("Wait... {0} seems exhausted... Let it rest a while \n", mascot.Name);
                    mascot.Tired -= 20;
                    break;
                }

                err = ChooseAction(mascot);

            } while (err);
        }



    /*Private Methods*/

    //Validate user's input on the chooseEgg function, private since it is not used on main
    private bool ValidateEggOp(int option, Egg myEgg)
        {
            switch (option)
            {
                case 1:
                    myEgg.Color = "white";

                    //Egg was white, then change to color white
                    Console.ForegroundColor = ConsoleColor.White;

                    return false;

                case 2:
                    myEgg.Color = "red";

                    //Egg was red, then change to color red
                    Console.ForegroundColor = ConsoleColor.Red;

                    return false;

                case 3:
                    myEgg.Color = "blue";

                    //Egg was blue, then change to color blue
                    Console.ForegroundColor = ConsoleColor.Blue;

                    return false;

                case 4:
                    myEgg.Color = "green";

                    //Egg was green, then change to color Green
                    Console.ForegroundColor = ConsoleColor.Green;

                    return false;

                case 5:
                    myEgg.Color = "yellow";


                    //Egg was yellow, then change to color yellow
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    return false;

                default:
                    Console.WriteLine("Please type a valid option");
                    return true;
            }
        }

        private bool ChooseAction(Pet p)
        {
            try
            {
                Console.WriteLine(" what would you like to do with your pet? \n (Choose an option)");

                Console.WriteLine("1 - Feed!");
                //Variable Results
                Console.WriteLine("2 - Compete in race!");

                Console.WriteLine("3 - Rest!");

                Console.WriteLine("4 - Walk!");

                Console.WriteLine("5 - Send to a party!");

                int op = int.Parse(Console.ReadLine());

                //Check until a valid option was selected
                switch (op)
                {
                    case 1:
                        if (Money < 10)
                        {
                            Console.WriteLine("Your actual balance is ${0} and food costs $10... You can't buy food!", Money);
                            return true;
                        }
                        else
                        {
                            Money = p.Eat(Money);
                            return false;
                        }
                    case 2:
                        p.CompeteRace();
                        return false;
                    case 3:
                        p.Rest();
                        return false;
                    case 4:
                        p.Walk();
                        return false;
                    case 5:
                        Money = p.SendParty(Money);
                        return false;
                    default:
                        Console.WriteLine("Error: {0} is confused, Please type a valid option", p.Name);
                        return true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Type a number between 1-5!");
                return true;
            }
        }

    }
}
