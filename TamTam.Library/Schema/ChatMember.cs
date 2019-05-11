using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class ChatMember
    {
        /// <summary>
        /// Users identifier.
        /// </summary>
        [JsonProperty(PropertyName = "user_id", Required = Required.Always)]
        public long UserId { get; set; }

        /// <summary>
        /// Users visible name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Unique public user name.
        /// Can be null if user is not accessible or it is not set.
        /// </summary>
        [JsonProperty(PropertyName = "username", Required = Required.AllowNull)]
        public string UserName { get; set; }

        /// <summary>
        /// URL of avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// URL of avatar of a bigger size.
        /// </summary>
        [JsonProperty(PropertyName = "full_avatar_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string FullAvatarUrl { get; set; }

        [JsonProperty(PropertyName = "last_access_time", Required = Required.Always)]
        public long LastAccessTime { get; set; }

        [JsonProperty(PropertyName = "is_owner", Required = Required.Always)]
        public bool IsOwner { get; set; }

        [JsonProperty(PropertyName = "is_admin", Required = Required.Always)]
        public bool IsAdmin { get; set; }

        [JsonProperty(PropertyName = "join_time", Required = Required.Always)]
        public long JoinTime { get; set; }

        /// <summary>
        /// Permissions in chat if member is admin. null otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "permissions", Required = Required.AllowNull)]
        public ChatAdminPermission Permissions { get; set; }
    }
}
