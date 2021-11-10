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
        public List<Album> GetAllAlbums();
        public Album GetById(int AlbumId);
        public Album GetByAlbum(string albumName);
        public List<Album> GetByArtist(string artistName);
        public List<Album> GetByValidity();
        public List<Album> GetByYear(int year);
        public void Insert(Album album);
        public void Update(Album album);
        public void Delete(int AlbumId);
        public void Save();
    }
}
