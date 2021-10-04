using System;
using System.Collections.Generic;
using System.Text;

namespace Magazin_onlineV3.Model
{
    public class Lista<T>: ILista<T> where T : IComparable<T>
    {
        private Node<T> head;

        public Lista()
        {
            head = null;
        }
        public Lista(Node<T> head)
        {
            this.head = head;
            this.head.Next = null;
        }

        public void addPosition(T item, int position)
        {
            if (head == null)
            {
                addStart(item);
            }
            else if (position <= 0)
            {
                addStart(item);
            }
            else if (position >= size() - 1)
            {
                addFinish(item);
            }
            else
            {
                int ct = 0;
                Node<T> aux = head;
                while (ct < position - 1)
                {
                    aux = aux.Next;
                    ct++;
                    Console.WriteLine("Nu e ok");
                }
                Node<T> node = new Node<T>();
                node.Data = item;
                node.Next = aux.Next;
                aux.Next = node;
            }

        }

        public void addStart(T item)
        {
            if (head == null)
            {
                head = new Node<T>();
                head.Data = item;
                head.Next = null;
            }
            else
            {
                Node<T> node = new Node<T>();
                node.Data = item;
                node.Next = head;
                head = node;
            }
        }

        public void addFinish(T item)
        {
            if (head == null)
            {
                head = new Node<T>();
                head.Data = item;
                head.Next = null;
            }
            else
            {
                Node<T> aux = head;
                while (aux.Next != null)
                {
                    aux = aux.Next;
                }
                Node<T> node = new Node<T>();
                node.Data = item;
                node.Next = null;
                aux.Next = node;
            }
        }

        public void deletePosition(int position)
        {
            if (head != null)
            {
                if (position <= 0)
                {
                    deleteStart();
                }
                else if (position >= size() - 1)
                {
                    deleteFinish();
                }
                else
                {
                    int ct = 0;
                    Node<T> aux = new Node<T>();
                    aux = head;
                    while (ct != position - 1)
                    {
                        aux = aux.Next;
                        ct++;
                    }
                    aux.Next = aux.Next.Next;
                }
            }
        }

        public void deleteStart()
        {
            if (head != null)
            {
                head = head.Next;
            }
            else
            {
                head = null;
            }
        }

        public void deleteFinish()
        {
            if (head != null)
            {
                if (size() >= 3)
                {
                    Node<T> aux = head;
                    while (aux.Next.Next != null)
                    {
                        aux = aux.Next;
                    }
                    aux.Next = null;
                }
                else if (size() == 2)
                {
                    head.Next = null;
                }
                else if (size() == 1)
                {
                    head = null;
                }
            }
        }

        public void setPosition(int pos, T item)
        {
            if (head != null)
            {
                if (pos == 0)
                    head.Data = item;
                else if (pos == size() - 1) 
                    getLast().Data = item;
                else
                {
                    Node<T> node = head;
                    for (int i = 0; i < pos; i++)
                    {
                        node = node.Next;
                    }
                    node.Data = item;
                }
            }
        }

        public Node<T> getIterator()
        {
            return head;
        }

        public int size()
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                Node<T> aux = head;
                int ct = 0;
                while (aux != null)
                {
                    aux = aux.Next;
                    ct++;
                }
                return ct;
            }
        }

        public int position(T item)
        {
            if (head == null)
            {
                return -1;
            }
            else
            {
                Node<T> aux = head;
                int ct = 0;
                while (aux != null)
                {
                    if (aux.Data.Equals(item))
                        return ct;
                    ct++;
                    aux = aux.Next;
                }
                return -1;
            }
        }

        public Node<T> getElement(T Item)
        {
            if (head == null)
            {
                return default;
            }
            else
            {
                Node<T> aux = head;
                while (aux != null)
                {
                    if (aux.Data.Equals(Item))
                        return aux;
                    aux = aux.Next;
                }
                return default;
            }
        }

        public override string ToString()
        {
            String text = "";
            if (head != null)
            {
                Node<T> aux = head;
                while (aux != null)
                {
                    text += aux.Data.ToString() + Environment.NewLine;
                    aux = aux.Next;
                }
            }
            return text;
        }

        public void update(T item, T itemNou)
        {
            if (head != null)
            {
                Node<T> aux = head;
                while (aux != null)
                {
                    if (aux.Data.Equals(item))
                        aux.Data = itemNou;
                    aux = aux.Next;
                }
            }
        }

        public void reset()
        {
            head = null;
        }

        public Node<T> getLast()
        {
            if (head != null)
            {
                Node<T> aux = head;
                while (aux.Next != null)
                    aux = aux.Next;
                return aux;
            }
            return default;
        }

        public void remove(T data) => this.deletePosition(position(data));

        public void swap(T itemUnu, T itemDoi)
        {
            int pos1 = position(itemUnu), pos2 = position(itemDoi);
            setPosition(pos1, itemDoi);
            setPosition(pos2, itemUnu);
        }

        public void sort(int direction)
        {
            Node<T> node = head;
            int flag = 1;
            while (flag == 1) 
            {
                flag = 0;
                node = head;
                for (int i = 0; i < size() - 1; i++) 
                {
                    if (node.Data.CompareTo(node.Next.Data) == direction)
                    {
                        swap(node.Data, node.Next.Data);
                        flag = 1;
                    }
                    node = node.Next;
                }
            }
        }
        
    }
}
