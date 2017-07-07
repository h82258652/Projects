namespace SoftwareKobo.Extensions
{
    public struct HttpProgress
    {
        public ulong BytesReceived
        {
            get;
            set;
        }

        public ulong? TotalBytesToReceive
        {
            get;
            set;
        }
    }
}