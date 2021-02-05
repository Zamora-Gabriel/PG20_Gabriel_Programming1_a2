using System;
using System.Collections.Generic;
using System.Text;

namespace PetSim
{
    public class Pet
    {

        public string Name;
        public string Species;

        //Statusses
        public int Hunger;
        public int Tired;
        public int Sickness;
        public int Happiness;
        public int Popularity;

        //Constructors
        public Pet() {
            Name = "None";
            Species = "None";
        }
        public Pet(string nam, string spec)
        {
            Name = nam;
            Species = spec;
        }

        //Get status
        public void PetStatus()
        {
            Console.WriteLine("{0} Status: ", Name);
            Console.WriteLine("Species: {0} \n", Species);

            Console.WriteLine("Hunger: {0}", Hunger);
            Console.WriteLine("Exhaustion: {0}", Tired);
            Console.WriteLine("Sickness: {0}", Sickness);
            Console.WriteLine("Happiness: {0} \n", Happiness);
            Console.WriteLine("Popularity: {0} \n", Popularity);
        }

        /*Methods*/

        //Feed the pet: Increase Sickness and Happiness. Decrease Hunger and Money
        public int Eat(int mon)
        {
            //Check if has the money to buy food
            Hunger -= 20;
            Sickness += 20;
            Happiness += 10;
            mon -= 10;

            return mon;
        }

        //Go to a competition with the pet. "Play"
        public void CompeteRace()
        {
            Console.WriteLine("Welcome to the Pinata Gand Race! Let's see which would be the victor!");
            //Generate a random roll for place
            Random rnd = new Random();
            int place = rnd.Next(1, 4);
            Console.WriteLine("{0} arived in {1} place!", Name, place);

            //Check place of the race and increase or decrease parameters with that information
            switch (place)
            {
                //First place
                case 1:
                    Popularity += 20;
                    Happiness += 20;
                    Tired += 20;
                    Hunger += 20;
                    break;
                //Second place
                case 2:
                    Popularity += 5;
                    Tired += 20;
                    Hunger += 20;
                    break;
                //Third place
                default:
                    Popularity -= 20;
                    Happiness -= 20;
                    Tired += 20;
                    Hunger += 20;
                    break;
            }
        }

        //Leave the pet to rest: Increase Hunger. Decrease Sickness and Tired values. 
        public void Rest()
        {
            Tired -= 10;
            Sickness -= 10;
            Hunger += 10;
        }

        //Walk with pet: Increase Hunger, Tired and Happiness.
        public void Walk()
        {
            Happiness += 10;
            Tired += 10;
            Hunger += 10;
        }

        //Send Pinata to party: Decrease Happiness. Increase Tired, Hunger, Popularity and Money
        public int SendParty(int money)
        {
            Popularity += 20;
            Happiness -= 20;
            Tired += 30;
            Hunger += 30;
            money += 30;
            return money;
        }

    }
}
