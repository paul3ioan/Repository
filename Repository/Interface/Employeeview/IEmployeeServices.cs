namespace Repository.Interface.Employeeview
{
    public interface IEmployeeServices
    {
        public void ShowAllItems();
        public void ShowAvailableItems();
        public void ShowItemsByArtist(string name);
        public void AddNewAlbum();
    }
}
