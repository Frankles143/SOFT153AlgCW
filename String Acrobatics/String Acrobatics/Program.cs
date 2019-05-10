using System;
using System.IO;
using System.Collections.Generic;

//Author: Josh Franklin
//Created: 21/03/19
//Edited: JF 21/03/19
//
//Pulling data from a file into a list

namespace String_Acrobatics
{
    //Node class with references to the next and previous nodes
    class IntNode
    {
        public int data;
        public IntNode nextNode;
        public IntNode prevNode;
    }

    //Creating the list with the first node being saved
    //class IntList
    //{
    //    public IntNode firstNode;
    //}

    class CharNode
    {
        public char[] data;
        public CharNode nextNode;
        public CharNode prevNode;
    }

    //class CharList
    //{
    //    public CharNode firstNode;
    //}

    class List
    {
        public CharNode firstName;
        public CharNode lastName;
        public IntNode Id;
    }


    class Program
    {
        static void Main(string[] args)
        {
            ReadInData();

        }

        static void ReadInData()
        {
            using (StreamReader fileInput = new StreamReader("records.txt"))
            {
                

                //Will read until end of the file
                while (!fileInput.EndOfStream)
                {
                    List<char> firstName = new List<char>();
                    List<char> lastName = new List<char>();
                    List<char> Id = new List<char>();

                    char input = Convert.ToChar(fileInput.Read());

                    //Reads in firstName until hits a comma
                    while (input != 44)
                    {
                        firstName.Add(input);
                        input = Convert.ToChar(fileInput.Read());
                    }
                    
                    //Extra .Read to clear the space
                    input = Convert.ToChar(fileInput.Read());
                    input = Convert.ToChar(fileInput.Read());

                    //Reads in lastName until hits a comma
                    while (input != 44)
                    {
                        lastName.Add(input);
                        input = Convert.ToChar(fileInput.Read());
                    }

                    //Extra .Read to clear the space
                    input = Convert.ToChar(fileInput.Read());
                    input = Convert.ToChar(fileInput.Read());

                    //Reads in ID until it hits a next line
                    while (input != 13)
                    {
                        Id.Add(input);
                        input = Convert.ToChar(fileInput.Read());
                    }

                    CharNode firstNameNode = new CharNode();
                    CharNode lastNameNode = new CharNode();
                    IntNode IdNode = new IntNode();

                    //For testing
                    //foreach (char c in firstName)
                    //{
                    //    Console.WriteLine($"{c}");
                    //}
                    //foreach (char c in lastName)
                    //{
                    //    Console.WriteLine($"{c}");
                    //}
                    //foreach (char c in Id)
                    //{
                    //    Console.WriteLine($"{c}");
                    //}


                    //char[] firstNameArray = new char[];
                }
            }
        }
    }
}
