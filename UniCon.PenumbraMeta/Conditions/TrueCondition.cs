namespace UniCon.PenumbraMeta.Conditions;

public record class TrueCondition()
    : Condition()
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitTrueCondition(this, ref param);
}
