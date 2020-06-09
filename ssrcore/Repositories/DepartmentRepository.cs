﻿using Microsoft.EntityFrameworkCore;
using ssrcore.Helpers;
using ssrcore.Models;
using ssrcore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssrcore.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<bool> Create(DepartmentModel model)
        {
            try
            {
                var department = new Department
                {
                    DepartmentId = model.DepartmentId,
                    DepartmentNm = model.DepartmentNm,
                    Hotline = model.Hotline,
                    ManagerId = model.ManagerId,
                    RoomNum = model.RoomNum,
                    InsBy = Constants.Admin.ADMIN,
                    InsDatetime = DateTime.Now,
                    UpdBy = Constants.Admin.ADMIN,
                    UpdDatetime = DateTime.Now
                };

                await _context.AddAsync(department);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public async Task<PagedList<DepartmentModel>> GetAllDepartments(SearchDepartmentModel model)
        {
            var query = _context.Department.Where(d => (d.DelFlg == false) 
                                                        && (model.DepartmentNm == null || d.DepartmentNm.Contains(model.DepartmentNm)))
                    .Select(s => new DepartmentModel
                    {
                        DepartmentId = s.DepartmentId,
                        DepartmentNm = s.DepartmentNm,
                        Hotline = s.Hotline,
                        RoomNum = s.RoomNum,
                        ManagerId = s.ManagerId,
                        Manager = s.Manager.StaffNavigation.FullName
                    });

            var totalCount = await query.CountAsync();

            var result = await query
                .OrderBy(t => t.DepartmentNm)
                .Skip(model.PageCount * (model.Page - 1))
                .Take(model.PageCount)
                .ToListAsync();

            return PagedList<DepartmentModel>.ToPagedList(result, totalCount, model.Page, model.PageCount);
        }

        public async Task<Department> GetDepartment(string departmentId)
        {
            return await _context.Department.FindAsync(departmentId);
        }

        public async Task<bool> Remove(string departmentId)
        {
            var department = await _context.Department.FindAsync(departmentId);
            if(department != null)
            {
                department.DelFlg = true;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public void UpdateDepartment(DepartmentModel model)
        {
            _context.SaveChanges();
        }
    }
}
