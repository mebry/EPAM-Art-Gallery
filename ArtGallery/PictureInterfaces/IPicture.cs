namespace ArtGallery.DI.PictureInterfaces
{
    /// <summary>
    /// Interface describing the properties of the picture.
    /// </summary>
    public interface IPicture 
    {
        string Name { get; }
        string Author { get; }
        string Genre { get; }
        string Direction { get; }
        int Year { get; }
    }
}
