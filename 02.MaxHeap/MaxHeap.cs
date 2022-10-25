namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            elements = new List<T>();
        }

        public int Size => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = GetParentIndex(index);

            while (parentIndex >= 0 && IsGreater(index, parentIndex))
            {
                Swap(index, parentIndex);
                HeapifyUp(parentIndex);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            T tempElement = elements[index];
            elements[index] = elements[parentIndex];
            elements[parentIndex] = tempElement;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            if (elements[index].CompareTo(elements[parentIndex]) > 0)
            {
                return true;
            }

            return false;
        }

        private static int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public T Peek()
        {
            if (elements.Count > 0)
            {
                return elements[0];
            }

            throw new InvalidOperationException("The collection is empty!");
        }
    }
}
