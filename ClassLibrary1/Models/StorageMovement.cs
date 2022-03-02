using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Bll.Models
{
    /// <summary>
    /// Recording to store the location of the painting.
    /// </summary>
    /// <param name="DateChange">Date the painting was moved.</param>
    /// <param name="TimeSpend">Time spent.</param>
    /// <param name="OldPlace">The old location of the painting.</param>
    /// <param name="CurrentPlace">The current position of the painting.</param>
    public record StorageMovement(DateTime DateChange, TimeSpan TimeSpend, string OldPlace, string CurrentPlace) : IStorageMovement;
}
