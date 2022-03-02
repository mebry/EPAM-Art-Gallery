using ArtGallery.DI.DataInterfaces;
using ArtGallery.DI.GalleryInterfaces;
using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Bll.Service
{
    /// <summary>
    /// Art Gallery Class.
    /// </summary>
    public class Gallery : IGallery, IGalleryFunction
    {
        private readonly IData<IGalleryPicture> _warehouse;
        private readonly IHallCollection _halls;
        public string Name { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Gallery constructor.
        /// </summary>
        /// <param name="halls">Hall collection.</param>
        /// <param name="warehouse">Place to store pictures.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public Gallery(IHallCollection halls, IData<IGalleryPicture> warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse),
                "The parameter cannot have a null value");
            _halls = halls ?? throw new ArgumentNullException(nameof(halls),
                "The parameter cannot have a null value");
        }

        /// <summary>
        /// The method for adding a new hall.
        /// </summary>
        /// <param name="hall">The hall being added.</param>
        public void AddHall(IHall hall) =>
            _halls.AddHall(hall);

        /// <summary>
        /// The method for adding a painting to a warehouse.
        /// </summary>
        /// <param name="picture">The picture being added.</param>
        public void AddPicture(IGalleryPicture picture)
        {
            picture.Move("warehouse");
            _warehouse.Add(picture);
        }

        /// <summary>
        /// The method for adding a painting to a given room.
        /// </summary>
        /// <param name="picture">The picture being added.</param>
        /// <param name="hallNumber">The number of the hall for which the production will be carried out adding a picture.</param>
        public void AddPictureByHall(IGalleryPicture picture, int hallNumber) =>
            _halls.AddPicture(picture, hallNumber);

        /// <summary>
        /// The method for displaying the painting from the warehouse to the specified hall.
        /// </summary>
        /// <param name="picture">The picture being added.</param>
        /// <param name="hallNumber">The number of the hall to which the painting will be moved.</param>
        public void ExposePictureWithWarehouse(IGalleryPicture picture, int hallNumber)
        {
            _warehouse.Remove(picture);
            _halls.AddPicture(picture, hallNumber);
        }   

        /// <summary>
        /// Getting a set of paintings in the specified hall.
        /// </summary>
        /// <param name="hallNumber">The hall where the paintings will be received.</param>
        /// <returns>A set of paintings.</returns>
        public IEnumerable<IGalleryPicture> GetPictureCollectionByHall(int hallNumber) =>
            _halls.GetPictureCollection(hallNumber);

        /// <summary>
        /// The method for getting a collection of paintings from a warehouse.
        /// </summary>
        /// <returns>A set of paintings from the warehouse.</returns>
        public IEnumerable<IGalleryPicture> GetPictureCollectionByWarehouse() =>
            _warehouse.ReadAll();

        /// <summary>
        /// The method for deleting the specified hall.
        /// </summary>
        /// <param name="hallNumber">The number of the hall to be deleted.</param>
        public void RemoveHall(int hallNumber)
        {
            IEnumerable<IGalleryPicture> pictures = _halls.GetPictureCollection(hallNumber);

            foreach (var picture in pictures)
            {
                _warehouse.Add(picture);
            }

            _halls.RemoveHall(hallNumber);
        }

        /// <summary>
        /// The method for deleting a painting by a given hall.
        /// </summary>
        /// <param name="picture">The picture being deleted.</param>
        /// <param name="hallNumber">The number of the hall where the painting will be removed.</param>
        public void RemovePictureByHall(IGalleryPicture picture, int hallNumber)
        {
            _halls.RemovePicture(picture, hallNumber);
            _warehouse.Add(picture);
        }
    }
}
