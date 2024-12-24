using System;

namespace CentroDePreguntasApi.Repository.IRepository;

public interface IUserRepository<User>
{
  Task<IEnumerable<User>> Get();
  Task<User> GetById(int id);
  Task<int> Add(User userId);
  void Delete(int id);
  Task Save();
  IEnumerable<User> Search(Func<User, bool> filter) => throw new NotImplementedException();
}
