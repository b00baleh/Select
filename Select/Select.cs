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
            var res = new MyIenum<TSource, TResult>(source, selector);
            return res;
        }

    }

    public class MyIenum<TSource, TResult> : IEnumerable<TResult>
    {
        private IEnumerable<TSource> _ienumerable;
        private readonly Func<TSource, TResult> _selector;

        public MyIenum(IEnumerable<TSource> ienumerable, Func<TSource, TResult> selector)
        {
            _ienumerable = ienumerable;
            _selector = selector;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new MyIenumerator<TSource, TResult>(_ienumerable.GetEnumerator(), _selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyIenumerator<TSource, TResult> : IEnumerator<TResult>
    {
        private readonly IEnumerator<TSource> _ienumerator;
        private readonly Func<TSource, TResult> _selector;

        public MyIenumerator(IEnumerator<TSource> ienumerator, Func<TSource, TResult> selector)
        {
            _ienumerator = ienumerator;
            _selector = selector;
        }

        public void Dispose()
        {
            _ienumerator.Dispose();
        }

        public bool MoveNext()
        {
            return _ienumerator.MoveNext();
        }

        public void Reset()
        {
            _ienumerator.Reset();
        }

        public TResult Current { get { return _selector(_ienumerator.Current); } }

        object IEnumerator.Current
        {
            get { return _selector(_ienumerator.Current); }
        }
    }
}
