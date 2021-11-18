using System;
using Repository.Interface.Clientview;
using Repository.Interface.Employeeview;
namespace Repository.Interface
{
    public class MainView
    {
        private readonly IAlbumRepo _repo;
        private readonly IEmployeeView _employeeView;
        private readonly IClientView _clientView;
        private const string EmployeePassword = "paul";
        public MainView(IAlbumRepo repo)
        {
            _repo = repo;
            _clientView = new ClientView(_repo);
            _employeeView = new EmployeeView(_repo);
        }
        private void ShowMain()
        {
            Console.WriteLine("Please select who are you: ");
            Console.WriteLine("[1] employee\n[2] client\n[3] exit\n");
        }
        public void Start()
        {
            Console.WriteLine("Data have been stored");
            bool isLoop = true;
            while (isLoop)
            {
                ShowMain();
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Please enter the password:\n");
                        var password = Console.ReadLine();
                        if (CheckPassword(password))
                        {
                            _employeeView.Start();
                        }
                        else
                        {
                            ShowMain();
                        }
                        break;
                    case '2':
                        _clientView.Start();
                        break;
                    case '3':
                        CloseProgram();
                        break;
                    default:
                        Console.WriteLine("Input is invalid please try again!");
                        continue;
                }
            }
        }
        private bool CheckPassword(string password)
        {
            return password == EmployeePassword;
        }
        private void CloseProgram()
        {
            _repo.Save();
            Console.WriteLine("Thank you for using our services!");
            Environment.Exit(0);
        }
    }
}
