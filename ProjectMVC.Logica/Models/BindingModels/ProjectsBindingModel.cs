﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Logica.Models.BindingModels
{
    public class ProjectsCreateBindingModel
    {
        [Required(ErrorMessage = "The field Title is rquired")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Details is rquired")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field Expected Completion Date is rquired")]
        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }
    }

    public class ProjectsEditBindingModel
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

        [Required(ErrorMessage = "The field Expected Completion Date is rquired")]
        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }
    }
}
