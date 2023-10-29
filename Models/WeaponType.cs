using System.Text.Json.Serialization;

namespace rpg.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WeaponType
    {
        Sword = 1,
        Bow=2,
        Axe=3
    }
}