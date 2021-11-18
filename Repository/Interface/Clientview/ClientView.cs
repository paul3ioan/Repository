using System;

namespace Repository.Interface.Clientview
{
    public class ClientView:IClientView
    {       
        private readonly IClientServices _clientServices;
        private readonly IAlbumRepo _repo;
        public ClientView(IAlbumRepo repo)
        {
            _repo = repo;
            _clientServices = new ClientServices(repo);
        }
        public void Start()
        {
            Console.WriteLine("\nHello client!");
            while (true)
            {
                Console.WriteLine("Press:\n [1] for showing all albmus\n [2] show only" +
                  " available albmus\n [3] show albmus by your favourite artist\n [4] exit");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        _clientServices.ShowAllItems(); 
                        break;
                    case '2': 
                        _clientServices.ShowAvailableItems();
                        break;
                    case '3':
                        Console.WriteLine("Write the name of your favourite artist:\n");
                        var text = Console.ReadLine();
                        _clientServices.ShowItemsByArtist(text); 
                        break;
                    case '4':
                        Console.WriteLine("Thanks for using our services!");
                        _repo.Save();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Invalid input try again!");
                        continue;                 
                }
            }
        }
    }
}
