using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using UniCon.PenumbraMeta.Manipulations;

namespace UniCon.PenumbraMeta;

public interface IContainer
{
    /// <summary>
    /// File redirections in this container.
    /// </summary>
    /// <remarks>
    /// Keys are game paths, values are relative file paths.
    /// </remarks>
    Dictionary<string, string>? Files { get; set; }
    /// <summary>
    /// File swaps in this container.
    /// </summary>
    /// <remarks>
    /// Keys are original game paths, values are actual game paths.
    /// </remarks>
    Dictionary<string, string>? FileSwaps { get; set; }

    List<Manipulation>? Manipulations { get; set; }
}

public record class Container(Dictionary<string, string>? Files, Dictionary<string, string>? FileSwaps, List<Manipulation> Manipulations) : IContainer
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Files { get; set; } = Files;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? FileSwaps { get; set; } = FileSwaps;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Manipulation>? Manipulations { get; set; } = Manipulations;
}

public record class NamedContainer(Dictionary<string, string>? Files, Dictionary<string, string>? FileSwaps, List<Manipulation> Manipulations, string? Name)
    : Container(Files, FileSwaps, Manipulations)
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; } = Name;
}
