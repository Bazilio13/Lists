using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class LinkedList
    {
        public int Length { get; private set; }

        private Node _root;
        private Node _tail;

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if (values.Length != 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    Add(values[i]);
                }
            }


        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }

            Length++;
        }

        public void AddToTheBeginning(int value)
        {
            Node tmpNode = _root;
            _root = new Node(value);
            _root.Next = tmpNode;
            if (Length == 0)
            {
                _tail = _root;
            }
            Length++;
        }

        public void AddByIndex(int value, int index)
        {
            if (index == 0)
            {
                AddToTheBeginning(value);
                return;
            }
            if (index == Length)
            {
                Add(value);
                return;
            }
            Node previousNode = GetNodeByIndex(index - 1);
            Node addedNode = new Node(value);
            addedNode.Next = previousNode.Next;
            previousNode.Next = addedNode;
            Length++;

        }

        public void RemoveFromTheEnd(int number = 1)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }

            if (Length == 0 || number == 0)
            {
                return;
            }
            if (Length <= number)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else
            {
                _tail = GetNodeByIndex(Length - number - 1);
                _tail.Next = null;
                Length -= number;
            }
        }

        public void RemoveFromTheBeginning(int number = 1)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }
            if (Length == 0 || number == 0)
            {
                return;
            }
            if (Length <= number)
            {
                _tail = null;
                _root = null;
                Length = 0;
            }
            else
            {
                _root = GetNodeByIndex(number);
                Length -= number;
            }
        }

        public void RemoveByIndex(int index, int number = 1)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (number < 0)
            {
                throw new ArgumentException();
            }
            if (index == 0)
            {
                RemoveFromTheBeginning(number);
            }
            else
            {
                Node previousNode = GetNodeByIndex(index - 1);
                if (Length - index <= number)
                {
                    _tail = previousNode;
                    _tail.Next = null;
                    Length = index;
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        previousNode.Next = previousNode.Next.Next;
                    }
                    Length -= number;
                }
            }

        }

        public int GetIndexByValue(int value)
        {
            int index = -1;
            Node currant = _root;
            for (int i = 0; i < Length; i++)
            {
                if (value == currant.Value)
                {
                    index = i;
                }
                currant = currant.Next;
            }
            return index;
        }

        public void ReversList()
        {
            if (Length < 2)
            {
                return;
            }
            Node current;
            current = _root;
            Node tmpNode;
            tmpNode = _tail;
            _tail = _root;
            _root = tmpNode;
            if (Length == 2)
            {
                _root.Next = _tail;
                _tail.Next = null;
            }
            else
            {
                Node previous = null;
                Node next = current.Next;
                while (!(current.Next is null))
                {
                    current.Next = previous;
                    previous = current;
                    current = next;
                    next = next.Next;
                }
                _root.Next = previous;

            }
        }

        public int GetMaxElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int maxElement;
            maxElement = _root.Value;
            Node current = _root;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (current.Value > maxElement)
                {
                    maxElement = current.Value;
                }
            }
            return maxElement;
        }
        public int GetIndexOfMaxElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int maxElement;
            maxElement = _root.Value;
            Node current = _root;
            int indexOfMaxElement = 0;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (current.Value > maxElement)
                {
                    maxElement = current.Value;
                    indexOfMaxElement = i;
                }
            }
            return indexOfMaxElement;
        }
        public int GetMinElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int minElement;
            minElement = _root.Value;
            Node current = _root;

            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (current.Value < minElement)
                {
                    minElement = current.Value;
                }
            }
            return minElement;
        }

        public int GetIndexOfMinElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int minElement;
            minElement = _root.Value;
            Node current = _root;
            int indexOfMinElement = 0;
            for (int i = 1; i < Length; i++)
            {
                current = current.Next;
                if (current.Value < minElement)
                {
                    minElement = current.Value;
                    indexOfMinElement = i;
                }
            }
            return indexOfMinElement;
        }

        public void AscendingSort()
        {
            Node iNode = _root;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j < Length; j++)
                {
                    if (iNode.Value > jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }
        public void DescendingSort()
        {
            Node iNode = _root;
            int tmp;
            for (int i = 0; i < Length; i++)
            {
                Node jNode = iNode.Next;
                for (int j = i + 1; j < Length; j++)
                {
                    if (iNode.Value < jNode.Value)
                    {
                        tmp = iNode.Value;
                        iNode.Value = jNode.Value;
                        jNode.Value = tmp;
                    }
                    jNode = jNode.Next;
                }
                iNode = iNode.Next;
            }
        }

        public int RemoveFirstByValue(int value)
        {
            Node current = _root;
            Node previous = null;
            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    RemoveCurrentNode(current, i, previous);

                    return i;
                }
                previous = current;
                current = current.Next;
            }

            return -1;
        }

        public int RemoveAllByValue(int value)
        {
            Node current = _root;
            Node previous = null;
            int countOfRemoved = 0;
            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    RemoveCurrentNode(current, i, previous);
                    countOfRemoved++;
                    i--;
                }
                previous = current;
                current = current.Next;
            }

            return countOfRemoved;
        }

        public void AddListToTheEnd(LinkedList list)
        {
            if (list.Length != 0)
            {
                LinkedList copy = Copy(list);
                if (Length == 0)
                {
                    _root = copy._root;
                    _tail = copy._tail;
                    Length = copy.Length;
                }
                else
                {
                    _tail.Next = copy._root;
                    _tail = copy._tail;
                    Length += copy.Length;
                }

            }
        }

        public void AddListToTheBeggining(LinkedList list)
        {
            if (list.Length != 0)
            {
                LinkedList copy = Copy(list);
                if (Length == 0)
                {
                    _root = copy._root;
                    _tail = copy._tail;
                    Length = copy.Length;
                }
                else
                {
                    copy._tail.Next = _root;
                    _root = copy._root;
                    Length += copy.Length;
                }

            }
        }

        public void AddListByIndex(LinkedList list, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (list.Length != 0)
            {

                if (index == 0)
                {
                    AddListToTheBeggining(list);
                }
                else if (index == Length)
                {
                    AddListToTheEnd(list);
                }
                else
                {
                    LinkedList copy = Copy(list);
                    if (Length == 0)
                    {
                        _root = copy._root;
                        _tail = copy._tail;
                        Length = copy.Length;
                    }
                    else
                    {
                        Node tmp;
                        tmp = GetNodeByIndex(index - 1);
                        copy._tail.Next = tmp.Next;
                        tmp.Next = copy._root;
                        Length += copy.Length;
                    }
                }
            }
        }

        public LinkedList Copy(LinkedList list)
        {
            LinkedList newList = new LinkedList();
            if (list.Length != 0)
            {
                Node current;
                current = list._root;
                for (int i = 0; i < list.Length; i++)
                {
                    newList.Add(current.Value);
                    current = current.Next;
                }
                newList._root = list._root;
                newList._tail = list._tail;
            }
            else
            {
                newList._root = list._root;
                newList._tail = list._tail;
                newList.Length = list.Length;
            }
            return newList;
        }

        public override string ToString()
        {
            string s = string.Empty;
            if (Length != 0)
            {
                Node current = _root;
                while (!(current.Next is null))
                {
                    s += current.Value + " ";
                    current = current.Next;
                }
                s += current.Value + " ";
            }

            return s;
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;
            if (this.Length != list.Length)
            {
                return false;
            }
            if (this.Length == 0)
            {
                return true;
            }
            Node currentThis = this._root;
            Node currentList = list._root;

            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }

            return true;
        }


        private void RemoveCurrentNode(Node currentNode, int index, Node previousNode)
        {
            if (index == 0)
            {
                _root = GetNewNextAndRemoveNode(currentNode);
            }
            else if (index == Length - 1)
            {
                _tail = previousNode;
                _tail.Next = null;
                Length--;
            }
            else
            {
                previousNode.Next = GetNewNextAndRemoveNode(currentNode);
            }
        }

        private Node GetNewNextAndRemoveNode(Node node)
        {
            Length--;
            if (!(node.Next is null))
            {
                return node.Next;
            }
            return null;
        }
        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            Node current;
            if (index == Length - 1)
            {
                current = _tail;
            }
            else
            {
                current = _root;


                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            return current;
        }
    }
}
