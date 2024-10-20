using Entities;
using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represents business logic for manipulating Person entity
/// </summary>
public interface IPersonsService
{
    /// <summary>
    /// Adds a new person into the list of persons
    /// </summary>
    /// <param name="personAddRequest">Person to add</param>
    /// <returns>Returns the same person details, along with newly generated person id</returns>
    PersonResponse AddPerson(PersonAddRequest? personAddRequest);
    
    /// <summary>
    /// Returns all persons
    /// </summary>
    /// <returns>return a list of PersonResponse object</returns>
    List<PersonResponse> GetAllPersons();
}