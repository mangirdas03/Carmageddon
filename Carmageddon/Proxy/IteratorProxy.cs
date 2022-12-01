using Carmageddon.Forms.IteratorPattern;

namespace Carmageddon.Forms.Proxy
{
    public class IteratorProxy : IAbstractIterator
    {
        private static GameObjAggregate _aggregate;
        private Iterator iterator;


        public IteratorProxy(GameObjAggregate aggregate)
        {
            _aggregate = aggregate;
            iterator = new Iterator(_aggregate);
        }

        public object CurrentItem()
        {
            return iterator.CurrentItem();
        }

        public object First()
        {
            return iterator.First();
        }

        public bool IsDone()
        {
            return iterator.IsDone();
        }

        public object Next()
        {
            return iterator.Next();
        }
    }
}
