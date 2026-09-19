namespace UniCon.PenumbraMeta.Conditions;

public record class FalseCondition()
    : Condition()
{
    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitFalseCondition(this, ref param);
}
