using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtGallery.Bll.Models;
using ArtGallery.Data.Collection;
using ArtGallery.Bll.Service;

namespace ArtGallery.Tests
{
    /// <summary>
    /// Testing the Gallery class.
    /// </summary>
    [TestClass]
    public class GalleryTests
    {
        /// <summary>
        /// Checking for a null value in the constructor.
        /// </summary>
        [TestMethod]
        public void Gallery_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() => new Gallery(null, null));
        }

        /// <summary>
        /// Checking the correct execution of the constructor.
        /// </summary>
        [TestMethod]
        public void Gallery_AddValidValueByConstructor_IsTrue()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());
        }

        /// <summary>
        /// Checking for the addition of a new hall.
        /// </summary>
        [TestMethod]
        public void AddHall_AddValidHall_IsTrue()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());
            gallery.AddHall(GetData.CreateDefaultHall(11));
        }

        /// <summary>
        /// Checking for the addition of an existing hall.
        /// </summary>
        [TestMethod]
        public void AddHall_AddTheSameHall_ThrowsException()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());
            gallery.AddHall(GetData.CreateDefaultHall(1));

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                gallery.AddHall(GetData.CreateDefaultHall(1)));
        }

        /// <summary>
        /// Checking for adding a painting to the warehouse.
        /// </summary>
        [TestMethod]
        public void AddPicture_AddValidPictureToWarehouse_IsTrue()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());
            int countPicturesInWarehouse = gallery.GetPictureCollectionByWarehouse().Count();

            gallery.AddPicture(GetData.CreateDefaultPicture());
            int newCountPicturesInWarehouse = gallery.GetPictureCollectionByWarehouse().Count();

            Assert.IsTrue(countPicturesInWarehouse == newCountPicturesInWarehouse - 1);
        }

        /// <summary>
        /// Checking for adding a painting to the warehouse.
        /// </summary>
        [TestMethod]
        public void AddPicture_AddValidPictureToWarehouse_IsFalse()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());
            int countPicturesInWarehouse = gallery.GetPictureCollectionByWarehouse().Count();

            gallery.AddPicture(GetData.CreateDefaultPicture());
            int newCountPicturesInWarehouse = gallery.GetPictureCollectionByWarehouse().Count();

            Assert.IsFalse(countPicturesInWarehouse == newCountPicturesInWarehouse);
        }

        /// <summary>
        /// Checking for adding a picture to the hall, if the value is null.
        /// </summary>
        [TestMethod]
        public void AddPictureByHall_AddNullValueByHall_ThrowsException()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentNullException>(() =>
                gallery.AddPictureByHall(null, 1));
        }

        /// <summary>
        /// Check for adding a picture to the hall, if the hall number is incorrect.
        /// </summary>
        [TestMethod]
        public void AddPicture_AddValidPictureByIncorrectHallNuber_ThrowsExceptios()
        {
            var halls = new HallCollection();
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                gallery.AddPictureByHall(GetData.CreateDefaultPicture(), 0));
        }

        /// <summary>
        /// Check for adding a picture to the hall, if the hall number is correct.
        /// </summary>
        [TestMethod]
        public void AddPicture_AddValidPictureByCorrectHallNuber_IsTrue()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());
            int countPicturesInWarehouse = gallery.GetPictureCollectionByHall(3).Count();

            gallery.AddPictureByHall(new GalleryPicture("Mona Lisa", "Leonardo", "Portrait",
                "Renaissance painting", 1504, Technic.Adhesive), 3);
            int newCountPicturesInWarehouse = gallery.GetPictureCollectionByHall(3).Count();

            Assert.IsTrue(countPicturesInWarehouse == newCountPicturesInWarehouse - 1);
        }

        /// <summary>
        /// Checking for the transfer of a painting with a null value from the warehouse.
        /// </summary>
        [TestMethod]
        public void ExposePictureWithWarehouse_AddNullValue_ThrowsException()
        {
            var halls = new HallCollection();
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentNullException>(() =>
                gallery.ExposePictureWithWarehouse(null, 0));
        }

        /// <summary>
        /// Checking for the transfer of a painting with an incorrect hall number from the warehouse.
        /// </summary>
        [TestMethod]
        public void ExposePictureWithWarehouse_AddValidPictureByIncorrectHallNuber_ThrowsExceptios()
        {
            var halls = new HallCollection();
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                gallery.ExposePictureWithWarehouse(GetData.CreateDefaultPicture(), 0));
        }

        /// <summary>
        /// Checking for the transfer of a painting from the warehouse with the correct hall number.
        /// </summary>
        [TestMethod]
        public void ExposePictureWithWarehouse_AddValidPictureByCorrectHallNuber_IsTrue()
        {
            var picture = new GalleryPicture("Mona Lisa", "Leonardo", "Portrait",
                "Renaissance painting", 1504, Technic.Adhesive);
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());
            int countPicturesInWarehouse = gallery.GetPictureCollectionByHall(3).Count();

            gallery.AddPicture(picture);
            gallery.ExposePictureWithWarehouse(picture, 3);
            int newCountPicturesInWarehouse = gallery.GetPictureCollectionByHall(3).Count();

            Assert.IsTrue(countPicturesInWarehouse == newCountPicturesInWarehouse - 1);
        }

        /// <summary>
        /// Checking for a set of paintings with an incorrect hall number.
        /// </summary>
        [TestMethod]
        public void GetPictureCollectionByHall_GetCollectionByIncorrectHallNuber_ThrowsExceptios()
        {
            var halls = new HallCollection();
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                gallery.GetPictureCollectionByHall(0));
        }

        /// <summary>
        /// Checking for a set of paintings with an correct hall number.
        /// </summary>
        [TestMethod]
        public void GetPictureCollectionByHall_GetCollectionByCorrectHallNuber_ReturnPictures()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());

            int countPicturesInWarehouse = gallery.GetPictureCollectionByHall(3).Count();

            Assert.IsTrue(countPicturesInWarehouse == 3);
        }

        /// <summary>
        /// Checking for receipt of a set of paintings from the warehouse.
        /// </summary>
        [TestMethod]
        public void GetPictureCollectionByWarehouse_GetCollection_IsTrue()
        {
            var halls = new HallCollection();
            var gallery = new Gallery(halls, new PictureCollection());

            gallery.AddPicture(GetData.CreateDefaultPicture());
            gallery.AddPicture(GetData.CreateDefaultPicture());
            int value = gallery.GetPictureCollectionByWarehouse().Count();

            Assert.IsTrue(value == 2);
        }

        /// <summary>
        /// Checking for receipt of a set of paintings from the warehouse.
        /// </summary>
        [TestMethod]
        public void GetPictureCollectionByWarehouse_GetCollection_IsFalse()
        {
            var halls = new HallCollection();
            var gallery = new Gallery(halls, new PictureCollection());

            int value = gallery.GetPictureCollectionByWarehouse().Count();

            Assert.IsFalse(value == 1);
        }

        /// <summary>
        /// Checking for the removal of a hall with an incorrect number.
        /// </summary>
        [TestMethod]
        public void RemoveHall_RemoveHallWithIncorrectHallNuber_ThrowsExceptios()
        {
            var halls = new HallCollection();
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                gallery.RemoveHall(0));
        }

        /// <summary>
        /// Checking for the removal of a hall with an correct number.
        /// </summary>
        [TestMethod]
        public void RemoveHall_RemoveHallWithCorrectHallNuber_IsTrue()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());

            gallery.RemoveHall(3);
        }

        /// <summary>
        /// Checking for the removal of a painting from the hall with an incorrect number.
        /// </summary>
        [TestMethod]
        public void RemovePictureByHall_RemoveValidPictureByHallWithIncorrectHallNuber_ThrowsExceptios()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                gallery.RemovePictureByHall(GetData.CreateDefaultPicture(), 0));
        }

        /// <summary>
        /// Checking for deleting a picture with a null value.
        /// </summary>
        [TestMethod]
        public void RemovePictureByHall_RemoveNullValueByHallWithCorrectHallNuber_ThrowsExceptios()
        {
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());

            Assert.ThrowsException<System.ArgumentNullException>(() =>
                gallery.RemovePictureByHall(null, 3));
        }

        /// <summary>
        /// Checking for the removal of a painting from the hall with an correct number.
        /// </summary>
        [TestMethod]
        public void RemoveHall_RemoveValidPictureByHallWithCorrectHallNuber_IsTrue()
        {
            var picture = new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                   "Renaissance painting", 1503, Technic.Watercolour);
            var halls = new HallCollection(GetData.GetHallCollection().ToList());
            var gallery = new Gallery(halls, new PictureCollection());

            gallery.RemovePictureByHall(picture, 3);
        }
    }
}
