using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIPO74_HFT_2021221.Logic;
using AIPO74_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIPO74_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LaboratoryStaffController : ControllerBase
    {
        ILaboratoryStaff laboratoryStaff;
        public LaboratoryStaffController(ILaboratoryStaff laboratoryStaff)
        {
            this.laboratoryStaff = laboratoryStaff;
        }
        [HttpGet("{id}")]
        public LaboratoryStaff GetStaff(int id)
        {
            return laboratoryStaff.GetStaffID(id);
        }

        [HttpGet]
        public IEnumerable<LaboratoryStaff> GetStaffs()
        {
            return laboratoryStaff.GetLaboratoryStaffs();
        }

        [HttpPost]
        public void CreateStaff([FromBody]LaboratoryStaff laboratoryStaff1)
        {
            laboratoryStaff.CreateNewStaff(laboratoryStaff1);
        }

        [HttpPut]
        public void UpdatePositionStaff([FromBody] LaboratoryStaff laboratory)
        {
            laboratoryStaff.ChangePosition(laboratory.StaffID, laboratory.Position);
        }

        [HttpPut("updateaccesslevel")]
        public void UpdateAccessLevelStaff([FromBody] LaboratoryStaff laboratory)
        {
            laboratoryStaff.ChangeAccessLevel(laboratory.StaffID, laboratory.AccessLevel);
        }

        [HttpDelete("{id}")]
        public void DeleteStaff(int id)
        {
            laboratoryStaff.DeleteStaff(id);
        }
    }
}