using System;
using System.Collections.Generic;
using System.Text;

namespace UniCon.PenumbraMeta.Manipulations;

public record class Shp(bool Entry, HumanSlot Slot, ushort Id, string Shape, ShapeConnectorCondition ConnectorCondition, ushort GenderRaceCondition)
{
    public bool Entry { get; set; } = Entry;
    public HumanSlot Slot { get; set; } = Slot;
    public ushort Id { get; set; } = Id;
    public string Shape { get; set; } = Shape;
    public ShapeConnectorCondition ConnectorCondition { get; set; } = ConnectorCondition;
    public ushort GenderRaceCondition { get; set; } = GenderRaceCondition;
}

public record class ShpManipulation(Shp Manipulation) : ManipulationBase<Shp>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitShpManipulation(this, ref param);
}