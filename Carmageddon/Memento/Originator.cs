using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carmageddon.Forms.Command;

namespace Carmageddon.Forms.Memento
{
    public class Originator
    {
        Invoker _invoker;
        public Invoker Invoker
        {
            get { return _invoker; }
            set { _invoker = value; }
        }
        public Memento SaveMemento() { return new Memento(_invoker); }
        public void RestoreMemento(Memento memento) { _invoker = memento.Invoker; }
    }
}
