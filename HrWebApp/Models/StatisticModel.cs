using HrWebApp.Data;

namespace HrWebApp.Models
{
    public class StatisticModel
    {
        public int StudentId { get; set; }
        public int VacancyId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public double StudentProfilScore { get; set; }
        public string? VacancyTitle { get; set; }
        public List<StatisticModel> StudInfos { get; set; }
        public List<StatisticModel>? Statistics { get; set; }
    }
}
