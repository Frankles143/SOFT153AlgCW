using System.IO;

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
        public char data;
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


        }

        static void ReadInData()
        {
            using (StreamReader fileInput = new StreamReader("records.txt"))
            {
                //Will read until end of the file
                while (!fileInput.EndOfStream)
                {
                    char[] firstName = new char[0];
                    char input = fileInput.Read();
                }
            }
        }
    }
}
