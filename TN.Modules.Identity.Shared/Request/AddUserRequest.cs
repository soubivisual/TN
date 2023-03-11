using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Modules.Identity.Shared.Request
{
    public record AddUserRequest(
            Guid IdentificationTypeId,
            string Identification,
            string Name,
            string Username,
            string Email,
            string Phone,
            Guid TypeId,
            Guid StatusId,
            int AddedUserId,
            DateTime AddedDate);
}
