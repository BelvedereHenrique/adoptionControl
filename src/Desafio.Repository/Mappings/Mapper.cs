namespace Desafio.Repository.Mappings
{
    internal static class Mapper
    {
        public static AnimalMapping Animal
        {
            get
            {
                return new AnimalMapping();
            }
        }

        public static AdopterMapping Adopter
        {
            get
            {
                return new AdopterMapping();
            }
        }


    }
}
