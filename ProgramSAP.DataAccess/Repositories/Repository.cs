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
    public IEnumerable<T> GetAll()
    {
        return entities.AsEnumerable();
    } 

    public T GetById(int id)
    {
        return entities.SingleOrDefault(s => s.Id == id);
    }

    public void Insert(T entity)
    {
        if (entity == null) 
        {
            throw new ArgumentNullException();
        }

        entities.Add(entity);
        recruitingProgramContext.SaveChanges();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
