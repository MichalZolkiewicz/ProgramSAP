using Microsoft.EntityFrameworkCore;
using ProgramSAP.DataAccess.Entities;

namespace ProgramSAP.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : EntityBase
{

    private readonly RecruitingProgramContext recruitingProgramContext;
    private DbSet<T> entities;

    public Repository(RecruitingProgramContext recruitingProgramContext)
    {
        this.recruitingProgramContext = recruitingProgramContext;
        entities = recruitingProgramContext.Set<T>();
    }
    public Task<List<T>> GetAll()
    {
        return entities.ToListAsync();
    } 

    public Task<T> GetById(int id)
    {
        return entities.SingleOrDefaultAsync(s => s.Id == id);
    }

    public Task Insert(T entity)
    {
        if (entity == null) 
        {
            throw new ArgumentNullException();
        }

        entities.Add(entity);
        return recruitingProgramContext.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }

        return recruitingProgramContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        T entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
        entities.Remove(entity);
        await recruitingProgramContext.SaveChangesAsync();
    }
}
