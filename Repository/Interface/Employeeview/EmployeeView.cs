using System;
using Repository.Interface.Employeeview;
namespace Repository.Interface
{
    public class EmployeeView : IEmployeeView
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IAlbumRepo _repo;
        public EmployeeView(IAlbumRepo repo)
        {
            _repo = repo;
            _employeeServices = new EmployeeServices(repo);
        }
        public void Start()
        {
            Console.WriteLine("\nHello employee!");
            while (true)
            {
                Console.WriteLine("Press:\n [1] for showing all albmus\n [2] show only" +
                  " available albmus\n [3] show albmus by your favourite artist\n [4] addNewAlbum\n [5] SaveChanges\n [6] ExitWithoutSaving\n [7] ExitAndSave");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1': 
                        _employeeServices.ShowAllItems(); 
                        break;
                    case '2': 
                        _employeeServices.ShowAvailableItems(); 
                        break;
                    case '3':
                        Console.WriteLine("Write the name of your favourite artist:\n");
                        var text = Console.ReadLine();
                        _employeeServices.ShowItemsByArtist(text); 
                        break;
                    case '4':
                        _employeeServices.AddNewAlbum(); 
                        break;
                    case '5':
                        Console.WriteLine("Saved!");
                        _repo.Save();
                        break;
                    case '6':
                        Console.WriteLine("Thanks for using our services!");
                        return;
                        
                    case '7':
                        _repo.Save();
                        Console.WriteLine("Everything has been saved! Thanks for using our services!");
                        return;
                    default:
                        Console.Write("Invalid input try again!");
                        continue;     
                }
            }
        }
    }

}
