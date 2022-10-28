using BusinessLogicLayer.Interface;
using ModelLayer;
using RepositoryLayer;

namespace BusinessLogicLayer
{
    public class EmployeeInterface : IEmployee
    {
        private readonly EmployeeDbContext _emplocontext;
            public EmployeeInterface (EmployeeDbContext emplocontext)
        {
            _emplocontext = emplocontext;
        }
        public void Delete(string empdlt)
        {
            EmployeeDetails emplo = _emplocontext.Details.FirstOrDefault(i => i.UserName==empdlt);
            if (empdlt != null)
            {
                _emplocontext.Remove(emplo);
                _emplocontext.SaveChanges();
            }
        }

        
        public void Edit(EmployeeDetails empe)
        {
            EmployeeDetails emplo = _emplocontext.Details.FirstOrDefault(i => i.UserName == empe.UserName);
            if (emplo != null)
            {
                _emplocontext.Details.Remove(emplo);
                _emplocontext.Details.Add(empe);
                _emplocontext.SaveChanges();
            }
        }

        public List<EmployeeDetails> Get()
        {
           return _emplocontext.Details.ToList();
        }
        public EmployeeDetails Get(string username)
        {
            return _emplocontext.Details.FirstOrDefault(i=>i.UserName==username);
        }

        

       public void Post(EmployeeDetails emp)
        {
            _emplocontext.Details.Add(emp);
            _emplocontext.SaveChanges();
        }
    }
}