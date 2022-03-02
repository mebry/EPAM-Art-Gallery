using ArtGallery.DI.DataInterfaces;
using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.DI.GalleryInterfaces
{
    /// <summary>
    /// Interface for setting the hall number.
    /// </summary>
    public interface IHall:IData<IGalleryPicture>
    {
        int HallNumber { get; set; }
    }
}
