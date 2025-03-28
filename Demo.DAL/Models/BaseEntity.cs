using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    //Base Entity Which All Of Entity Will Be Inherited From Base for common Props
    public class BaseEntity
    {
        public int Id { get; set; } //PK
        public int CreatedBy { get; set; } //User Id
        public DateTime? CreatedOn { get; set; } //Time Of create //Default Value 
        public int LastModifiedBy { get; set; } //User ID
        public DateTime? LastModifiedOn { get; set; } //Time Of create [Automaticlly Created]
        public bool IsDeleted { get; set; } //Soft Delete


    }
}
