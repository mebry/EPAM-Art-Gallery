namespace ArtGallery.DI.PictureInterfaces
{
    /// <summary>
    /// Interface describing the movement of a painting in a gallery.
    /// </summary>
    public interface IStorageMovement
    {
        DateTime DateChange { get; }
        TimeSpan TimeSpend { get; }
        string OldPlace { get; }
        string CurrentPlace { get; }
    }
}
