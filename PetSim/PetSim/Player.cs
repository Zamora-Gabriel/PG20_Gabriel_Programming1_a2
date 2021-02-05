using System;
using System.Collections.Generic;
using System.Text;

namespace PetSim
{
    class Player
    {
        //Variables
        public int Money;


        /*Public Methods*/
        public void ChooseEgg(Egg myEgg)
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

            Console.WriteLine("Your selected color was: {0} \n", myEgg.Color);

        }


        /*Private Methods*/

        //Validate user's input on the chooseEgg function, private since it is not used on main
        private bool ValidateEggOp(int option, Egg myEgg)
        {
            switch (option)
            {
                case 1:
                    myEgg.Color = "white";
                    return false;

                case 2:
                    myEgg.Color = "red";
                    return false;

                case 3:
                    myEgg.Color = "blue";
                    return false;

                case 4:
                    myEgg.Color = "green";
                    return false;

                case 5:
                    myEgg.Color = "yellow";
                    return false;

                default:
                    Console.WriteLine("Please type a valid option");
                    return true;
            }
        }
    }
}
