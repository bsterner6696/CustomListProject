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

        T[] emptyArray = new T[0];

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

        public T this[int index]
        {
            get
            {
                return contents[index];
            }
        }

        

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int index = 0; index < size; index++)
            {
                yield return contents[index];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < size; index++)
            {
                yield return contents[index];
            }
        }

        public void Add(T item)
        {

            EnsureCapacity(size + 1);
            contents[size] = item;
            size++;
         

        }

        public int Capacity
        {
            get
            {
                return size;
            }
            set
            {
                if (value < size)
                {
                    Console.WriteLine("Entered capacity is too small to set as list length.  Reenter with valid entry");
                }
                else if (value!= size)
                {
                    if (value > 0)
                    {
                        T[] newContents = new T[value];
                        if (size > 0)
                        {
                            

                            for (int index = 0; index < size; index++)
                            {
                                newContents[index] = contents[index];
                            }          
                        }
                        contents = newContents;
                    }
                    else contents = emptyArray;
                }
                
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (size < minimumCapacity)
            {
                int newCapacity = size;
                if (newCapacity < minimumCapacity)
                {
                    newCapacity = minimumCapacity;
                }
                Capacity = newCapacity;

            }
        }
        public int IndexOf(T item)
        {

            int itemIndex = 0;
            for (int index = size - 1; index >= 0; index--)
            {
                if (Equals(contents[index], item))
                {
                    itemIndex = index;
                }
            }
            return itemIndex;
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
                CustomList<T> newList = new CustomList<T>();
                for (int x = 0; x < index; x++)
                {
                    newList.Add(contents[x]);
                }
                if (index + 1 < size)
                {
                    for (int x = index + 1; x < size; x++)
                    {
                        newList.Add(contents[x]);
                    }
                }
                size--;
                contents = newList.contents;
            }
        }

        public int Count()
        {
            return size;
        }

        public override string ToString()
        {
            string[] temporaryArray = new string[size];
            string contentsString = "";
            for (int index = 0; index < size; index++)
            {
                try
                {
                    temporaryArray[index] = Convert.ToString(contents[index]);
                    
                    
                    if (index == size-1)
                    {
                        contentsString = contentsString + temporaryArray[index];
                    }
                    else
                    {
                        contentsString = contentsString + temporaryArray[index] + ", ";
                    }
                }
                catch
                {
                    Console.WriteLine("Cannot convert to string.");
                }
            }
            return contentsString;
            
        }

        public static CustomList<T> operator +(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> newList = new CustomList<T>();
            for (int index = 0; index < firstList.size; index++)
            {
                newList.Add(firstList.contents[index]);
            }
            for (int index = 0; index < secondList.size; index++)
            {
                newList.Add(secondList.contents[index]);
            }

            return newList;
        }

        public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> newList = new CustomList<T>();
            for (int index = 0; index < firstList.size; index++)
            {
                newList.Add(firstList.contents[index]);
            }            
            for (int index = 0; index < secondList.size; index++)
            {
                newList.Remove(secondList.contents[index]);
            }
            return newList;
        }

        public CustomList<T> Zip(CustomList<T> zipList)
        {
            CustomList<T> newList = new CustomList<T>();
            if (size >= zipList.size)
            {
                for (int index = 0; index < size; index++)
                {
                    newList.Add(contents[index]);
                    if (index < zipList.size)
                    {
                        newList.Add(zipList.contents[index]);
                    }
                }
            } else
            {
                for (int index = 0; index < zipList.size; index++)
                {
                    newList.Add(zipList.contents[index]);
                    if (index < size)
                    {
                        newList.Add(contents[index]);
                    }
                }
            }
            return newList;
        }

        public void BubbleSort()
        {

            T[] newList = new T[size];
            for (int x = size - 1; x > 0; x--)
            {
                for (int y = 0; y < x; y++)
                {
                    if (contents[y] > contents[y + 1])
                    {
                        for (int index = 0; index < y; y++)
                        {
                            newList[index] = contents[index];
                        }
                        newList[y] = contents[y + 1];
                        newList[y + 1] = contents[y];
                        for (int index = y + 2; index < size; index++)
                        {
                            newList[index] = contents[index];
                        }
                        contents = newList;
                    }
                }
            }


        }

    }
}
