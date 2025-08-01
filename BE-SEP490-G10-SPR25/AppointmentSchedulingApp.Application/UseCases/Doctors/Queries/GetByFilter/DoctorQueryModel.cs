namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetByFilter
{
    public  class DoctorQueryModel
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; } = null!;

        public string? AcademicTitle { get; set; }

        public string Degree { get; set; }

        public string? CurrentWork { get; set; }

        public string DoctorDescription { get; set; }

        public string[] SpecialtyNames { get; set; }

        public int NumberOfService { get; set; }

        public int NumberOfExamination { get; set; }

        public double Rating { get; set; } = 0;

        public int RatingCount { get; set; } = 0;
    }
}
