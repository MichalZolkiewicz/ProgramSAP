using ProgramSAP.DataAccess.CQRS.Queries;

namespace ProgramSAP.DataAccess.CQRS;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(QueryBase<TResult> query);
}
