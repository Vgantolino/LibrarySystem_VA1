using LibrarySystem_VA.Debugging;

namespace LibrarySystem_VA
{
    public class LibrarySystem_VAConsts
    {
        public const string LocalizationSourceName = "LibrarySystem_VA";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "4ee78be6f5fa4f6793d69c1165ee1c10";
    }
}
