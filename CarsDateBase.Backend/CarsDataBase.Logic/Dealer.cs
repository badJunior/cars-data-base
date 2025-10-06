namespace CarsDataBase.Logic
{
    public class Dealer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public double Rating { get; set; }

        // Навигационное свойство
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
