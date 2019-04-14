using System;

//Author: Josh Franklin
//Created: 21/03/19
//Edited: JF 21/03/19
//
//Creating a double linked list and adding functionality

namespace Double_Linked_List
{
    //Node class with references to the next and previous nodes
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
            List listTwo = new List();
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
                InsertFront(listTwo, r.Next(100));
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

            FindNode(list, 13);
            FindNode(list, list.firstNode.nextNode.nextNode);

            Console.WriteLine("Remove first node:");
            RemoveFirstNode(list);
            ShowList(list);

            Console.WriteLine("Remove 4th node:");
            RemoveNode(list, 4);
            ShowList(list);

            Console.WriteLine("2 nodes will be swapped: ");
            SwapNodes(list, list.firstNode.nextNode, list.firstNode.nextNode.nextNode.nextNode.nextNode.nextNode);
            ShowList(list);

            Console.WriteLine("Add another list onto the end");
            AppendList(list, listTwo);
            ShowList(list);

            Console.WriteLine("Sort the list: ");
            InsertionSort(list);
            ShowList(list);

            Console.WriteLine("");

            ShowTraversal(list);

            Console.ReadLine();
        }

        //Creates a node with data
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

        //Appends listTwo on the end of listOne 
        static void AppendList(List listOne, List listTwo)
        {
            Node listOneLastNode = listOne.firstNode;

            while (listOneLastNode.nextNode != null)
            {
                listOneLastNode = listOneLastNode.nextNode;
            }

            listOneLastNode.nextNode = listTwo.firstNode;
            listTwo.firstNode.prevNode = listOneLastNode;
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

        //Inserts a node after a specific node reference
        static void InsertAfter(List list, int data, Node nodeBefore)
        {
            Node nodeToAdd = CreateNode(data);

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

        //Removes the first node in list
        static Node RemoveFirstNode(List list)
        {
            Node nodeToBeRemoved = list.firstNode;

            //Checks to make sure there are at least 2 nodes in the list
            if (list.firstNode != null && list.firstNode.nextNode != null)
            {
                list.firstNode = list.firstNode.nextNode;
                list.firstNode.prevNode = null;
            }
            else
            {
                Console.WriteLine("Cannot remove first node if no other nodes are in the list!");
            }
            //returns the removed node
            return nodeToBeRemoved;
        }

        //Removes a node, given a specific node reference
        static Node RemoveNode(List list, Node nodeToBeRemoved)
        {
            if (nodeToBeRemoved == list.firstNode.prevNode || nodeToBeRemoved == null)
            {
                Console.WriteLine("The target node cannot be null");
            }
            else
            {
                //checks to see if this is the last node
                if (nodeToBeRemoved.nextNode == null)
                {
                    nodeToBeRemoved.prevNode.nextNode = null;
                }

                //checks to see if this is the first node
                if (nodeToBeRemoved.prevNode == null)
                {
                    nodeToBeRemoved.nextNode.prevNode = null;
                }

                //changes the target of the next nodes prevNode and the previous nodes nextNode
                nodeToBeRemoved.nextNode.prevNode = nodeToBeRemoved.prevNode;
                nodeToBeRemoved.prevNode.nextNode = nodeToBeRemoved.nextNode;
            }


            return nodeToBeRemoved;
        }

        //Removes a specific node given node number
        static Node RemoveNode(List list, int nodeNumber)
        {
            Node nodeToBeRemoved = new Node();

            if (nodeNumber == 0 || nodeNumber > LengthOfList(list))
            {
                Console.WriteLine("The target node cannot be null");
            }
            else
            {
                //traverse to nodeToBeRemoved using the nodeNumber
                nodeToBeRemoved = list.firstNode;
                for (int i = 1; i < nodeNumber; i++)
                {
                    nodeToBeRemoved = nodeToBeRemoved.nextNode;
                }

                //checks to see if this is the last node
                if (nodeToBeRemoved.nextNode == null)
                {
                    nodeToBeRemoved.prevNode.nextNode = null;
                }

                //checks to see if this is the first node
                if (nodeToBeRemoved.prevNode == null)
                {
                    nodeToBeRemoved.nextNode.prevNode = null;
                }

                //changes the target of the next nodes prevNode and the previous nodes nextNode
                nodeToBeRemoved.nextNode.prevNode = nodeToBeRemoved.prevNode;
                nodeToBeRemoved.prevNode.nextNode = nodeToBeRemoved.nextNode;
            }
            //returns the removed node
            return nodeToBeRemoved;
        }

        //Swaps 2 nodes
        static void SwapNodes(List list, Node nodeOne, Node nodeTwo)
        {
            Node nodeOnePrev = nodeOne.prevNode; 
            Node nodeOneNext = nodeOne.nextNode; 

            Node nodeTwoPrev = nodeTwo.prevNode;
            Node nodeTwoNext = nodeTwo.nextNode; 

            //check if either nodes are the first in list, if so, update the firstnode
            if (list.firstNode == nodeOne)
            {
                list.firstNode = nodeTwo;
            }
            else if (list.firstNode == nodeTwo)
            {
                list.firstNode = nodeOne;
            }

            if (nodeOnePrev != null)
            {
                nodeOnePrev.nextNode = nodeTwo;
            }

            nodeTwo.prevNode = nodeOnePrev;
            nodeTwo.nextNode = nodeOneNext;

            if (nodeOneNext != null)
            {
                nodeOneNext.prevNode = nodeTwo;
            }

            if (nodeTwoPrev != null)
            {
                nodeTwoPrev.nextNode = nodeOne;
            }

            nodeOne.prevNode = nodeTwoPrev;
            nodeOne.nextNode = nodeTwoNext;

            if (nodeTwoNext != null)
            {
                nodeTwoNext.prevNode = nodeOne;
            }

        }

        //Sorts a given list by node data
        static void InsertionSort(List list)
        {
            Node currentNode = list.firstNode;
            List sortedList = new List();

            //Until end of list
            while (currentNode!= null)
            {
                Node next = currentNode.nextNode;

                //Clear links to old list
                currentNode.nextNode = null;
                currentNode.prevNode = null;

                //Run a sort function
                InsertSorted(sortedList, currentNode);

                currentNode = next;
            }
            list.firstNode = sortedList.firstNode;
        }

        //Insert a node into a list, sorted by it's data
        static void InsertSorted(List list, Node node)
        {
            Node currentNode = new Node();

            //If the list is empty make it the first node
            if (list.firstNode == null)
            {
                list.firstNode = node;
            }
            //If the data is less than the current first node, make it the firstnode
            else if (list.firstNode.data >= node.data)
            {
                node.nextNode = list.firstNode;
                node.nextNode.prevNode = node;
                list.firstNode = node;
            }
            //Anything else:
            else
            {
                currentNode = list.firstNode;

                while (currentNode.nextNode != null)
                {
                    //Find the place in the list the node needs to be inserted
                    if (node.data < currentNode.nextNode.data)
                    {
                        node.nextNode = currentNode.nextNode;
                        node.nextNode.prevNode = node;
                        currentNode.nextNode = node;
                        node.prevNode = currentNode;

                        break;
                    }
                    //Checks to see if the data is bigger than the last node in list
                    else if (node.data > currentNode.nextNode.data && currentNode.nextNode.nextNode == null)
                    {
                        node.nextNode = null;
                        currentNode.nextNode.nextNode = node;
                        node.prevNode = currentNode.nextNode;
                    }

                    currentNode = currentNode.nextNode;
                }
            }
        }

        //Quicksort
        static void Quicksort()
        {

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
            Console.WriteLine("Forward list");
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
            Console.WriteLine("Backward list");
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
        static bool FindNode(List list, int nodeData)
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
