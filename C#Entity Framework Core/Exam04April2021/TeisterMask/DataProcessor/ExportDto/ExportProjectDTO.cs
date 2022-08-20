using System.Linq;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDTO
    {
        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlElement("Tasks")]
        public ExportProjectTasksDTO[] Tasks { get; set; }

        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }
    }
}
