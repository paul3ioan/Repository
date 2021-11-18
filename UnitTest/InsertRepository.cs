using Repository;
using InputRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTest
{
    [TestClass]
    public class InsertRepository : RepositoryTesting
    {
        static string path = "../../../albums.csv";
        static string path2 = "../../../albums.xml";
        static IAlbumRepo albumRepo;
        static IAlbumRepo xmlRepo;
        public InsertRepository()
        {
            albumRepo = new CSVAlbumRepo(path);
            xmlRepo = new XMLAlbumRepo(path2);
        }

        [TestMethod]

        public void InsertElement_ListIsNotNull()
        {
            //Arrange
            bool testCSV = false, testXML = false;
            var newAlbum = new Album();
            newAlbum.Name = "TEST";
            //Act
            xmlRepo.Insert(newAlbum);
            albumRepo.Insert(newAlbum);
            foreach (var album in albumRepo.GetAllAlbums())
            {
                if (album == newAlbum)
                    testCSV = true;
            }
            foreach (var album in xmlRepo.GetAllAlbums())
            {
                if (album == newAlbum)
                    testXML = true;
            }
            //Assert
            Assert.IsTrue(testCSV);
            Assert.IsTrue(testXML);
        }
        [TestMethod]
        public void InsertElement_ListIsNull()
        {
            //Arrange
            bool testCSV = false, testXML = false;
            var newAlbum = new Album();
            newAlbum.Name = "TEST";
            //Act
            IAlbumRepo nullAlbumRepo = new CSVAlbumRepo("ads"),
                xmlNullAlbumRepo = new XMLAlbumRepo("ads");
            xmlRepo.Insert(newAlbum);
            albumRepo.Insert(newAlbum);
            foreach (var album in albumRepo.GetAllAlbums())
            {
                if (album == newAlbum)
                    testCSV = true;
            }
            foreach (var album in xmlRepo.GetAllAlbums())
            {
                if (album == newAlbum)
                    testXML = true;
            }
            //Assert
            Assert.IsTrue(testCSV);
            Assert.IsTrue(testXML);
        }
    }
}
