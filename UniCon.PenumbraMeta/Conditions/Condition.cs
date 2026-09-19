using System.Text.Json.Serialization;

namespace UniCon.PenumbraMeta.Conditions;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(TrueCondition), typeDiscriminator: "True")]
[JsonDerivedType(typeof(FalseCondition), typeDiscriminator: "False")]
[JsonDerivedType(typeof(AndCondition), typeDiscriminator: "And")]
[JsonDerivedType(typeof(OrCondition), typeDiscriminator: "Or")]
[JsonDerivedType(typeof(NotCondition), typeDiscriminator: "Not")]
[JsonDerivedType(typeof(SettingCondition), typeDiscriminator: "Setting")]
public abstract record class Condition()
{
    public abstract TResult Visit<TVisitor, TParam, TResult>(ref TParam param)
        where TVisitor : IConditionVisitor<TParam, TResult>;
}
