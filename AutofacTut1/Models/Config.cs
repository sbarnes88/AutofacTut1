using System;
using System.Threading;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;

namespace AutofacTut1.Models
{
    public class Config
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("uuid")]
        public int Uuid { get; set; }
        public DateTimeOffset InitializeDate { get; }

        public Config()
        {
            InitializeDate = DateTimeOffset.Now;
            Thread.Sleep(1234);
        }

        public static Config Initialize(string file)
        {
            if(File.Exists(file))
            {
                var config = JsonSerializer.Deserialize<Config>(File.ReadAllText(file));
                return config;
            }
            return new Config();
        }
    }
}
