using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_onlineV3.Model
{
    class Queue<T> where T : IComparable<T>
    {
        private Lista<T> queue;

        public Queue()
        {
            queue = new Lista<T>();
        }

        public bool empty()
        {
            if (queue.size() == 0)
                return true;
            return false;
        }

        public int size()
        {
            return queue.size();
        }

        public void push(T item)
        {
            queue.addStart(item);
        }

        public Node<T> pop()
        {
            if (!empty())
            {
                Node<T> item = queue.getIterator();
                queue.deleteStart();
                return item;
            }
            return null;
        }

        public Node<T> peek()
        {
            if (!empty())
                return queue.getIterator();
            return null;
        }
    }
}
