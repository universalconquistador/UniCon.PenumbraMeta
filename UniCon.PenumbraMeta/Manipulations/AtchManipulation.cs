using System;
using System.Collections.Generic;
using System.Text;

namespace UniCon.PenumbraMeta.Manipulations;

public record class Atch(AtchEntry Entry, Gender Gender, ModelRace Race, string Type, ushort Index)
{
    public AtchEntry Entry { get; set; } = Entry;
    public Gender Gender { get; set; } = Gender;
    public ModelRace Race { get; set; } = Race;
    public string Type { get; set; } = Type;
    public ushort Index { get; set; } = Index;
}

public record class AtchEntry(string Bone, float Scale, float OffsetX, float OffsetY, float OffsetZ, float RotationX, float RotationY, float RotationZ)
{
    public string Bone { get; set; } = Bone;
    public float Scale { get; set; } = Scale;
    public float OffsetX { get; set; } = OffsetX;
    public float OffsetY { get; set; } = OffsetY;
    public float OffsetZ { get; set; } = OffsetZ;
    public float RotationX { get; set; } = RotationX;
    public float RotationY { get; set; } = RotationY;
    public float RotationZ { get; set; } = RotationZ;
}

public record class AtchManipulation(Atch Manipulation) : ManipulationBase<Atch>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitAtchManipulation(this, ref param);
}