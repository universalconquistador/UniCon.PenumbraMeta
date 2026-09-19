using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UniCon.PenumbraMeta;

/// <summary>
/// Equip Slot, mostly as defined by the games EquipSlotCategory.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.GameData.Enums.EquipSlot</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EquipSlot : byte
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// Primary Weapon
    /// </summary>
    MainHand = 1,
    /// <summary>
    /// Secondary Weapon
    /// </summary>
    OffHand = 2,
    /// <summary>
    /// Head
    /// </summary>
    Head = 3,
    /// <summary>
    /// Body
    /// </summary>
    Body = 4,
    /// <summary>
    /// Hands
    /// </summary>
    Hands = 5,
    /// <summary>
    /// Belt
    /// </summary>
    Belt = 6,
    /// <summary>
    /// Legs
    /// </summary>
    Legs = 7,
    /// <summary>
    /// Feet
    /// </summary>
    Feet = 8,
    /// <summary>
    /// Earrings
    /// </summary>
    Ears = 9,
    /// <summary>
    /// Necklace
    /// </summary>
    Neck = 10,
    /// <summary>
    /// Bracelets
    /// </summary>
    Wrists = 11,
    /// <summary>
    /// Right Ring
    /// </summary>
    RFinger = 12,
    /// <summary>
    /// Primary Weapon
    /// </summary>
    BothHand = 13,
    /// <summary>
    /// Left Ring
    /// </summary>
    /// <remarks>
    /// Not officially existing, means "weapon could be equipped in either hand" for the game.
    /// </remarks>
    LFinger = 14,
    /// <summary>
    /// Head and Body
    /// </summary>
    HeadBody = 15,
    /// <summary>
    /// Costume
    /// </summary>
    BodyHandsLegsFeet = 16,
    /// <summary>
    /// Soul Crystal
    /// </summary>
    SoulCrystal = 17,
    /// <summary>
    /// Bottom
    /// </summary>
    LegsFeet = 18,
    /// <summary>
    /// Costume
    /// </summary>
    FullBody = 19,
    /// <summary>
    /// Top
    /// </summary>
    BodyHands = 20,
    /// <summary>
    /// Costume
    /// </summary>
    BodyLegsFeet = 21,
    /// <summary>
    /// Top
    /// </summary>
    ChestHands = 22,
    /// <summary>
    /// Costume
    /// </summary>
    ChestLegs = 23, // NOT IN SCHEMA
    /// <summary>
    /// Unknown
    /// </summary>
    Nothing = 24,
    /// <summary>
    /// Costume
    /// </summary>
    /// <remarks>
    /// Not officially existing.
    /// </remarks>
    All = 25,
}

/// <summary>
/// The available Equip Slots on a Human.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.GameData.Enums.HumanSlot</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HumanSlot : uint
{
    /// <summary>
    /// Head
    /// </summary>
    Head = 0,
    /// <summary>
    /// Body
    /// </summary>
    Body = 1,
    /// <summary>
    /// Hands
    /// </summary>
    Hands = 2,
    /// <summary>
    /// Legs
    /// </summary>
    Legs = 3,
    /// <summary>
    /// Feet
    /// </summary>
    Feet = 4,
    /// <summary>
    /// Earrings
    /// </summary>
    Ears = 5,
    /// <summary>
    /// Necklace
    /// </summary>
    Neck = 6,
    /// <summary>
    /// Bracelets
    /// </summary>
    Wrists = 7,
    /// <summary>
    /// Right Ring
    /// </summary>
    RFinger = 8,
    /// <summary>
    /// Left Ring
    /// </summary>
    LFinger = 9,
    /// <summary>
    /// Hair
    /// </summary>
    Hair = 10,
    /// <summary>
    /// Face
    /// </summary>
    Face = 11,
    /// <summary>
    /// Ears
    /// </summary>
    Ear = 12,
    /// <summary>
    /// Glasses
    /// </summary>
    Glasses = 16,
    /// <summary>
    /// Unknown Bonus
    /// </summary>
    UnkBonus = 17, // NOT IN SCHEMA
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = uint.MaxValue,
}

/// <summary>
/// Available character genders.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.GameData.Enums.Gender</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender : byte
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,
    /// <summary>
    /// Male
    /// </summary>
    Male,
    /// <summary>
    /// Female
    /// </summary>
    Female,
    /// <summary>
    /// Male (Child)
    /// </summary>
    MaleNpc,
    /// <summary>
    /// Female (Child)
    /// </summary>
    FemaleNpc,
}

/// <summary>
/// Available model races, which includes Highlanders as a separate model base to Midlanders.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.GameData.Enums.ModelRace</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ModelRace : byte
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,
    /// <summary>
    /// Midlander
    /// </summary>
    Midlander,
    /// <summary>
    /// Highlander
    /// </summary>
    Highlander,
    /// <summary>
    /// Elezen
    /// </summary>
    Elezen,
    /// <summary>
    /// Lalafell
    /// </summary>
    Lalafell,
    /// <summary>
    /// Miqo'te
    /// </summary>
    Miqote,
    /// <summary>
    /// Roegadyn
    /// </summary>
    Roegadyn,
    /// <summary>
    /// Au Ra
    /// </summary>
    AuRa,
    /// <summary>
    /// Hrothgar
    /// </summary>
    Hrothgar,
    /// <summary>
    /// Viera
    /// </summary>
    Viera,
}

/// <summary>
/// Types of game objects or identities.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.GameData.Enums.ObjectType</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ObjectType
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,
    /// <summary>
    /// Visual Effect
    /// </summary>
    Vfx,
    /// <summary>
    /// Demi Human
    /// </summary>
    DemiHuman,
    /// <summary>
    /// Accessory
    /// </summary>
    Accessory,
    /// <summary>
    /// Doodad
    /// </summary>
    World,
    /// <summary>
    /// Housing Object
    /// </summary>
    Housing,
    /// <summary>
    /// Monster
    /// </summary>
    Monster,
    /// <summary>
    /// Icon
    /// </summary>
    Icon,
    /// <summary>
    /// Loading Screen
    /// </summary>
    LoadingScreen,
    /// <summary>
    /// Map
    /// </summary>
    Map,
    /// <summary>
    /// UI Element
    /// </summary>
    Interface,
    /// <summary>
    /// Equipment
    /// </summary>
    Equipment,
    /// <summary>
    /// Character
    /// </summary>
    Character,
    /// <summary>
    /// Weapon
    /// </summary>
    Weapon,
    /// <summary>
    /// Font
    /// </summary>
    Font,
}

/// <summary>
/// Body Slots as used by character model parts.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.GameData.Enums.BodySlot</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BodySlot : byte
{
    Unknown,
    Hair,
    Face,
    Tail,
    Body,
    Ear, // NOTE: The schema has "Zear" instead
    Head, // NOTE: The schema is missing this
}

/// <summary>
/// Available sub-races or clans for player characters.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.GameData.Enums.SubRace</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubRace : byte
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,
    /// <summary>
    /// Midlander
    /// </summary>
    Midlander,
    /// <summary>
    /// Highlander
    /// </summary>
    Highlander,
    /// <summary>
    /// Wildwood
    /// </summary>
    Wildwood,
    /// <summary>
    /// Duskwight
    /// </summary>
    Duskwight,
    /// <summary>
    /// Plainsfolk
    /// </summary>
    Plainsfolk,
    /// <summary>
    /// Dunesfolk
    /// </summary>
    Dunesfolk,
    /// <summary>
    /// Seeker of the Sun
    /// </summary>
    SeekerOfTheSun,
    /// <summary>
    /// Keeper of the Moon
    /// </summary>
    KeeperOfTheMoon,
    /// <summary>
    /// Seawolf
    /// </summary>
    Seawolf,
    /// <summary>
    /// Hellsguard
    /// </summary>
    Hellsguard,
    /// <summary>
    /// Raen
    /// </summary>
    Raen,
    /// <summary>
    /// Xaela
    /// </summary>
    Xaela,
    /// <summary>
    /// Hellion
    /// </summary>
    Helion,
    /// <summary>
    /// Lost
    /// </summary>
    Lost,
    /// <summary>
    /// Rava
    /// </summary>
    Rava,
    /// <summary>
    /// Veena
    /// </summary>
    Veena,
}

/// <summary>
/// Controls the visibility of connectors.
/// </summary>
/// <remarks>
/// This is equivalent to <c>Penumbra.Meta.Manipulations.ShapeConnectorCondition</c> and can be cast as necessary.
/// </remarks>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShapeConnectorCondition : byte
{
    None = 0,
    Wrists = 1,
    Waist = 2,
    Ankles = 3,
}
