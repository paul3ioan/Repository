using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Employeeview
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IAlbumRepo _repo;
        public EmployeeServices(IAlbumRepo repo)
        {
            _repo = repo;
        }
        public void ShowAllItems()
        {
            var allAlbums = _repo.GetAllAlbums();
            if (allAlbums == null) { Console.WriteLine($"No albums found"); return; }
            foreach (var album in allAlbums)
            {
                var avalability = album.Valid == true ? "Available" : "Sold";
                Console.WriteLine($"\n{album.Id} {album.Name} {album.ArtistName} {album.Genre} {avalability} {album.Sales} {album.RecordLabel}");
            }

            ShowOptionsToModify();

        }
        public void ShowAvailableItems()
        {
            var allAlbums = _repo.GetByValidity();
            if (allAlbums == null) { Console.WriteLine($"No albums available"); return; }
            foreach (var album in allAlbums)
            {
                Console.WriteLine($"\n{album.Id} {album.Name} {album.ArtistName} {album.Genre} {"Available"}");
            }

            ShowOptionsToModify();
        }
        public void ShowItemsByArtist(string name)
        {
            var allAlbums = _repo.GetByArtist(name);
            if (allAlbums == null) { Console.WriteLine($"No albums by {name}"); return; }
            foreach (var album in allAlbums)
            {
                var avalability = album.Valid == true ? "Available" : "Sold";
                Console.WriteLine($"\n{album.Id} {album.Name} {album.ArtistName} {album.Genre} {"Available"}");
            }

            ShowOptionsToModify();
        }
        private void ShowOptionsToModify()
        {

            bool inLoop = true;
            while (inLoop)
            {
                Console.WriteLine("If you want to modify an item press [1] or [2] if you want to go back");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Please enter the id of the album");
                        var inputId = Convert.ToInt32(Console.ReadLine());
                        var album = _repo.GetById(inputId);
                        if (album == null)
                        {
                            Console.WriteLine("Sorry the item doesn't exists or is unavailable.Please try again!");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"Welcome here you can modify the item {album.Name}");
                            ChangeItem(album);
                            inLoop = false;
                        }
                        break;
                    case '2':
                        inLoop = false;
                        break;
                }
            }
        }
        public void AddNewItem()
        {
            Console.WriteLine("Type :\n AlbumName Artist Genre Sales RecordLabel Year\n In a single line");
            var input1 = Console.ReadLine();
            _repo.Insert(AlbumRepo.AddFromDataBaseElement(input1));            
        }
    private void ChangeItem(Album album)
        {
            Console.WriteLine("Press:\n [1] change item\n [2] delete item\n [3] exit");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1': break;
                    case '2':
                        _repo.Delete(album.Id);
                        Console.WriteLine($"{album.Name} was deleted succesfully"); 
                        break;
                    case '3': return;
                }
            
        }
    }
}
