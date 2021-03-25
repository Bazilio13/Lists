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
            if (Length > 1)
            {
                _tail = _root;
                Node previous = null;
                Node next = _root.Next;
                while (!(_root.Next is null))
                {
                    _root.Next = previous;
                    previous = _root;
                    _root = next;
                    next = next.Next;
                }
                _root.Next = previous;
            }
        }

        public int GetMaxElement()
        {
            return GetMaxElementWithIndex()._root.Value;
        }
        public int GetIndexOfMaxElement()
        {
            return GetMaxElementWithIndex()._tail.Value;
        }

        public int GetMinElement()
        {
            return GetMinElementWithIndex()._root.Value;
        }

        public int GetIndexOfMinElement()
        {
            return GetMinElementWithIndex()._tail.Value;
        }

        public void MergeSort()
        {
            if (Length > 1)
            {


                LinkedList left = this;
                LinkedList right = this.CutRightHulf();
                if (left.Length > 1)
                {
                    left.MergeSort();
                }
                if (right.Length > 1)
                {
                    right.MergeSort();
                }

                LinkedList mergedList = new LinkedList();
                left._tail = left._root;
                Node currentLeft = left._root;
                Node currentRight = right._root;
                Node nextRight = currentRight.Next;
                if (right._root.Value < left._root.Value )
                {
                    left._root = right._root;
                    left._tail = right._root;
                    currentRight = currentRight.Next;
                    left.Length++;
                }
                else
                {
                    currentLeft = currentLeft.Next;
                }
                while (!(currentLeft is null))
                {
                    if (currentRight is null || currentLeft.Value <= currentRight.Value)
                    {
                        left._tail.Next = currentLeft;
                        left._tail = currentLeft;
                        currentLeft = currentLeft.Next;
                    }
                    else
                    {
                        while (!(currentRight is null))
                        {
                            if (currentRight.Value <= currentLeft.Value)
                            {
                                left._tail.Next = currentRight;
                                left._tail = currentRight;
                                currentRight = currentRight.Next;
                                if (!(nextRight is null))
                                {
                                    nextRight = nextRight.Next;
                                }
                                left.Length++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                while (!(currentRight is null))
                {
                    left._tail.Next = currentRight;
                    left._tail = currentRight;
                    currentRight = currentRight.Next;
                    left.Length++;
                }
                left._tail.Next = null;
            }
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
            if (this._tail.Value != list._tail.Value)
            {
                return false;
            }
            if (!(this._tail.Next is null) || !(list._tail.Next is null))
            {
                return false;
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
        private LinkedList CutRightHulf()
        {
            LinkedList rightHulf = new LinkedList();
            rightHulf._tail = _tail;
            _tail = GetNodeByIndex(Length / 2 - 1);
            rightHulf._root = _tail.Next;
            rightHulf.Length = Length - Length / 2;
            Length /= 2;
            _tail.Next = null;
            return rightHulf;
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

        private LinkedList GetMaxElementWithIndex()
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
            LinkedList maxElementWithIndex = new LinkedList(new int[] { maxElement, indexOfMaxElement });
            return maxElementWithIndex;
        }
        private LinkedList GetMinElementWithIndex()
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
            LinkedList maxElementWithIndex = new LinkedList(new int[] { minElement, indexOfMinElement });
            return maxElementWithIndex;
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
