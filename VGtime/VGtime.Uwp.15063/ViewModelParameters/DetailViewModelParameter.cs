using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGtime.Uwp.ViewModelParameters
{
    public class DetailViewModelParameter
    {
        public DetailViewModelParameter(int postId, int detailType)
        {
            PostId = postId;
            DetailType = detailType;
        }

        public int PostId
        {
            get;
        }

        public int DetailType
        {
            get;
        }
    }
}