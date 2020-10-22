using System;

namespace TaxComputationAPI.Helpers
{
    public static class StaticDetails
    {
        public const string SystemAdmin = "SystemAdmin";
        public const string User = "User";

        public static string GenerateToken()
        {
            Random random = new Random();
            return random.Next(0, 9999).ToString("D4");
        }

    }
}