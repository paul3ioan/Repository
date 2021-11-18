using System.Collections.Generic;

namespace Repository.Repository
{
    public interface IRrepository
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album GetById(int AlbumId);
        public Album GetByAlbum(string albumName);
        public IEnumerable<Album> GetByArtist(string artistName);
        public IEnumerable<Album> GetByValidity();
        public IEnumerable<Album> GetByYear(int year);
        public void Insert(Album album);
        public void Update(Album album);
        public void Delete(int AlbumId);
        public Album AddFromDataBaseElement(string s);
        public abstract void Save();

    }
}
