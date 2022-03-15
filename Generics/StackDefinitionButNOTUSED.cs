
namespace Generics
{

    /// <summary>
    ///     //THIS class was an example of how the GENERIC STACK class WORKS, but is not longer used, becasuse the

    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StackDefinitionButNOTUSED<T>
    {
        private readonly T[] _item;
        private int _currentIndex = -1;

        public StackDefinitionButNOTUSED()
        {
            _item = new T[10];
        }

        public  void Push(T item)
        {
            _item[++_currentIndex] = item;
        }

        //public int Count => _currentIndex + 1;
        public int Count() {
           return _currentIndex + 1;
        }

        //public double Pop() => _item[_currentIndex--];
        public T Pop() {
            return _item[_currentIndex--];
        }

    }
}