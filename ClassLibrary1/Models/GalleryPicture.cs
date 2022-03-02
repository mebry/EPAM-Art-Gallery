using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Bll.Models
{
    /// <summary>
    /// Class paintings in galleries.
    /// </summary>
    public class GalleryPicture : Picture, IGalleryPicture
    {
        private readonly List<IStorageMovement> _storageMovements;
        public int? NumberPlace { get; set; }

        /// <summary>
        /// Constructor for filling in properties.
        /// </summary>
        /// <param name="name">The name of the painting.</param>
        /// <param name="author">The author of the painting.</param>
        /// <param name="genre">The genre of the painting.</param>
        /// <param name="direction">The direction of the painting.</param>
        /// <param name="year">Year of painting.</param>
        /// <param name="technic">Painting technique.</param>
        public GalleryPicture(string name, string author, string genre, string direction, int year, Technic technic)
            : base(name, author, genre, direction, year, technic)
        {
            _storageMovements = new List<IStorageMovement>();
        }

        /// <summary>
        /// The method for adding a new location of the painting.
        /// </summary>
        /// <param name="currentPlace">Current location of the painting.</param>
        /// <param name="numberPlace">Picture number.</param>
        public void Move(string currentPlace, int? numberPlace = null)
        {
            if (numberPlace is not null)
            {
                NumberPlace = numberPlace;
            }

            if (_storageMovements.Count == 0)
            {
                _storageMovements.Add(new StorageMovement(
                    DateChange: DateTime.Now,
                    TimeSpend: TimeSpan.Zero,
                    OldPlace: "Undefined",
                    CurrentPlace: currentPlace ?? throw new ArgumentNullException(nameof(currentPlace),
                    "The parameter cannot have a null value")
                ));
            }
            else
            {
                _storageMovements.Add(new StorageMovement(
                    DateChange: DateTime.Now,
                    TimeSpend: _storageMovements[_storageMovements.Count - 1].DateChange - DateTime.Now,
                    OldPlace: _storageMovements[_storageMovements.Count - 1].CurrentPlace,
                    CurrentPlace: currentPlace ?? throw new ArgumentNullException(nameof(currentPlace),
                    "The parameter cannot have a null value")
                ));
            }
        }

        /// <summary>
        /// The method for getting a list of picture locations.
        /// </summary>
        /// <returns>A set of picture movements.</returns>
        public IEnumerable<IStorageMovement> GetMoving()
        {
            return _storageMovements;
        }
    }
}
