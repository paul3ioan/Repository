using System;
namespace Repository.Interface.Employeeview
{
    public class AddNewAlbum
    {
        protected Album AddAlbum()
        {
            Album newAlbum = new();
            Console.WriteLine("Enter the name of the album:");
            newAlbum.Name = Console.ReadLine();

            Console.WriteLine("Enter the name of the artist:");
            newAlbum.ArtistName = Console.ReadLine();

            Console.WriteLine("Enter the genre of the album:");
            newAlbum.Genre = Console.ReadLine();
            newAlbum.Valid = true;
            Console.WriteLine("Enter the number of sales for the album:");
            try
            {
                newAlbum.Sales = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Input is invalid please try again!");
                return null;
            }
            Console.WriteLine("Enter the year of the album:");
            try
            {
                newAlbum.Year = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Input is invalid please try again!");
                return null;
            }
            Console.WriteLine("Record Label:");
            newAlbum.RecordLabel = Console.ReadLine();

            return newAlbum;
        }
    }
    
}
