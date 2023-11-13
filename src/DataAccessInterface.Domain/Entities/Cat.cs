namespace DataAccessInterface.Domain.Entities
{
    public class Cat
    {
        public int CatId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string FavouriteFood { get; set; }
        public string HairColour { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
