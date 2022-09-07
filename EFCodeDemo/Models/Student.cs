using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFCodeDemo.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudID { get; set; }
        public string StudName { get; set; }
        public string City { get; set; }
    }
    public class DacDbContext : DbContext
    {
        public DacDbContext() : base(@"data source=ACTSB14;initial catalog=DACDB;user id=sa;password=cdacacts")
        {
        }
        public DbSet<Student> students { get; set; }
         
    }
}
