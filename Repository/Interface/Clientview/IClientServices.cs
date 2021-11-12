using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface.Clientview
{
    public interface IClientServices
    {
        public void ShowAllItems();
        public void ShowAvailableItems();
        public void ShowItemsByArtist(string nameOfArtist);
    }
}
