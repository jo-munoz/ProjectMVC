using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Logica.Models.BindingModels
{
    public class TasksCreateBindingModel
    {
        [Required(ErrorMessage = "The field Id is rquired")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field Title is rquired")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Details is rquired")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field Expiration Date is rquired")]
        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessage = "The field Is Completed is rquired")]
        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "The field Effort is rquired")]
        [Display(Name = "Effort")]
        public int? Effort { get; set; }

        [Required(ErrorMessage = "The field Remaining Work is rquired")]
        [Display(Name = "Remaining Work")]
        public int? RemainingWork { get; set; }

        [Required(ErrorMessage = "The field State is rquired")]
        [Display(Name = "State")]
        public int? StateId { get; set; }

        [Required(ErrorMessage = "The field Activity is rquired")]
        [Display(Name = "Activity")]
        public int? ActivityId { get; set; }

        [Required(ErrorMessage = "The field Priority is rquired")]
        [Display(Name = "Priority")]
        public int? PriorityId { get; set; }

        [Required(ErrorMessage = "The field Project is rquired")]
        [Display(Name = "Project")]
        public int? ProjectId { get; set; }
    }
}
