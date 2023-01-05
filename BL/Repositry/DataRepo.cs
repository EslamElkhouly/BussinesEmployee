using BussinesEmployee.BL.Interface;
using BussinesEmployee.DAL.Database;
using Microsoft.AspNetCore.Identity;

namespace BussinesEmployee.BL.Repositry
{
    public class DataRepo : IDataRepo
    {
        private readonly DbContainer dbContainer;
        private readonly RoleManager<IdentityRole> roleManager;

        public DataRepo(DbContainer dbContainer ,RoleManager<IdentityRole> roleManager)
        {
            this.dbContainer = dbContainer;
            this.roleManager = roleManager;
        }
        public int GetTotaldepartmentNumber()
        {
            return dbContainer.Department.Count();
        }

        public int GetTotalEmployeeNumers()
        {
            return dbContainer.Employee.Count();
        }

        public int GetTotalRolesNumber()
        {
           return roleManager.Roles.Count();
        }
    }
}
