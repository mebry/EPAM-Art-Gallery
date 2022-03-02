using ArtGallery.DI.DataInterfaces;
using ArtGallery.DI.GalleryInterfaces;
using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Bll.Models
{
    /// <summary>
    /// Class describing the hall.
    /// </summary>
    public class Hall : IHall
    {
        private IData<IGalleryPicture> _galleryPictures;
        private int _freePosition;
        private int _count;
        public int HallNumber { get; set; }

        /// <summary>
        /// Constructor for setting values.
        /// </summary>
        /// <param name="galleryPictures">List of paintings.</param>
        /// <param name="hallNumber">Hall number.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public Hall(IData<IGalleryPicture> galleryPictures, int hallNumber)
        {
            _galleryPictures = galleryPictures ?? throw new ArgumentNullException(nameof(galleryPictures),
                "The parameter cannot have a null value");
            HallNumber = hallNumber;
        }

        /// <summary>
        /// Adding a new picture.
        /// </summary>
        /// <param name="item">Picture being added.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public void Add(IGalleryPicture picture)
        {
            if(picture is null)
            {
                throw new ArgumentNullException(nameof(picture), "The parameter cannot have a null value");
            }

            picture.Move($"hall #{HallNumber}", GetPosition());
            _galleryPictures.Add(picture);
            
        }

        /// <summary>
        /// Getting a set of pictures.
        /// </summary>
        /// <returns>A set of paintings.</returns>
        public IEnumerable<IGalleryPicture> ReadAll() =>
            _galleryPictures.ReadAll();

        /// <summary>
        /// Deleting a picture.
        /// </summary>
        /// <param name="item">The picture being deleted.</param>
        /// /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public void Remove(IGalleryPicture picture)
        {
            if (picture is null)
            {
                throw new ArgumentNullException(nameof(picture), "The parameter cannot have a null value");
            }

            _freePosition = picture.NumberPlace ?? 0;
            _galleryPictures.Remove(picture);
        }

        /// <summary>
        /// The method for getting an unoccupied position for a picture..
        /// </summary>
        /// <returns>Hall number.</returns>
        private int GetPosition()
        {
            if (_freePosition != 0)
            {
                int value = _freePosition;
                _freePosition = 0;

                return value;
            }

            _count++;
            return _count++;
        }
    }
}
