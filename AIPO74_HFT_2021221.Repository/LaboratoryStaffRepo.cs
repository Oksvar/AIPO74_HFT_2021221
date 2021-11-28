using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
    public class LaboratoryStaffRepo : Repository<LaboratoryStaff>, ILaboratoryStaffRepo
    {
        public LaboratoryStaffRepo(DbContext context) : base(context)
        {

        }

        public void ChangeAccessLevel(int id, string newAccesslevel)
        {
            LaboratoryStaff staff = GetOne(id);
            staff.AccessLevel = newAccesslevel;
            context.SaveChanges();
        }

        public void ChangePosition(int id, string newPosition)
        {
            LaboratoryStaff staff = GetOne(id);
            staff.Position = newPosition;
            context.SaveChanges();
        }

        public override LaboratoryStaff GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.StaffID == id);
        }

        public override void Remove(int id)
        {
            LaboratoryStaff staff = GetOne(id);
            context.Set<LaboratoryStaff>().Remove(staff);
            context.SaveChanges();
        }
    }
}
