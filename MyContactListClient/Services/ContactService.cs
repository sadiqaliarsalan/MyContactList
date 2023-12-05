using MyContactList.Common.Models;
using System.Net.Http.Json;

public class ContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Retrieves a list of all contacts from the server
    /// </summary>
    /// <returns>A task that represents the asynchronous operation and returns a list of contacts</returns>
    public async Task<List<Contact>> GetContactsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Contact>>("api/contacts/GetAllContacts");
    }

    /// <summary>
    /// Get a single contact by its id
    /// </summary>
    /// <param name="id">The id of the contact</param>
    /// <returns>A task that represents the asynchronous operation and returns the requested contact</returns>
    public async Task<Contact> GetContactAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/GetContact/{id}");
    }

    /// <summary>
    /// Updates a contact information on the server side
    /// </summary>
    /// <param name="contact">The contact information to update</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task UpdateContactAsync(Contact contact)
    {
        await _httpClient.PutAsJsonAsync($"api/contacts/{contact.Id}", contact);
    }
}
