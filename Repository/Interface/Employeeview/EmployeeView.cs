using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                  " available albmus\n [3] show albmus by your favourite artist\n [4] addNewAlbum\n [5] exit");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1': _employeeServices.ShowAllItems(); break;
                    case '2': _employeeServices.ShowAvailableItems(); break;
                    case '3':
                        Console.WriteLine("Write the name of your favourite artist:\n");
                        var text = Console.ReadLine();
                        _employeeServices.ShowItemsByArtist(text); break;
                    case '4':
                        _employeeServices.AddNewItem(); break;
                    case '5':
                        Console.WriteLine("Thanks for using our services!");
                        _repo.Save();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Invalid input try again!");
                        continue;
                        break;
                }



            }
        }
    }

}
