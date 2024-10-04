using Core.Enums;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

#region #Common

public abstract class BaseEntity
{
    public long Id { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; }
}
public abstract class BaseAuditableEntity : BaseEntity
{
    public long CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public long UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
}

#endregion

#region #MainCategory
public class MainCatagory :BaseAuditableEntity
{
    [Required(ErrorMessage = "Maincategory is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Maincategory must be between 1 and 100 characters.")]
    public string Name { get; set; } = string.Empty;    
}

#endregion

#region #User
public class Users : BaseAuditableEntity
{

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 50 characters.")]

    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 50 characters.")]

    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email Id is required.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Email Id must be between 5 and 100 characters.")]

    public string EmailId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mobile number is required.")]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "Mobile number must be between 10 and 15 characters.")]

    public string MobileNo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
    [NoSpaces]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role is required.")]
    [ValidEnum<Roles>()]
    public Roles Role { get; set; }
}

public class UserWithToken
{
    public int UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

#endregion