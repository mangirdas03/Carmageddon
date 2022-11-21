using Carmageddon.Forms.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Memento
{
    public class Memento
    {
        Invoker _invoker;

        public Memento(Invoker invoker)
        {
            _invoker = invoker;
        }
        public Invoker Invoker { get { return _invoker; } set { _invoker = value; } }

    }
}
