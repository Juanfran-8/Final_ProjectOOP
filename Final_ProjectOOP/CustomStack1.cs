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

        public void Pop(T item) //para sacar elemento
        {
        }

        public void Peek(T item) //ver elemento de arriba sin quitarlo
        {
        }

        public bool IsEmpty() //checar si la pila esta vacia
        {
        }
    }
}