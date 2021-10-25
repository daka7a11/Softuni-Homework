namespace CarDealer.Datasets.DTO.Cars
{
    public class ImportCarDTO
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; }
        public int[] PartsId { get; set; }
    }
}
