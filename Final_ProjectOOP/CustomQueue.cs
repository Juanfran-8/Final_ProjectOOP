using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class CustomQueue<T> : IQueueable<T> //adjuntar interfaz
    {
        private List<T> items;

        public CustomQueue() 
        {
            items = new List<T>();
        }

        public void Enqueue(T item) 
        {
            items.Add(item);
        }
        public T Dequeue() 
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T firstItem = items[0];
            items.RemoveAt(0);
            return firstItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return items[0];
        }

        public bool IsEmpty() 
        {
            return items.Count == 0;
        }
    }
}
