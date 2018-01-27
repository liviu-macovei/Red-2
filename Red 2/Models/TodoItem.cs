using System;
using System.ComponentModel.DataAnnotations;

namespace Red_2.Models
{
    public class TodoItem
    {
        private DateTime? _dateCreated;
        public int Id { get; set; }

        [Required] public string Description { get; set; }

        public DateTime Created
        {
            get => _dateCreated ?? DateTime.Now;

            set => _dateCreated = value;
        }

        [Required] public bool IsDone { get; set; }
    }
}