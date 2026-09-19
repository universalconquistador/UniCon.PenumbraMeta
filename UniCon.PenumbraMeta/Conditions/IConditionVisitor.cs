namespace UniCon.PenumbraMeta.Conditions;

public interface IConditionVisitor<TParam, TResult>
{
    static abstract TResult VisitTrueCondition(TrueCondition trueCondition, ref TParam param);
    static abstract TResult VisitFalseCondition(FalseCondition falseCondition, ref TParam param);
    static abstract TResult VisitAndCondition(AndCondition andCondition, ref TParam param);
    static abstract TResult VisitOrCondition(OrCondition orCondition, ref TParam param);
    static abstract TResult VisitNotCondition(NotCondition notCondition, ref TParam param);
    static abstract TResult VisitSettingCondition(SettingCondition settingCondition, ref TParam param);
}
