namespace UniCon.PenumbraMeta.Conditions;

public record class NotCondition(Condition Condition)
    : Condition()
{
    public Condition Condition { get; set; } = Condition;

    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitNotCondition(this, ref param);
}
