using ProgramSAP.DataAccess.CQRS.Commands;
using ProgramSAP.DataAccess.Repositories;

namespace ProgramSAP.DataAccess.CQRS;

public class CommandExecutor : ICommandExecutor
{
    private readonly RecruitingProgramContext context;

    public CommandExecutor(RecruitingProgramContext context)
    {
        this.context = context;
    }
    public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return command.Execute(this.context);
    }
}
