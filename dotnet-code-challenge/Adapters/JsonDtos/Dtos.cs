using System;
using Newtonsoft.Json;

namespace dotnet_code_challenge.Adapters.JsonDtos
{

    public partial class Root
    {
        [JsonProperty("FixtureId")]
        public string FixtureId { get; set; }

        [JsonProperty("Timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("RawData")]
        public RawData RawData { get; set; }
    }

    public partial class RawData
    {
        [JsonProperty("FixtureName")]
        public string FixtureName { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("StartTime")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("Sequence")]
        public long Sequence { get; set; }

        [JsonProperty("Tags")]
        public RawDataTags Tags { get; set; }

        [JsonProperty("Markets")]
        public Market[] Markets { get; set; }

        [JsonProperty("Participants")]
        public Participant[] Participants { get; set; }
    }

    public partial class Market
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Selections")]
        public Selection[] Selections { get; set; }

        [JsonProperty("Tags")]
        public MarketTags Tags { get; set; }
    }

    public partial class Selection
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("Tags")]
        public SelectionTags Tags { get; set; }
    }

    public partial class SelectionTags
    {
        [JsonProperty("participant")]
        public long Participant { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class MarketTags
    {
        [JsonProperty("Places")]
        public long Places { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Participant
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Tags")]
        public ParticipantTags Tags { get; set; }
    }

    public partial class ParticipantTags
    {
        [JsonProperty("Weight")]
        public string Weight { get; set; }

        [JsonProperty("Drawn")]
        
        public long Drawn { get; set; }

        [JsonProperty("Jockey")]
        public string Jockey { get; set; }

        [JsonProperty("Number")]
        
        public long Number { get; set; }

        [JsonProperty("Trainer")]
        public string Trainer { get; set; }
    }

    public partial class RawDataTags
    {
        [JsonProperty("CourseType")]
        public string CourseType { get; set; }

        [JsonProperty("Distance")]
        public string Distance { get; set; }

        [JsonProperty("Going")]
        public string Going { get; set; }

        [JsonProperty("Runners")]
        
        public long Runners { get; set; }

        [JsonProperty("MeetingCode")]
        
        public long MeetingCode { get; set; }

        [JsonProperty("TrackCode")]
        public string TrackCode { get; set; }

        [JsonProperty("Sport")]
        public string Sport { get; set; }
    }
}
