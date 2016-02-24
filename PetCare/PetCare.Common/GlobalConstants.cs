namespace PetCare.Common
{
    public static class GlobalConstants
    {
        public static readonly char[] Delimiters = { ' ', ',', '\n', '\r' };

        public const int VetHoursPerDay = 18;

        public const int BusyHoursPerPage = 10;

        public const string VetVisitNotificationInThreeDays = "Your pet {0} has a scheduled vet visit to Dr. {1} {2}.";

        public const string AdministratorRoleName = "admin";

        public const string VetRoleName = "vet";
    }
}
