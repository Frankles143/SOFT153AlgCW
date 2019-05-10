using System;

//Author: Josh Franklin
//Created: 21/03/19
//Edited: JF 09/05/19
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
            List listThree = new List();
            int nodesToAdd = 5;

            Random r = new Random();

            //Creates a pre-determined number of nodes
            for (int i = 0; i < nodesToAdd; i++)
            {
                InsertFront(list, r.Next(100));
                InsertFront(listTwo, r.Next(100));
                InsertFront(listThree, r.Next(100));
                InsertFront(listThree, r.Next(100));
            }

            //Showing the list and how long it is
            ShowList(list);
            PrintLengthOfList(list);

            //Inserting nodes to the back of a list
            for (int i = 0; i < nodesToAdd; i++)
            {
                InsertBack(list, r.Next(100));
            }

            //Inserting a node after a specific node, using a number or node reference
            InsertAfter(list, 13, 3);

            ShowList(list);
            PrintLengthOfList(list);

            //Finding two nodes, one based on data, the other by node reference 
            FindNode(list, 13);
            FindNode(list, list.firstNode.nextNode.nextNode);

            //Removes the first node in the list
            Console.WriteLine("\nRemove first node:");
            RemoveFirstNode(list);
            ShowList(list);

            //Removes x node in list, using number or node reference
            Console.WriteLine("\nRemove 4th node:");
            RemoveNode(list, 4);
            ShowList(list);

            //Swapping two nodes by node reference
            Console.WriteLine("\n2 nodes will be swapped: ");
            SwapNodes(list, list.firstNode.nextNode, list.firstNode.nextNode.nextNode.nextNode.nextNode.nextNode);
            ShowList(list);

            //Adds a list onto the end of another, by list reference
            Console.WriteLine("\nAdd another list onto the end");
            AppendList(list, listTwo);
            ShowList(list);

            //Insertion sorting a list
            Console.WriteLine("\nInsertion sorting this list: ");
            ShowList(list);
            InsertionSort(list);
            Console.WriteLine("Sorted!");
            ShowList(list);

            //Quicksorting a list
            Console.WriteLine("\nQuicksorting this list: ");
            ShowList(listThree);
            Quicksort(listThree);
            Console.WriteLine("Sorted!");
            ShowList(listThree);

            //Showing that a list can be travelled in both directions
            Console.WriteLine("");
            ShowTraversal(list);
            Console.WriteLine("");

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
            //Create a node to add
            Node nodeToAdd = CreateNode(data);

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
                //Grab last node from the list
                Node lastNode = LastNode(list);

                lastNode.nextNode = nodeToAdd;
                nodeToAdd.prevNode = lastNode;
            }
        }

        //Appends listTwo on the end of listOne 
        static void AppendList(List listOne, List listTwo)
        {
            Node listOneLastNode = LastNode(listOne);

            listOneLastNode.nextNode = listTwo.firstNode;
            listTwo.firstNode.prevNode = listOneLastNode;
        }

        //Inserts a node after a specific node - using a node number
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

        static void SwapNodes(List list, Node nodeOne, Node nodeTwo)
        {
            Node nodeOnePrev = nodeOne.prevNode;
            Node nodeOneNext = nodeOne.nextNode;

            Node nodeTwoPrev = nodeTwo.prevNode;
            Node nodeTwoNext = nodeTwo.nextNode;

            //Checks if the nodes are adjacent
            if (nodeOne.nextNode == nodeTwo)
            {
                nodeOne.nextNode = nodeTwoNext;
                nodeOne.prevNode = nodeTwo;

                nodeTwo.nextNode = nodeOne;
                nodeTwo.prevNode = nodeOnePrev;

                FirstNodeCheck(nodeOnePrev, nodeTwo);
            }
            else if (nodeTwo.nextNode == nodeOne)
            {
                nodeTwo.nextNode = nodeOneNext;
                nodeTwo.prevNode = nodeOne;

                nodeOne.nextNode = nodeTwo;
                nodeOne.prevNode = nodeTwoPrev;

                FirstNodeCheck(nodeTwoPrev, nodeOne);
            }
            else
            {
                //check if either nodes are the first in list, if so, update the first node
                if (list.firstNode == nodeOne)
                {
                    list.firstNode = nodeTwo;
                }
                else if (list.firstNode == nodeTwo)
                {
                    list.firstNode = nodeOne;
                }

                nodeTwo.prevNode = nodeOnePrev;
                nodeTwo.nextNode = nodeOneNext;

                nodeOne.prevNode = nodeTwoPrev;
                nodeOne.nextNode = nodeTwoNext;

                //Makes sure neither node is the first node
                FirstNodeCheck(nodeTwoPrev, nodeOne);
                FirstNodeCheck(nodeOnePrev, nodeTwo);

                //Makes sure neither node is the last node
                LastNodeCheck(nodeTwoNext, nodeOne);
                LastNodeCheck(nodeOneNext, nodeTwo);
            }
        }

        private static void FirstNodeCheck(Node prevNode, Node node)
        {
            if (prevNode != null)
            {
                prevNode.nextNode = node;
            }
        }

        private static void LastNodeCheck(Node nextNode, Node node)
        {
            if (nextNode != null)
            {
                nextNode.prevNode = node;
            }
        }

        //Sorts a given list by node data
        static void InsertionSort(List list)
        {
            Node currentNode = list.firstNode;
            List sortedList = new List();

            //Until end of list
            while (currentNode != null)
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
                InsertFront(list, node.data);
            }
            //If the data is less than the current first node, make it the firstnode
            else if (node.data <= list.firstNode.data)
            {
                InsertFront(list, node.data);
            }
            //Anything else:
            else
            {
                currentNode = list.firstNode;

                while (currentNode != null)
                {
                    //Find the place in the list the node needs to be inserted
                    if (node.data <= currentNode.data)
                    {
                        InsertAfter(list, node.data, currentNode.prevNode);
                        break;
                    }
                    //Checks to see if the data is bigger than the last node in list
                    else if (node.data > currentNode.data && currentNode.nextNode == null)
                    {
                        InsertBack(list, node.data);
                        break;
                    }

                    currentNode = currentNode.nextNode;
                }
            }
        }

        //First quicksort call that then recursively quicksorts a list
        static void Quicksort(List list)
        {
            Quicksort(list, list.firstNode, LastNode(list));
        }

        static void Quicksort(List list, Node left, Node right)
        {
            //Don't continue if either are null or left has reached right
            if (left == right || left == null || right == null)
            {
                return;
            }

            //Find out which number node the left and right nodes are
            int leftNumber = FindNodeNumber(list, left), rightNumber = FindNodeNumber(list, right);

            if (leftNumber < rightNumber)
            {
                //Find the partition point of the list after swapping nodes
                Node partitionNode = QuicksortPartition(ref list, ref left, ref right);

                //Run quicksort on either side of the list
                Quicksort(list, left, partitionNode.prevNode);
                Quicksort(list, partitionNode.nextNode, right);
            }
        }

        //Part of the quicksort function, it swaps node and returns a partition node
        static Node QuicksortPartition(ref List list, ref Node left, ref Node right)
        {
            Node leftPointer = left, rightPointer = right.prevNode, pivot = right;

            //Continue as long as the leftPointer does not reach the right pointer
            while (leftPointer != rightPointer)
            {
                //Carry on if the leftPointer is greater than the pivot
                if (leftPointer.data > pivot.data)
                {
                    //Cycle the right pointer until it is a node that is less than the pivot
                    while (rightPointer.data > pivot.data && leftPointer != rightPointer)
                    {
                        rightPointer = rightPointer.prevNode;
                    }

                    //break if the pointers are the same
                    if (leftPointer == rightPointer)
                    {
                        break;
                    }

                    if (leftPointer == left)
                    {
                        left = rightPointer;
                    }

                    Node tempLeftPointer = leftPointer, tempRightPointer = rightPointer;

                    SwapNodes(list, leftPointer, rightPointer);

                    leftPointer = tempRightPointer;
                    rightPointer = tempLeftPointer;
                }

                leftPointer = leftPointer.nextNode;
            }

            if (left.nextNode == right && left.data < right.data)
            {
                left = right;
            }

            //Swap leftPointer and pivot, only if leftPointer is larger
            if (leftPointer.data <= pivot.data)
            {
                return pivot;
            }

            SwapNodes(list, leftPointer, pivot);
            right = leftPointer;

            return pivot;
        }

        //Returns last node in list
        static Node LastNode(List list)
        {
            Node node = list.firstNode;

            while (node.nextNode != null)
            {
                node = node.nextNode;
            }

            return node;
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
            int length = LengthOfList(list);

            for (int i = 0; i < length; i++)
            {
                if (nodeToCheck.data == nodeData)
                {
                    Console.WriteLine("Node found; number: " + (i + 1));
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
            int length = LengthOfList(list);
            if (nodeToFind != null)
            {
                for (int i = 0; i < length; i++)
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

        //Finds a node number based on node passed in
        static int FindNodeNumber(List list, Node nodeToFind)
        {
            Node nodeToCheck = list.firstNode;
            int count = 1;

            while (nodeToCheck != nodeToFind)
            {
                nodeToCheck = nodeToCheck.nextNode;
                count++;
            }
            return count;
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

        //Returns number of nodes in a list
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
