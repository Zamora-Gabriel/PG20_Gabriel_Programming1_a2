using System;
using System.Collections.Generic;
using System.Text;

namespace PetSim
{
    public class Egg
    {
        //Getters and setters
        public string Color;
        //the rank of the pet: Greater rank, greater difficulty for taking care
        public int Rank { get; private set; }
        public string hatchSpecie { get; private set; }
        public string Candy { get; private set; }
        public string RealSp { get; private set; }

        //Constructor
        public Egg()
        {
            Color = "white";
            Rank = 1;
        }

        public void Hatch()
        {
            //Generate a random roll for pet rank
            Random rnd = new Random();
            Rank = rnd.Next(1, 3);

            switch (Color)
            {
                case "white":
                    if(Rank == 1)
                    {
                        hatchSpecie = "Swanana";
                        RealSp = "Swan";
                        Candy = "Banana";
                        return;
                    }
                    hatchSpecie = "Moozipan";
                    RealSp = "Cow";
                    Candy = "Marzipan";

                    return;

                case "red":
                    if (Rank == 1)
                    {
                        hatchSpecie = "Raisant";
                        RealSp = "Ant";
                        Candy = "Raisin";
                        return;
                    }
                    hatchSpecie = "Pieena";
                    RealSp = "Hyena";
                    Candy = "Pie";

                    return;
                case "blue":
                    if (Rank == 1)
                    {
                        hatchSpecie = "Sherbat";
                        RealSp = "Bat";
                        Candy = "Sherbet";
                        return;
                    }
                    hatchSpecie = "Horstachio";
                    RealSp = "Horse";
                    Candy = "Pistachio";

                    return;

                case "green":
                    if (Rank == 1)
                    {
                        hatchSpecie = "Fudgehog";
                        RealSp = "Hedgehog";
                        Candy = "Fudge";
                        return;
                    }
                    hatchSpecie = "Jameleon";
                    RealSp = "Chameleon";
                    Candy = "Jam";

                    return;

                case "yellow":
                    if (Rank == 1)
                    {
                        hatchSpecie = "S'morepion";
                        RealSp = "Scorpion";
                        Candy = "S'more";
                        return;
                    }
                    hatchSpecie = "Roario";
                    RealSp = "Lion";
                    Candy = "Oreo";

                    return;
                //Since Color was already validated, default status may never be accessed
                default:
                    hatchSpecie = "Swanana";
                    RealSp = "Swan";
                    Candy = "Banana";
                    return;
            }
        }
    }
}
