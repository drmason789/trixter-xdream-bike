﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trixter.XDream.API.Meters
{
    /// <summary>
    /// A FILO buffer, allowing a client to put items on the front (head), and take them off the back (tail). 
    /// A queue-stack hybrid: push like a stack, dequeue like a queue. Uses a circular buffer internally, 
    /// moving the head and tail indexes rather than the items themselves. Automatically expands if an item
    /// is added beyond its current capacity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class CircularBuffer<T> : IEnumerable<T>
    {
        private T[] buffer;

        private int tail = -1;
        private int head = -1;
        private int delta;
        
        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the buffer is empty.
        /// Used interally to provide a consistent exception and message for this error.
        /// </summary>
        /// <returns></returns>
        private Exception GetBufferEmptyException() => new InvalidOperationException("Buffer is empty.");

        /// <summary>
        /// The number of items in the buffer.
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// The current capacity of the buffer.
        /// </summary>
        public int Capacity => this.buffer.Length;


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bufferSize">The initial size of the buffer. Must be > 0.</param>
        /// <param name="delta">The number of items the buffer will be expanded by if it is filled. Must be > 0.</param>
        /// <exception cref="ArgumentException"></exception>
        public CircularBuffer(int bufferSize, int delta)
        {
            if (bufferSize < 1)
                throw new ArgumentException(nameof(bufferSize));
            if(delta<1)
                throw new ArgumentException(nameof(delta));

            this.buffer = new T[bufferSize];
            this.delta = delta;
        }

        /// <summary>
        /// Expand the buffer by <see cref="delta"/> items.
        /// </summary>
        private void Expand()
        {
            T[] newBuffer = new T[this.buffer.Length + this.delta];
            int i = 0;

            foreach (var item in this)
                newBuffer[i++] = item;

            if (i == 0)
                this.tail = this.head = -1;
            else 
            {
                this.tail = 0;
                this.head = i - 1;
            }
            this.buffer = newBuffer;
        }

        /// <summary>
        /// Increment a buffer index accounting for the circularity.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int Increment(int value) => (value + 1) % this.buffer.Length;

        /// <summary>
        /// Clear the specified elements. Not strictly necessary but when debugging it is easier to see
        /// the current content when old content is not there.
        /// </summary>
        /// <param name="from">First bound. Can be after the second bound.</param>
        /// <param name="to">Second bound. Can be before the first bound.</param>
        private void ClearBuffer(int from, int to)
        {
            if (from == to)
                this.buffer[from] = default(T);
            else
            {
                int start = Math.Min(from, to), end = Math.Max(from, to);
                Array.Clear(this.buffer, start, end - start + 1);
            }
        }

        /// <summary>
        /// Add the item to the head.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            int nextLocation = this.Increment(this.head);

            if (nextLocation == this.tail)
            {
                Expand();
                nextLocation = this.Increment(this.head);
            }

            this.head = nextLocation;
            if (this.tail == -1) this.tail = this.head;
            this.buffer[this.head] = item;

            this.Count++;

        }

        /// <summary>
        /// Add a range of items to the head.
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<T> items)
        {
            foreach(var item in items)
                this.Add(item);
        }

        /// <summary>
        /// Add a range of items to the head.
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(params T[] items) => AddRange((IEnumerable<T>)items);

        /// <summary>
        /// Gets the tail of the buffer. Throws an <see cref="InvalidOperationException"/> if the buffer is empty.
        /// </summary>
        public T Tail
        {
            get
            {
                if (this.tail == -1)
                    throw GetBufferEmptyException();

                return this.buffer[this.tail];
            }
        }

        /// <summary>
        /// Gets the head of the buffer. Throws an <see cref="InvalidOperationException"/> if the buffer is empty.
        /// </summary>
        public T Head
        {
            get
            {
                if (this.head == -1)
                    throw GetBufferEmptyException();

                return this.buffer[this.head];
            }
        }

        /// <summary>
        /// Removes the tail of the buffer. Throws an <see cref="InvalidOperationException"/> if the buffer is empty.
        /// </summary>
        public void RemoveTail()
        {
            if (this.tail == -1)
                throw GetBufferEmptyException();

            this.ClearBuffer(this.tail, this.tail);

            if (this.tail == this.head)
                this.tail = this.head = -1;
            else
                this.tail = this.Increment(this.tail);

            this.Count--;
        }

        /// <summary>
        /// Remove the tail as long as the condition is met.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="onRemove"></param>
        public void RemoveTailWhile(Func<T,bool> condition, Action<T> onRemove=null)
        {
            if(condition==null)
                throw new ArgumentNullException(nameof(condition));

            if (this.tail == -1)
                return;

            bool remove;
            do
            {
                T currentTail = this.Tail;
                remove = condition(currentTail);
                if (remove)
                {
                    if (onRemove != null)
                        onRemove(currentTail);
                    this.RemoveTail();
                }
            } while (remove);           
        }

        /// <summary>
        /// Clears the buffer.
        /// </summary>
        public void Clear()
        {
            if (this.Count == 0)
                return;

            this.ClearBuffer(this.tail, this.head);
            this.tail = this.head = -1;
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.tail, j = 0; j < this.Count; j++)
            {
                yield return this.buffer[i];
                i = this.Increment(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }


}
