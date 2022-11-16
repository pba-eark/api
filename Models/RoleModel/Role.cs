﻿namespace pba_api.Models.RoleModel
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public double HourlyWage { get; set; }

        public virtual ICollection<TaskModel.Task> Tasks { get; set; }
    }
}