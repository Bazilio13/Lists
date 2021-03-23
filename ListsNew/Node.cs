using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }

    }
}
