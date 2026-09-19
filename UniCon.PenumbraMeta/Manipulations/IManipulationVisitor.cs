namespace UniCon.PenumbraMeta.Manipulations;

public interface IManipulationVisitor<TParam, TResult>
{
    static abstract TResult VisitUnknownManipulation(UnknownManipulation manipulation, ref TParam param);
    static abstract TResult VisitAtchManipulation(AtchManipulation manipulation, ref TParam param);
    static abstract TResult VisitAtrManipulation(AtrManipulation manipulation, ref TParam param);
    static abstract TResult VisitEqdpManipulation(EqdpManipulation manipulation, ref TParam param);
    static abstract TResult VisitEqpManipulation(EqpManipulation manipulation, ref TParam param);
    static abstract TResult VisitEstManipulation(EstManipulation manipulation, ref TParam param);
    static abstract TResult VisitGeqpManipulation(GeqpManipulation manipulation, ref TParam param);
    static abstract TResult VisitGmpManipulation(GmpManipulation manipulation, ref TParam param);
    static abstract TResult VisitImcManipulation(ImcManipulation manipulation, ref TParam param);
    static abstract TResult VisitRspManipulation(RspManipulation manipulation, ref TParam param);
    static abstract TResult VisitShpManipulation(ShpManipulation manipulation, ref TParam param);
}
