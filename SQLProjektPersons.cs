using System;

namespace MiniProjektSQL.Models
{
    public class SQLProjektPerson
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public int Person_Id { get; set; }
        public string? person_name { get; set; }
        public string? project_name { get; set; }
        public int hours { get; set; }   
    }
}