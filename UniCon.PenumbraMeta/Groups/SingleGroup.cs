using System;
using System.Collections.Generic;
using System.Text;
using UniCon.PenumbraMeta.Conditions;

namespace UniCon.PenumbraMeta.Groups;

public record class SingleGroup(int Version, string Name, string? Description, string? Image, int Page, int Priority, int DefaultSettings, Guid Id,
    List<GroupLayoutOptions>? Layout, Condition? Condition, List<ContainerOption> Options)
    : Group(Version, Name, Description, Image, Page, Priority, DefaultSettings, Id, Layout, Condition)
{
    public List<ContainerOption> Options { get; set; } = Options;

    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitSingleGroup(this, ref param);
}
