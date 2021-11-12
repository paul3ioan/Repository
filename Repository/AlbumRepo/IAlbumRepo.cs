using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAlbumRepo
    {
        public int GetGenericId();
        public IEnumerable<Album> GetAllAlbums();
        public Album GetById(int AlbumId);
        public Album GetByAlbum(string albumName);
        public IEnumerable<Album> GetByArtist(string artistName);
        public IEnumerable<Album> GetByValidity();
        public IEnumerable<Album> GetByYear(int year);
        public void Insert(Album album);
        public void Update(Album album);
        public void Delete(int AlbumId);
        public void Save();
    }
}
