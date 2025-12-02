using ModelDates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ManagerDB:UserDB
    {
        public override BaseEntity NewEntity()
        {
            return new Manager();
        }

        public ManagerList SelectAll()
        {
            command.CommandText = $"SELECT  Manager.ID, Manager.Pass, [User].Username, " +
                $" [User].Email, [User].[Password], [User].Gender, [User].DateOfBirth, " +
                $" [User].City, [User].Bio, [User].ProfilePic, [User].CreatedAt, " +
                $" [User].Age FROM  (Manager INNER JOIN  [User] ON Manager.ID = [User].ID)";

            ManagerList managerList = new ManagerList(base.Select());
            return managerList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Manager man = entity as Manager;
            man.MangPassword =reader["Pass"].ToString();
            base.CreateModel(entity);
            return man;

        }
    }
}
