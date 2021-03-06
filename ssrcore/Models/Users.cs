﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ssrcore.Models
{
    public partial class Users
    {
        public Users()
        {
            Comment = new HashSet<Comment>();
            FcmToken = new HashSet<FcmToken>();
            Notification = new HashSet<Notification>();
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        [StringLength(450)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(11)]
        public string Phonenumber { get; set; }
        [StringLength(450)]
        public string Address { get; set; }
        public string Photo { get; set; }
        [Required]
        [StringLength(10)]
        public string RoleId { get; set; }
        public bool DelFlg { get; set; }
        [Required]
        [StringLength(50)]
        public string InsBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InsDatetime { get; set; }
        [Required]
        [StringLength(50)]
        public string UpdBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdDatetime { get; set; }
        [StringLength(11)]
        public string UserNo { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; }
        [InverseProperty("StaffNavigation")]
        public virtual Staff Staff { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Comment> Comment { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<FcmToken> FcmToken { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Notification> Notification { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
