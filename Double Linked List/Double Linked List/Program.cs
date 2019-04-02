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
            int nodesToAdd = 5;

            //CAN'T USE RANDOM - CREATE OWN - YOU WILL LOSE A MARK
            Random r = new Random();                            //
            //CAN'T USE RANDOM - CREATE OWN - YOU WILL LOSE A MARK

            //Console.WriteLine("How many nodes would you like to add?");
            //nodesToAdd = Convert.ToInt32(Console.ReadLine());

            //Creates a pre-determined number of nodes
            for (int i = 0; i < nodesToAdd; i++)
            {
                InsertFront(list, r.Next(100));
            }

            ShowList(list);
            PrintLengthOfList(list);

            for (int i = 0; i < nodesToAdd; i++)
            {
                InsertBack(list, r.Next(100));
            }

            InsertAfter(list, 13, 3);

            ShowList(list);
            PrintLengthOfList(list);

            FindNodeData(list, 13);
            FindNode(list, list.firstNode.nextNode.nextNode);

            ShowTraversal(list);

            Console.ReadLine();
        }

        static Node CreateNode(int data)
        {
            Node node = new Node();
            node.data = data;
            return node;
        }

        //Adds a node at the beginning of a list
        static void InsertFront(List list, int data)
        {
            Node nodeToAdd = CreateNode(data);

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
        static void InsertBack(List list, int data)
        {
            Node nodeToAdd = CreateNode(data);
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
        static void InsertAfter(List list, int data, int nodeBeforeNumber)
        {
            Node nodeToAdd = CreateNode(data);
            Node nodeBefore = new Node();
            nodeBefore = list.firstNode;

            if (nodeBeforeNumber == 0 || nodeBeforeNumber > LengthOfList(list))
            {
                Console.WriteLine("The target node cannot be null");
            }
            else
            {
                //increases the nodeBefore to represent the int value that was passed in
                for (int i = 1; i < nodeBeforeNumber; i++)
                {
                    nodeBefore = nodeBefore.nextNode;
                }

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
            while (node != null)
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

        //Prints out every node in the forwards and backwards
        static void ShowTraversal(List list)
        {
            Node node = list.firstNode;
            Node lastNode = new Node();
            //Forward
            while (node != null)
            {
                if (node.nextNode != null)
                {
                    Console.Write(node.data + " <-> ");
                }
                else
                {
                    Console.Write(node.data);
                }
                lastNode = node;
                node = node.nextNode;
            }
            Console.WriteLine("");
            //Backward
            while (lastNode != null)
            {
                if (lastNode.prevNode != null)
                {
                    Console.Write(lastNode.data + " <-> ");
                }
                else
                {
                    Console.Write(lastNode.data);
                }
                lastNode = lastNode.prevNode;
            }
            Console.WriteLine("");
        }

        //Finds a node based on the node data
        static bool FindNodeData(List list, int nodeData)
        {
            Node nodeToCheck = list.firstNode;

            for (int i = 0; i < LengthOfList(list); i++)
            {
                if (nodeToCheck.data == nodeData)
                {
                    Console.WriteLine("Node found; number: " + (i+1));
                    return true;
                }
                nodeToCheck = nodeToCheck.nextNode;
            }
            Console.WriteLine("Node not found");
            return false;
        }

        //Finds a node based on node passed in
        static bool FindNode(List list, Node nodeToFind)
        {
            Node nodeToCheck = list.firstNode;
            if (nodeToFind != null)
            {
                for (int i = 0; i < LengthOfList(list); i++)
                {
                    if (nodeToCheck == nodeToFind)
                    {
                        Console.WriteLine("Node found; number: " + (i + 1));
                        return true;
                    }
                    nodeToCheck = nodeToCheck.nextNode;
                }
            }
            Console.WriteLine("Node not found");
            return false;
        }

        //Prints out number of nodes in a list
        static void PrintLengthOfList(List list)
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

        //returns number of nodes in a list
        static int LengthOfList(List list)
        {
            int count = 0;
            Node counter = list.firstNode;

            //adds to a counter until end of list
            while (counter != null)
            {
                count++;
                counter = counter.nextNode;
            }
            return count;
        }
    }
}
