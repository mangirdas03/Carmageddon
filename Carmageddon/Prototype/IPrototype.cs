using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Prototype
{
    public interface IPrototype
    {
        public Car MakeCopy();
    }
}
