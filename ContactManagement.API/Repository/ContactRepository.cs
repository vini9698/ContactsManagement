using ContactManagement.Repository.Interface;
using ContactMangement.DTO;

using System.Text.Json;

namespace ContactManagement.Repository.Contact
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _filePath = "wwwroot/contacts.json";

        public async Task<bool> AddContact(ContactDTO contact)
        {
            var contacts = ReadContactsFromFile();
            // Auto-increment the ContactId
            contact.ContactId = contacts.Count > 0 ? contacts.Max(c => c.ContactId) + 1 : 1;


            // Add the new contact to the list
            contacts.Add(contact);
            WriteContactsToFile(contacts);
            return true;
        }

        public async Task<ContactDTO> DeleteContact(int Id)
        {
            var contacts = ReadContactsFromFile();

            // Find the contact by ID
            var contactToRemove = contacts.FirstOrDefault(c => c.ContactId == Id);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                WriteContactsToFile(contacts);
            }

            return contactToRemove;
        }

        public async Task<ContactDTO> GetContactById(int contactId)
        {
            var contacts =  ReadContactsFromFile();
            // Find the contact with the specified ContactId
            return contacts.FirstOrDefault(c => c.ContactId == contactId)??new ContactDTO();
        }

        public async Task<List<ContactDTO>> GetContactList(int page, int pageSize)
        {
            var contacts = ReadContactsFromFile();

            // Paginate the results
            var result = contacts.Skip((page - 1) * pageSize).Take(pageSize);
            return result.ToList();
        }

        public async Task<ContactDTO> UpdateContact(ContactDTO updatedContact)
        {
            var contacts = ReadContactsFromFile();

            // Find the contact by ID
            var contact = contacts.FirstOrDefault(c => c.ContactId == updatedContact.ContactId);
            if (contact != null)
            {
                // Update the contact details
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                contact.Email = updatedContact.Email;
                WriteContactsToFile(contacts);
            }
            return updatedContact;
        }
        private List<ContactDTO> ReadContactsFromFile()
        {
            if (File.Exists(_filePath))
            {
                // Read existing contacts from the JSON file
                var jsonData = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<ContactDTO>>(jsonData) ?? new List<ContactDTO>();
            }
            return new List<ContactDTO>();
        }
        private void WriteContactsToFile(List<ContactDTO> contacts)
        {
            // Read existing contacts from the JSON file
            var jsonData = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);

        }
    }
}
