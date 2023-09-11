using ApiDapper.Entities;

namespace ApiDapper.Interfaces.Repositories
{
    public interface ICosaRepository
    {
        public Task<IEnumerable<Cosa>> GetAll();
        public Task<Cosa?> GetById(int id);
        public Task<int> Update(int id, Cosa entity);
        public Task<int> DeleteById(int id);
        public Task<int> Insert(Cosa entity);
    }
}
