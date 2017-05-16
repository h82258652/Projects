using VGtime.Models;

namespace VGtime.Uwp.ViewParameters
{
    public class AblumDetailViewParameter
    {
        public AblumDetailViewParameter(Ablum[] ablums, int index)
        {
            Ablums = ablums;
            Index = index;
        }

        public Ablum[] Ablums
        {
            get;
        }

        public int Index
        {
            get;
        }
    }
}