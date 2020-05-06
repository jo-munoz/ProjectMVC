using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Logica.Models.ViewModels
{
    #region ProjectsIndexViewModel
    public class ProjectsIndexViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }

        [Display(Name = "Expected Completion Date")]
        public string ExpectedCompletionDatestring { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Created At")]
        public string CreatedAtstring { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Updated At")]
        public string UpdatedAtstring { get; set; }
    }
    #endregion

    #region ProjectsDetailsViewModel
    public class ProjectsDetailsViewModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }

        [Display(Name = "Expected Completion Date")]
        public string ExpectedCompletionDatestring { get; set; }

        [Display(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "CreatedAt")]
        public string CreatedAtstring { get; set; }

        [Display(Name = "UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "UpdatedAt")]
        public string UpdatedAtstring { get; set; }
    } 
    #endregion
}
