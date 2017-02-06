namespace WhenItsDone.DTOs.MedicalInformationDTOs
{
    public class MedicalInformationFullDTO
    {
        public int Id { get; set; }
        
        public int? BustSizeInCm { get; set; }
        
        public int? WaistSizeInCm { get; set; }
        
        public int? HipSizeInCm { get; set; }
        
        public int? HeightInCm { get; set; }
        
        public int? WeightInKg { get; set; }

        public int BMI { get; set; }
    }
}
