using System;
using System.Collections.Generic;
using System.Text;
using UniCon.PenumbraMeta.Conditions;

namespace UniCon.PenumbraMeta.Groups;

public record class CombiningGroup(int Version, string Name, string? Description, string? Image, int Page, int Priority, int DefaultSettings, Guid Id,
    List<GroupLayoutOptions>? Layout, Condition? Condition, List<Option> Options, List<NamedContainer> Containers)
    : Group(Version, Name, Description, Image, Page, Priority, DefaultSettings, Id, Layout, Condition)
{
    public List<Option> Options { get; set; } = Options;
    public List<NamedContainer> Containers { get; set; } = Containers;

    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitCombiningGroup(this, ref param);
}
