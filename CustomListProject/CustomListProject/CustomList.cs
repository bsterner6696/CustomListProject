using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Security.Permissions;
using System.Runtime;
using System.Runtime.Versioning;
using System.Collections.ObjectModel;
using System.Collections;

namespace CustomListProject
{
    class CustomList<T>: IEnumerable<T>
    {
        
        public T[] contents;
        int size;

        static readonly T[] emptyArray = new T[0];

        public CustomList()
        {
            contents = emptyArray;
        }

        public CustomList(int capacity)
        {
            if (capacity == 0)
            {
                contents = emptyArray;
            }
            else
            {
                contents = new T[capacity];
            }
        }

        public CustomList(IEnumerable<T> enumerableGroup)
        {
            ICollection<T> collection = enumerableGroup as ICollection<T>;
            if (collection != null)
            {
                int count = collection.Count;
                if (count == 0)
                {
                    contents = emptyArray;
                }
                else
                {
                    contents = new T[count];
                    collection.CopyTo(contents, 0);
                    size = count;
                }
            }
            else
            {
                size = 0;
                contents = emptyArray;
            }
            
        }



        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int index = 0; index < contents.Length; index++)
            {
                yield return contents[index];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < contents.Length; index++)
            {
                yield return contents[index];
            }
        }

        public void Add(T item)
        {
            if (size == contents.Length)
            {
                EnsureCapacity(size + 1);
                contents[size++] = item;
            }
        }

        public int Capacity
        {
            get
            {
                return contents.Length;
            }
            set
            {
                if (value < size)
                {
                    Console.WriteLine("Capacity is too small to set as list length.  Reenter with valid entry");
                }
                else if (value!= contents.Length)
                {
                    if (value > 0)
                    {
                        T[] newContents = new T[value];
                        if (size > 0)
                        {
                            Array.Copy(contents, 0, newContents, 0, size);
                        }
                        contents = newContents;
                    }
                    else contents = emptyArray;
                }
                
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (contents.Length < minimumCapacity)
            {
                int newCapacity = contents.Length;
                if (newCapacity < minimumCapacity)
                {
                    newCapacity = minimumCapacity;
                }
                Capacity = newCapacity;

            }
        }
        public int IndexOf(T item)
        {
            return Array.IndexOf(contents, item, 0, size);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            
            if (index < size)
            {
                size--;
                Array.Copy(contents, index + 1, contents, index, size - index);
            }
            contents[size] = default(T);
        }

        public int Count()
        {
            return size;
        }

    }
}
