using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Bll.Models
{
    /// <summary>
    /// Abstract Painting class.
    /// </summary>
    public abstract class Picture : IPicture
    {
        public string Name { get; }
        public string Author { get; }
        public string Genre { get; }
        public string Direction { get; }
        public int Year { get; }
        public Technic Technic { get; }

        /// <summary>
        /// Constructor for filling in properties.
        /// </summary>
        /// <param name="name">The name of the painting.</param>
        /// <param name="author">The author of the painting.</param>
        /// <param name="genre">The genre of the painting.</param>
        /// <param name="direction">The direction of the painting.</param>
        /// <param name="year">Year of painting.</param>
        /// <param name="technic">Painting technique.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public Picture(string name, string author, string genre, string direction, int year, Technic technic)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name),
                "The parameter cannot have a null value.");
            Author = author ?? throw new ArgumentNullException(nameof(author),
                "The parameter cannot have a null value.");
            Genre = genre ?? throw new ArgumentNullException(nameof(genre),
                "The parameter cannot have a null value.");
            Direction = direction ?? throw new ArgumentNullException(nameof(direction),
                "The parameter cannot have a null value.");

            (Year, Technic) = (year, technic);
        }

        /// <summary>
        /// An overridden method for comparing 2 objects.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Picture picture)
            {
                bool isStringEquals = (Name, Author, Genre, Direction).ToString().ToLower() ==
                    (picture.Name, picture.Author, picture.Genre, picture.Direction).ToString().ToLower();
                bool isParamsEquals = (Year, Technic) == (picture.Year, picture.Technic);

                return isStringEquals && isParamsEquals;
            }

            return false;
        }

        /// <summary>
        /// An overridden method for getting the hash code of the object.
        /// </summary>
        /// <returns>Hash code of the object.</returns>
        public override int GetHashCode() =>
            (Name, Author, Genre, Direction, Year, Technic).GetHashCode();

        /// <summary>
        /// An overridden method for getting a string in CVS format.
        /// </summary>
        /// <returns>String in CVS format.</returns>
        public override string ToString() =>
            $"{Name},{Author},{Genre},{Direction},{Year},{Technic}";
    }
}
