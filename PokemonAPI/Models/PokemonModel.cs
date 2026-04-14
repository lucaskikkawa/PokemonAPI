using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PokemonAPI.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public bool IsDefault { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        public List<PokemonAbility> Abilities { get; set; } = [];
        public List<NamedAPIResource> Forms { get; set; } = [];
        public List<VersionGameIndex> GameIndices { get; set; } = [];
        public List<PokemonHeldItem> HeldItems { get; set; } = [];
        public string LocationAreaEncounters { get; set; } = string.Empty;
        public List<PokemonMove> Moves { get; set; } = [];
        public List<PokemonTypePast> PastTypes { get; set; } = [];
        public PokemonSprites? Sprites { get; set; }
        public PokemonCries? Cries { get; set; }
        public NamedAPIResource? Species { get; set; }
        public List<PokemonStat> Stats { get; set; } = [];
        public List<PokemonType> Types { get; set; } = [];
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonAbility
    {
        public NamedAPIResource? Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class NamedAPIResource
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class VersionGameIndex
    {
        public int GameIndex { get; set; }
        public NamedAPIResource? Version { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonHeldItem
    {
        public NamedAPIResource? Item { get; set; }
        public List<PokemonHeldItemVersion> VersionDetails { get; set; } = [];
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonHeldItemVersion
    {
        public int Rarity { get; set; }
        public NamedAPIResource? Version { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonMove
    {
        public NamedAPIResource? Move { get; set; }
        public List<PokemonMoveVersion> VersionGroupDetails { get; set; } = [];
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonMoveVersion
    {
        public int LevelLearnedAt { get; set; }
        public NamedAPIResource? MoveLearnMethod { get; set; }
        public int? Order { get; set; }
        public NamedAPIResource? VersionGroup { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonTypePast
    {
        public NamedAPIResource? Generation { get; set; }
        public List<PokemonType> Types { get; set; } = [];
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonSprites
    {
        public string? BackDefault { get; set; }
        public string? BackFemale { get; set; }
        public string? BackShiny { get; set; }
        public string? BackShinyFemale { get; set; }
        public string? FrontDefault { get; set; }
        public string? FrontFemale { get; set; }
        public string? FrontShiny { get; set; }
        public string? FrontShinyFemale { get; set; }
        public Dictionary<string, PokemonSpritesSet> Other { get; set; } = [];
        public Dictionary<string, Dictionary<string, PokemonSpritesSet>> Versions { get; set; } = [];
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonSpritesSet
    {
        public string? BackDefault { get; set; }
        public string? BackFemale { get; set; }
        public string? BackShiny { get; set; }
        public string? BackShinyFemale { get; set; }
        public string? BackGray { get; set; }
        public string? BackTransparent { get; set; }
        public string? BackShinyTransparent { get; set; }
        public string? FrontDefault { get; set; }
        public string? FrontFemale { get; set; }
        public string? FrontShiny { get; set; }
        public string? FrontShinyFemale { get; set; }
        public string? FrontGray { get; set; }
        public string? FrontTransparent { get; set; }
        public string? FrontShinyTransparent { get; set; }
        public PokemonSpritesSet? Animated { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonCries
    {
        public string? Latest { get; set; }
        public string? Legacy { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonStat
    {
        public int BaseStat { get; set; }
        public int Effort { get; set; }
        public NamedAPIResource? Stat { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class PokemonType
    {
        public int Slot { get; set; }
        public NamedAPIResource? Type { get; set; }
    }
}
