using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.DI.GalleryInterfaces
{
    /// <summary>
    /// Interface for working with the gallery.
    /// </summary>
    public interface IGalleryFunction
    {
        void AddHall(IHall hall);
        void AddPicture(IGalleryPicture picture);
        void AddPictureByHall(IGalleryPicture picture, int hallNumber);
        void ExposePictureWithWarehouse(IGalleryPicture picture, int hallNumber);
        void RemovePictureByHall(IGalleryPicture picture, int hallNumber);
        void RemoveHall(int hallNumber);
        IEnumerable<IGalleryPicture> GetPictureCollectionByHall(int hallNumber);
        IEnumerable<IGalleryPicture> GetPictureCollectionByWarehouse();

    }
}
