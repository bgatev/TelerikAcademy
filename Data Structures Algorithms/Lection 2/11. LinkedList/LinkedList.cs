﻿namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public ListElement<T> FirstElement { get; set; }
        public ListElement<T> LastElement { get; set; }

        public int Count
        {
            get;
            private set;
        }

        public void AddFirst(ListElement<T> element)
        {
            if (this.Count == 0)
            {
                this.FirstElement = element;
                this.LastElement = element;
            }
            else
            {
                element.NextElement = this.FirstElement;
                this.FirstElement = element;
            }

            this.Count++;
        }

        public void AddFirst(T item)
        {
            this.AddFirst(new ListElement<T>(item));
        }

        public void AddLast(ListElement<T> element)
        {
            if (this.Count == 0)
            {
                this.FirstElement = element;
                this.LastElement = element;
            }
            else
            {
                this.LastElement.NextElement = element;
                this.LastElement = element;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            this.AddLast(new ListElement<T>(element));
        }

        public void AddBefore(ListElement<T> node, ListElement<T> newElement)
        {
            if (node == null || newElement == null) throw new ArgumentNullException();

            if (node == this.FirstElement)
            {
                this.AddFirst(newElement);
                return;
            }

            GetPrevious(node).NextElement = newElement;
            newElement.NextElement = node;
            this.Count++;
        }

        public void AddBefore(ListElement<T> node, T newElement)
        {
            this.AddBefore(node, new ListElement<T>(newElement));
        }

        private ListElement<T> GetPrevious(ListElement<T> element)
        {
            ListElement<T> currentNode = this.FirstElement;

            while (currentNode.NextElement != null)
            {
                if (currentNode.NextElement == element) return currentNode;
                currentNode = currentNode.NextElement;
            }

            throw new NullReferenceException();
        }

        public void AddAfter(ListElement<T> node, ListElement<T> newElement)
        {
            if (node == null || newElement == null) throw new ArgumentNullException();
            if (node.NextElement == null)
            {
                this.AddLast(newElement);
                return;
            }

            newElement.NextElement = node.NextElement;
            node.NextElement = newElement;
            this.Count++;
        }

        public void AddAfter(ListElement<T> node, T newElement)
        {
            this.AddAfter(node, new ListElement<T>(newElement));
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.FirstElement;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}