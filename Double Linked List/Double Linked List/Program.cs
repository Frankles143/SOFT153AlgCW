using System;

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

        public Node(int d)
        {
            data = d; 
        }
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

            //Console.WriteLine("How many nodes would you like to add?");
            //nodesToAdd = Convert.ToInt32(Console.ReadLine());

            //Creates a pre-determined set of nodes
            for (int i = 0; i < nodesToAdd; i++)
            {
                //node = new Node(r.Next(100));
                InsertFront(list, r.Next(100));
            }

            ShowList(list);
            LengthOfList(list);

            for (int i = 0; i < nodesToAdd; i++)
            {
                node = new Node(r.Next(100));
                InsertBack(list, node);
            }

            node = new Node(13);
            InsertAfter(list, node, list.firstNode.nextNode.nextNode);

            ShowList(list);
            LengthOfList(list);

            Console.ReadLine();
        }

        ////Adds a node at the beginning of a list
        //static void InsertFront(List list, Node nodeToAdd)
        //{
        //    //pushes the current first node to be the next node
        //    nodeToAdd.nextNode = list.firstNode;
        //    nodeToAdd.prevNode = null;

        //    //changes prevNode of the firstNode to be the new node
        //    if (list.firstNode != null)
        //    {
        //        list.firstNode.prevNode = nodeToAdd;
        //    }   

        //    //the new node then becomes the first node
        //    list.firstNode = nodeToAdd;
        //}

        //Adds a node at the beginning of a list
        static void InsertFront(List list, int data)
        {
            Node nodeToAdd = new Node(data);

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

        //Inserts a node after a specific node
        static void InsertAfter(List list, Node nodeToAdd, Node nodeBefore)
        {
            if (nodeBefore == null)
            {
                Console.WriteLine("The target node cannot be null");
            }
            else
            {
                //puts the new node in after the nodeBefore
                nodeToAdd.nextNode = nodeBefore.nextNode;
                nodeBefore.nextNode = nodeToAdd;
                nodeToAdd.prevNode = nodeBefore;

                //changes the previous node of the node after nodeToAdd
                if (nodeToAdd.nextNode != null)
                {
                    nodeToAdd.nextNode.prevNode = nodeToAdd;
                }
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

        //Prints out number of nodes in a list
        static void LengthOfList(List list)
        {
            int count = 0;
            Node counter = list.firstNode;

            //adds to a counter until end of list
            while (counter != null)
            {
                count++;
                counter = counter.nextNode;
            }

            Console.WriteLine("There are " + count + " nodes in the list.");
        }
    }
}
