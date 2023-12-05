using Microsoft.AspNetCore.Mvc;
using MyContactList.Common.Models;
using MyContactList.Interfaces;

namespace MyContactList.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // Get all contacts
        [HttpGet]
        [Route("GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            var contacts = _contactRepository.GetAllContacts();
            if (contacts == null)
            {
                return NotFound("Contact are not found");
            }
            return Ok(contacts);
        }

        // Get a single contact by id
        [HttpGet]
        [Route("GetContact/{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return NotFound($"Contact is not found with id {id}");
            }
            return Ok(contact);
        }

        // Update a single contact by id
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, Contact contact)
        {
            var updatedContact = _contactRepository.UpdateContact(contact);
            if (updatedContact == null)
            {
                return NotFound($"Contact with id {id} not found");
            }

            return Ok(updatedContact);
        }
    }
}
