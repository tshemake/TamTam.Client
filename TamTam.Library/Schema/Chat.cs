using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTam.Bot.Schema
{
    public class Chat
    {
        /// <summary>
        /// Chats identifier.
        /// </summary>
        [JsonProperty(PropertyName = "chat_id", Required = Required.Always)]
        public long ChatId { get; set; }

        /// <summary>
        /// Type of chat.
        /// One of:
        /// <list type="bullet">
        /// <item>
        /// <term>dialog</term>  
        /// </item>
        /// <item>
        /// <term>chat</term>  
        /// </item>
        /// <item>
        /// <term>channel</term>  
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public ChatType ChatType { get; set; }

        /// <summary>
        /// Chat status.
        /// One of:
        /// <list type="bullet">
        /// <item>
        /// <term>active</term>  
        /// <description>Bot is active member of chat.</description>
        /// </item>
        /// <item>
        /// <term>removed</term>  
        /// <description>Bot was kicked.</description>
        /// </item>
        /// <item>
        /// <term>left</term>  
        /// <description>Bot intentionally left chat.</description>
        /// </item>
        /// <item>
        /// <term>closed</term>  
        /// <description>Bhat was closed.</description>
        /// </item>
        /// <item>
        /// <term>suspended</term>  
        /// <description></description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public ChatStatus ChatStatus { get; set; }

        /// <summary>
        /// Visible title of chat.
        /// Can be null for <see cref="ChatType.Dialog"/> chat type.
        /// </summary>
        [JsonProperty(PropertyName = "title", Required = Required.AllowNull)]
        public string Title { get; set; }

        /// <summary>
        /// Icon of chat.
        /// </summary>
        [JsonProperty(PropertyName = "icon", Required = Required.Always)]
        public ChatIcon Icon { get; set; }

        /// <summary>
        /// Time of last event occured in chat.
        /// </summary>
        [JsonProperty(PropertyName = "last_event_time", Required = Required.Always)]
        public long LastEventTime { get; set; }

        /// <summary>
        /// Number of people in chat.
        /// Always 2 for <see cref="ChatType.Dialog"/> chat type.
        /// </summary>
        [JsonProperty(PropertyName = "participants_count", Required = Required.Always)]
        public int ParticipantsCount { get; set; }

        /// <summary>
        /// Identifier of chat owner.
        /// Visible only for chat admins.
        /// </summary>
        [JsonProperty(PropertyName = "owner_id", NullValueHandling = NullValueHandling.Ignore)]
        public long OwnerId { get; set; }

        /// <summary>
        /// Participants in chat with time of last activity.
        /// Can be null when you request list of chats. 
        /// Visible for chat admins only.
        /// </summary>
        [JsonProperty(PropertyName = "participants", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IReadOnlyDictionary<string, long> Participants { get; set; }

        /// <summary>
        /// Is current chat publicly available.
        /// Always false for dialogs.
        /// </summary>
        [JsonProperty(PropertyName = "is_public", Required = Required.Always)]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Link on chat if it is public.
        /// </summary>
        [JsonProperty(PropertyName = "link", NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }

        /// <summary>
        /// Chat description.
        /// </summary>
        [JsonProperty(PropertyName = "description", Required = Required.Always)]
        public ChatDescription ChatDescription { get; set; }
    }
}
