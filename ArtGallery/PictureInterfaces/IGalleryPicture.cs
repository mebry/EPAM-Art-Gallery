namespace ArtGallery.DI.PictureInterfaces
{
    /// <summary>
    /// Interface describing the behavior of the picture in the gallery.
    /// </summary>
    public interface IGalleryPicture: IPicture
    {
        int? NumberPlace { get; set; }
        void Move(string currentPlace, int? numberPlace = null);
        IEnumerable<IStorageMovement> GetMoving();
    }
}
