using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using UniCon.PenumbraMeta.Groups;

namespace UniCon.PenumbraMeta;

/// <summary>
/// Base class for all versions of Penumbra mod metadata.
/// </summary>
/// <param name="Name">Name of the mod.</param>
/// <param name="Author">Author of the mod.</param>
/// <param name="Description">Description of the mod. Can span multiple paragraphs.</param>
/// <param name="Image">Relative path to a preview image for the mod. Unused by Penumbra, present for round-trip import/export of TexTools-generated mods.</param>
/// <param name="Version">Version of the mod. Can be an arbitrary string.</param>
/// <param name="Website">URL of the web page of the mod.</param>
/// <param name="ModTags">Author-defined tags for the mod.</param>
/// <param name="DefaultPreferredItems">Item IDs must be unique.</param>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "FileVersion")]
[JsonDerivedType(typeof(PenumbraModMetaV3), typeDiscriminator: 3)]
[JsonDerivedType(typeof(PenumbraModMetaV4), typeDiscriminator: 4)]
public record class PenumbraModMeta(string Name, string? Author, string? Description, string? Image, string? Version, string? Website, List<string>? ModTags, List<int>? DefaultPreferredItems)
{
    public static readonly JsonSerializerOptions SerializerOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        WriteIndented = true,
    };

    /// <summary>
    /// Name of the mod.
    /// </summary>
    /// <remarks>
    /// Cannot be empty.
    /// </remarks>
    public string Name
    {
        get => field;
        set
        {
            if (value.Length < 1)
            {
                throw new ArgumentException("Name cannot be empty.", nameof(value));
            }

            field = value;
        }
    } = Name;

    /// <summary>
    /// Author of the mod.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Author { get; set; } = Author;

    /// <summary>
    /// Description of the mod. Can span multiple paragraphs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; } = Description;

    /// <summary>
    /// Relative path to a preview image for the mod. Unused by Penumbra, present for round-trip import/export of TexTools-generated mods.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; } = Image;

    /// <summary>
    /// Version of the mod. Can be an arbitrary string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Version { get; set; } = Version;

    /// <summary>
    /// URL of the web page of the mod.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Website { get; set; } = Website;

    /// <summary>
    /// Author-defined tags for the mod.
    /// </summary>
    /// <remarks>
    /// Tags must be unique and at least one character long.
    /// </remarks>
    public List<string>? ModTags { get; set; } = ModTags;

    /// <summary>
    /// Default preferred items to list as the main item of a group managed by the mod creator.
    /// </summary>
    /// <remarks>
    /// Item IDs must be unique.
    /// </remarks>
    public List<int>? DefaultPreferredItems { get; set; } = DefaultPreferredItems;

    public static ValueTask<PenumbraModMeta?> FromStreamAsync(Stream stream)
    {
        return JsonSerializer.DeserializeAsync<PenumbraModMeta>(stream, SerializerOptions);
    }

    public Task SerializeToStreamAsync(Stream stream)
    {
        return JsonSerializer.SerializeAsync(stream, this, SerializerOptions);
    }
}

/// <summary>
/// Version 3 of Penumbra mod metadata.
/// </summary>
/// <param name="Name">Name of the mod.</param>
/// <param name="Author">Author of the mod.</param>
/// <param name="Description">Description of the mod. Can span multiple paragraphs.</param>
/// <param name="Image">Relative path to a preview image for the mod. Unused by Penumbra, present for round-trip import/export of TexTools-generated mods.</param>
/// <param name="Version">Version of the mod. Can be an arbitrary string.</param>
/// <param name="Website">URL of the web page of the mod.</param>
/// <param name="ModTags">Author-defined tags for the mod.</param>
/// <param name="DefaultPreferredItems">Item IDs must be unique.</param>
/// <param name="RequiredFeatures">A list of required features by name.</param>
public record class PenumbraModMetaV3(string Name, string? Author, string? Description, string? Image, string? Version, string? Website, List<string>? ModTags, List<int>? DefaultPreferredItems, List<string>? RequiredFeatures)
    : PenumbraModMeta(Name, Author, Description, Image, Version, Website, ModTags, DefaultPreferredItems)
{
    /// <summary>
    /// A list of required features by name.
    /// </summary>
    /// <remarks>
    /// Feature names must be unique.
    /// </remarks>
    public List<string>? RequiredFeatures { get; set; } = RequiredFeatures;
}

/// <summary>
/// Version 4 of Penumbra mod metadata.
/// </summary>
/// <param name="Name">Name of the mod.</param>
/// <param name="Author">Author of the mod.</param>
/// <param name="Description">Description of the mod. Can span multiple paragraphs.</param>
/// <param name="Image">Relative path to a preview image for the mod. Unused by Penumbra, present for round-trip import/export of TexTools-generated mods.</param>
/// <param name="Version">Version of the mod. Can be an arbitrary string.</param>
/// <param name="Website">URL of the web page of the mod.</param>
/// <param name="ModTags">Author-defined tags for the mod.</param>
/// <param name="DefaultPreferredItems">Item IDs must be unique.</param>
/// <param name="Identifier">A stable GUID for this mod. Currently not used.</param>
/// <param name="LastWrite">The UTC time when this file was written by Penumbra.</param>
/// <param name="RequiredFeatures">A list of required features by name.</param>
/// <param name="DefaultData">The default redirections, file swaps and meta edits applied by this mod when enabled.</param>
/// <param name="Groups">All option groups this mod contains.</param>
/// <param name="PageNames">Optional names for pages referenced in the option groups, represented as a dictionary from int to string.</param>
public record class PenumbraModMetaV4(string Name, string? Author, string? Description, string? Image, string? Version, string? Website, List<string>? ModTags, List<int>? DefaultPreferredItems,
    Guid? Identifier, DateTimeOffset? LastWrite, List<PenumbraModFeature>? RequiredFeatures, Container? DefaultData, List<Group>? Groups, Dictionary<int, string?>? PageNames)
    : PenumbraModMeta(Name, Author, Description, Image, Version, Website, ModTags, DefaultPreferredItems)
{
    /// <summary>
    /// A stable GUID for this mod. Currently not used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? Identifier { get; set; } = Identifier;

    /// <summary>
    /// The UTC time when this file was written by Penumbra.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? LastWrite { get; set; } = LastWrite;

    /// <summary>
    /// A list of required features by name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PenumbraModFeature>? RequiredFeatures { get; set; } = RequiredFeatures;

    /// <summary>
    /// The default redirections, file swaps and meta edits applied by this mod when enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Container? DefaultData { get; set; } = DefaultData;

    /// <summary>
    /// All option groups this mod contains.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Group>? Groups { get; set; } = Groups;

    /// <summary>
    /// Optional names for pages referenced in the option groups, represented as a dictionary from int to string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<int, string?>? PageNames { get; set; } = PageNames;
}
