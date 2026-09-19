using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using UniCon.PenumbraMeta.Conditions;

namespace UniCon.PenumbraMeta.Groups;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GroupLayoutOptions
{
    Hide,
    Space,
    ParentHeader,
    DefaultClosed,
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(CombiningGroup), typeDiscriminator: "Combining")]
[JsonDerivedType(typeof(ImcGroup), typeDiscriminator: "Imc")]
[JsonDerivedType(typeof(MultiGroup), typeDiscriminator: "Multi")]
[JsonDerivedType(typeof(SingleGroup), typeDiscriminator: "Single")]
public abstract record class Group(int Version, string Name, string? Description, string? Image, int Page, int Priority, int DefaultSettings, Guid Id,
    List<GroupLayoutOptions>? Layout, Condition? Condition)
{
    public int Version { get; set; } = Version;
    public string Name { get; set; } = Name;
    public string? Description { get; set; } = Description;
    public string? Image { get; set; } = Image;
    public int Page { get; set; } = Page;
    public int Priority { get; set; } = Priority;
    public int DefaultSettings { get; set; } = DefaultSettings;
    public Guid Id { get; set; } = Id;
    public List<GroupLayoutOptions>? Layout { get; set; } = Layout;
    public Condition? Condition { get; set; } = Condition;

    public abstract TResult Visit<TVisitor, TParam, TResult>(ref TParam param)
        where TVisitor : IGroupVisitor<TParam, TResult>;
}
