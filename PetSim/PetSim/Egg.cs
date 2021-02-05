using System;
using System.Collections.Generic;
using System.Text;

namespace PetSim
{
    class Egg
    {
        //Getters and setters
        public string Color;
        public int Rank;

        //Constructor
        public Egg()
        {
            Color = "white";
            Rank = 1;
        }

        public string Hatch()
        {
            //Generate a random roll for pet rank
            Random rnd = new Random();
            Rank = rnd.Next(1, 3);

            switch (Color)
            {
                case "white":
                    if(Rank == 1)
                    {
                        return "Flutterscotch";
                    }
                    return "Moozipan";

                case "red":
                    if (Rank == 1)
                    {
                        return "Raisant";
                    }
                    return "Pieena";

                case "blue":
                    if (Rank == 1)
                    {
                        return "Sherbat";
                    }
                    return "Horstachio";

                case "green":
                    if (Rank == 1)
                    {
                        return "Fudgehog";
                    }
                    return "Jameleon";

                case "yellow":
                    if (Rank == 1)
                    {
                        return "Ponocky";
                    }
                    return "Roario";

                default:
                    return "Flutterscotch";
            }
        }
    }
}
