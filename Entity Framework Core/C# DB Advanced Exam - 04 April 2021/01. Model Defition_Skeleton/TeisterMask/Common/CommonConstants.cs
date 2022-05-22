namespace TeisterMask.Common
{
    public static class CommonConstants
    {
        public const int USERNAME_MIN_LENGTH = 3;
        public const int USERNAME_MAX_LENGTH = 40;
        public const int PROJECT_NAME_MIN_LENGTH = 2;
        public const int PROJECT_NAME_MAX_LENGTH = 40;
        public const int TASK_NAME_MIN_LENGTH = 2;
        public const int TASK_NAME_MAX_LENGTH = 40;

        public const string USERNAME_VALIDATION_REGEX = "^[A-Za-z0-9]{3,}$";
        public const string PHONE_VALIDATION_REGEX = @"^\d{3}-\d{3}-\d{4}$";
    }
}