using System;

namespace RandomQueue
{
    class MyQueueItem<T>
    {
        public T Data { get; set; }
        public MyQueueItem<T> Next { get; set; }
        public MyQueueItem<T> Prev { get; set; }
    }

    class MyQueue<T>
    {
        private MyQueueItem<T> _head;
        private MyQueueItem<T> _tail;
        private int _counter;

        public MyQueue()
        {
            _counter = 0;
        }
        // Add a new value to the queue
        public void Push(T item)
        {
            if (_head == null)
            {
                _head = new MyQueueItem<T> {Data = item};
                _tail = _head;
            }
            else
            {
                MyQueueItem<T> tempItem = new MyQueueItem<T> {Data = item};
                _tail.Next = tempItem;
                tempItem.Prev = _tail;
                _tail = tempItem;
            }
            _counter++;
        }

        // Add several new values to the queue
        public void Push(T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }
            if (items.Length == 0)
            {
                throw new ArgumentException();
            }

            foreach (T item in items)
            {
                Push(item);
            }
        }

        // Pick a random item from the queue, remove it from the internal storage and return it
        public T Pop()
        {
            if (_counter == 0)
            {
                throw new InvalidOperationException();
            }

            MyQueueItem<T> tmpLink = GetLinkByIndex(GetRndIndex());
            T elementData = tmpLink.Data;

            ReLinkItems(tmpLink);

            _counter--;
            return elementData;

        }

        // Number of stored items
        public int Count
        {
            get { return _counter; }
        }

        // Number of allocated slots for storing items
        public int Capacity
        {
            get { return _counter; }
        }

        // Boolean flag: true if no items are stored in the queue, false otherwise
        public bool IsEmpty
        {
            get { return _counter == 0; }
        }

        private int GetRndIndex()
        {
            Random r = new Random();
            return r.Next(0, _counter);
        }

        private MyQueueItem<T> GetLinkByIndex(int index)
        {
            MyQueueItem<T> tmpLink = _head;

            for (int i = 0; i < index; i++)
            {
                tmpLink = tmpLink.Next;
            }

            return tmpLink;
        }

        private void ReLinkItems(MyQueueItem<T> item)
        {
            if (item.Prev == null && item.Next == null)
            {
                _head = _tail = null;
            }
            else if (item.Prev == null)
            {
                item.Next.Prev = null;
                _head = item.Next;
            }
            else if (item.Next == null)
            {
                item.Prev.Next = null;
                _tail = item.Prev;
            }
            else
            {
                item.Next.Prev = item.Prev;
                item.Prev.Next = item.Next;
            }
        }
    }
}
