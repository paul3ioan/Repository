using System;

namespace Repository.Interface.Employeeview
{
    public class EmployeeServices :AddNewAlbum, IEmployeeServices
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
            if (allAlbums == null)
            {
                Console.WriteLine($"No albums available");
                return;
            }
            foreach (var album in allAlbums)
            {
                Console.WriteLine($"\n{album.Id} {album.Name} {album.ArtistName} {album.Genre} {"Available"}");
            }

            ShowOptionsToModify();
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
                Console.WriteLine($"\n{album.Id} {album.Name} {album.ArtistName} {album.Genre} {avalability}");
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
                            ModifyItemOptions(album);
                            inLoop = false;
                        }
                        break;
                    case '2':
                        inLoop = false;
                        break;
                }
            }
        }

        private void ModifyItemOptions(Album album)
        {
            Console.WriteLine("PRESS:\n [1] change item\n [2] delete item\n [3] SaveChanges\n [4] ExitWithoutSaving\n [5] ExitAndSave");
            var input = Console.ReadKey();
            switch (input.KeyChar)
            {
                case '1': 
                    ChangeItem(album); 
                    break;
                case '2': 
                    _repo.Delete(album.Id); 
                    break;
                case '3': 
                    _repo.Save(); 
                    break;
                case '4': 
                    Environment.Exit(0); 
                    break;
                case '5': 
                    return;
                default: 
                    Console.WriteLine("You're input is incorrect!"); 
                    break;
            }
        }

        private void ChangeItem(Album album)
        {
            Console.WriteLine("What do you want to change about this item?");
            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine(" [1] name\n [2] artist name\n [3] genre\n [4] Sales\n [5] Year\n [6] Record Label\n [7] GoBack/Save");
                var input = Console.ReadKey();
                Console.WriteLine();
                switch (input.KeyChar)
                {
                    case '1':

                        var text = Console.ReadLine();
                        album.Name = text;
                        break;
                    case '2':
                        var text1 = Console.ReadLine(); 
                        album.ArtistName = text1; 
                        break;
                    case '3':
                        var text2 = Console.ReadLine(); 
                        album.Genre = text2; 
                        break;
                    case '4':
                        var text3 = Console.ReadLine(); album.Sales = Int32.Parse(text3); break;
                    case '5':
                        var text4 = Console.ReadLine(); album.Year = Int32.Parse(text4); break;
                    case '6':
                        var text5 = Console.ReadLine(); album.RecordLabel = text5; break;
                    case '7':
                        Console.WriteLine("Thank you for the changes!"); isLoop = false; break;
                    default:
                        Console.WriteLine("Input is invalid try again!"); break;
                }
            }
        }

        public void AddNewAlbum()
        {
            var newAlbum = AddAlbum();
            if (newAlbum != null)
            {
                _repo.Insert(newAlbum);
            }
        }        
    }
}
