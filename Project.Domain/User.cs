﻿using Dapper.Contrib.Extensions;

namespace Project.Domain
{
    [Table("tb_user")]
    public class User
    {
        [Key]
        // [ExplicitKey] if column not auto increment else [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}