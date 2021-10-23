using Newtonsoft.Json;

namespace ProductShop.Datasets.DTO.User
{
    public class ImportUserDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
