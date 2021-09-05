public class Person
{
    string Name;
    string Surname;
    int Age;
}

public IEnumerable<Person> GetPersons(int pageIndex, int pageSize, string sortBy, int minAge, int maxAge, string sortBy, int minAge, int maxAge)
{
    var allPersons = _context.GetPersons();
    allPersons = allPersons.Skip(pageIndex * pageSize - 1);
    allPersons = allPersons.Take(pageSize);
    if (!string.IsNullOrWhiteSpace(sortBy))
    {
        System.Reflection.PropertyInfo prop = typeof(YourType).GetProperty(sortBy);
        allPersons = allPersons.OrderBy(p => prop.GetValue(p));
    }
    if (minAge != 0)
    {
        allPersons = allPersons.where(p => p.Age >= minAge);
    }
    if (maxAge != 0)
    {
        allPersons = allPersons.where(p => p.Age <= maxAge);
    }

    return allPersons.ToArray();
}