namespace ProgramSAP.DataAccess.CQRS.Queries;

public abstract class QueryBase<TResult>
{
    public abstract Task<TResult> Execute(RecruitingProgramContext context);
}
