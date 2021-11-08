using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class SortedList<T> : IEnumerable<T> where T : IComparable<T>
    {

        class SortedListNode<TNode> where TNode : IComparable<TNode>
        {
            public SortedListNode(TNode value, SortedListNode<TNode> prev = null, SortedListNode<TNode> next = null)
            {
                this.data = value;
                this.prev = prev;
                this.next = next;
            }
            public TNode data;
            public SortedListNode<TNode> prev;
            public SortedListNode<TNode> next;

        }
        SortedListNode<T> head = null;
        SortedListNode<T> tail = null;
        public int Count { get; private set; }
        public IEnumerator<T> GetEnumerator()
        {
            SortedListNode<T> temp = head;
            while (temp != null)
            {
                yield return temp.data;
                temp = temp.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T value)
        {
            if (head == null)
            {
                head = new SortedListNode<T>(value);
                tail = head;
            }
            else if (head.data.CompareTo(value) >= 0)
            {
                var newHead = new SortedListNode<T>(value);
                newHead.next = head;
                head.prev = newHead;
                head = newHead;
            }
            else if (tail.data.CompareTo(value) < 0)
            {
                var newTail = new SortedListNode<T>(value);
                newTail.prev = tail;
                tail.next = newTail;
                tail = newTail;
            }
            else
            {
                var insertBefore = head;
                while (insertBefore.data.CompareTo(value) < 0)
                {
                    insertBefore = insertBefore.next;
                }
                var insertNode = new SortedListNode<T>(value);
                insertNode.prev = insertBefore.prev;
                insertNode.next = insertBefore;
                insertBefore.prev = insertNode;
                insertNode.prev.next = insertNode;
            }
            Count++;
        }

    }
}
