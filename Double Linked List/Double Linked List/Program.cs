﻿using System;

//Author: Josh Franklin
//Created: 21/03/19
//Edited: JF 21/03/19
//
//Creating a double linked list and adding functionality

namespace Double_Linked_List
{
    //Node class with references to the next and previous nodes in the list
    class Node
    {
        public int data;
        public Node nextNode;
        public Node prevNode;
    }

    //Creating the list with the first node being saved
    class List
    {
        public Node firstNode;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            Node node;
            int nodesToAdd = 5;
            //CAN'T USE RANDOM - CREATE OWN - YOU WILL LOSE A MARK
            Random r = new Random();                            //
            //CAN'T USE RANDOM - CREATE OWN - YOU WILL LOSE A MARK

            //Creates a pre-determined set of nodes
            for (int i = 0; i < nodesToAdd; i++)
            {
                node = new Node();
                node.data = r.Next(100);
                InsertFront(list, node);
            }

            ShowList(list);

            for (int i = 0; i < nodesToAdd; i++)
            {
                node = new Node();
                node.data = r.Next(100);
                InsertBack(list, node);
            }

            ShowList(list);

            Console.ReadLine();
        }

        //Adds a node at the beginning of a list
        static void InsertFront(List list, Node nodeToAdd)
        {
            //pushes the current first node to be the next node
            nodeToAdd.nextNode = list.firstNode;
            nodeToAdd.prevNode = null;

            //changes prevNode of the firstNode to be the new node
            if (list.firstNode != null)
            {
                list.firstNode.prevNode = nodeToAdd;
            }

            //the new node then becomes the first node
            list.firstNode = nodeToAdd;
        }

        //Adds a node to the end of a list
        static void InsertBack(List list, Node nodeToAdd)
        {
            //Will contain the last current node
            Node lastNode = list.firstNode;

            nodeToAdd.nextNode = null;

            //if the list is empty, make this node the front
            if (list.firstNode == null)
            {
                nodeToAdd.prevNode = null;
                list.firstNode = nodeToAdd;
            }
            //goes to the end of the list, then alters prev and next node for the nodeToAdd
            else
            {
                while (lastNode.nextNode != null)
                {
                    lastNode = lastNode.nextNode;
                }

                lastNode.nextNode = nodeToAdd;
                nodeToAdd.prevNode = lastNode;
            }
        }

        //Prints out every node in the list
        static void ShowList(List list)
        {
            Node node = list.firstNode;
            while (node != null) //Until end of list
            {
                if (node.nextNode != null)
                {
                    Console.Write(node.data + " <-> ");
                }
                else
                {
                    Console.Write(node.data);
                }
                
                node = node.nextNode;
            }
            Console.WriteLine("");
        }
    }
}
