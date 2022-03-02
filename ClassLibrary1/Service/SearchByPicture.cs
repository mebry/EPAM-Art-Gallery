using ArtGallery.DI.DataInterfaces;
using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Bill.Service
{
    /// <summary>
    /// A class for searching for paintings by criteria.
    /// </summary>
    public class SearchByPicture : IDataSearch<IPicture>
    {
        private readonly IEnumerable<IPicture> _pictures;

        /// <summary>
        /// Constructor for getting a set of paintings.
        /// </summary>
        /// <param name="pictures">A set of paintings.</param>
        /// <exception cref="ArgumentNullException">Creating an exception if the passed object is not defined.</exception>
        public SearchByPicture(IEnumerable<IPicture> pictures) =>
            _pictures = pictures ?? throw new ArgumentNullException(nameof(pictures),
                "The parameter cannot have a null value.");

        /// <summary>
        /// The method for searching by author.
        /// </summary>
        /// <param name="author">The name of the author of the picture.</param>
        /// <returns>The resulting set of paintings after the search.</returns>
        public IEnumerable<IPicture> SearchByAuthor(string author) =>
            _pictures.Where(i => i.Author.ToLower() == author.ToLower());

        /// <summary>
        /// The method for searching by direction.
        /// </summary>
        /// <param name="direction">Direction of the painting.</param>
        /// <returns>The resulting set of paintings after the search.</returns>
        public IEnumerable<IPicture> SearchByDirection(string direction) =>
            _pictures.Where(i => i.Direction.ToLower() == direction.ToLower());

        /// <summary>
        /// The method for searching by genre.
        /// </summary>
        /// <param name="genre">Genre of the painting.</param>
        /// <returns>The resulting set of paintings after the search.</returns>
        public IEnumerable<IPicture> SearchByGenre(string genre) =>
            _pictures.Where(i => i.Genre.ToLower() == genre.ToLower());

        /// <summary>
        /// The method for searching by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The resulting set of paintings after the search.</returns>
        public IEnumerable<IPicture> SearchByName(string name) =>
            _pictures.Where(i => i.Name.ToLower() == name.ToLower());

        /// <summary>
        /// The method for searching by sample.
        /// </summary>
        /// <param name="picture">The picture on which the search will be performed.</param>
        /// <returns>The resulting set of paintings after the search.</returns>
        public IEnumerable<IPicture> SearchBySample(IPicture picture) =>
            _pictures.Where(i => i.Equals(picture));

        /// <summary>
        /// The method for searching by year.
        /// </summary>
        /// <param name="year">The year of painting.</param>
        /// <returns>The resulting set of paintings after the search.</returns>
        public IEnumerable<IPicture> SearchByYear(int year) =>
            _pictures.Where(i => (i.Year >= year - 10) && (i.Year <= year + 10));
    }
}
