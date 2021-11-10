using System;
using System.IO;
using System.Collections.Generic;
namespace Repository
{
    public class AlbumRepo : IAlbumRepo
    {
        private int id = 0;
        private List<Album> albums = new();
        public List<Album> GetAllAlbums()
        {
            return albums;
        }
        public int GetGenericId()
        {
            id++;
            return id;
        }
        public Album GetById(int AlbumId)
        {
            foreach (var album in albums)
                if (album.Id == AlbumId)
                    return album;
            throw new NullReferenceException($"No album with the id of {AlbumId}");
        }
        public Album GetByAlbum(string albumName)
        {
            foreach (var album in albums)
                if (album.Name == albumName)
                    return album;
            throw new NullReferenceException($"No album with the name of {albumName}");
        }
        public List<Album> GetByArtist(string artistName)
        {
            List<Album> albumsByArtist = new();
            foreach (var album in albums)
                if (album.ArtistName == artistName)
                    albumsByArtist.Add(album);
            if(albumsByArtist.Count == 0)
                throw new NullReferenceException("No album by artist ");
            return albumsByArtist;
        }
        public List<Album> GetByValidity()
        {
            List<Album> albumsByValidity = new List<Album>();
            foreach (var album in albums)
                if (album.Valid)
                    albumsByValidity.Add(album);
            return albumsByValidity;
        }
        public void Update(Album changedAlbum)
        {
            foreach(var album in albums)
            {
                if(album.Id == changedAlbum.Id)
                {
                    album.Name = changedAlbum.Name;
                    album.Valid = changedAlbum.Valid;
                    album.Year = changedAlbum.Year;
                    album.ArtistName = changedAlbum.ArtistName;
                    Save();
                }
            }
        }
        public List<Album> GetByYear(int year)
        {
            List<Album> albumsByYear = new();
            foreach (var album in albums)
                if (album.Year == year)
                    albumsByYear.Add(album);
            return albumsByYear;
        }
        public void Insert(Album album)
        {
            albums.Add(album);
            Save();
        }
        public void Delete(int AlbumId)
        {
            foreach(var album in albums)
            {
                if (album.Id == AlbumId)
                {
                    albums.Remove(album);
                    return;
                }
            }
            Save();
        }
        public void Save()
        {
            string path = "../../../OutputAlbums.csv";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Album,Artist,Valid,Year");
                foreach (var album in albums)
                    sw.WriteLine($"{album.Name},{album.ArtistName},{album.Valid},{album.Year}");     
            }
            
            
        }
    }
}
