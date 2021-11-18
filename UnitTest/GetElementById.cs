using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using InputRepo;

namespace UnitTest
{
    [TestClass]
    public class GetelementById
    {
        static string path = "../../../albums.csv";
        static string path2 = "../../../albums.xml";
        static IAlbumRepo albumRepo;
        static IAlbumRepo xmlRepo;
        public GetelementById()
        {
            albumRepo = new CSVAlbumRepo(path);
            xmlRepo = new XMLAlbumRepo(path2);

        }
        [TestMethod]
        public void GetElementByID_ListIsNotNull()
        {
            //Arrange
            var newAlbum = new Album();
            newAlbum.Id = -1;
            //Act
            xmlRepo.Insert(newAlbum);
            albumRepo.Insert(newAlbum);
            var CSVAlbum = albumRepo.GetById(newAlbum.Id);
            var XMLAlbum = xmlRepo.GetById(newAlbum.Id);
            //Assert
            Assert.IsTrue(CSVAlbum == newAlbum);
            Assert.IsTrue(XMLAlbum == newAlbum);
        }
        [TestMethod]
        public void GetElementByID_ListIsNull()
        {
            //Arrange
            var newAlbum = new Album();
            newAlbum.Id = -1;
            //Act
            IAlbumRepo nullAlbumRepo = new CSVAlbumRepo("ads"),
             xmlNullAlbumRepo = new XMLAlbumRepo("ads");
            xmlNullAlbumRepo.Insert(newAlbum);
            nullAlbumRepo.Insert(newAlbum);
            var CSVAlbum = xmlNullAlbumRepo.GetById(newAlbum.Id);
            var XMLAlbum = nullAlbumRepo.GetById(newAlbum.Id);
            //Assert
            Assert.IsTrue(CSVAlbum == newAlbum);
            Assert.IsTrue(XMLAlbum == newAlbum);
        }
    }
}
