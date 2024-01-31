using System;
using test_coding.Models;

namespace test_coding.Services
{
	public class ReverceService
	{
        public Node ReverseList(Node head)
        {
            Node previousNode = null;
            Node currentNode = head;
            while (currentNode != null)
            {
                Node nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            return previousNode;
        }

        public Node BuildList(int[] values)
        {
            Node head = null;
            Node current = null;
            foreach (var value in values)
            {
                if (head == null)
                {
                    head = new Node(value);
                    current = head;
                }
                else
                {
                    current.Next = new Node(value);
                    current = current.Next;
                }
            }
            return head;
        }
    }
}

