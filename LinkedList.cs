using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ApplicationCore;

namespace LinkedList
{
    internal static class MathExtraMethods
    {
        public static bool DividesCompletelyBy(this short number, short divider)
        {
            return number == number / divider * divider;
        }

        public static bool IsEvenIndex(this int number)
        {
            return (number + 1) % 2 == 0;
        }

        public static bool IsOddIndex(this int number)
        {
            return (number + 1) % 2 == 1;
        }
    }

    internal class NodeExtraFunctions
    {
        public static void GoNext(ref Node? node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("cannot move forward a null node");
            }
            node = node.NextNode;
        }
    }

    internal class InfRangedIndexes : IEnumerable<int>
    {
        public InfRangedIndexes() { }

        public IEnumerator<int> GetEnumerator()
        {
            return EnumeratorImplementation();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return EnumeratorImplementation();
        }

        private IEnumerator<int> EnumeratorImplementation()
        {
            for (int i = 0; true; i++)
            {
                yield return i;
            }
        }
    }

    public class Node
    {
        public Node(short value)
        {
            Value = value;
        }

        public void SetNextNode(Node? newNextNode)
        {
            NextNode = newNextNode;
        }

        public short Value { get; set; }
        public Node? NextNode { get; private set; }
    }

    public class LinkedList : IEnumerable<short>
    {
        public LinkedList() { }

        public LinkedList(params short[] initializerList)
        {
            foreach (short newElement in initializerList)
            {
                Add(newElement);
            }
        }

        public void Add(short newElement)
        {
            Node newNode = new Node(newElement);

            if (elementsCount == 0)
            {
                firstNode = newNode;
                lastNode = newNode;
            }
            else
            {
                lastNode.SetNextNode(newNode);
                NodeExtraFunctions.GoNext(ref lastNode);
            }

            elementsCount++;
        }

        public short this[int index, short newValue]
        {
            get
            {
                if (! (0 <= index && index < elementsCount))
                {
                    throw new IndexOutOfRangeException($"cannot obtain the element at the index {index}");
                }
                return NodeEnumerator().Skip(index).First().Value;
            }
            set
            {
                if (! (0 <= index && index < elementsCount))
                {
                    throw new IndexOutOfRangeException($"cannot set the element's value at the index {index}");
                }
                NodeEnumerator().Skip(index).First().Value = newValue;
            }
        }

        public short GetFirstElementCompletelyDivivesBy(short divider)
        {
            foreach (short element in this)
            {
                if (element.DividesCompletelyBy(divider))
                {
                    return element;
                }
            }

            throw new ArgumentException($"there is no such value which completely divides on {divider}");
        }

        public void ZeroEvenPosedElems()
        {
            foreach ((Node node, int index) in NodeEnumerator().Zip(new InfRangedIndexes()))
            {
                if (index.IsEvenIndex())
                {
                    node.Value = 0;
                }
            }
        }

        public LinkedList GetAllElementsGreaterThan(short greaterThan)
        {
            LinkedList newList = new LinkedList();

            foreach (short element in this)
            {
                if (element > greaterThan)
                {
                    newList.Add(element);
                }
            }

            return newList;
        }

        public void RemoveOddPosedOnes()
        {
            LinkedList newList = new LinkedList();

            foreach ((Node node, int index) in NodeEnumerator().Zip(new InfRangedIndexes()))
            {
                if (! index.IsOddIndex())
                {
                    newList.Add(node.Value);
                }
            }

            SubstituteAsMove(newList);
        }

        public short[] ToArray()
        {
            short[] arrayRepresentation = new short[elementsCount];
            int newArrayIndexer = 0;

            foreach (short outElement in this)
            {
                arrayRepresentation[newArrayIndexer] = outElement;

                newArrayIndexer++;
            }

            return arrayRepresentation;
        }

        public IEnumerator<short> GetEnumerator()
        {
            Node? currentNode = firstNode;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                NodeExtraFunctions.GoNext(ref currentNode);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void SubstituteAsMove(LinkedList oldLinkedList)
        {
            firstNode = oldLinkedList.firstNode;
            lastNode  = oldLinkedList.lastNode;
            
            elementsCount = oldLinkedList.elementsCount;

            oldLinkedList.firstNode = null;
            oldLinkedList.lastNode = null;
        }

        private IEnumerable<Node> NodeEnumerator()
        {
            Node? currentNode = firstNode;

            while (currentNode != null)
            {
                yield return currentNode;

                NodeExtraFunctions.GoNext(ref currentNode);
            }
        }

        private Node? firstNode = null;
        private Node? lastNode = null;
        private int elementsCount = 0;
    }
}