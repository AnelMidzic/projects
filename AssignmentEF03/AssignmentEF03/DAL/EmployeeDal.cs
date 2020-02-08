using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentEF03.Models;
using System.Data.Entity;

namespace AssignmentEF03.DAL
{
    class EmployeeDal
    {
        private Model db;

        public EmployeeDal(Model _db)
        {
            db = _db;
        }

        public List<Employee> ReturnEmployees()
        {
            return db.Employees.ToList();
        }

        public int InsertEmployee(Employee e)
        {
            try
            {
                db.Employees.Add(e);
                db.SaveChanges();
                return e.EmployeeID;
            }
            catch (Exception)
            {
                db.Entry(e).State = EntityState.Detached;
                return -1;
            }
        }

        public int ChangeEmployee(Employee e)
        {
            Employee e1 = null;

            try
            {
                e1 = db.Employees.Find(e.EmployeeID);
                e1.FirstName = e.FirstName;
                e1.LastName = e.LastName;
                e1.BirthDate = e.BirthDate;
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(e1).State = EntityState.Unchanged;
                return -1;
            }
        }

        public int DeleteEmployee(Employee e)
        {
            Employee e1 = null;

            try
            {
                e1 = db.Employees.Find(e.EmployeeID);
                db.Employees.Remove(e1);
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(e1).State = EntityState.Unchanged;
                return -1;
            }
        }
    }
}
