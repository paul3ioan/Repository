using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace Repository
{
    public class AlbumRepo : IAlbumRepo
    {
        private int id = 0;
        private string outputPath = "../../../OutputAlbums.csv";
        private IEnumerable<Album> albums = new List<Album>();
   
        public AlbumRepo(string path)
        {
            
            List<Album> supportNewAlbums = new();
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    s = sr.ReadLine();
                    while ((s = sr.ReadLine()) != null)
                    {
                        var newAlbum = AddFromDataBaseElement(s);
                        supportNewAlbums.Add(newAlbum);
                    }
                }
                id = supportNewAlbums.Count() + 1;
                albums=supportNewAlbums.AsEnumerable<Album>();
            }
        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return albums;
        }
        public int GetGenericId()
        {
            return id;
        }
        public Album GetById(int AlbumId)
        {
            if (!albums.Where(x => x.Id == AlbumId).Any())
                return null;
            var album = albums.Where(x => x.Id == AlbumId).First();
            return album;
        }
        public Album GetByAlbum(string albumName)
        {
            if (!albums.Where(x => x.Name == albumName).Any())
                return null;
            var album = albums.Where(x => x.Name == albumName).First();
            return album;
        }
        public IEnumerable<Album> GetByArtist(string artistName)
        {
            if (!albums.Where(x => x.ArtistName == artistName).Any())
                return null;

            List<Album> albumsByArtist = albums.Where(x => x.ArtistName == artistName).ToList();
            return albumsByArtist.AsEnumerable<Album>();
        }
        public IEnumerable<Album> GetByValidity()
        {
            IEnumerable<Album> albumsByValidity = albums.Where(x => x.Valid == true).AsEnumerable<Album>();
            return albumsByValidity;
        }
        public void Update(Album changedAlbum)
        {
            foreach (var album in albums)
            {
                if (album.Id == changedAlbum.Id)
                {
                    album.Name = changedAlbum.Name;
                    album.Genre = changedAlbum.Genre;
                    album.RecordLabel = changedAlbum.RecordLabel;
                    album.Sales = changedAlbum.Sales;
                    album.Valid = changedAlbum.Valid;
                    album.Year = changedAlbum.Year;
                    album.ArtistName = changedAlbum.ArtistName;
                }
            }
        }
        public IEnumerable<Album> GetByYear(int year)
        {
            IEnumerable<Album> albumsByYear = albums.Where(x => x.Year == year);
            if (albumsByYear == null)
                throw new ArgumentNullException($"No album from the year {year}");
            return albumsByYear;
        }
        public void Insert(Album album)
        {
            List<Album> supportList = albums.ToList();
            supportList.Add(album);
            albums = supportList.AsEnumerable<Album>();
        }
        public void Delete(int AlbumId)
        {
            var newAlbums = albums.Where(x => x.Id != AlbumId);
            albums = newAlbums;
        }
        public void Save()
        {
            using (StreamWriter sw = File.CreateText(outputPath))
            {
                sw.WriteLine("ID,Album,Genre,Artist,Valid,Sales,Year,Record Label");
                foreach (var album in albums)
                    sw.WriteLine($"{album.Id},{album.Name},{album.Genre},{album.ArtistName},{album.Valid}," +
                        $"{album.Sales},{album.Year},{album.RecordLabel}");
            }
        }
        public static Album AddFromDataBaseElement(string s)
        {
            Album newAlbum = new();
            var list = s.Split(',');
            if (list.Length != 8) throw new Exception("Input is invalid");
            newAlbum.Id = Int32.Parse(list[0]);
            newAlbum.Name = list[1];
            newAlbum.ArtistName = list[3];
            newAlbum.Genre = list[2];
            if (list[4] == "true")
                newAlbum.Valid = true;
            else
                newAlbum.Valid = false;
            newAlbum.Sales = Int32.Parse(list[5]);
            newAlbum.Year = Convert.ToInt32(list[6]);
            newAlbum.RecordLabel = list[7];
            return newAlbum;
        }
    }
}
