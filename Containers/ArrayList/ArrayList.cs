using System;
using System.Collections.Generic;
using System.Text;

namespace Containers.ArrayList
{
    public class ArrayList<T>
    {
        private T[] arrayList;
        private int size;

        public ArrayList()
        {
            this.size = 0;
            this.arrayList = new T[300];
        }

        public ArrayList(int desiredSize)
        {
            this.size = 0;
            if (desiredSize > 0)
                this.arrayList = new T[desiredSize];
            else
                this.arrayList = new T[300];
        }

        public int Size                                 { get { return this.size; }                                 set { this.size = value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetElement(int index)
        {
            if (this.arrayList != null)
            {
                if (index >= 0 && index < this.size)
                {
                    return this.arrayList[index];
                } else
                {
                    throw new IndexOutOfRangeException("Index: " + index + " was either greater than the max index " + this.size + " or smaller than 0");
                }
            }
            return default(T);
        }

        public void Add(T item)
        {
            if (item != null)
            {
                if (this.arrayList != null)
                {
                    if (this.size == this.arrayList.Length)
                    {

                    }
                    this.arrayList[size++] = item;
                } else
                {
                    this.arrayList = new T[5];
                }
            } else
            {
                throw new NullReferenceException("The item passed in was null.");
            }
        }


    }
}
