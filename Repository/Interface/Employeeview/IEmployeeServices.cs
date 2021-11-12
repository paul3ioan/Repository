using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Employeeview
{
    public interface IEmployeeServices
    {
        public void ShowAllItems();
        public void ShowAvailableItems();
        public void ShowItemsByArtist(string name);
        public void AddNewItem();
    }
}
