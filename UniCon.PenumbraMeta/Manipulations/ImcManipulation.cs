using System;
using System.Collections.Generic;
using System.Text;

namespace UniCon.PenumbraMeta.Manipulations;

public record class Imc(ImcEntry Entry, ushort PrimaryId, ushort SecondaryId, byte Variant, ObjectType ObjectType, EquipSlot EquipSlot, BodySlot BodySlot)
    : ImcIdentifier(PrimaryId, SecondaryId, Variant, ObjectType, EquipSlot, BodySlot)
{
    public ImcEntry Entry { get; set; } = Entry;
}

public record class ImcIdentifier(ushort PrimaryId, ushort SecondaryId, byte Variant, ObjectType ObjectType, EquipSlot EquipSlot, BodySlot BodySlot)
{
    public ushort PrimaryId { get; set; } = PrimaryId;
    public ushort SecondaryId { get; set; } = SecondaryId;
    public byte Variant { get; set; } = Variant;
    public ObjectType ObjectType { get; set; } = ObjectType;
    public EquipSlot EquipSlot { get; set; } = EquipSlot;
    public BodySlot BodySlot { get; set; } = BodySlot;
}

public record class ImcEntry(byte MaterialId, byte DecalId, byte VfxId, byte MaterialAnimationId, int AttributeMask, int SoundId)
{
    public byte MaterialId { get; set; } = MaterialId;
    public byte DecalId { get; set; } = DecalId;
    public byte VfxId { get; set; } = VfxId;
    public byte MaterialAnimationId { get; set; } = MaterialAnimationId;
    public int AttributeMask { get; set; } = AttributeMask;
    public int SoundId { get; set; } = SoundId;
}

public record class ImcManipulation(Imc Manipulation) : ManipulationBase<Imc>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitImcManipulation(this, ref param);
}