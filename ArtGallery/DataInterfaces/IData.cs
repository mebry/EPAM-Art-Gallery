namespace ArtGallery.DI.DataInterfaces
{
	/// <summary>
	/// Interface for working with a collection of data.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IData<T>
	{
		IEnumerable<T> ReadAll();
		void Add(T item);
		void Remove(T item);

	}
}
