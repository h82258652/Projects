using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BingoWallpaper.Models.LeanCloud
{
    [JsonObject]
    public class LeanCloudResultCollection<T> : LeanCloudResultBase, IEnumerable<T> where T : AVObject
    {
        [JsonProperty("results")]
        public T[] Results
        {
            get;
            set;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Results).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}