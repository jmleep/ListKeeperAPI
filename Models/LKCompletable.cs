using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ListKeeperAPI.Models
{
    public abstract class LKCompletable
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Color")]
        public string Color { get; set; } = "#000000";

        [JsonPropertyName("IsComplete")]
        public bool IsComplete { get; set; } = false;

        [JsonPropertyName("DateCreated")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}