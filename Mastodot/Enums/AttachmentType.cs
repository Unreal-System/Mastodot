﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mastodot.Enums
{
	// https://stackoverflow.com/questions/18551452/deserialize-json-character-as-enumeration
	[JsonConverter(typeof(StringEnumConverter))]
    public enum AttachmentType
    {
        [EnumMember(Value = "image")]
        Image,
        [EnumMember(Value = "video")]
        Video,
        [EnumMember(Value = "gifv")]
        GifVideo,
        [EnumMember(Value = "audio")]
        Audio,
        [EnumMember(Value = "unknown")]
        Unknown
    }
}
