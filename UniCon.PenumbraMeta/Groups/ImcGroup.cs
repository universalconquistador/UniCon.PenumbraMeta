using System;
using System.Collections.Generic;
using System.Text;
using UniCon.PenumbraMeta.Conditions;
using UniCon.PenumbraMeta.Manipulations;

namespace UniCon.PenumbraMeta.Groups;

public record class ImcGroup(int Version, string Name, string? Description, string? Image, int Page, int Priority, int DefaultSettings, Guid Id,
    List<GroupLayoutOptions>? Layout, Condition? Condition, bool AllVariants, bool OnlyAttributes, ImcIdentifier Identifier, ImcEntry DefaultEntry, List<Option> Options)
    : Group(Version, Name, Description, Image, Page, Priority, DefaultSettings, Id, Layout, Condition)
{
    public bool AllVariants { get; set; } = AllVariants;
    public bool OnlyAttributes { get; set; } = OnlyAttributes;
    public ImcIdentifier Identifier { get; set; } = Identifier;
    public ImcEntry DefaultEntry { get; set; } = DefaultEntry;
    public List<Option> Options { get; set; } = Options;

    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitImcGroup(this, ref param);
}
