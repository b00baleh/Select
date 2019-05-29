using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Select
{
    public static class Select
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            var en = new MyIenumClass<TSource, TResult>(source, selector);

            return (IEnumerable<TResult>)en;
        }
    }

    public class MyIenumClass<TSource, TResult> : IEnumerable<TSource>
    {
        private IEnumerable<TSource> _list;
        private Func<TSource, TResult> _selector;
        public MyIenumClass(IEnumerable<TSource> input, Func<TSource, TResult> selector)
        {
            _list = input;
            _selector = selector;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return new MyEnumerator<TSource, TResult>(_list, _selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerator<TSource, TResult> : IEnumerator<TSource>
    {
        private IEnumerable<TSource> _objects;
        private Func<TSource, TResult> _selector;
        //private int _pos = -1;

        public MyEnumerator(IEnumerable<TSource> input, Func<TSource, TResult> selector)
        {
            _objects = input;
            _selector = selector;
        }

        public void Dispose()
        {
            _objects.GetEnumerator().Dispose();
        }

        public bool MoveNext()
        {
            Console.WriteLine("+");
            
            return (_objects.GetEnumerator().MoveNext());
        }

        public void Reset()
        {
            _objects.GetEnumerator().Reset();
        }

        public TSource Current
        {
            get { return _objects.GetEnumerator().Current; }
        }

        object IEnumerator.Current
        {
            get { return _selector(_objects.GetEnumerator().Current); }
        }
    }
}
