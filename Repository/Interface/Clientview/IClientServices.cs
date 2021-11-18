namespace Repository.Interface.Clientview
{
    public interface IClientServices
    {
        public void ShowAllItems();
        public void ShowAvailableItems();
        public void ShowItemsByArtist(string nameOfArtist);
    }
}
