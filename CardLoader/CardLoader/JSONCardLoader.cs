using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLoader
{
    public class JSONCardLoader
    {
        private string _sourceFilePath;
        private bool _strict;

        public JSONCardLoader(string sourceFilePath, bool strictDeserialization = false)
        {
            this._sourceFilePath = sourceFilePath;
            this._strict = strictDeserialization;
        }

        public IList<JSONCard> LoadCards()
        {
            Dictionary<string, List<JSONCard>> deserilised;
            using (var file = File.OpenText(_sourceFilePath))
            {
                JsonSerializer serializer = _strict ?
                    JsonSerializer.Create(new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Error}) :
                    JsonSerializer.Create();

                deserilised = (Dictionary<string, List<JSONCard>>)serializer.Deserialize(file, typeof(Dictionary<string, List<JSONCard>>));
            }

            foreach(var kvp in deserilised)
            {
                kvp.Value.ForEach(c => c.Set = kvp.Key);
            }
            
            return deserilised.SelectMany(kvp => kvp.Value).ToList();
        }
    }
}
