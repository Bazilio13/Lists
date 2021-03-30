using NUnit.Framework;
using System;
using Lists;

namespace DoubleLinkedListTests
{
    public class DoubleLinkedListTests
    {
        [TestCase(new int[] { 0, 4, -1, 5 }, 4, new int[] { 0, 4, -1, 5, 4 })]
        [TestCase(new int[] { }, -2, new int[] { -2 })]
        [TestCase(new int[] { 5, 1, -10 }, 0, new int[] { 5, 1, -10, 0 })]
        public void Add_Test(int[] array, int value, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.Add(value);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 4, 2, new int[] { 0, 4, 4, -1, 5 })]
        [TestCase(new int[] { 1 }, -2, 0, new int[] { -2, 1 })]
        [TestCase(new int[] { 5, 1, -10 }, 0, 3, new int[] { 5, 1, -10, 0 })]
        public void AddByIndex_Test(int[] array, int value, int index, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddByIndex(value, index);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 4, -1)]
        [TestCase(new int[] { 1 }, -2, 2)]
        public void AddByIndex_NegativeTest(int[] array, int value, int index)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, new int[] { 9, 0, 4, -1, 5 })]
        [TestCase(new int[] { }, new int[] { 9 })]
        [TestCase(new int[] { 5 }, new int[] { 9, 5 })]
        public void AddToTheBeginning_Test(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AddToTheBeginning(9);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, new int[] { 0, 4, -1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 5 }, new int[] { })]
        public void RemoveFromTheEnd_Test(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFromTheEnd();
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, new int[] { 4, -1, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 5 }, new int[] { })]
        public void RemoveFromTheBeginning_Test(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFromTheBeginning();
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 0, 4, -1, 5 }, 2, new int[] { 0, 4, 5 })]
        [TestCase(new int[] { 2 }, 0, new int[] { })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 0, new int[] { 4, -1, 5 })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 3, new int[] { 0, 4, -1 })]
        public void RemoveByIndex_Test(int[] array, int index, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveByIndex(index);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0, 4, -1, 5 }, 4)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 0, 4, -1, 5 }, -1)]
        public void RemoveByIndex_NegativeTest(int[] array, int index)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 1, new int[] { 0, 4, -1 })]
        [TestCase(new int[] { 2 }, 3, new int[] { })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 5, new int[] { })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 3, new int[] { 0 })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 0, new int[] { 0, 4, -1, 5 })]
        public void RemoveFromTheEnd_Test(int[] array, int number, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFromTheEnd(number);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, -1)]
        public void RemoveFromTheEnd_NegativeTest(int[] array, int number)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveFromTheEnd(number));
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 1, new int[] { 4, -1, 5 })]
        [TestCase(new int[] { 2 }, 3, new int[] { })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 5, new int[] { })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 3, new int[] { 5 })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 0, new int[] { 0, 4, -1, 5 })]
        public void RemoveFromTheBeginning_Test(int[] array, int number, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveFromTheBeginning(number);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, -1)]
        public void RemoveFromTheBeginning_NegativeTest(int[] array, int number)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveFromTheBeginning(number));
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 1, 2, new int[] { 0, 5 })]
        [TestCase(new int[] { 2 }, 0, 3, new int[] { })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 3, 5, new int[] { 0, 4, -1 })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 0, 3, new int[] { 5 })]
        [TestCase(new int[] { 0, 4, -1, 5 }, 2, 0, new int[] { 0, 4, -1, 5 })]
        public void RemoveByIndex_Test(int[] array, int index, int number, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.RemoveByIndex(index, number);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, -1, 10)]
        [TestCase(new int[] { 0, 4, -1, 5 }, 5, 10)]
        public void RemoveByIndex_IndexOutOfRange_IndexOutOfRangeException(int[] array, int index, int number)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index, number));
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 2, -10)]
        public void RemoveByIndex_NumberLessThen0_ArgumentException(int[] array, int index, int number)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveByIndex(index, number));
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, -1, 2)]
        [TestCase(new int[] { 2 }, 2, 0)]
        [TestCase(new int[] { 0, 4, -1, 5 }, 5, 3)]
        [TestCase(new int[] { 0, 4, -1, 5 }, 0, 0)]
        [TestCase(new int[] { 0, 4, -1, 5 }, 4, 1)]
        [TestCase(new int[] { 0, 4, -1, 5 }, 7, -1)]
        public void GetIndexByValue_Test(int[] array, int value, int expected)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual;
            actual = actualArray.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, new int[] { 5, -1, 4, 0 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 5, 2, -8 }, new int[] { -8, 2, 5 })]
        public void ReversList_Test(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.ReversList();
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 5)]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 3, 2, -8 }, 3)]
        [TestCase(new int[] { 3, 9, -8 }, 9)]
        public void GetMaxElement_Test(int[] array, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(array);
            int actual;
            actual = actualList.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxElement_NegativeTest(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetMaxElement());
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, -1)]
        [TestCase(new int[] { 2 }, 2)]
        [TestCase(new int[] { 3, 2, -8 }, -8)]
        [TestCase(new int[] { 3, 0, 5 }, 0)]
        public void GetMinElement_Test(int[] array, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(array);
            int actual;
            actual = actualList.GetMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinElement_NegativeTest(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetMinElement());
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 3)]
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 3, 2, -8 }, 0)]
        [TestCase(new int[] { 3, 9, -8 }, 1)]
        public void GetIndexOfMaxElement_Test(int[] array, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(array);
            int actual;
            actual = actualList.GetIndexOfMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaxElement_NegativeTest(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetIndexOfMaxElement());
        }

        [TestCase(new int[] { 0, 4, -1, 5 }, 2)]
        [TestCase(new int[] { 2 }, 0)]
        [TestCase(new int[] { 3, 2, -8 }, 2)]
        [TestCase(new int[] { 3, -10, -8 }, 1)]
        public void GetIndexOfMinElement_Test(int[] array, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(array);
            int actual;
            actual = actualList.GetIndexOfMinElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinElement_NegativeTest(int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<NullReferenceException>(() => actual.GetIndexOfMinElement());
        }

        //[TestCase(new int[] { 1, -6, 5, -10 }, new int[] { -10, -6, 1, 5 })]
        //[TestCase(new int[] { 1, 6, 2, 5, 7, 8, 4, 9, 3 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        //[TestCase(new int[] { }, new int[] { })]
        //[TestCase(new int[] { 1 }, new int[] { 1 })]
        //public void MergeSort_Test(int[] array, int[] expectedArray)
        //{
        //    DoubleLinkedList actual = new DoubleLinkedList(array);
        //    actual.MergeSort();
        //    DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
        //    Assert.AreEqual(expected, actual);
        //}

        [TestCase(new int[] { 1, -6, 5, -10 }, new int[] { -10, -6, 1, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void AscendingSort_Test(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.AscendingSort();
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -6, 5, -10 }, new int[] { 5, 1, -6, -10 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void DescendingSort_Test(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DescendingSort();
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, -6, 5, -10 }, -6, new int[] { 1, 5, -10 }, 1)]
        [TestCase(new int[] { 1, -6, 1, -10 }, 1, new int[] { -6, 1, -10 }, 0)]
        [TestCase(new int[] { }, 6, new int[] { }, -1)]
        [TestCase(new int[] { 1 }, 5, new int[] { 1 }, -1)]
        public void RemoveFirstByValue_Test(int[] array, int value, int[] expectedArray, int expectedIndex)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            int actualIndex;
            actualIndex = actual.RemoveFirstByValue(value);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(new int[] { 1, -6, 5, -10 }, -6, new int[] { 1, 5, -10 }, 1)]
        [TestCase(new int[] { 1, -6, 1, -10 }, 1, new int[] { -6, -10 }, 2)]
        [TestCase(new int[] { 1, 1, 1, -10 }, 1, new int[] { -10 }, 3)]
        [TestCase(new int[] { }, 6, new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 5, new int[] { 1 }, 0)]
        public void RemoveAllByValue_Test(int[] array, int value, int[] expectedArray, int expectedCount)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            int actualCount;
            actualCount = actual.RemoveAllByValue(value);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 9 }, new int[] { 1, 5, -10 }, new int[] { 1, 9, 1, 5, -10 })]
        [TestCase(new int[] { 1, -6, 1, -10 }, new int[] { }, new int[] { 1, -6, 1, -10 })]
        [TestCase(new int[] { }, new int[] { 1, -6, 1, -10 }, new int[] { 1, -6, 1, -10 })]
        public void AddListToTheEnd_Test(int[] array, int[] addedArray, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList added = new DoubleLinkedList(addedArray);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.AddListToTheEnd(added);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 9 }, new int[] { 1, 5, -10 }, new int[] { 1, 5, -10, 1, 9 })]
        [TestCase(new int[] { 1, -6, 1, -10 }, new int[] { }, new int[] { 1, -6, 1, -10 })]
        [TestCase(new int[] { }, new int[] { 1, -6, 1, -10 }, new int[] { 1, -6, 1, -10 })]
        public void AddListToTheBeggining_Test(int[] array, int[] addedArray, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList added = new DoubleLinkedList(addedArray);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.AddListToTheBeggining(added);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4, 5 }, 0, new int[] { 3, 4, 5, 1, 2 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5, 2 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4, 5 }, 2, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, -6, 1, -10 }, new int[] { }, 2, new int[] { 1, -6, 1, -10 })]
        [TestCase(new int[] { }, new int[] { 1, -6, 1, -10 }, 0, new int[] { 1, -6, 1, -10 })]
        public void AddListByIndex_Test(int[] array, int[] addedArray, int index, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList added = new DoubleLinkedList(addedArray);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.AddListByIndex(added, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4, 5 }, -1)]
        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4, 5 }, 3)]
        public void AddListByIndex_NegativeTest(int[] array, int[] addedArray, int index)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList added = new DoubleLinkedList(addedArray);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddListByIndex(added, index));
        }
    }
}