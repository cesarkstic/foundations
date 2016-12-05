//Assignment #6
//Copy this block into your Visual Studio.
// Review and Redo this code line by line at home.  
// Place comments on each line and describe what the code is doing

using System;

namespace Assignment6               // Namespace renamed
{
    public struct Pet               // Declare a structure called Pet
    {
        public string Name;         // Contains two items, Name as string type
        public string TypeOfPet;    // And TypeOfPet as string
    }
    class Program
    {
        static void Main()      
        {
            var numberOfPets = 0;       // initialize variables, this one as zero
            var pets = new Pet[10];
            while (true)                // Starts a cycle, it won't stop unless explicitely within the cycle
            {
                Console.Write("A)dd D)elete L)ist pets:");      // Present user with options
                var choice = Console.ReadLine();                // Read option from user
                switch (choice)                                 // And depending on the choice...
                {
                    case "A":
                    case "a":                                   // If A or a entered (add pet)
                        {
                            Console.Write("Name :");            
                            var name = Console.ReadLine();      // Receives name of pet
                            Console.Write("Type of pet :"); 
                            var typeOfPet = Console.ReadLine(); // Receivies type of pet
                            // Always add the pet at the end of the array
                            pets[numberOfPets].Name = name;     // Stores name and type on pet strut
                            pets[numberOfPets].TypeOfPet = typeOfPet;
                            numberOfPets++;                     // Increases counter of pets
                            break;
                        }
                    case "D":
                    case "d":                                   // If D or d entered (delete pet)
                        {
                            if (numberOfPets == 0)              // If there are no pets then inform user and leave
                            {
                                Console.WriteLine("No pets");
                                break;
                            }
                            for (var index = 0; index < numberOfPets; index++)  // Present a list of pets to user
                            {
                                Console.WriteLine("{0}. {1,-10} {2}", index + 1, pets[index].Name, pets[index].TypeOfPet);
                            }
                            Console.Write("Which pet to remove (1-{0})", numberOfPets); // Ask what pet to remove
                            var petNumberToDelete = Console.ReadLine();
                            var indexToDelete = int.Parse(petNumberToDelete);           // Gets number of pet to remove
                            // Squish the array from index to the end
                            for (var index = indexToDelete - 1; index < numberOfPets; index++)
                            {
                                // Just copy the pet from the next index into the current index
                                pets[index] = pets[index + 1];
                            }
                            // We have one less pet
                            numberOfPets--;
                            break;
                        }
                    case "L":
                    case "l":                                   // If L or l entered (list pets)
                        {
                            if (numberOfPets == 0)              // If there are no pets then inform user and leave
                            {
                                Console.WriteLine("No pets");
                            }
                            for (int index = 0; index < numberOfPets; index++)  // cycle to go throw all array elements
                            {
                                Console.WriteLine("{0}. {1,-10} {2}", index + 1, pets[index].Name, pets[index].TypeOfPet); // display pet information
                            }
                            break;
                        }
                    default:        // invalid entry
                        {
                            Console.WriteLine("Invalid option [{0}]", choice);  // inform user
                            break;
                        }
                }
            }
        }
    }
}