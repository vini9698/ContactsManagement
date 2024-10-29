using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ContactMangement.DTO;

namespace ContactManagement.Repository.Interface
{
    public interface IContactRepository
    {
        Task<ContactDTO> GetContactById(int contactId);
        Task<List<ContactDTO>> GetContactList(int page, int pageSize);
        Task<bool> AddContact(ContactDTO contact);
        Task<ContactDTO> UpdateContact(ContactDTO contact);
        Task<ContactDTO> DeleteContact(int Id);
    }
}
