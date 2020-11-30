using FluentValidation.Attributes;
using NTier.Core.Entity;
using NTier.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace NTier.Model.Entities
{
    [Validator(typeof(PersonValidator))]
    public class Person : CoreEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual List<Directory> Directories { get; set; }
        public virtual bool BirthDay => BirthDate.Day == DateTime.Now.Day && BirthDate.Month == DateTime.Now.Month;
    }
}
