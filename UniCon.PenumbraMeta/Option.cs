using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using UniCon.PenumbraMeta.Conditions;
using UniCon.PenumbraMeta.Manipulations;

namespace UniCon.PenumbraMeta;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OptionLayoutOptions
{
    Hide,
    Separator,
    HideOptionLabel,
    Space,
}

public interface IOption
{
    /// <summary>
    /// Name of the option.
    /// </summary>
    string Name { get; set; }
    /// <summary>
    /// Description of the option.
    /// </summary>
    string? Description { get; set; }
    /// <summary>
    /// Priority of the option. If several enabled options within the group define conflicting files or manipulations, the highest priority wins.
    /// </summary>
    int Priority { get; set; }
    /// <summary>
    /// Unused by Penumbra.
    /// </summary>
    string? Image { get; set; }
    /// <summary>
    /// A unique identifier to reference this option within this mod.
    /// </summary>
    Guid Id { get; set; }
    /// <summary>
    /// Additional flags to control this options layout behaviour when drawn.
    /// </summary>
    List<OptionLayoutOptions>? Layout { get; set; }
    /// <summary>
    /// Conditions on the full settings of this mod to control whether this option is visible and applied.
    /// </summary>
    Condition? Condition { get; set; }
    /// <summary>
    /// A color to use for the label of this option, mapped to 8 user-customizable colors. 0 means normal text color.
    /// </summary>
    int Color { get; set; }
}

public record class Option(string Name, string? Description, int Priority, string? Image, Guid Id, List<OptionLayoutOptions>? Layout, Condition? Condition, int Color)
    : IOption
{
    public string Name { get; set; } = Name;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; } = Description;
    public int Priority { get; set; } = Priority;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; } = Image;
    public Guid Id { get; set; } = Id;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<OptionLayoutOptions>? Layout { get; set; } = Layout;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Condition? Condition { get; set; } = Condition;
    public int Color { get; set; } = Color;
}

public record class ContainerOption(string Name, string? Description, int Priority, string? Image, Guid Id, List<OptionLayoutOptions>? Layout, Condition? Condition, int Color,
    Dictionary<string, string>? Files, Dictionary<string, string>? FileSwaps, List<Manipulation>? Manipulations)
    : IOption, IContainer
{
    #region IOption
    public string Name { get; set; } = Name;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; } = Description;
    public int Priority { get; set; } = Priority;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; } = Image;
    public Guid Id { get; set; } = Id;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<OptionLayoutOptions>? Layout { get; set; } = Layout;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Condition? Condition { get; set; } = Condition;
    public int Color { get; set; } = Color;
    #endregion

    #region IContainer
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Files { get; set; } = Files;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? FileSwaps { get; set; } = FileSwaps;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Manipulation>? Manipulations { get; set; } = Manipulations;
    #endregion
}
