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
        private int length;
        private int size;
        private int defaultLength = 5;      

        public CustomList()
        {
            length = defaultLength;
            contents = new T[length];
        }

        public CustomList(int capacity)
        {
            contents = new T[capacity];
            length = capacity;
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
            for (int index = 0; index < Count; index++)
            {
                yield return contents[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < Count; index++)
            {
                yield return contents[index];
            }
        }

        public void Add(T item)
        {
            EnsureLength(Count + 1);
            contents[Count] = item;
            size++;
            
        }

        private int Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value < Count)
                {
                    Console.WriteLine("Entered capacity is too small to set as list length.  Reenter with valid entry");
                }
                else if (value >= 0)
                {
                    T[] newContents = new T[value];
                    for (int index = 0; index < Count; index++)
                    {
                        newContents[index] = contents[index];
                    }
                    contents = newContents;
                    length = value;
                }
            }
        }

        private void EnsureLength(int minimumLength)
        {
            if (Length < minimumLength)
            {
                Length = minimumLength*2;
            }
        }
        private int IndexOf(T item)
        {

            int itemIndex = -1;
            for (int index = Count - 1; index >= 0; index--)
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
            
            if (index < Count)
            {
                CustomList<T> newList = new CustomList<T>();
                for (int x = 0; x < index; x++)
                {
                    newList.Add(contents[x]);
                }
                if (index + 1 < Count)
                {
                    for (int x = index + 1; x < Count; x++)
                    {
                        newList.Add(contents[x]);
                    }
                }
                
                contents = newList.contents;
                size--;
            }
        }

        public int Count
        {
            get
            {
                return size;

                //if (contents[0] == null)
                //{
                //    return 0;
                //}
                //else
                //{

                //    for (int x = 1; x < length; x++)
                //    {
                //        if (contents[x] == null)
                //        {
                //            break;
                //        }
                //        count++;
                //    }

                //    return count;
                //}
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (T item in contents)
            {
                stringBuilder.Append(item);
            }
            return stringBuilder.ToString();
                       
        }
        public static CustomList<T> operator +(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> newList = new CustomList<T>();
            for (int index = 0; index < firstList.Count; index++)
            {
                newList.Add(firstList.contents[index]);
            }
            for (int index = 0; index < secondList.Count; index++)
            {
                newList.Add(secondList.contents[index]);
            }

            return newList;
        }

        public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> newList = new CustomList<T>();
            for (int index = 0; index < firstList.Count; index++)
            {
                newList.Add(firstList[index]);
            }            
            for (int index = 0; index < secondList.Count; index++)
            {
                newList.Remove(secondList[index]);
            }
            return newList;
        }

        public CustomList<T> Zip(CustomList<T> zipList)
        {
            CustomList<T> newList = new CustomList<T>();
            if (Count >= zipList.Count)
            {
                for (int index = 0; index < Count; index++)
                {
                    newList.Add(contents[index]);
                    if (index < zipList.Count)
                    {
                        newList.Add(zipList.contents[index]);
                    }
                }
            } else
            {
                for (int index = 0; index < zipList.Count; index++)
                {
                    newList.Add(zipList.contents[index]);
                    if (index < Count)
                    {
                        newList.Add(contents[index]);
                    }
                }
            }
            return newList;
        }

        public void BubbleSort()
        {
            
            for (int x = Count - 1; x > 0; x--)
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
