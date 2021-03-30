using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class DoubleLinkedList
    {
        private DoubleLinkedListNode _root;
        private DoubleLinkedListNode _tail;

        public int Length { get; private set; }

        public DoubleLinkedList()
        {
            _root = null;
            _tail = null;
            Length = 0;
        }

        public DoubleLinkedList(int value)
        {
            Add(value);
        }

        public DoubleLinkedList(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Add(values[i]);
            }
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
            DoubleLinkedListNode currentNode = GetNodeByIndex(index);
            DoubleLinkedListNode addedNode = new DoubleLinkedListNode(value);
            addedNode.Next = currentNode;
            addedNode.Previous = currentNode.Previous;
            currentNode.Previous = addedNode;
            addedNode.Previous.Next = addedNode;
            Length++;

        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new DoubleLinkedListNode(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new DoubleLinkedListNode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }

            Length++;
        }

        public void AddToTheBeginning(int value)
        {
            if (Length == 0)
            {
                Add(value);
            }
            else
            {
                _root.Previous = new DoubleLinkedListNode(value);
                _root.Previous.Next = _root;
                _root = _root.Previous;
                Length++;
            }
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
                _root.Previous = null;
                Length -= number;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                RemoveFromTheBeginning();
            }
            else
            {
                if (index == Length - 1)
                {
                    RemoveFromTheEnd();
                }
                else
                {
                    DoubleLinkedListNode removingNode = GetNodeByIndex(index);
                    removingNode.Previous.Next = removingNode.Next;
                    removingNode.Next.Previous = removingNode.Previous;
                    Length--;
                }
            }

        }

        public void RemoveByIndex(int index, int number)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (number < 0)
            {
                throw new ArgumentException();
            }
            if (number == 0) return;
            if (index == 0)
            {
                RemoveFromTheBeginning(number);
            }
            else
            {
                if (Length - index <= number)
                {
                    DoubleLinkedListNode previousNode = GetNodeByIndex(index - 1);
                    _tail = previousNode;
                    _tail.Next = null;
                    Length = index;
                }
                else
                {
                    DoubleLinkedList segment = GetSegmentOfList(index, index + number - 1);
                    segment._root.Previous.Next = segment._tail.Next;
                    segment._tail.Next.Previous = segment._root.Previous;
                    Length -= number;
                }
            }
        }

        public int GetIndexByValue(int value)
        {
            int index = -1;
            DoubleLinkedListNode currant = _root;
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
                DoubleLinkedListNode current = _root;
                DoubleLinkedListNode tmp;
                while (!(current is null))
                {
                    tmp = current.Next;
                    current.Next = current.Previous;
                    current.Previous = tmp;
                    current = tmp;
                }
                tmp = _root;
                _root = _tail;
                _tail = tmp;
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

        public void AscendingSort()
        {
            if (Length > 1)
            {
                DoubleLinkedList right = this.CutRightHulf();
                if (Length > 1)
                {
                    AscendingSort();
                }
                if (right.Length > 1)
                {
                    right.AscendingSort();
                }
                Merge(right, true);
            }
        }

        public void DescendingSort()
        {
            if (Length > 1)
            {
                DoubleLinkedList right = this.CutRightHulf();
                if (Length > 1)
                {
                    DescendingSort();
                }
                if (right.Length > 1)
                {
                    right.DescendingSort();
                }
                Merge(right, false);
            }
        }

        public int RemoveFirstByValue(int value)
        {
            DoubleLinkedListNode current = _root;
            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    RemoveCurrentNode(current, i);
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public int RemoveAllByValue(int value)
        {
            int countOfRemoved = 0;
            DoubleLinkedListNode current = _root;
            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    RemoveCurrentNode(current, i);
                    countOfRemoved++;
                    i--;
                }
                current = current.Next;
            }

            return countOfRemoved;
        }

        public void AddListToTheEnd(DoubleLinkedList list)
        {
            if (list.Length != 0)
            {
                DoubleLinkedList copy = Copy(list);
                if (Length == 0)
                {
                    _root = copy._root;
                    _tail = copy._tail;
                    Length = copy.Length;
                }
                else
                {
                    _tail.Next = copy._root;
                    copy._root.Previous = _tail;
                    _tail = copy._tail;
                    Length += copy.Length;
                }

            }
        }

        public void AddListToTheBeggining(DoubleLinkedList list)
        {
            if (list.Length != 0)
            {
                DoubleLinkedList copy = Copy(list);
                if (Length == 0)
                {
                    _root = copy._root;
                    _tail = copy._tail;
                    Length = copy.Length;
                }
                else
                {
                    copy._tail.Next = _root;
                    _root.Previous = copy._tail;
                    _root = copy._root;
                    Length += copy.Length;
                }

            }
        }

        public void AddListByIndex(DoubleLinkedList list, int index)
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
                    DoubleLinkedList copy = Copy(list);
                    DoubleLinkedListNode tmp;
                    tmp = GetNodeByIndex(index);
                    copy._tail.Next = tmp;
                    copy._root.Previous = tmp.Previous;
                    tmp.Previous.Next = copy._root;
                    tmp.Previous = copy._tail;
                    Length += copy.Length;
                }
            }
        }

        public DoubleLinkedList Copy(DoubleLinkedList list)
        {
            DoubleLinkedList newList = new DoubleLinkedList();
            if (list.Length != 0)
            {
                DoubleLinkedListNode current = list._root;
                while (!(current is null))
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
                DoubleLinkedListNode current = _root;
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
            DoubleLinkedList list = (DoubleLinkedList)obj;
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
            DoubleLinkedListNode currentThis = this._root;
            DoubleLinkedListNode currentList = list._root;

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

        public void RemoveCurrentNode(DoubleLinkedListNode current, int index)
        {
            if (index == 0)
            {
                RemoveFromTheBeginning();
            }
            else if (index == Length - 1)
            {
                RemoveFromTheEnd();
            }
            else
            {
                current.Next.Previous = current.Previous;
                current.Previous.Next = current.Next;
                Length--;
            }

        }

        private void Merge(DoubleLinkedList rightList, bool isAscending)
        {
            DoubleLinkedListNode currentLeft = _root;
            DoubleLinkedListNode currentRight = rightList._root;
            if (rightList._root.Value >= _root.Value ^ isAscending)
            {
                _root = rightList._root;
                _tail = rightList._root;
                currentRight = currentRight.Next;
            }
            else
            {
                _tail = _root;
                currentLeft = currentLeft.Next;
            }
            while (!(currentLeft is null))
            {
                if (currentRight is null || (currentLeft.Value >= currentRight.Value ^ isAscending))
                {
                    HookNode(currentLeft);
                    currentLeft = currentLeft.Next;
                }
                else
                {
                    while (!(currentRight is null))
                    {
                        if (currentRight.Value >= currentLeft.Value ^ isAscending)
                        {
                            HookNode(currentRight);
                            currentRight = currentRight.Next;
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
                HookNode(currentRight);
                currentRight = currentRight.Next;
            }
            _tail.Next = null;
            Length += rightList.Length;
        }

        private DoubleLinkedList CutRightHulf()
        {
            DoubleLinkedList rightHulf = new DoubleLinkedList();
            rightHulf._tail = _tail;
            _tail = GetNodeByIndex(Length / 2 - 1);
            rightHulf._root = _tail.Next;
            rightHulf._root.Previous = null;
            rightHulf.Length = Length - Length / 2;
            Length /= 2;
            _tail.Next = null;
            return rightHulf;
        }

        private void HookNode(DoubleLinkedListNode hookedNode)
        {
            _tail.Next = hookedNode;
            hookedNode.Previous = _tail;
            _tail = hookedNode;
        }

        private DoubleLinkedList GetMaxElementWithIndex()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int maxElement;
            maxElement = _root.Value;
            DoubleLinkedListNode current = _root;
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
            DoubleLinkedList maxElementWithIndex = new DoubleLinkedList(new int[] { maxElement, indexOfMaxElement });
            return maxElementWithIndex;
        }
        private DoubleLinkedList GetMinElementWithIndex()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int minElement;
            minElement = _root.Value;
            DoubleLinkedListNode current = _root;
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
            DoubleLinkedList maxElementWithIndex = new DoubleLinkedList(new int[] { minElement, indexOfMinElement });
            return maxElementWithIndex;
        }

        private DoubleLinkedListNode GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            DoubleLinkedListNode current;
            if (index > Length / 2)
            {
                current = _tail;
                current = StepLeft(current, Length - 1 - index);
            }
            else
            {
                current = _root;
                current = StepRight(current, index);
            }
            return current;
        }

        private DoubleLinkedList GetSegmentOfList(int indexLeft, int indexRight)
        {
            DoubleLinkedList segment = new DoubleLinkedList();
            if (indexLeft <= Length - 1 - indexRight)
            {
                segment._root = GetNodeByIndex(indexLeft);
                segment._tail = _tail;
                segment.Length = Length - indexLeft;
                segment._tail = segment.GetNodeByIndex(indexRight - indexLeft);
            }
            else
            {
                segment._root = _root;
                segment._tail = GetNodeByIndex(indexRight);
                segment.Length = indexRight + 1;
                segment._root = segment.GetNodeByIndex(indexLeft);
            }
            return segment;
        }

        private DoubleLinkedListNode StepLeft(DoubleLinkedListNode current, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                current = current.Previous;
            }
            return current;
        }

        private DoubleLinkedListNode StepRight(DoubleLinkedListNode current, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                current = current.Next;
            }
            return current;
        }


    }
}
