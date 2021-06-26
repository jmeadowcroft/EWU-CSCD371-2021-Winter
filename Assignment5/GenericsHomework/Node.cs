using System;
using System.Collections.Generic;

namespace GenericsHomework
{
    public class Node<T>
    {
        public Node<T> Next { get; private set; }
        T Value { get; set; }

        public Node(T value, Node<T> next)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Value = value;

            if (next is null)
            {
                Next = this;
            }
            else
            {
                Next = next;
                if(Next.Next == Next)
                {
                    Next.Next = this;
                }
            }
        }

        public Node(T value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            Value = value;
            Next = this;
        }

        public override string? ToString()
        {
            return Value?.ToString();
        }

        public void Insert(T value)
        {
            Node<T> nextNode = new Node<T>(value, Next);
            Next = nextNode;
        }
        public void DestroyLinks()
        {
            if(Next != this)
            {
                Node<T>? currentNode = Next;
                Node<T> nextNode = currentNode.Next;
                do
                {
                    nextNode = currentNode.Next;
                    currentNode.Next = this;
                    currentNode = nextNode;
                }
                while (currentNode != this);
            }
            Next = this;
        }
    }
}
