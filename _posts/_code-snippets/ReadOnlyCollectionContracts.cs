public interface IEnumerable<T> : IEnumerable
{
  IEnumerator<T> GetEnumerator();
}

public interface IReadableCollection<T> : IEnumerable<T>
{
  int Count { get; }
  bool Contains(T item);
  void CopyTo(T[] array, int arrayIndex);
}

public interface IReadableList<T> : IReadableCollection<T>
{
  T this[int index] { get; }
  int IndexOf(T item);
}

public interface ICollection<T> : IReadableCollection<T>
{
  void Clear();
  void Add(T item);
  bool Remove(T item);
  bool IsReadOnly { get; }
}

public interface IList<T> : ICollection<T>, IReadableList<T>
{
  T this[int index] { get; set; }
  void Insert(int index, T item);
  void RemoveAt(int index);
}