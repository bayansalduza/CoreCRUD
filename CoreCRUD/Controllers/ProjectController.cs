using Data.Context;
using Data.Dto;
using Data.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        MasterContext masterContext = new MasterContext();
        public ProjectController()
        {
        }

        [HttpPost("AddProject")]
        public string AddProject(ProjectDto projectDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                Project project = new Project()
                {
                    Id = projectDto.Id,
                    Name = projectDto.Name
                };
                unitOfWork.GetRepository<Project>().Add(project);
                unitOfWork.SaveChanges();
                return "Kayıt başarılı";
            }
        }

        [HttpPost("AddProjectRole")]
        public string AddProjectRole(ProjectRoleDto projectRoleDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                ProjectRoles projectRoles = new ProjectRoles()
                {
                    Id = projectRoleDto.Id,
                    Projectid = projectRoleDto.Projectid,
                    Userid = projectRoleDto.Userid
                };
                unitOfWork.GetRepository<ProjectRoles>().Add(projectRoles);
                unitOfWork.SaveChanges();
                return "Kayıt başarılı";
            }
        }

        [HttpGet("GetProjectRoles")]
        public List<ProjectRoleDto> GetProjectRole(int id)
        {
            List<ProjectRoleDto> projectRoleDtos = (from prole in masterContext.ProjectRoles
                                                    join pro in masterContext.Project on prole.Projectid equals pro.Id
                                                    where prole.Projectid == id
                                                    select new ProjectRoleDto
                                                    {
                                                        Id = prole.Id,
                                                        Projectid = prole.Projectid,
                                                        Userid = prole.Userid,
                                                        ProjectName = pro.Name
                                                    }
                                                    ).ToList();
            return projectRoleDtos;
        }
    }
}
