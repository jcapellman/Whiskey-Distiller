namespace WhiskeyDistiller.library.Common
{
    public class ReturnSet<T>
    {
        public T _value;

        public T GetObject() => _value;

        public ReturnSet(T objvalue)
        {
            _value = objvalue;
        }
    }
}