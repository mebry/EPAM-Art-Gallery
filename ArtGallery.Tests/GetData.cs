using System.Linq;
using System.Collections.Generic;
using ArtGallery.Bll.Models;
using ArtGallery.Data.Collection;
using ArtGallery.DI.DataInterfaces;
using ArtGallery.DI.GalleryInterfaces;
using ArtGallery.DI.PictureInterfaces;

namespace ArtGallery.Tests
{
    /// <summary>
    /// A class that stores data for convenient unit testing.
    /// </summary>
    public class GetData
    {
        /// <summary>
        /// Creating a default picture.
        /// </summary>
        /// <returns></returns>
        public static IGalleryPicture CreateDefaultPicture() =>
            new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                    "Renaissance painting", 1503, Technic.Watercolour);

        /// <summary>
        /// Creating a default hall.
        /// </summary>
        /// <param name="hallNumber"></param>
        /// <returns></returns>
        public static IHall CreateDefaultHall(int hallNumber)=>
            new Hall(new PictureCollection(GetPictureCollection().ToList()), hallNumber);

        /// <summary>
        /// Getting a set of paintings.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IGalleryPicture> GetPictureCollection()
        {
            IData<IGalleryPicture> pictures = new PictureCollection();

            pictures.Add(new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                    "Renaissance painting", 1503, Technic.Watercolour));
            pictures.Add(new GalleryPicture("Night terrace cafe", "Vincent Willem Van Gogh", "Urban landscape",
                "Post - Impressionism", 1888, Technic.Encaustic));
            pictures.Add(new GalleryPicture("Black Square", "Kazimir Malevich", "Suprematism",
                "Avant-garde art", 1915, Technic.Gouache));
            pictures.Add(new GalleryPicture("Heroes", "Viktor Vasnetsov", "Suprematism",
                "Neo - Russian", 1898, Technic.Watercolour));
            pictures.Add(new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                "Renaissance painting", 1506, Technic.Watercolour));
            pictures.Add(new GalleryPicture("Starry Night", "Vincent Willem Van Gogh", "Urban landscape",
                "Post - Impressionism", 1889, Technic.Watercolour));
            pictures.Add(new GalleryPicture("Red vineyards in Arles", "Vincent Willem Van Gogh", "Landscape",
                "Post - Impressionism", 1888, Technic.Gouache));

            return pictures.ReadAll();
        }

        /// <summary>
        /// Getting a list of paintings.
        /// </summary>
        /// <returns></returns>
        public static List<IHall> GetHallCollection()
        {
            IHallCollection hallCollection = new HallCollection();
            IData<IGalleryPicture> theFirstPictureCollection = new PictureCollection();
            IData<IGalleryPicture> theSecondPictureCollection = new PictureCollection();

            theFirstPictureCollection.Add(new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
                   "Renaissance painting", 1503, Technic.Watercolour));
            theFirstPictureCollection.Add(new GalleryPicture("Mona Lisa", "Leonardo da Vinci", "Portrait",
               "Renaissance painting", 1506, Technic.Watercolour));
            theFirstPictureCollection.Add(new GalleryPicture("Red vineyards in Arles", "Vincent Willem Van Gogh", "Landscape",
                "Post - Impressionism", 1888, Technic.Gouache));
            theSecondPictureCollection.Add(new GalleryPicture("Black Square", "Kazimir Malevich", "Suprematism",
                "Avant-garde art", 1915, Technic.Gouache));
            theSecondPictureCollection.Add(new GalleryPicture("Heroes", "Viktor Vasnetsov", "Suprematism",
                "Neo - Russian", 1898, Technic.Watercolour));

            hallCollection.AddHall(new Hall(theFirstPictureCollection, 3));
            hallCollection.AddHall(new Hall(theSecondPictureCollection, 10));

            return hallCollection.GetHallCollection().ToList();
        }
    }
}
