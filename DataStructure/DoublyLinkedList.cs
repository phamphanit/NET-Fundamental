using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{

    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T> next, DoublyLinkedListNode<T> previous)
        {
            Value = value;
            //Next = next;
        }
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
    }
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head
        {
            get;
            set;
        }
        public DoublyLinkedListNode<T> Tail
        {
            get;
            private set;
        }
        public void AddHead(T value)
        {
            //AddHead(new DoublyLinkedListNode<T>(value));
            var oldHead = Head;
            var adding = new DoublyLinkedListNode<T>(value);
            Head = adding;

            Head.Next = oldHead;
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                oldHead.Previous = Head;
            }
            Count++;
        }
        public void AddHead(DoublyLinkedListNode<T> node)
        {
            var temp = Head;
            Head = node;
            Head.Next = temp;
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }
            Count++;
        }
        public void AddTail(T value)
        {
            var oldTail = Tail;
            var adding = new DoublyLinkedListNode<T>(value);
            Tail = adding;
            Tail.Previous = oldTail;
            if (Count == 0)
            {
                Head = adding;
            }
            else
            {
                oldTail.Next = Tail;
            }
            Count++;
        }
        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }
        public DoublyLinkedListNode<T> Find(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var found = Find(item);
            if (found == null)
            {
                return false;
            }
            var next = found.Next;
            var previous = found.Previous;

            if (previous == null)
            {
                Head = next;
                if (Head != null)
                {
                    Head.Previous = null;
                }
            }
            else
            {
                previous.Next = next;
            }
            if(next == null)
            {
                Tail = previous;
                if(Tail != null)
                {
                    Tail.Next = null;
                }
            }
            else
            {
                next.Previous = previous;
            }
            Count--;

            return true;
        }

       
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        public System.Collections.Generic.IEnumerable<T> GetReverseEnumerator()
        {
            DoublyLinkedListNode<T> current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
