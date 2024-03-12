using ProgramSAP.DataAccess.CQRS.Commands;

namespace ProgramSAP.DataAccess.CQRS;

public interface ICommandExecutor
{
    Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
}
