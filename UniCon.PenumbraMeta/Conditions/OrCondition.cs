using System.Text.Json.Serialization;

namespace UniCon.PenumbraMeta.Conditions;

public record class OrCondition(List<Condition>? Conditions)
    : Condition()
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Condition>? Conditions { get; set; } = Conditions;

    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitOrCondition(this, ref param);
}
