using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtGallery.Bll.Models;
using ArtGallery.Bill.Service;

namespace ArtGallery.Tests
{
    /// <summary>
    /// Testing the SearchByPicture class.
    /// </summary>
    [TestClass]
    public class SearchByPictureTests
    {
        /// <summary>
        /// Checking for the correct operation of the constructor.
        /// </summary>
        [TestMethod]
        public void SearchByPicture_ValidConstructor_IsTrue()
        {
            var pictures = new SearchByPicture(GetData.GetPictureCollection());
        }

        /// <summary>
        /// Checking for throwing an exception when passing null values to the constructor.
        /// </summary>
        [TestMethod]
        public void SearchByPicture_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() => new SearchByPicture(null));
        }

        /// <summary>
        /// Checking for a search by author.
        /// </summary>
        [TestMethod]
        public void SearchByAuthor_SearchPicturesByTheSameAuthor_IsTrue()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByAuthor("Leonardo da Vinci");

            Assert.IsTrue(foundPictures.Count() == 2);
        }

        /// <summary>
        /// Checking for a search by author.
        /// </summary>
        [TestMethod]
        public void SearchByAuthor_SearchPicturesByTheSameAuthor_IsFalse()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByAuthor("Vincent Willem Van Gogh");

            Assert.IsFalse(foundPictures.Count() == 1);
        }

        /// <summary>
        /// Checking for a search by name.
        /// </summary>
        [TestMethod]
        public void SearchByName_SearchPicturesByTheSameName_IsTrue()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByName("Mona Lisa");

            Assert.IsTrue(foundPictures.Count() == 2);
        }

        /// <summary>
        /// Checking for a search by name.
        /// </summary>
        [TestMethod]
        public void SearchByName_SearchPicturesByTheSameName_IsFalse()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByName("Mona Lisa");

            Assert.IsFalse(foundPictures.Count() == 1);
        }

        /// <summary>
        /// Checking for a search by genre.
        /// </summary>
        [TestMethod]
        public void SearchByGenre_SearchPicturesByTheSameGenre_IsTrue()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByGenre("Urban landscape");

            Assert.IsTrue(foundPictures.Count() == 2);
        }

        /// <summary>
        /// Checking for a search by genre.
        /// </summary>
        [TestMethod]
        public void SearchByGenre_SearchPicturesByTheSameGenre_IsFalse()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByGenre("Urban landscape");

            Assert.IsFalse(foundPictures.Count() == 1);
        }

        /// <summary>
        /// Checking for a search by direction.
        /// </summary>
        [TestMethod]
        public void SearchByDirection_SearchPicturesByTheSameDirection_IsTrue()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByDirection("Post - Impressionism");

            Assert.IsTrue(foundPictures.Count() == 3);
        }

        /// <summary>
        /// Checking for a search by direction.
        /// </summary>
        [TestMethod]
        public void SearchByDirection_SearchPicturesByTheSameDirection_IsFalse()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByDirection("Post - Impressionism");

            Assert.IsFalse(foundPictures.Count() == 1);
        }

        /// <summary>
        /// Checking for a search by year.
        /// </summary>
        [TestMethod]
        public void SearchByYear_SearchPicturesByTheRangeOfYear_IsTrue()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByYear(1888);

            Assert.IsTrue(foundPictures.Count() == 4);
        }

        /// <summary>
        /// Checking for a search by year.
        /// </summary>
        [TestMethod]
        public void SearchByYear_SearchPicturesByTheSameYear_IsFalse()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchByYear(1888);

            Assert.IsFalse(foundPictures.Count() == 1);
        }

        /// <summary>
        /// Checking for a search by sample.
        /// </summary>
        [TestMethod]
        public void SearchBySample_SearchPicturesByTheSameSample_IsTrue()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchBySample(
                new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                    "Renaissance painting", 1503, Technic.Watercolour));

            Assert.IsTrue(foundPictures.Count() == 1);
        }

        /// <summary>
        /// Checking for a search by sample.
        /// </summary>
        [TestMethod]
        public void SearchBySample_SearchPicturesByTheSameSample_IsFalse()
        {
            var picturesBySearch = new SearchByPicture(GetData.GetPictureCollection());

            var foundPictures = picturesBySearch.SearchBySample(
                new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                    "Renaissance painting", 1503, Technic.Watercolour));

            Assert.IsFalse(foundPictures.Count() == 2);
        }
    }
}