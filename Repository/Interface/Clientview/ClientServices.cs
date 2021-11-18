using System;

namespace Repository.Interface.Clientview
{
    public class ClientServices:IClientServices
    {
        
        private readonly IAlbumRepo _repo;
        public ClientServices ( IAlbumRepo repo)
        {
            _repo = repo;
        }
        public void ShowAllItems()
        {
            var allAlbums = _repo.GetAllAlbums();
            if (allAlbums == null) 
            {
                Console.WriteLine($"No albums found");
                return; 
            }
            foreach (var album in allAlbums)
            {
                var avalability = album.Valid == true ? "Available" : "Sold";
                Console.WriteLine($"\n{album.Name} {album.ArtistName} {album.Genre} {avalability}");
            }        
            ShowOptionsToBuy();
        }
        public void ShowAvailableItems()
        {
            var allAlbums = _repo.GetByValidity();
            if (allAlbums == null) 
            {
                Console.WriteLine($"No albums by available"); 
                return; 
            }
            foreach (var album in allAlbums)
            {
                Console.WriteLine($"\n{album.Name} {album.ArtistName} {album.Genre} {"Available"}");
            }       
            ShowOptionsToBuy();
        }
        public void ShowItemsByArtist(string name)
        {
            var allAlbums = _repo.GetByArtist(name);
            if (allAlbums == null) 
            { 
                Console.WriteLine($"No albums by {name}"); 
                return; 
            }
            foreach (var album in allAlbums)
            {
                var avalability = album.Valid == true ? "Available" : "Sold";
                Console.WriteLine($"\n{album.Name} {album.ArtistName} {album.Genre} {avalability}");
            } 
            ShowOptionsToBuy();
        }
        private void ItemBought(Album album)
        {
            if(album.Valid == false)
            {
                Console.WriteLine($"The album {album.Name} is not available!");
                return;
            }
            Console.WriteLine("Thank you for the purchase!");
            album.Valid = false;
            _repo.Update(album);          
        }
        private void ShowOptionsToBuy()
        {           
            bool inLoop = true;
            while (inLoop)
            {
                Console.WriteLine("If you want to buy an item press [1] or [2] if you want to go back");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Please enter the name of the album");
                        var text = Console.ReadLine();
                        var album = _repo.GetByAlbum(text);
                        if (album == null)
                        {
                            Console.WriteLine("Sorry the item doesn't exists or is unavailable.Please try again!");
                            continue;
                        }
                        else
                        {     
                            ItemBought(album);
                            inLoop = false;
                        }
                        break;
                    case '2':
                        inLoop = false;
                        break;
                }
            }
        }
    }
}
