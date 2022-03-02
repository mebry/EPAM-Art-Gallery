using ArtGallery.DI.DataInterfaces;
using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Data.Collection
{
    /// <summary>
    /// Class collection of pictures.
    /// </summary>
    public class PictureCollection : IData<IGalleryPicture>
    {
        private readonly List<IGalleryPicture> _pictures;

        /// <summary>
        /// Constructor for creating an empty list.
        /// </summary>
        public PictureCollection() : this(new List<IGalleryPicture>()) { }

        /// <summary>
        /// Constructor for creating a list.
        /// </summary>
        /// <param name="pictures">List of paintings.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public PictureCollection(List<IGalleryPicture> pictures)
        {
            if (pictures is null)
            {
                throw new ArgumentNullException(nameof(pictures), "The parameter cannot have a null value.");
            }

            _pictures = pictures;
        }

        /// <summary>
        /// The method for adding a new picture.
        /// </summary>
        /// <param name="picture">The picture being added.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public void Add(IGalleryPicture picture)
        {
            if (picture is null)
            {
                throw new ArgumentNullException(nameof(picture), "The parameter cannot have a null value.");
            }

            _pictures.Add(picture);
        }

        /// <summary>
        /// Getting a set of paintings.
        /// </summary>
        /// <returns>A set of paintings.</returns>
        public IEnumerable<IGalleryPicture> ReadAll() => _pictures;

        /// <summary>
        /// The method for removing a picture from the list.
        /// </summary>
        /// <param name="picture">Picture to delete.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public void Remove(IGalleryPicture picture)
        {
            if (picture is null)
            {
                throw new ArgumentNullException(nameof(picture), "The parameter cannot have a null value.");
            }

            _pictures.Remove(picture);
        }
    }
}