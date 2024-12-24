using System;

namespace CentroDePreguntasApi.Repository.IRepository;

public interface IUserRepository<User>
{
  Task<IEnumerable<User>> Get();
  Task<User> GetById(int id);
  Task Add(User entity);
  void Update(User entity);
  void Delete(User entity);
  Task Save();
  IEnumerable<User> Search(Func<User, bool> filter) => throw new NotImplementedException();
}
