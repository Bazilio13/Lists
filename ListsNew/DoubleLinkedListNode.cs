using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class DoubleLinkedListNode
    {
        public int Value { get; set; }
        public DoubleLinkedListNode Next { get; set; }
        public DoubleLinkedListNode Previous { get; set; }

        public DoubleLinkedListNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
