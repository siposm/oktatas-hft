using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancoltListaLibrary
{
    public class ChainedList <T>
    {
        private ListItem head;

        class ListItem
        {
            public T content;
            public ListItem next;
        }

        public void Insert(T newContent)
        {
            ListItem x = new ListItem();
            x.content = newContent;
            x.next = head;
            head = x;
        }

        public void Process()
        {
            ListItem p = head;
            while(p != null)
            {
                Console.WriteLine(p.content);
                p = p.next;
            }
        }
    }
}
