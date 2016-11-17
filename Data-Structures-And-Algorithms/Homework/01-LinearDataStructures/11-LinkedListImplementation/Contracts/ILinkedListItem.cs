namespace _11_LinkedListImplementation.Contracts
{
    public interface ILinkedListItem<T>
    {
        T Value { get; }

        ILinkedListItem<T> NextItem { get; set; }
    }
}
