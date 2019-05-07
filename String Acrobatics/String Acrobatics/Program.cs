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
                    List<int> firstName = new List<int>();
                    List<int> lastName = new List<int>();
                    List<int> Id = new List<int>();

                    int input = fileInput.Read();

                    //Reads in firstName until hits a comma
                    while (input != 44)
                    {
                        firstName.Add(input);
                        input = fileInput.Read();
                    }

                    //Extra .Read to clear the space
                    input = fileInput.Read();
                    input = fileInput.Read();

                    //Reads in lastName until hits a comma
                    while (input != 44)
                    {
                        lastName.Add(input);
                        input = fileInput.Read();
                    }

                    //Extra .Read to clear the space
                    input = fileInput.Read();
                    input = fileInput.Read();

                    while (input != 13)
                    {
                        Id.Add(input);
                        input = fileInput.Read();
                    }

                    CharNode firstNameNode = new CharNode();
                    CharNode lastNameNode = new CharNode();
                    IntNode IdNode = new IntNode();


                }
            }
        }
    }
}
