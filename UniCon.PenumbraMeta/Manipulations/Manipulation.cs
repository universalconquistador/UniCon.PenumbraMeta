using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UniCon.PenumbraMeta.Manipulations;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(UnknownManipulation), typeDiscriminator: "Unknown")]
[JsonDerivedType(typeof(AtchManipulation), typeDiscriminator: "Atch")]
[JsonDerivedType(typeof(AtrManipulation), typeDiscriminator: "Atr")]
[JsonDerivedType(typeof(EqdpManipulation), typeDiscriminator: "Eqdp")]
[JsonDerivedType(typeof(EqpManipulation), typeDiscriminator: "Eqp")]
[JsonDerivedType(typeof(EstManipulation), typeDiscriminator: "Est")]
[JsonDerivedType(typeof(GeqpManipulation), typeDiscriminator: "GlobalEqp")]
[JsonDerivedType(typeof(GmpManipulation), typeDiscriminator: "Gmp")]
[JsonDerivedType(typeof(ImcManipulation), typeDiscriminator: "Imc")]
[JsonDerivedType(typeof(RspManipulation), typeDiscriminator: "Rsp")]
[JsonDerivedType(typeof(ShpManipulation), typeDiscriminator: "Shp")]
public abstract record class Manipulation()
{
    public abstract TResult Visit<TVisitor, TParam, TResult>(ref TParam param)
        where TVisitor : IManipulationVisitor<TParam, TResult>;
}

public abstract record class ManipulationBase<TManipulation>(TManipulation Manipulation) : Manipulation
{
    public TManipulation Manipulation { get; set; } = Manipulation;
}

public record class UnknownManipulation(object Manipulation) : ManipulationBase<object>(Manipulation)
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitUnknownManipulation(this, ref param);
}
