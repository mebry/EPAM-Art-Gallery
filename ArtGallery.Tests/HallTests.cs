using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtGallery.Bll.Models;
using ArtGallery.Data.Collection;

namespace ArtGallery.Tests
{
    /// <summary>
    /// Testing the Hall class.
    /// </summary>
    [TestClass]
    public class HallTests
    {
        /// <summary>
        /// Checking for the creation of a hall through the constructor, if the parameter passed is null.
        /// </summary>
        [TestMethod]
        public void Hall_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() => new Hall(null, 1));
        }

        /// <summary>
        /// Checking for the creation of a hall through the constructor.
        /// </summary>
        [TestMethod]
        public void Hall_AddValidValueByConstructor_IsTrue()
        {
            var pictures = new PictureCollection(GetData.GetPictureCollection().ToList());
            var chechHall = new Hall(pictures, 1);
        }

        /// <summary>
        /// Checking for adding a new painting to the hall.
        /// </summary>
        [TestMethod]
        public void Add_ValidValue_AddingPicture()
        {
            var checkHall = new Hall(new PictureCollection(), 1);

            checkHall.Add(GetData.CreateDefaultPicture());
            int value = checkHall.ReadAll().Count();

            Assert.AreEqual(1, value);
        }

        /// <summary>
        /// Checking for adding a null to the hall.
        /// </summary>
        [TestMethod]
        public void Add_NullValue_ThrowsException()
        {
            var hall = new Hall(new PictureCollection(), 1);

            Assert.ThrowsException<System.ArgumentNullException>(() => hall.Add(null));
        }

        /// <summary>
        /// Checking for the removal of the picture.
        /// </summary>
        [TestMethod]
        public void Remove_ValidValue_DeletingPicture()
        {
            var pictures = new PictureCollection(GetData.GetPictureCollection().ToList());
            var chechHall = new Hall(pictures, 1);
            int countPictures = chechHall.ReadAll().Count();

            chechHall.Remove(GetData.CreateDefaultPicture());
            int actualCount = chechHall.ReadAll().Count();

            Assert.AreEqual(countPictures, actualCount + 1);
        }

        /// <summary>
        /// Checking for removal a null to the hall.
        /// </summary>
        [TestMethod]
        public void Remove_NullValue_ThrowsException()
        {
            var hall = new Hall(new PictureCollection(), 1);

            Assert.ThrowsException<System.ArgumentNullException>(() => hall.Remove(null));
        }

        /// <summary>
        /// Checking for the reading of paintings in the hall.
        /// </summary>
        [TestMethod]
        public void ReadAll_ReturnPictures_IsTrue()
        {
            var Hall = new Hall(new PictureCollection(), 1);
            Hall.Add(GetData.CreateDefaultPicture());
            Hall.Add(GetData.CreateDefaultPicture());
            Hall.Add(GetData.CreateDefaultPicture());

            int countPictures = Hall.ReadAll().Count();

            Assert.IsTrue(countPictures == 3);
        }

        /// <summary>
        /// Checking for the reading of paintings in the hall.
        /// </summary>
        [TestMethod]
        public void ReadAll_ReturnPictures_IsFalse()
        {
            var Hall = new Hall(new PictureCollection(), 1);

            int countPictures = Hall.ReadAll().Count();

            Assert.IsFalse(countPictures == 6);
        }
    }
}