﻿using ProjectManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class Project : IProject
    {
        public Project(string name, DateTime startingDate, DateTime endingDate, string state)
        {
            this.Name = name;
            this.StartingDate = startingDate;
            this.EndingDate = endingDate;
            this.State = state;
            this.Users = new List<IUser>();
            this.Tasks = new List<ITask>();
        }

        [Required(ErrorMessage = "Project Name is required!")]
        public string Name { get; set; }

        [Range(typeof(DateTime), "1800-1-1", "2017-1-1", ErrorMessage = "Project StartingDate must be between 1800-1-1 and 2017-1-1!")]
        public DateTime StartingDate { get; set; }

        [Range(typeof(DateTime), "2018-1-1", "2144-1-1", ErrorMessage = "Project EndingDate must be between 2018-1-1 and 2144-1-1!")]
        public DateTime EndingDate { get; set; }

        public string State { get; set; }

        public List<ITask> Tasks { get; set; }

        public List<IUser> Users { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Name: " + this.Name);
            builder.AppendLine("  Starting date: " + this.StartingDate.ToString("yyyy-MM-dd"));
            builder.AppendLine("  Ending date: " + this.EndingDate.ToString("yyyy-MM-dd"));
            builder.AppendLine("  State: " + this.State);
            builder.AppendLine("  Users: ");

            builder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Users));

            if (this.Users.Count == 0)
            {
                builder.AppendLine("  - This project has no users!");
            }

            builder.AppendLine("  Tasks: ");
            builder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Tasks));

            if (this.Tasks.Count == 0)
            {
                builder.Append("  - This project has no tasks!");
            }

            return builder.ToString();
        }
    }
}