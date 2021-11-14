namespace PetStore.Common
{
    public static class GlobalConstants
    {
        //Breed, Food, Toy, Food, Manufacturer
        public const int NameMinLength = 2;
        public const int NameMaxLength = 30;

        //Food
        public const int FoodMinKg = 0;

        //Pet
        public const int PetMinAge = 0;
        public const int PetMaxAge = 200;
        public const int PetMinPrice = 0;

        //Client
        public const int ClientNameMinLength = 4;
        public const int ClientNameMaxLength = 50;
        public const int ClientPasswordMinLength = 6;
        public const int ClientMinAge = 0;
        public const int ClientMaxAge = 120;

        //Product
        public const int ProductMinPrice = 0;

        //Order
        public const int OrderMinQuantity = 1;
    }
}
