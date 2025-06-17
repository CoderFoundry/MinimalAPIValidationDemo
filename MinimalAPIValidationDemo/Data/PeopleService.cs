using System;
using System.Text.Json;
using MinimalAPIValidationDemo.Models;

namespace MinimalAPIValidationDemo.Data;    

public class PeopleService
{
  private readonly List<Person> _people = [];

  public PeopleService()
  {
    var mockData = File.ReadAllText("Data/people.json");
    _people = JsonSerializer.Deserialize<List<Person>>(mockData, JsonSerializerOptions.Web) ?? [];
  }

  public List<Person> GetPeople(string? searchTerm = null)
  {
    return string.IsNullOrWhiteSpace(searchTerm)
        ? _people
        : [.. _people.Where(p => $"{p.FirstName} {p.LastName}".Contains(searchTerm, StringComparison.OrdinalIgnoreCase))];
  }

  public void AddPerson(Person person)
  {
    if (!_people.Contains(person))
    {
      _people.Add(person);
    }
  }

}
