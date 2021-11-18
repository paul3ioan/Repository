using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using InputRepo;
namespace UnitTest
{
    [TestClass]
    public class RepositoryTesting
    {
        static string path = "../../../albums.csv";
        static string path2 = "../../../albums.xml";
        static IAlbumRepo albumRepo;
        static IAlbumRepo xmlRepo;
        public RepositoryTesting()
        {
            albumRepo = new CSVAlbumRepo(path);
            xmlRepo = new XMLAlbumRepo(path2);        
        }
       
    }
}
