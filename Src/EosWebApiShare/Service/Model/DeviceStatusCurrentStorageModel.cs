﻿namespace EosWebApi.Service.Model;

internal class DeviceStatusCurrentStorage
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}
