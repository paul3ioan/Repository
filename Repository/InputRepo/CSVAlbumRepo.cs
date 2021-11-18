using System.IO;
using Repository.Repository;
using Repository;
namespace InputRepo
{
    public class CSVAlbumRepo : Rrepository, IAlbumRepo
    {
        private readonly string outputPath = "../../../OutputAlbums.csv";

        public CSVAlbumRepo(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    s = sr.ReadLine();
                    while ((s = sr.ReadLine()) != null)
                    {
                        var newAlbum = AddFromDataBaseElement(s);
                        Insert(newAlbum);
                    }
                }

            }
        }

        public override void Save()
        {
            using (StreamWriter sw = File.CreateText(outputPath))
            {
                sw.WriteLine("ID,Album,Genre,Artist,Valid,Sales,Year,Record Label");
                foreach (var album in albums)
                    sw.WriteLine($"{album.Id},{album.Name},{album.Genre},{album.ArtistName},{album.Valid}," +
                        $"{album.Sales},{album.Year},{album.RecordLabel}");
            }
        }
    }
}
