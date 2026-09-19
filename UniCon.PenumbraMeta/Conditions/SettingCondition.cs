namespace UniCon.PenumbraMeta.Conditions;

public record class SettingCondition(Guid Setting)
    : Condition()
{
    public Guid Setting { get; set; } = Setting;

    public override TResult Visit<TVisitor, TParam, TResult>(ref TParam param) => TVisitor.VisitSettingCondition(this, ref param);
}
