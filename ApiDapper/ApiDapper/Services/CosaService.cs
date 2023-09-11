using ApiDapper.Entities;
using ApiDapper.Interfaces.Repositories;
using ApiDapper.Interfaces.Services;

namespace ApiDapper.Services
{
    public class CosaService : ICosaService
    {
        private readonly ICosaRepository _repository;
        public CosaService(ICosaRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> DeleteById(int id)
        {
            var result = await _repository.DeleteById(id);
            return result;
        }

        public async Task<IEnumerable<Cosa>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Cosa?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public Task<int> Insert(Cosa entity)
        {
            return _repository.Insert(entity);
        }

        public async Task<int> Update(int id, Cosa entity)
        {
            return await _repository.Update(id, entity);
        }
    }
}
