using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UniCon.PenumbraMeta.Manipulations;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RspAttribute
{
    MaleMinSize,
    MaleMaxSize,
    MaleMinTail,
    MaleMaxTail,
    FemaleMinSize,
    FemaleMaxSize,
    FemaleMinTail,
    FemaleMaxTail,
    BustMinX,
    BustMinY,
    BustMinZ,
    BustMaxX,
    BustMaxY,
    BustMaxZ,
}

public record class Rsp(float Entry, SubRace SubRace, RspAttribute Attribute)
{
    public float Entry { get; set; } = Entry;
    public SubRace SubRace { get; set; } = SubRace;
    public RspAttribute Attribute { get; set; } = Attribute;
}

public record class RspManipulation(Rsp Manipulation) : ManipulationBase<Rsp>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitRspManipulation(this, ref param);
}