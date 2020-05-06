using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    [Authorize]
    public class ProjectsJsonController : Controller
    {
        //Obtiene el usuario en sesion
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public ProjectsJsonController(ApplicationUserManager userManager)
        {
            userManager = UserManager;
        }

        public ProjectsJsonController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Projects
        public async Task<ActionResult> GetProjects()
        {
            try
            {
                //Recupero el Usuario en sesion
                ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

                //Consulta la organizacion del usuario que esta ingresando al sistema
                Logica.BL.Tenants tenants = new Logica.BL.Tenants();
                var tenant = tenants.GetTenants(user.Id).FirstOrDefault();

                Logica.BL.Projects projects = new Logica.BL.Projects();

                var result = await UserManager.IsInRoleAsync(user.Id, "Admin") ?
                    projects.GetProjects(null, tenant.Id) :     //Si es admin consulta todos los proyectos de la organizacion
                    projects.GetProjects(null, tenant.Id, user.Id);  //si es miembro consulta los projectos de la organizacion que le pertenezca

                var listprojects = result.Select(x => new Logica.Models.ViewModels.ProjectsIndexViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Details = x.Details,
                    ExpectedCompletionDatestring = x.ExpectedCompletionDate == null ? string.Empty : x.ExpectedCompletionDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreatedAtstring = x.CreatedAt == null ? string.Empty : x.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdatedAtstring = x.UpdatedAt == null ? " " : x.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                }).ToList();

                listprojects = tenant.Plan.Equals("Premium") ?
                     listprojects :
                     listprojects.Take(1).ToList();

                return Json(new
                {
                    Data = listprojects,
                    IsSuccessful = true
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModels.ResponseViewModel
                {
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [ActionName("Create")]
        public ActionResult ProjectsCreate()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> ProjectsCreate(Logica.Models.BindingModels.ProjectsCreateBindingModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Recupero el Usuario en sesion
                    ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);

                    //Consulta la organizacion del usuario que esta ingresando al sistema
                    Logica.BL.Tenants tenants = new Logica.BL.Tenants();
                    var tenant = tenants.GetTenants(user.Id).FirstOrDefault(); ;

                    Logica.BL.Projects projects = new Logica.BL.Projects();
                    projects.CreateProjects(model.Title,
                                            model.Details,
                                            model.ExpectedCompletionDate,
                                            tenant.Id);
                }
                else
                {
                    return Json(new Logica.Models.ViewModels.ResponseViewModel
                    {
                        IsSuccessful = false,
                        Errors = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage).ToList()
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    IsSuccessful = true
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModels.ResponseViewModel
                {
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Edit(int? id)
        {
            Logica.BL.Projects projects = new Logica.BL.Projects();
            var project = projects.GetProjects(id, null).FirstOrDefault();

            var projectBindinModel = new Logica.Models.BindingModels.ProjectsEditBindingModel
            {
                Id = project.Id,
                Title = project.Title,
                Details = project.Details,
                ExpectedCompletionDate = project.ExpectedCompletionDate
            };

            return View(projectBindinModel);
        }

        [HttpPost]
        public ActionResult Edit(Logica.Models.BindingModels.ProjectsEditBindingModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Logica.BL.Projects projects = new Logica.BL.Projects();
                    projects.UpdateProjects(model.Id,
                                            model.Title,
                                            model.Details,
                                            model.ExpectedCompletionDate);
                }
                else
                {
                    return Json(new Logica.Models.ViewModels.ResponseViewModel
                    {
                        IsSuccessful = false,
                        Errors = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage).ToList()
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    IsSuccessful = true
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModels.ResponseViewModel
                {
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int? id)
        {
            ViewBag.ProjectId = id;

            return View();
        }

        public ActionResult GetProject(int? id)
        {
            try
            {
                Logica.BL.Projects projects = new Logica.BL.Projects();
                var project = projects.GetProjects(id, null).FirstOrDefault();

                var projectDetailsViewModel = new Logica.Models.ViewModels.ProjectsDetailsViewModel
                {
                    Title = project.Title,
                    Details = project.Details,
                    ExpectedCompletionDatestring = project.ExpectedCompletionDate == null ? string.Empty : project.ExpectedCompletionDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreatedAtstring = project.CreatedAt == null ? string.Empty : project.CreatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdatedAtstring = project.UpdatedAt == null ? string.Empty : project.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                };

                return Json(new
                {
                    IsSuccessful = true,
                    Data = projectDetailsViewModel
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Logica.Models.ViewModels.ResponseViewModel
                {
                    IsSuccessful = false,
                    Errors = new List<string> { ex.Message }
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int? id)
        {
            Logica.BL.Projects projects = new Logica.BL.Projects();
            projects.DeleteProjects(id);

            return RedirectToAction("Index");
        }
    }
}