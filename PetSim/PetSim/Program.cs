using System;

namespace PetSim
{


    class Program
    {

        static void ChooseEgg(Egg myEgg)
        {
            bool error = false;
            Console.WriteLine("Please select the color of the egg you would like: ");
            Console.WriteLine("1 - White \n"
                + "2 - Red \n"
                + "3 - Blue \n"
                + "4 - Green \n"
                + "5 - Yellow \n"
                );

            //Cycle until a valid option is typed
            do
            {
                //Protect code from exceptions
                try
                {
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            myEgg.Color = "white";
                            error = false;
                            break;

                        case 2:
                            myEgg.Color = "red";
                            error = false;
                            break;

                        case 3:
                            myEgg.Color = "blue";
                            error = false;
                            break;

                        case 4:
                            myEgg.Color = "green";
                            error = false;
                            break;

                        case 5:
                            myEgg.Color = "yellow";
                            error = false;
                            break;

                        default:
                            Console.WriteLine("Please type a valid option");
                            error = true;
                            break;
                    }
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

            Console.WriteLine("Your selected color was: {0} \n", myEgg.Color);

        }

        static void PetNaming(Pet p)
        {
            //Pet naming
            Console.WriteLine("Please choose a name for your new {0} buddy: ", p.Species);
            p.Name = Console.ReadLine();
            Console.WriteLine("Your pet's name is: {0} \n", p.Name);
        }

        static bool ChooseAction(Pet p, int money)
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
                        if (money < 10)
                        {   
                            Console.WriteLine("Your actual balance is ${0} and food costs $10... You can't buy food!", money);
                            return true;
                        }
                        else
                        {
                            money = p.Eat(money);
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
                        money = p.SendParty(money);
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

        static int Action(Pet mascot, int daytime, int money)
        {
            bool err = false;
            string MsgMorning = "Time to get up! ";
            string MsgEvening = "Now is evening, ";

            if(mascot.Tired >= 80)
            {
                Console.WriteLine("Wait... {1} seems exhausted... Let him/her rest... \n", mascot.Name);
                mascot.Tired -= 20;
            } else
            {    
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

                    err = ChooseAction(mascot, money);
                    
                } while (err);
            }
            return money;
        }

        static void Main(string[] args)
        {
            //Greet and ask user if he wants to play
            Console.WriteLine("Welcome to Pet Sim Game! Type Y if you want to play, else type anything: ");
            string option = Console.ReadLine();

            //Flag for player to start or continue playing
            bool play = true;

            //Money counter (each player starts with $20)
            int money = 20;

            //pet counter
            int petcount = 0;

            //instantiate egg object
            Egg myEgg = new Egg();

            //Pet array
            Pet[] pinata = new Pet[30];

            //day counter
            int day = 0;

            //Flag to determine if pet is still active (alive and hasn't run away)
            bool active = true;

            while (play)
            {

                if (!(option.ToLower() == "y" || option.ToLower() == "yes"))
                {
                    play = false;
                    break;
                }

                ChooseEgg(myEgg);

                pinata[petcount] = new Pet();

                //Hatch the egg and save specie of the pet
                pinata[petcount].Species = myEgg.Hatch();

                Console.WriteLine("Congratulations you got a: {0} pinata", pinata[petcount].Species);
                PetNaming(pinata[petcount]);

                while (active)
                {
                    //choose morning action (Pet, morning(0) or evening(any other number), money)
                    money = Action(pinata[petcount], 0, money);
                    //choose evening action
                    money = Action(pinata[petcount], 1, money);
                    //Ask user for showing pet status
                    Console.WriteLine("Would you like to see {0} status? (Type y if yes, else type anything)", pinata[petcount].Name);
                    option = Console.ReadLine();
                    if (option.ToLower() == "y" || option.ToLower() == "yes")
                    {
                        pinata[petcount].PetStatus();
                    }
                    active = false;
                }

                play = false;

                petcount++;
            }
            Console.ReadLine();
        }
    }
}
