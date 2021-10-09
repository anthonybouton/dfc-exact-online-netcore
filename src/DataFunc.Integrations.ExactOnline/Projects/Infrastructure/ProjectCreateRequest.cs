using System;

namespace DataFunc.Integrations.ExactOnline.Projects.Infrastructure
{
    public class ProjectCreateRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Guid Account { get; set; }
        public int Type { get; set; }
    }
}