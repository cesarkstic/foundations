// Final Project
// Cesar Castro

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{

    class Program
    {
        public struct Item
        {
            public int Nmbr;
            public string Desc;
            public decimal Price;
            public int Qty;
            public decimal Cost;
            public decimal Value;
        }

        public static int itemPointer = 0;
        public static Item [] itemInventory = new Item[100];  // Can hold 100 items

        static void addItem()
        {
            Item newItem;

            Console.Write("Item Number:");
            newItem.Nmbr = int.Parse(Console.ReadLine());   //Item Number

            Console.Write("Description:");
            newItem.Desc= Console.ReadLine();               // Description

            Console.Write("Price:");
            newItem.Price = decimal.Parse(Console.ReadLine());  //Price

            Console.Write("Quantity:");
            newItem.Qty= int.Parse(Console.ReadLine());     //Quantity

            Console.Write("Cost:");
            newItem.Cost = decimal.Parse(Console.ReadLine());   //Cost

            itemInventory[itemPointer].Nmbr = newItem.Nmbr;
            itemInventory[itemPointer].Desc = newItem.Desc;
            itemInventory[itemPointer].Price = newItem.Price;
            itemInventory[itemPointer].Qty = newItem.Qty;
            itemInventory[itemPointer].Cost = newItem.Cost;
            itemInventory[itemPointer].Value = newItem.Price * newItem.Price;
            itemPointer++;

            Console.WriteLine("Item # {0} has been created", itemPointer);
        }

        static void listItems ()
        {
            Console.WriteLine("Item  Description                  Price  Quantity          Cost         Value");
            Console.WriteLine("----  --------------------  ------------  --------  ------------  ------------");

            foreach (Item item in itemInventory) 
            {
                if (item.Nmbr!= 0)             
                    Console.WriteLine("{0,4}  {1,-20}  {2,12:C}  {3,8}  {4,12:C}  {5,12:C}", item.Nmbr, item.Desc, item.Price, item.Qty, item.Cost, item.Value);
            }
        }

        static void deleteItem()
        {
            int itemNmbr;

            listItems();

            Console.Write("Enter item to delete:");
            itemNmbr = int.Parse(Console.ReadLine());

            for (var index = 0; index < itemPointer; index++)
            {
                if (itemInventory[index].Nmbr == itemNmbr)

                    for (var index2 = index; index2 < itemPointer; index2++)
                    {
                        itemInventory[index2] = itemInventory[index2 + 1];
                    }
            }

            itemPointer--;
            Console.WriteLine();
            listItems();
        }

        static void modifyItem()
        {
            int itemNmbr;
            string field;
            int index;

            listItems();

            Console.Write("Enter item to modify: ");
            itemNmbr = int.Parse(Console.ReadLine());
            Console.WriteLine("(D)escription");
            Console.WriteLine("(P)rice");
            Console.WriteLine("(Q)uantity");
            Console.WriteLine("(C)ost");
            Console.Write("Enter field to modify: ");
            field = Console.ReadLine();

            for (index = 0; index < itemPointer; index++)
            {
                if (itemInventory[index].Nmbr == itemNmbr)
                    break;
            }

            switch (field)
            {
                case "d":
                case "D":
                    {
                        Console.Write("Enter new description: ");
                        itemInventory[index].Desc = Console.ReadLine();
                        break;
                    }
                case "p":
                case "P":
                    {
                        Console.Write("Enter new price: ");
                        itemInventory[index].Price = decimal.Parse(Console.ReadLine());
                        break;
                    }
                case "q":
                case "Q":
                    {
                        Console.Write("Enter new quantity: ");
                        itemInventory[index].Qty = int.Parse(Console.ReadLine());
                        break;
                    }
                case "c":
                case "C":
                    {
                        Console.Write("Enter new cost: ");
                        itemInventory[index].Cost = decimal.Parse(Console.ReadLine());
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option [{0}]", field);  // inform user
                        break;
                    }
            }

            itemInventory[index].Value = itemInventory[index].Price * itemInventory[index].Price;
            listItems();
        }


        static void Main()
        {
            string choice;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine ("MAIN MENU");
                Console.WriteLine ("=========");
                Console.WriteLine ("(A)dd");
                Console.WriteLine ("(D)elete");
                Console.WriteLine ("(M)odify");
                Console.WriteLine ("(L)ist");
                Console.WriteLine ("E(x)it");
                Console.Write ("Enter your selection: ");
                choice = Console.ReadLine();    // Present menu and read option from user
                Console.WriteLine();

                switch (choice) // And depending on the choice...
                {
                    case "A":
                    case "a":   // add item
                        {
                            addItem();
                            break;
                        }
                    case "D":
                    case "d":   // delete item
                        {

                            if (itemPointer == 0)
                            {
                                Console.WriteLine("No items in DB");
                                break;
                            }

                            deleteItem();
                            break;
                        }
                    case "M":
                    case "m":   // modify item
                        {

                            if (itemPointer == 0)
                            {
                                Console.WriteLine("No items in DB");
                                break;
                            }

                            modifyItem();
                            break;
                        }
                    case "L":
                    case "l":   // list items
                        {
                            if (itemPointer == 0)
                            {
                                Console.WriteLine("No items in DB");
                                break;
                            }

                            listItems();
                            break;
                        }
                    case "X":
                    case "x":   // exit
                        {
                            return;
                        }

                    default:    // invalid entry
                        {
                            Console.WriteLine("Invalid option [{0}]", choice);  // inform user
                            break;
                        }
                }
            }
        }
    }
}