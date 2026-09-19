using System;
using System.Collections.Generic;
using System.Text;

namespace UniCon.PenumbraMeta.Manipulations;

public record class Eqdp(int Entry, Gender Gender, ModelRace Race, ushort SetId, EquipSlot Slot)
{
    public int Entry { get; set; } = Entry;
    public Gender Gender { get; set; } = Gender;
    public ModelRace Race { get; set; } = Race;
    public ushort SetId { get; set; } = SetId;
    public EquipSlot Slot { get; set; } = Slot;
}

public record class EqdpManipulation(Eqdp Manipulation) : ManipulationBase<Eqdp>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitEqdpManipulation(this, ref param);
}