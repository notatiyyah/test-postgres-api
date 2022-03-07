using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresTest.V1.Infrastructure
{
    [Table("users")]
    public class UserDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
    }
}
