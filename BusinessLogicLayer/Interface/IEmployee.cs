using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace BusinessLogicLayer.Interface
{
    public interface IEmployee
    {
        List<EmployeeDetails> Get();
        EmployeeDetails Get(string username);
        
        void Post(EmployeeDetails emp);
        //List<EmployeeDetails> Edit();
        void Delete(string empdlt);
        void Edit(EmployeeDetails empe);

    }
}
