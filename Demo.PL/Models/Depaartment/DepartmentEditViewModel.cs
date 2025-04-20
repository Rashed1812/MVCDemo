namespace Demo.PL.Models.Depaartment
{
    public class DepartmentEditViewModel
    {
        //public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; }
        public string? Description { get; set; }
    }
}
