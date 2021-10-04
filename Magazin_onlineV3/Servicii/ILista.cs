using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_onlineV3.Model
{
    interface ILista<T> where T:IComparable<T>
    {
        void addPosition(T item ,int position);
        void addStart(T item);
        void addFinish(T item);
        void deletePosition(int position);
        void deleteStart();
        void deleteFinish();
        int position(T item);
        int size();
        Node<T> getIterator();
    }
}
