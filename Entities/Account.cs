using System;
using Newtonsoft.Json;

namespace Mastodot.Entities
{
    public class Account : BaseMastodonEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("acct")]
        public string FullUserName { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("followers_count")]
        public long FollowersCount { get; set; }

        [JsonProperty("following_count")]
        public long FollowingCount { get; set; }

        [JsonProperty("statuses_count")]
        public long StatusesCount { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("avatar_static")]
        public string StaticAvatar { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("header_static")]
        public string StaticHeader { get; set; }
    }
}
