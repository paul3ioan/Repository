using Repository.Interface;
using InputRepo;
using System;
namespace Repository
{
    class Program
    {
        static bool inLoop = true;
        static void Main(string[] args)
        {     
            string path;

            while (inLoop)
            {
                Console.WriteLine("What database to use ? Type csv or xml");
                string input = Console.ReadLine();
                LoadDatabaseAndInteface(input);
            }      
        }
        static void LoadDatabaseAndInteface(string input)
        {
            IAlbumRepo _repo;
            string pathForCSV = "../../../albums.csv";
            string pathForXML = "../../../XMLFiles/albums.xml";
            if (input == "csv")
            {
                _repo = new CSVAlbumRepo(pathForCSV);
                inLoop = false;
            }
            else if (input == "xml")
            {     
                _repo = new XMLAlbumRepo(pathForXML);
                inLoop = false;
            }
            else
            {
                Console.WriteLine("Invalid input! Please try again");
                return;
            }
            MainView _view = new(_repo);
            _view.Start();
            _repo.Save();
        }
    }
}
