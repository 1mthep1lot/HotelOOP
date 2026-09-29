namespace HotelOOP;

internal class Department
{
    public string Name { get; set; }
    public Employee Manager { get; set; }
    public List<Employee> Employees { get; } = new List<Employee>();
    public List<Department> Subdepartments { get; } = new List<Department>();

    public Department(string name, Employee manager = null)
    {
        Name = name;
        Manager = manager;
    }

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        Employees.Remove(employee);
    }

    public void AddSubdepartment(Department department)
    {
        Subdepartments.Add(department);
    }

    public void PrintOrganizationChart(int level = 0)
    {
        string indent = new string(' ', level * 2);
        Console.WriteLine($"{indent}{Name} (Manager: {Manager?.Name ?? "Not assigned"})");

        foreach (var employee in Employees)
        {
            Console.WriteLine($"{indent}  - {employee.Name} ({employee.JobTitle})");
        }

        foreach (var subdepartment in Subdepartments)
        {
            subdepartment.PrintOrganizationChart(level + 1);
        }
    }
}
