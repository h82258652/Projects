using System.Runtime.InteropServices;

namespace VGtime.Utils
{
    public static class UserAgentHelper
    {
        private const int URLMON_OPTION_USERAGENT = 0x10000001;

        public static void SetDefaultUserAgent(string userAgent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, userAgent, userAgent.Length, 0);
        }

        [DllImport("urlmon.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
    }
}