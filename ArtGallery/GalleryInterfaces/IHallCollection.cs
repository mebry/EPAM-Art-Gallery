using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.DI.GalleryInterfaces
{
    /// <summary>
    /// Interface for working with halls.
    /// </summary>
    public interface IHallCollection
    {
        void AddHall(IHall hall);
        void RemoveHall(int hallNumber);
        void AddPicture(IGalleryPicture picture, int hallNumber);
        void RemovePicture(IGalleryPicture picture, int hallNumber);
        IEnumerable<IGalleryPicture> GetPictureCollection(int hallNumber);
        IEnumerable<IHall> GetHallCollection();
    }
}
