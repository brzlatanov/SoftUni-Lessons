using System.Reflection.Metadata.Ecma335;

namespace PetStore.Common
{
    public static class ProductValidationConstants
    {
        public const int NAME_MAX_LENGTH = 75;

        public const int DESCRIPTION_MAX_LENGTH = 1000;

        public const int DISTRIBUTOR_NAME_MAX_LENGTH = 100;
        public const int URL_MAX_LENGTH = 2048;
    }
}