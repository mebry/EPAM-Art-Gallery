namespace ArtGallery.DI.DataInterfaces
{
    /// <summary>
    /// Interface for searching by criteria.
    /// </summary>
    /// <typeparam name="T">Universal parameter.</typeparam>
    public interface IDataSearch<T>
    {
        IEnumerable<T> SearchByName(string name);
        IEnumerable<T> SearchByGenre( string genre);
        IEnumerable<T> SearchByAuthor(string author);
        IEnumerable<T> SearchByDirection(string direction);
        IEnumerable<T> SearchByYear(int year);
        IEnumerable<T> SearchBySample(T picture);
    }
}
