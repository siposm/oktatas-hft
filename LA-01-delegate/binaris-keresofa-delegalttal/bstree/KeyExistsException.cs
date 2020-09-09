using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bstree
{
    class KeyExistsException : Exception
    {
        public KeyExistsException(string msg) : base(msg)
        {
                // ... do nothing
        }
    }
}
