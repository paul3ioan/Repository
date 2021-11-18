﻿using System.Collections.Generic;

namespace Repository
{
    public interface IAlbumRepo
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album GetById(int albumId);
        public Album GetByAlbum(string albumName);
        public IEnumerable<Album> GetByArtist(string artistName);
        public IEnumerable<Album> GetByValidity();
        public IEnumerable<Album> GetByYear(int year);
        public void Insert(Album album);
        public void Update(Album album);
        public void Delete(int albumId);
        public void Save();
    }
}
