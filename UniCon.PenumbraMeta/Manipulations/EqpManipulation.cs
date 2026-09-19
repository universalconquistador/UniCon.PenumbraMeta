using System;
using System.Collections.Generic;
using System.Text;

namespace UniCon.PenumbraMeta.Manipulations;

public record class Eqp(int Entry, ushort SetId, EquipSlot Slot)
{
    public int Entry { get; set; } = Entry;
    public ushort SetId { get; set; } = SetId;
    public EquipSlot Slot { get; set; } = Slot;
}

public record class EqpManipulation(Eqp Manipulation) : ManipulationBase<Eqp>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitEqpManipulation(this, ref param);
}