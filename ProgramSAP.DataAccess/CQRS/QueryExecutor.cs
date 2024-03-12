using ProgramSAP.DataAccess.CQRS.Queries;

namespace ProgramSAP.DataAccess.CQRS;

public class QueryExecutor : IQueryExecutor
{
    private readonly RecruitingProgramContext context;

    public QueryExecutor(RecruitingProgramContext context)
    {
        this.context = context;
    }
    public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
    {
        return query.Execute(context);
    }
}
