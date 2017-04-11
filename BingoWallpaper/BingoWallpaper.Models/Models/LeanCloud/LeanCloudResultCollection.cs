using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            return Results.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Results.GetEnumerator();
        }
    }
}