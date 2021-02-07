using System;

namespace PetSim
{


    class Program
    {
        //Function to ask player if wants to keep playing
        static bool KeepPlaying(string  Msg)
        {
            Console.WriteLine("{0} Type Y if you want to play, else type anything: ", Msg);
            string option = Console.ReadLine();

            if (!(option.ToLower() == "y" || option.ToLower() == "yes"))
            {
                //The player doesn't want to play
                return false;
            }
            return true;
        }

        //function to change text color
        static void DialogColor(string Colour)
        {
            switch (Colour.ToLower()){
                case "narrator":
                    //Narrator Color dialog
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                case "pet":
                    //Pet color dialog
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return;
                case "money":
                    //Money displaying color
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return;
                default:
                    return;
            }
        }

        static void Main(string[] args)
        {
            //Flag for player to start or continue playing
            bool play = true;

            //Instantiate player
            Player player1 = new Player();

            //limit of pets per game
            const int petLimit = 5;

            //instantiate egg object
            Egg myEgg = new Egg();

            //Pet array
            Pet[] pinata = new Pet[petLimit];

            //boolean for player naming
            bool nameDone = false;

            //Flag to determine if pet is still active (alive and hasn't run away)
            bool active = true;

            //Greet and ask user if he wants to play
            //Intro message
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Msg = "Welcome to picturesque Pinata Island! \n"+
                "in its many gardens all variety of pinatas live, dance, and dream \n"+
                "that one day they will be chosen by a human to find a partner and have \n"+
                "a wonderful life \n";
            play = KeepPlaying(Msg);
            

            while (play)
            {

                //Ask, user's name, if user's name already asked and approved, won't be asked 
                nameDone = player1.YourName(nameDone);

               //Ask the user for an input to choose the pet's egg
                player1.ChooseEgg(myEgg);


                //Hatch the egg and save specie of the pet
                myEgg.Hatch();

                pinata[player1.petcount] = new Pet(myEgg.hatchSpecie, myEgg.Rank, myEgg.RealSp, myEgg.Candy);

                Console.WriteLine("Congratulations you got a: {0} pinata", pinata[player1.petcount].Species);
                player1.PetNaming(pinata[player1.petcount]);

                //While pinata hasn't died or ran away
                while (active)
                {
                    //Color of console
                    DialogColor("Money");

                    //Print user's money
                    Console.WriteLine("\n ------------------------------------------------------------");
                    Console.WriteLine("\n Your actual money balance to buy food is: {0} \n", player1.Money);
                    Console.WriteLine("------------------------------------------------------------ \n");

                    //Color of console to narrator
                    DialogColor("narrator");

                    //choose morning action (Pet, morning(0) or evening(any other number), money)
                    player1.Action(pinata[player1.petcount], 0);
                    //choose evening action
                    player1.Action(pinata[player1.petcount], 1);

                    //Showing pet status (Debug purposes)
                    /*
                    Console.WriteLine("\n Would you like to see {0} status? (Type y if yes, else type anything)", pinata[player1.petcount].Name);
                    string optionStatus = Console.ReadLine();
                    if (optionStatus.ToLower() == "y" || optionStatus.ToLower() == "yes")
                    {
                        pinata[player1.petcount].PetStatus();
                    }*/

                    //Pet's response and status
                    //pet
                    DialogColor("pet");
                    active = pinata[player1.petcount].StatusMsgAlive(player1.Name);
                    player1.Money += pinata[player1.petcount].PopularityToMoney();

                    //Increase pet days
                    pinata[player1.petcount].DaysAlive++;
                }

                //Increase number of pets that user had
                player1.petcount++;

                if ( player1.petcount < petLimit)
                {
                    //Narrator
                    DialogColor("narrator");
                    //Ask user if he wants to keep playing
                    play = KeepPlaying("Would you like to keep playing? ");
                } else
                {
                    //Narrator
                    DialogColor("narrator");
                    //Game completed at maximum pets
                    Console.WriteLine("\n Congratulations! You've already had {0} pets! Thank you for playing and please, come again!", player1.petcount);
                    play = false; 
                }

                //Set active flag to play with new pet
                active = true;
            }

            //Print all Pinatas information and conclusions

            Console.WriteLine("Name \t\t Specie \t\t Inspired Specie \t\t Inspired Candy \t\t Status");

            foreach (Pet pet in pinata)
            {
                if(pet == null)
                {
                    break;
                }

                //random colors per line
                Random rnd = new Random();
                int randColor = rnd.Next(1, 16);

                Console.ForegroundColor = (ConsoleColor)randColor;

                pet.printInfo();
            }

            Console.ReadLine();
        }
    }
}
