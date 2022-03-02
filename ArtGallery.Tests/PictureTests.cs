using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtGallery.Bll.Models;

namespace ArtGallery.Tests
{
    /// <summary>
    /// Testing the Picture class.
    /// </summary>
    [TestClass]
    public class PictureTests
    {
        /// <summary>
        /// Checking for the creation of a picture through the constructor.
        /// </summary>
        [TestMethod]
        public void Pictire_CreateValidPicture_AreEqual()
        {
            var actual = GetData.CreateDefaultPicture();

            Assert.AreEqual(new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                    "Renaissance painting", 1503, Technic.Watercolour), actual);
        }

        /// <summary>
        /// Checking for the creation of a picture through the constructor.
        /// </summary>
        [TestMethod]
        public void Pictire_CreateInvalidPicture_AreNotEqual()
        {
            var actual = GetData.CreateDefaultPicture();

            Assert.AreNotEqual(new GalleryPicture("Undefined", "Leonardo da Vinci", "Portrait",
                    "Renaissance painting", 1503, Technic.Watercolour), actual);
        }

        /// <summary>
        /// Checking to create a picture through the constructor if 1 of the fields is null.
        /// </summary>
        [TestMethod]
        public void Pictire_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() => new GalleryPicture(null, "Kazimir Malevich", "Suprematism",
                "Avant-garde art", 1915, Technic.Gouache));

        }
    }
}
