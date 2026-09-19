using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UniCon.PenumbraMeta.Manipulations;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EstSlot
{
    Hair,
    Face,
    Body,
    Head,
}

public record class Est(ushort Entry, Gender Gender, ModelRace Race, ushort SetId, EstSlot Slot)
{
    public ushort Entry { get; set; } = Entry;
    public Gender Gender { get; set; } = Gender;
    public ModelRace Race { get; set; } = Race;
    public ushort SetId { get; set; } = SetId;
    public EstSlot Slot { get; set; } = Slot;
}

public record class EstManipulation(Est Manipulation) : ManipulationBase<Est>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitEstManipulation(this, ref param);
}