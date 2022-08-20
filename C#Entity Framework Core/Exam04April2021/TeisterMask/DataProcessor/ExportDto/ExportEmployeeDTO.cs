namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmployeeDTO
    {
        public string Username { get; set; }
        public ExportEmployeeTasksDTO[] Tasks { get; set; }
    }
}
