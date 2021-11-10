using System;
using System.IO;
namespace Repository
{
    class Program
    {
        private static readonly IAlbumRepo _repo = new AlbumRepo();
        static void Main(string[] args)
        {
            
            string path = "../../../albums.csv";
            if(File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    s = sr.ReadLine();
                    while((s = sr.ReadLine()) !=null)
                    {
                        addElement(s);
                    }
                }
            }
            MakeSomeChanges();
            _repo.Save();
        }
        static void MakeSomeChanges()
        {
            Album astro = _repo.GetByAlbum("Astroworld");
            astro.Year = 2017;
            astro.Valid = false;
            _repo.Update(astro);
            var deleteAlbums = _repo.GetByArtist("Pantera");
            foreach(var album in deleteAlbums)
            {
                _repo.Delete(album.Id);
            }
        }
        static void addElement(string s)
        {
            Album newAlbum = new();
            var list = s.Split(',');
            if (list.Length != 4) throw new Exception("Input is invalid");
            newAlbum.Id = _repo.GetGenericId();
            newAlbum.Name = list[0];
            newAlbum.ArtistName = list[1];
            if (list[2] == "true")
                newAlbum.Valid = true;
            else
                newAlbum.Valid = false;
            newAlbum.Year =Convert.ToInt32(list[3]);
            _repo.Insert(newAlbum);
        }
    }
}
