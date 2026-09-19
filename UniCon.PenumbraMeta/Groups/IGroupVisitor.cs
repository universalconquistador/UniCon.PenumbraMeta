namespace UniCon.PenumbraMeta.Groups;

public interface IGroupVisitor<TParam, TResult>
{
    static abstract TResult VisitSingleGroup(SingleGroup singleGroup, ref TParam param);
    static abstract TResult VisitMultiGroup(MultiGroup multiGroup, ref TParam param);
    static abstract TResult VisitCombiningGroup(CombiningGroup combiningGroup, ref TParam param);
    static abstract TResult VisitImcGroup(ImcGroup imcGroup, ref TParam param);
}
