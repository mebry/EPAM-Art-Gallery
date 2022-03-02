using ArtGallery.DI.GalleryInterfaces;
using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Data.Collection
{
    /// <summary>
    /// Class collection of halls.
    /// </summary>
    public class HallCollection : IHallCollection
    {
        private readonly List<IHall> _halls;

        /// <summary>
        /// Constructor for creating an empty list of halls.
        /// </summary>
        public HallCollection():this(new List<IHall>()) { }

        /// <summary>
        /// Constructor for creating a list of halls.
        /// </summary>
        /// <param name="pictures">List of halls.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public HallCollection(List<IHall> halls)
        {
            if (halls is null)
            {
                throw new ArgumentNullException(nameof(halls), "The parameter cannot have a null value.");
            }

            _halls = halls;
        }

        /// <summary>
        /// The method for adding a new hall.
        /// </summary>
        /// <param name="hall">The hall for adding</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Creating an exception if such a hall number already exists.</exception>
        public void AddHall(IHall hall)
        {
            if(hall is null)
            {
                throw new ArgumentNullException(nameof(hall), "The parameter cannot have a null value.");
            }

            bool check = CheckHallNumber(hall.HallNumber);

            if (check)
            {
                throw new ArgumentOutOfRangeException(nameof(hall), "The hall number is set incorrectly.");
            }
            _halls.Add(hall);
        }

        /// <summary>
        /// The method for adding a new picture.
        /// </summary>
        /// <param name="picture">The picture for adding.</param>
        /// <param name="hallNumber">Hall number for adding a picture.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Creating an exception if such a hall number already exists.</exception>
        public void AddPicture(IGalleryPicture picture, int hallNumber)
        {
            if(picture is null)
            {
                throw new ArgumentNullException(nameof(picture), "The parameter cannot have a null value.");
            }

            bool check = CheckHallNumber(hallNumber);

            if (!check)
            {
                throw new ArgumentOutOfRangeException(nameof(hallNumber), "The hall number is set incorrectly.");
            }

            int index = GetIndexByHallNumber(hallNumber);
            _halls[index].Add(picture);
        }

        /// <summary>
        /// The method for obtaining a set of paintings.
        /// </summary>
        /// <param name="hallNumber">The number of the hall where the set of paintings will be returned.</param>
        /// <returns>A set of paintings.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Creating an exception if the room is not found by number.</exception>
        public IEnumerable<IGalleryPicture> GetPictureCollection(int hallNumber)
        {
            int index = GetIndexByHallNumber(hallNumber);

            if (index == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(hallNumber), "The hall number is set incorrectly.");
            }

            return _halls[index].ReadAll();
        }

        /// <summary>
        /// The method for obtaining a set of halls.
        /// </summary>
        /// <returns>A set of halls.</returns>
        public IEnumerable<IHall> GetHallCollection() => _halls;

        /// <summary>
        /// The method for deleting the hall.
        /// </summary>
        /// <param name="hallNumber">The number of the hall to be deleted.</param>
        /// <exception cref="ArgumentOutOfRangeException">Creating an exception if the room is not found by number.</exception>
        public void RemoveHall(int hallNumber)
        {
            int index = GetIndexByHallNumber(hallNumber);

            if (index == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(hallNumber));
            }

            _halls.RemoveAt(index);
        }

        /// <summary>
        /// The method of removing the painting by the number of the hall.
        /// </summary>
        /// <param name="picture">The picture that needs to be deleted.</param>
        /// <param name="hallNumber">The number of the hall in which you want to delete the picture.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Creating an exception if the room is not found by number.</exception>
        public void RemovePicture(IGalleryPicture picture, int hallNumber)
        {
            if (picture is null)
            {
                throw new ArgumentNullException(nameof(picture), "The parameter cannot have a null value.");
            }

            bool check = CheckHallNumber(hallNumber);

            if (!check)
            {
                throw new ArgumentOutOfRangeException(nameof(hallNumber), "The hall number is set incorrectly.");
            }

            int index = GetIndexByHallNumber(hallNumber);
            _halls[index].Remove(picture);
        }

        /// <summary>
        /// The method for verifying the existence of such a hall number.
        /// </summary>
        /// <param name="hallNumber">The hall number for checking for availability.</param>
        /// <returns>The values responsible for the presence of such a number.</returns>
        private bool CheckHallNumber(int hallNumber) =>
            _halls.Any(i => i.HallNumber == hallNumber);

        /// <summary>
        /// The method for getting the index in the list.
        /// </summary>
        /// <param name="hallNumber">The number of the hall to get the index.</param>
        /// <returns>The resulting index.</returns>
        private int GetIndexByHallNumber(int hallNumber)
        {
            int index = -1;
            int count = 0;

            foreach (var hall in _halls)
            {
                if (hall.HallNumber == hallNumber)
                {
                    index = count;
                }

                count++;
            }

            return index;
        }
    }
}
