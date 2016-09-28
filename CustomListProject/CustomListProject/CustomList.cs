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
    public class CustomList<T>: IEnumerable<T> where T : IComparable
    {
        
        private T[] contents;
        private int size;
        private int length;
        private int defaultLength = 5;      

        private T[] emptyArray = new T[0];

        public CustomList()
        {
            length = defaultLength;
            contents = new T[length];
        }

        public CustomList(int capacity)
        {
            if (capacity == 0)
            {
                contents = emptyArray;
                Length = 0;
                
            }
            else if (capacity > 0)
            {
                contents = new T[capacity];
                Length = capacity;
            }
        }

        public T this[int index]
        {
            get
            {
                return contents[index];
            }

            set
            {
                contents[index] = value;
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

        public int Length
        {

            get
            {
                return length;
            }
            set
            {
                length = value;
            }
            //var countableArray = from item in contents
            //                     select contents;
            //int count = countableArray.Count();
            //return count;

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
                return Length;
            }
            set
            {
                if (value < size)
                {
                    Console.WriteLine("Entered capacity is too small to set as list length.  Reenter with valid entry");
                }
                else if (value > 0)
                {
                    T[] newContents = new T[value];
                    for (int index = 0; index < size; index++)
                    {
                        newContents[index] = contents[index];
                    }
                    contents = newContents;
                    Length = value;
                }
                else
                {
                    contents = emptyArray;
                    Length = 0;
                }
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (Length < minimumCapacity)
            {
                Capacity = minimumCapacity*2;
            }
        }
        private int IndexOf(T item)
        {

            int itemIndex = -1;
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

        private void RemoveAt(int index)
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

        public int Count
        {
            get
            {
                return size;
            }
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
                newList.Add(firstList[index]);
            }            
            for (int index = 0; index < secondList.size; index++)
            {
                newList.Remove(secondList[index]);
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

        public void bubbleSort()
        {
            
            for (int x = size - 1; x > 0; x--)
            {
                for (int y = 0; y < x; y++)
                {
                    if (contents[y].CompareTo(contents[y+1]) >= 0)
                    {
                        CustomList<T> newList = new CustomList<T>(1);
                        newList[0] = contents[y];
                        contents[y] = contents[y + 1];
                        contents[y + 1] = newList[0];
                    }
                    
                }
            }
        }

    }
}
