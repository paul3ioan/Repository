using System;
using System.Collections.Generic;
using System.Linq;
namespace Repository.Repository
{
    public abstract class Rrepository : IRrepository
    {

        protected int id = 1;
        private List<int> missingIds = new();

        protected IEnumerable<Album> albums = new List<Album>();
        public IEnumerable<Album> GetAllAlbums()
        {
            return albums;
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
            return albumsByArtist;
        }
        public IEnumerable<Album> GetByValidity()
        {
            IEnumerable<Album> albumsByValidity = albums.Where(x => x.Valid == true).ToList();
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
            IEnumerable<Album> albumsByYear = albums.Where(x => x.Year == year).ToList();
            if (albumsByYear == null)
                throw new ArgumentNullException($"No album from the year {year}");
            return albumsByYear;
        }
        public void Insert(Album album)
        {
            var supportList = albums.ToList();
            if (missingIds.Count == 0)
            {
                album.Id = id++;
            }
            else
            {
                album.Id = missingIds[0];
                missingIds.Remove(missingIds[0]);
            }
            supportList.Add(album);
            albums = supportList;
        }
        public void Delete(int AlbumId)
        {
            
            missingIds.Add(AlbumId);
            var newAlbums = albums.Where(x => x.Id != AlbumId).ToList();
            albums = newAlbums;
        }
        public Album AddFromDataBaseElement(string s)
        {
            Album newAlbum = new();
            var list = s.Split(',');
            if (list.Length != 8) throw new Exception("Input is invalid");
            newAlbum.Id = Int32.Parse(list[0]);
            newAlbum.Name = list[1];
            newAlbum.ArtistName = list[3];
            newAlbum.Genre = list[2];
            if (list[4] == "true")
            {
                newAlbum.Valid = true;
            }
            else
            {
                newAlbum.Valid = false;
            }
            newAlbum.Sales = Int32.Parse(list[5]);
            newAlbum.Year = Convert.ToInt32(list[6]);
            newAlbum.RecordLabel = list[7];
            return newAlbum;
        }
        public abstract void Save();
    }
}
