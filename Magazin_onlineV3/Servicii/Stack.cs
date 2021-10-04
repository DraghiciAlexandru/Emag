using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_onlineV3.Model
{
    class Stack<T> where T : IComparable<T>
    {
        private Lista<T> stiva;

        public Stack()
        {
            stiva = new Lista<T>();
        }

        public bool empty()
        {
            if (stiva.size() == 0)
                return true;
            return false;
        }
        
        public int size()
        {
            return stiva.size();
        }

        public void push(T item)
        {
            stiva.addFinish(item);
        }

        public Node<T> pop()
        {
            if (!empty())
            {
                Node<T> item = stiva.getIterator();
                stiva.deleteStart();
                return item;
            }
            return null; 
        }
        
        public Node<T> peek()
        {
            if (!empty())
                return stiva.getIterator();
            return null;
        }
    }
}
