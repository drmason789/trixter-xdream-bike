using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class CircularBufferTest
    {

        [Test]
        public void TestAdd()
        {
            CircularBuffer<int> buffer = new CircularBuffer<int>(3, 2);

            Assert.AreEqual(3, buffer.Capacity);

            buffer.Add(1);
            Assert.AreEqual(1, buffer.Count);
            Assert.AreEqual(1, buffer.Tail);
            Assert.AreEqual(1, buffer.Head);
            Assert.AreEqual(3, buffer.Capacity);
            buffer.Add(3);
            Assert.AreEqual(2, buffer.Count);
            Assert.AreEqual(1, buffer.Tail);
            Assert.AreEqual(3, buffer.Head);
            Assert.AreEqual(3, buffer.Capacity);
            buffer.Add(5);
            Assert.AreEqual(3, buffer.Count);
            Assert.AreEqual(5, buffer.Head);
            Assert.AreEqual(1, buffer.Tail);
            buffer.Add(10);
            Assert.AreEqual(5, buffer.Capacity);
            Assert.AreEqual(4, buffer.Count);
            Assert.AreEqual(1, buffer.Tail);
            Assert.AreEqual(10, buffer.Head);
        }

        [Test]
        public void TestRemove()
        {
            CircularBuffer<int> buffer = new CircularBuffer<int>(3, 2);

            buffer.AddRange(1,2,3);
            Assert.AreEqual(3, buffer.Count);
            Assert.AreEqual(1, buffer.Tail);
            Assert.AreEqual(3, buffer.Head);

            buffer.RemoveTail();
            Assert.AreEqual(2, buffer.Count);
            Assert.AreEqual(2, buffer.Tail);
            Assert.AreEqual(3, buffer.Head);

            buffer.Add(4);
            Assert.AreEqual(3, buffer.Capacity);
            Assert.AreEqual(3, buffer.Count);
            Assert.AreEqual(2, buffer.Tail);
            Assert.AreEqual(4, buffer.Head);

            buffer.RemoveTail();
            Assert.AreEqual(2, buffer.Count);
            Assert.AreEqual(3, buffer.Tail);
            Assert.AreEqual(4, buffer.Head);
            buffer.RemoveTail();
            Assert.AreEqual(1, buffer.Count);
            Assert.AreEqual(4, buffer.Tail);
            Assert.AreEqual(4, buffer.Head);
            buffer.RemoveTail();

            Assert.AreEqual(0, buffer.Count);

            this.TestExceptions(buffer);
        }

        [Test]
        public void Clear()
        {
            const int initialCapacity = 3, delta = 2;
            CircularBuffer<int> buffer = new CircularBuffer<int>(initialCapacity, delta);

            Assert.AreEqual(initialCapacity, buffer.Capacity);

            // Fill the buffer
            buffer.AddRange(1, 2, 3);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, buffer);

            // Clear it
            buffer.Clear();

            // Check there's nothing in it...
            Assert.AreEqual(0, buffer.Count);

            // and it still works
            CollectionAssert.AreEqual(new int[] { }, buffer);
            Assert.AreEqual(3, buffer.Capacity);

            buffer.Add(1);
            Assert.AreEqual(1, buffer.Count);
            Assert.AreEqual(1, buffer.Tail);
            Assert.AreEqual(1, buffer.Head);
            Assert.AreEqual(3, buffer.Capacity);


            buffer.RemoveTail();
            Assert.AreEqual(0, buffer.Count);
            Assert.AreEqual(3, buffer.Capacity);

            this.TestExceptions(buffer);
        }

        /// <summary>
        /// Test that an empty buffer throws the expected exceptions.
        /// </summary>
        /// <param name="emptyBuffer"></param>
        public void TestExceptions(CircularBuffer<int> emptyBuffer)
        {
            Assert.AreEqual(0, emptyBuffer.Count);
            Assert.Throws<InvalidOperationException>(() => { int x=emptyBuffer.Head; });
            Assert.Throws<InvalidOperationException>(() => { int x = emptyBuffer.Tail; });
            Assert.Throws<InvalidOperationException>(() => emptyBuffer.RemoveTail());
        }


        [Test]
        public void TestEnumerator()
        {
            const int initialCapacity = 3, delta = 2;
            CircularBuffer<int> buffer = new CircularBuffer<int>(initialCapacity, delta);
            
            Assert.AreEqual(initialCapacity, buffer.Capacity);

            // Fill the buffer
            buffer.AddRange(1,2,3);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, buffer);

            buffer.RemoveTail();
            CollectionAssert.AreEqual(new[] { 2, 3 }, buffer);

            // add a new value that should go to the front of the internal circular buffer
            // i.e. the enumeration should hit the end and loop back to the beginning of the internal array
            buffer.Add(4);
            CollectionAssert.AreEqual(new[] { 2, 3, 4 }, buffer);

            // Add a value that should expand the capacity, and check the enumeration is still correct.
            buffer.Add(5);
            Assert.AreEqual(initialCapacity+delta, buffer.Capacity);
            Assert.AreEqual(2, buffer.Tail);
            Assert.AreEqual(5, buffer.Head);
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5 }, buffer);

        }
    }
}
