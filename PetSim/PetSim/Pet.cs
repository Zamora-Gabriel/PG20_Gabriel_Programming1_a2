using System;
using System.Collections.Generic;
using System.Text;

namespace PetSim
{
    public class Pet
    {

        public string Name;
        public string Species { get; private set; }
        public int DaysAlive;

        //private "difficulty" level of the pet. Negative statuses are multiplied by rank
        private int Rank;
        private string PetConclusion;
       

        //Inspired data for the pinata species on the game
        private string RealSpecie;
        private string InspiredCandy;


        //Statusses
        public int Tired;
        public int Hunger { get; private set; }
        public int Sickness { get; private set; }
        public int Happiness { get; private set; }
        public int Popularity { get; private set; }

        //Constructors
        public Pet(string spec, int rank, string realSp, string candy)
        {
            Name = "None";
            Species = spec;
            Rank = rank;
            DaysAlive = 0;
            Hunger = 0;
            Tired = 0;
            Sickness = 0;
            Happiness = 50;
            Popularity = 0;
            RealSpecie = realSp;
            InspiredCandy = candy;
        }

        //Get status
        public void PetStatus()
        {
            Console.WriteLine("{0}: \n", Name);
            Console.WriteLine("Species: {0} \n", Species);
            Console.WriteLine("Rank: {0} \n\n", Rank);

            Console.WriteLine("{0} Status: \n", Name);
            Console.WriteLine("Days: {0} \n", DaysAlive);
            Console.WriteLine("Hunger: {0}", Hunger);
            Console.WriteLine("Exhaustion: {0}", Tired);
            Console.WriteLine("Sickness: {0}", Sickness);
            Console.WriteLine("Happiness: {0} \n", Happiness);
            Console.WriteLine("Popularity: {0} \n", Popularity);
        }

        /*Methods*/

        //Pets status and message, returns bool if it is or not alive
        public bool StatusMsgAlive(string plaName)
        {
            bool alive = true;

            //Check if pet is alive or hasn't run away
            alive = CheckHappiness(plaName, alive);
            alive = CheckHunger(plaName, alive);
            alive = CheckSickness(plaName, alive);
            alive = CheckOld(plaName, alive);

            if (alive)
            {
                Console.WriteLine("A day full of surprises awaits us!");
            }
            
            return alive;
        }

        //Feed the pet: Increase Sickness and Happiness. Decrease Hunger and Money
        public int Eat(int mon)
        {
            //Check if has the money to buy food
            Hunger -= 10;
            Sickness += 20;
            Happiness += 10;
            mon -= 10;
            NegativesToZero();
            return mon;
        }

        //Go to a competition with the pet. "Play"
        public void CompeteRace()
        {
            Console.WriteLine("Welcome to the Pinata Grand Race! Let's see which would be the victor!");
            //Generate a random roll for place
            Random rnd = new Random();
            int place = rnd.Next(1, 4);
            Console.WriteLine("{0} arived in {1} place!", Name, place);

            //Check place of the race and increase or decrease parameters with that information
            switch (place)
            {
                //First place
                case 1:
                    Popularity += 20*Rank;
                    Happiness += 20*Rank;
                    Tired += 20*Rank;
                    Hunger += 10*Rank;
                    break;
                //Second place
                case 2:
                    Popularity += 10*Rank;
                    Tired += 30*Rank;
                    Hunger += 10*Rank;
                    break;
                //Third place
                default:
                    Popularity -= 10*Rank;
                    Happiness -= 10*Rank;
                    Tired += 30*Rank;
                    Hunger += 20*Rank;
                    break;
            }
            NegativesToZero();
        }

        //Leave the pet to rest: Increase Hunger. Decrease Sickness and Tired values. 
        public void Rest()
        {
            Tired -= 10;
            Sickness -= 10;
            Hunger += 20;
            NegativesToZero();
        }

        //Walk with pet: Increase Hunger, Tired and Happiness.
        public void Walk()
        {
            Happiness += 20;
            Tired += 20*Rank;
            Hunger += 20*Rank;
            NegativesToZero();
        }

        //Send Pinata to party: Decrease Happiness. Increase Tired, Hunger, Popularity and Money
        public int SendParty(int money)
        {
            Popularity += 20*Rank;
            Happiness -= 20;
            Tired += 20*Rank;
            Hunger += 20;
            money += 20;
            NegativesToZero();
            return money;
        }

        //If pet died being old, popularity changes to gold
        public int PopularityToMoney()
        {
            if(DaysAlive >= 5)
            {
                return Popularity;
            }
            return 0;
        }

        //Print final information
        public void printInfo()
        { 
            Console.Write("{0} \t\t ", Name);
            Console.Write("{0} \t\t ", Species);
            Console.Write("{0} \t\t ", RealSpecie);
            Console.Write("{0} \t\t ", InspiredCandy);
            Console.WriteLine("{0} \t\t  \n", PetConclusion);

        }


        /*Private Methods*/

        //Set statusses in negative numbers to zero
        private void NegativesToZero()
        {
            if(Hunger < 0)
            {
                Hunger = 0;
            }

            if(Tired < 0)
            {
                Tired = 0;
            }

            if (Sickness < 0)
            {
                Sickness = 0;
            }

            if(Popularity < 0)
            {
                Popularity = 0;
            }
        }

        //Check every critical status
        private bool CheckHunger(string plaName, bool alive)
        {
            //First Check if the pet is alive
            if (alive)
            {
                if (Hunger >= 80)
                {
                    if (Hunger >= 100)
                    {
                        Console.WriteLine("{0} I... can't... too hungry...", plaName);

                        //Narration
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0} died at day {1} by hunger", Name, DaysAlive);

                        PetConclusion = "Died by hunger at day " + DaysAlive;
                        return false;
                    }

                    Console.WriteLine("I-I'm starving");
                    return true;
                }
            }
            
            return alive;
        }

        private bool CheckSickness(string plaName, bool alive)
        {
            //First Check if the pet is alive
            if (alive)
            {
                if (Sickness >= 80)
                {
                    if (Sickness >= 100)
                    {
                        Console.WriteLine("{0}, I don't want to go... I don't want to...", plaName);

                        //Narration
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0} died at day {1} by Sickness", Name, DaysAlive);

                        PetConclusion = "Died by sickness at day " + DaysAlive;
                        return false;
                    }

                    Console.WriteLine("{0}, I don't feel so good...", plaName);
                    return true;
                }
            }
            
            return alive;
        }

        private bool CheckHappiness(string plaName, bool alive)
        {
            //First Check if the pet is alive
            if (alive)
            {
                if (Happiness <= 20)
                {
                    if (Happiness <= 0)
                    {
                        Console.WriteLine("I'm leaving I can't take this anymore!", plaName);

                        //Narration
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0} ran away at day {1}", Name, DaysAlive);

                        PetConclusion = "Ran away at day " + DaysAlive;
                        return false;
                    }

                    Console.WriteLine("{0}, I think I'm just a money making machine for you...", plaName);
                    return true;
                }
            }
            return alive;
        }

        private bool CheckOld(string plaName, bool alive)
        {
            //First Check if the pet is alive
            if (alive)
            {
                //Pinatas live until 5 days past
                if (DaysAlive >= 5)
                {
                    Console.WriteLine("I-I had a great life, thank you... {0}", plaName);

                    //Narration
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0} lived a good life, sadly passed away at day {1}", Name, DaysAlive);

                    PetConclusion = "Lived a good life";
                    return false;
                }
            }
            return alive;
        }
    }
}
