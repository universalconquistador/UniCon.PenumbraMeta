using System;
using System.Collections.Generic;
using System.Text;

namespace UniCon.PenumbraMeta.Manipulations;

public record class Gmp(GmpEntry Entry, ushort SetId)
{
    public GmpEntry Entry { get; set; } = Entry;
    public ushort SetId { get; set; } = SetId;
}

public record class GmpEntry(bool Enabled, bool Animated, int RotationA, int RotationB, int RotationC, int UnknownA, int UnknownB)
{
    public bool Enabled { get; set; } = Enabled;
    public bool Animated { get; set; } = Animated;
    public int RotationA { get; set; } = RotationA;
    public int RotationB { get; set; } = RotationB;
    public int RotationC { get; set; } = RotationC;
    public int UnknownA { get; set; } = UnknownA;
    public int UnknownB { get; set; } = UnknownB;
}

public record class GmpManipulation(Gmp Manipulation) : ManipulationBase<Gmp>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitGmpManipulation(this, ref param);
}