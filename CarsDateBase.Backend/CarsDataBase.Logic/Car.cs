namespace CarsDataBase.Logic
{
    public class Car
    {
        public int Id { get; set; }
        public string Firm { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }

        // Внешний ключ
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
