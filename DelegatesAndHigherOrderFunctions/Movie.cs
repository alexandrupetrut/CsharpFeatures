namespace DelegatesAndHigherOrderFunctions
{
    internal class Movie
    {
        public string Title;
        public string Picture;
        public string Category;
        public int Year;

        public Movie(string Title, string Picture, string Category, int Year)
        {
            this.Title = Title;
            this.Picture = Picture;
            this.Category = Category;
            this.Year = Year;
        }
    }
}