using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }
        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }
        public ArrayList(int[] value)
        {
            Length = value.Length;
            _array = new int[value.Length];
            _array = (int[])value.Clone();
        }

        public int this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }

            _array[Length] = value;
            Length++;
        }
        public void AddToTheBeginning(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            ShiftRight(0,1);
            _array[0] = value;
        }

        public void AddByIndex (int value, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length == _array.Length)
            {
                UpSize();
            }
            ShiftRight(index, 1);
            _array[index] = value;
        }

        //public void RemoveFromTheEnd ()
        //{
        //    if (Length == 0)
        //    {
        //        return;
        //    }
        //    if (Length == (int)(_array.Length * 0.67 + 1) )
        //    {
        //        DownSize();
        //    }

        //    Length--;
        //}

        //public void RemoveFromTheBeginning()
        //{
        //    if (Length == 0)
        //    {
        //        return;
        //    }
        //    int[] tmpArray = new int[_array.Length];
        //    for (int i = 1; i < Length; i++)
        //    {
        //        tmpArray[i-1] = _array[i];
        //    }
        //    _array = tmpArray;
        //    Length--;

        //    if (Length == (int)(_array.Length * 0.67 + 1))
        //    {
        //        DownSize();
        //    }

        //}

        //public void RemoveByIndex(int index)
        //{
        //    if (index >= Length || index < 0)
        //    {
        //        throw new IndexOutOfRangeException();
        //    }

        //    for (int i = index; i < Length-1; i++)
        //    {
        //        _array[i] = _array[i + 1];
        //    }
        //    Length--;

        //    if (Length == (int)(_array.Length * 0.67 + 1))
        //    {
        //        DownSize();
        //    }
        //}

        public void RemoveFromTheEnd(int number = 1)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }

            if (number >= Length)
            {
                Length = 0;
                DownSize();
            }
            else
            {
                Length -= number;
                if (Length <= _array.Length / 2)
                {
                    DownSize();
                }
            }
        }

        public void RemoveFromTheBeginning(int number = 1)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }
            if (number >= Length)
            {
                Length = 0;
                DownSize();
            }
            else
            {
                ShiftLeft(0, number);
            }

        }

        public void RemoveByIndex(int index, int number = 1)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (number < 0)
            {
                throw new ArgumentException();
            }
            if (number >= Length - index)
            {
                Length = index;

                if (Length <= _array.Length / 2)
                {
                    DownSize();
                }
            }
            else
            {
                ShiftLeft(index, number);

            }
            if (Length <= _array.Length / 2)
            {
                DownSize();
            }

        }

        public int GetIndexByValue(int value)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                }
            }
            return index;
        }

        public void ReversList()
        {
            int j = Length - 1;
            int tmp;
            for (int i = 0; i <= ((Length) / 2) - 1; i++)
            {
                tmp = _array[j];
                _array[j] = _array[i];
                _array[i] = tmp;
                j--;
            }
        }

        public int GetMaxElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int maxElement;
            maxElement = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > maxElement)
                {
                    maxElement = _array[i];
                }
            }
            return maxElement;
        }

        public int GetMinElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int minElement;
            minElement = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < minElement)
                {
                    minElement = _array[i];
                }
            }
            return minElement;
        }

        public int GetIndexOfMaxElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int indexOfMaxElement;
            indexOfMaxElement = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > _array[indexOfMaxElement])
                {
                    indexOfMaxElement = i;
                }
            }
            return indexOfMaxElement;
        }

        public int GetIndexOfMinElement()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }
            int indexOfMinElement;
            indexOfMinElement = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < _array[indexOfMinElement])
                {
                    indexOfMinElement = i;
                }
            }
            return indexOfMinElement;
        }

        public void AscendingSort()
        {
            int tmp;
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] < _array[i])
                    {
                        tmp = _array[j];
                        _array[j] = _array[i];
                        _array[i] = tmp;
                    }
                }
            }
        }

        public void DescendingSort()
        {
            int tmp;
            for (int i = 0; i < Length - 1; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] > _array[i])
                    {
                        tmp = _array[j];
                        _array[j] = _array[i];
                        _array[i] = tmp;
                    }
                }
            }
        }

        public int RemoveFirstByValue(int value)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    RemoveByIndex(i);
                    index = i;
                    break;
                }
            }
            return index;
        }

        public int RemoveAllByValue(int value)
        {
            int counter = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    RemoveByIndex(i);
                    i--;
                    counter++;
                }
            }
            return counter;
        }

        public void AddListToTheEnd(ArrayList list)
        {
            AddListByIndex(list, Length);
        }

        public void AddListToTheBeggining(ArrayList list)
        {
            AddListByIndex(list, 0);

        }

        public void AddListByIndex(ArrayList list, int index = 0)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            
            ShiftRight(index, list.Length);
            InsertList(list, index);

            //int j = 0;

            //for (int i = index; i < index + list.Length; i++)
            //{
            //    _array[i] = list[j];
            //    j++;
            //}
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;
            if (this.Length != arrayList.Length)
            {
                return false;
            }
            for (int i = 0; i < this.Length; i++)
            {
                if (this._array[i] != arrayList._array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string arrayToString = "";
            for (int i = 0; i < Length; i++)
            {
                arrayToString += $"{_array[i]} ";
            }
            return arrayToString;
        }

        private void UpSize()
        {
            int newLength = (int)(Length * 1.33 + 1);
            int[] tmpArray = new int[newLength];
            for (int i = 0; i < _array.Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.67 + 1);
            while (Length <= newLength / 2 && newLength > 10)
            {
                newLength = (int)(newLength * 0.67 + 1);
            }
            int[] tmpArray = new int[newLength];
            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

        private void ShiftRight(int startIndex, int steps)
        {
            
            if (startIndex > Length || startIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Length += steps;
            if (Length > _array.Length)
            {
                UpSize();
            }

            if (steps < 0)
            {
                throw new ArgumentException();
            }

            for (int i = Length-1; i >= startIndex + steps; i--)
            {
                _array[i] = _array[i-steps];
            }
        }

        private void ShiftLeft(int startIndex, int steps)
        {
            if (startIndex >= Length || startIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (steps < 0)
            {
                throw new ArgumentException();
            }

            for (int i = startIndex; i < Length - steps; i++)
            {
                _array[i] = _array[i + steps];
            }

            Length -= steps;
            if (Length <= _array.Length / 2)
            {
                DownSize();
            }
        }

        private void InsertList(ArrayList list, int index)
        {
            int j = 0;
            for (int i = index; i < index + list.Length; i++)
            {
                _array[i] = list[j];
                j++;
            }
        }
    }
}
