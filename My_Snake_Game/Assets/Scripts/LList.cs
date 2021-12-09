using System;

namespace SnakeGameNS
{
    public class LList<T> : IDynamicList<T>
    {
        private int _count;
        private LListNode<T> _head;
        private LListNode<T> _tail;
        private T[] arr = new T[100];
        public LList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new LListNode<T>(item);
                _tail = _head;
            }

            else
            {
                _tail.NextNode = new LListNode<T>(item);
                _tail = _tail.NextNode;
            }

            _count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException("Index out of range: " + index);

            LListNode<T> currentNode = _head;

            if (_head == null && index == 0)
            {
                _head = new LListNode<T>(item);
                _tail = _head;
            }

            else if (index == 0)
            {
                LListNode<T> tempNode = _head;
                _head = new LListNode<T>(item);
                _head.NextNode = tempNode;
            }

            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                LListNode<T> newNode = new LListNode<T>(item);
                newNode.NextNode = currentNode.NextNode;
                currentNode.NextNode = newNode;

            }
            _count++;
        }

        public int Count
        {
            get { return _count; }
        }

        public bool Remove(T item)
        {
            LListNode<T> currentNode = _head;

            for (int i = 0; i < _count; i++)
            {
                if (currentNode.NextNode.Data.Equals(item))
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    _count--;
                    return true;
                }
                currentNode = currentNode.NextNode;

            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index out of range :" + index);
            if (index >= Count || _head == null)
                throw new Exception("invalid index");

            LListNode<T> currentNode = _head;

            if (index == 0)
            {
                _head = currentNode.NextNode;
            }

            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.NextNode = currentNode.NextNode.NextNode;
            }

            _count--;
        }

        public void Clear()
        {
            _head = null;
        }

        public int IndexOf(T item)
        {
            LListNode<T> currentNode = _head;

            for (int i = 0; i < _count; i++)
            {
                if (currentNode.Data.Equals(item))
                {
                    return i;
                }

                currentNode = currentNode.NextNode;
            }
            return -1;
        }

        public bool Contains(T item)
        {
            LListNode<T> currentNode = _head;

            for (int i = 0; i < _count; i++)
            {
                if (currentNode.Data.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.NextNode;
            }
            return false;
        }

        public void CopyTo(T[] target, int index)
        {
            LListNode<T> currentNode = _head;

            for (int i = index; i < _count + index; i++)
            {
                target[i] = currentNode.Data;

                currentNode = currentNode.NextNode;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("Index: " + index);
                if (_head == null)
                    return default;

                LListNode<T> currentNode = _head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                return currentNode.Data;
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("Index: " + index);
                if (_head == null)
                    throw new ArgumentException("List empty");

                LListNode<T> currentNode = _head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.Data = value;
            }
        }

        public void Print()
        {
            if (_head != null)
            {
                LListNode<T> currentNode = _head;

                for (int i = 0; i < _count; i++)
                {
                    Console.WriteLine(currentNode.Data + " -> ");
                    currentNode = currentNode.NextNode;
                }
            }
        }

        public void PrintHeadAndTail()
        {
            if (_head != null)
            {
                Console.WriteLine("Head:" + _head.Data + " Tail: " + _tail.Data);
            }
            else
            {
                Console.WriteLine("List empty");
            }
        }
    }

    public class LListNode<T>
    {
        private T _data;
        private LListNode<T> _nextNode;

        public LListNode(T data)
        {
            _data = data;
            _nextNode = null;
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public LListNode<T> NextNode
        {
            get { return _nextNode; }
            set { _nextNode = value; }
        }
    }
}

