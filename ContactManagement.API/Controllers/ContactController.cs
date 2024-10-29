using CMA.Model;
using ContactManagement.Repository.Interface;
using ContactMangement.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManagement.API.Controllers
{

    [Route("Contact")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetContacts")]
        public async Task<IEnumerable<ContactDTO>> GetContactList(int page = 1, int pageSize = 10)
        {

            return await _contactRepository.GetContactList(page, pageSize);
        }
        [HttpGet("GetContactById")]
        public async Task<ContactDTO> GetContactById(int contactId)
        {

            return await _contactRepository.GetContactById(contactId);
        }

        [HttpPost("AddContact")]
        public async Task<bool> AddContact([FromBody] ContactDTO contact)
        {
            return await _contactRepository.AddContact(contact);
        }

        [HttpPut("UpdateContact")]
        public async Task<ContactDTO> UpdateContact([FromBody] ContactDTO contact)
        {
            return await _contactRepository.UpdateContact(contact);
        }

        [HttpDelete("DeleteContact")]
        public async Task<ContactDTO> DeleteContact(int Id)
        {
            return await _contactRepository.DeleteContact(Id);
        }
        

    }
}
