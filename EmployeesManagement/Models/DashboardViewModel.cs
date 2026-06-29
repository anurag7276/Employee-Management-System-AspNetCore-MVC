namespace EmployeesManagement.Models
{
    public class DashboardViewModel
    {
        public int TotalEmployees { get; set; }

        public int TotalDepartments { get; set; }

        public int TotalDesignations { get; set; }

        public List<Employee> RecentEmployees { get; set; } = new();
    }

}
