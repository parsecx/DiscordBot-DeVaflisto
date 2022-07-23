using Newtonsoft.Json;


namespace AdminBot
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get; private set; }

        [JsonProperty("data")]
        public string Data { get; private set; }

        [JsonProperty("vocab")]
        public List<Vocab> Words {get; set;}
    }
    public struct Vocab
    {
        public string Word { get; set;}
    }
}
