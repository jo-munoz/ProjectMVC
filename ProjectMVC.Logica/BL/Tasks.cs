using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectMVC.Logica.BL
{
    public class Tasks
    {
        /// <summary>
        /// GET TASKS
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Models.DB.Tasks> GetTasks(int? projectId,
                                                int? id)
        {
            DAL.Models.ProjectMVCEntities _context = new DAL.Models.ProjectMVCEntities();

            var listTasks = (from _tasks in _context.Tasks
                             join _states in _context.States on _tasks.StateId equals _states.Id
                             join _activities in _context.Activities on _tasks.ActivityId equals _activities.Id
                             join _priorities in _context.Priorities on _tasks.PriorityId equals _priorities.Id
                             select new Models.DB.Tasks
                             {
                                 Id = _tasks.Id,
                                 Title = _tasks.Title,
                                 Details = _tasks.Details,
                                 ExpirationDate = _tasks.ExpirationDate,
                                 IsCompleted = _tasks.IsCompleted,
                                 Effort = _tasks.Effort,
                                 RemainingWork = _tasks.RemainingWork,
                                 ProjectId = _tasks.ProjectId,
                                 ActivityId = _tasks.ActivityId,
                                 Activities = new Models.DB.Activities
                                 {
                                     Name = _activities.Name
                                 },
                                 PriorityId = _tasks.PriorityId,
                                 Priorities = new Models.DB.Priorities
                                 {
                                     Name = _priorities.Name
                                 },
                                 StateId = _tasks.StateId,
                                 States = new Models.DB.States
                                 {
                                     Name = _states.Name
                                 }
                             }).ToList();

            if (projectId != null)
            {
                listTasks = listTasks.Where(x => x.ProjectId == projectId).ToList();
            }

            if (id != null)
            {
                listTasks = listTasks.Where(x => x.Id == id).ToList();
            }

            return listTasks;
        }
        
        /// <summary>
        /// CREATE TASKS        
        /// </summary>
        /// <param name="title"></param>
        /// <param name="details"></param>
        /// <param name="expirationDate"></param>
        /// <param name="isCompleted"></param>
        /// <param name="effort"></param>
        /// <param name="remainingWork"></param>
        /// <param name="statedId"></param>
        /// <param name="activityId"></param>
        /// <param name="prioritId"></param>
        /// <param name="projectId"></param>
        public void CreateTasks(string title,
                                string details,
                                DateTime? expirationDate,
                                bool isCompleted,
                                int? effort,
                                int? remainingWork,
                                int? statedId,
                                int? activityId,
                                int? prioritId,
                                int? projectId)
        {
            DAL.Models.ProjectMVCEntities _context = new DAL.Models.ProjectMVCEntities();

            _context.Tasks.Add(new DAL.Models.Tasks
            {
                Title = title,
                Details = details,
                ExpirationDate = expirationDate,
                IsCompleted = isCompleted,
                Effort = effort,
                RemainingWork = remainingWork,
                StateId = statedId,
                ActivityId = activityId,
                PriorityId = prioritId,
                ProjectId = projectId
            });
            _context.SaveChanges();
        }
    }
}
