﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace assignment2.Models
{
    [Table("employees")]
    [Index(nameof(LastName), Name = "last_name")]
    [Index(nameof(PostalCode), Name = "postal_code")]
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
            InverseReportsToNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Column("title")]
        [StringLength(30)]
        public string Title { get; set; }
        [Column("title_of_courtesy")]
        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }
        [Column("birth_date", TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column("hire_date", TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [Column("address")]
        [StringLength(60)]
        public string Address { get; set; }
        [Column("city")]
        [StringLength(15)]
        public string City { get; set; }
        [Column("region")]
        [StringLength(15)]
        public string Region { get; set; }
        [Column("postal_code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Column("country")]
        [StringLength(15)]
        public string Country { get; set; }
        [Column("home_phone")]
        [StringLength(24)]
        public string HomePhone { get; set; }
        [Column("extension")]
        [StringLength(4)]
        public string Extension { get; set; }
        [Column("notes", TypeName = "ntext")]
        public string Notes { get; set; }
        [Column("reports_to")]
        public int? ReportsTo { get; set; }
        [Column("photo_path")]
        [StringLength(255)]
        public string PhotoPath { get; set; }

        [ForeignKey(nameof(ReportsTo))]
        [InverseProperty(nameof(Employee.InverseReportsToNavigation))]
        public virtual Employee ReportsToNavigation { get; set; }
        [InverseProperty(nameof(EmployeeTerritory.Employee))]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        [InverseProperty(nameof(Employee.ReportsToNavigation))]
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
        [InverseProperty(nameof(Order.Employee))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
