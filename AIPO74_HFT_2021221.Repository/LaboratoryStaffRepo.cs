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
            var Scientist = this.GetOne(id);
            if (Scientist == null)
            {
                throw new InvalidOperationException("Cannot find Scientist");
            }
            Scientist.AccessLevel = newAccesslevel;
            this.Context.SaveChanges();
        }

        public void ChangePosition(int id, string newPosition)
        {
            var Scientist = this.GetOne(id);
            if (Scientist == null)
            {
                throw new InvalidOperationException("Cannot find Scientist");
            }
            Scientist.Position = newPosition;
            this.Context.SaveChanges();
        }

        public void ChangeYearExpirience(int id, int newYearExpirience)
        {
            var Scientist = this.GetOne(id);
            if (Scientist == null)
            {
                throw new InvalidOperationException("Cannot find Scientist");
            }
            Scientist.YearExpirience = newYearExpirience;
            this.Context.SaveChanges();
        }

        public override LaboratoryStaff GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Insert(LaboratoryStaff entity)
        {
            this.Context.Set<LaboratoryStaff>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            LaboratoryStaff obj = this.GetOne(id);
            this.Context.Set<LaboratoryStaff>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
