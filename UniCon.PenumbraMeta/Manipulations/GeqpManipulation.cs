using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UniCon.PenumbraMeta.Manipulations;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GeqpType
{
    DoNotHideEarrings,
    DoNotHideNecklace,
    DoNotHideBracelets,
    DoNotHideRingR,
    DoNotHideRingL,
    DoNotHideHrothgarHats,
    DoNotHideVieraHats,
    HideHorns,
    HideVieraEars,
    HideMiqoteEars,
}

public record class Geqp(ushort Condition, GeqpType Type)
{
    public ushort Condition { get; set; } = Condition;
    public GeqpType Type { get; set; } = Type;
}

public record class GeqpManipulation(Geqp Manipulation) : ManipulationBase<Geqp>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitGeqpManipulation(this, ref param);
}