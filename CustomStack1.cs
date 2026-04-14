using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_ProjectOOP
{
    public class CustomStack<T>
    {
        private List<T> items;
        public CustomStack()
        {
            items = new List<T>();
        }
        public void Push(T item) //para meter elemento
        {
            items.Add(item);
        }
        public T Pop() //para sacar elemento
        {
            if (IsEmpty())
            {
                throw new EmptyStructureException("Stack is empty");
            }
            int lastIndex = items.Count - 1;
            T lastItem = items[lastIndex];
            items.RemoveAt(lastIndex);
            return lastItem;
        }
        public T Peek() //ver elemento de arriba sin quitarlo
        {
            if (IsEmpty())
            {
                throw new EmptyStructureException("Stack is empty");
            }
            return items[items.Count - 1];
        }
        public bool IsEmpty() //checar si la pila esta vacia
        {
            return items.Count == 0;
        }
    }
}