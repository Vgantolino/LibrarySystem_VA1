using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystem_VA.Departments.Dto;
using LibrarySystem_VA.Entities;
using LibrarySystem_VA.Students.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_VA.Students
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>, IStudentAppService
    {

        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Department> _departmentRepository;

        public StudentAppService(IRepository<Student, int> repository, IRepository<Student> studentRepository, IRepository<Department> departmentRepository) : base(repository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        public override Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task<PagedResultDto<StudentDto>> GetAllAsync(PagedStudentResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<StudentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<StudentDto> UpdateAsync(StudentDto input)
        {
            return base.UpdateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        protected override Task<Student> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }

        public async Task<PagedResultDto<StudentDto>> GetAllDepartment(PagedStudentResultRequestDto input)
        {
            var query = await _studentRepository.GetAll()
                .Include(x => x.Department)
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();

            return new PagedResultDto<StudentDto>(query.Count(), query);
        }

        public async Task<List<StudentDto>> GetAllStudent()
        {
            var query = await _studentRepository.GetAll()
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();

            return query;
        }
    }
}
