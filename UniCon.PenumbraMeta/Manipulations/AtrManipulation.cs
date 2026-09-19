using System;
using System.Collections.Generic;
using System.Text;

namespace UniCon.PenumbraMeta.Manipulations;

public record class Atr(bool Entry, HumanSlot Slot, ushort Id, string Attribute)
{
    public bool Entry { get; set; } = Entry;
    public HumanSlot Slot { get; set; } = Slot;
    public ushort Id { get; set; } = Id;
    public string Attribute { get; set; } = Attribute;
}

public record class AtrManipulation(Atr Manipulation) : ManipulationBase<Atr>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitAtrManipulation(this, ref param);
}