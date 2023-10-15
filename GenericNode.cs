namespace ProductManagementApp
{
    internal class GenericNode<T>
    {
        public T? Value { get; set; }
        public int Count { get; set; }
        public GenericNode<T>? Prev { get; set; }
        public GenericNode<T>? Next { get; set; }

    }
}