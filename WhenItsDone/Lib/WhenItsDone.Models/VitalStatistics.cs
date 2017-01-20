namespace WhenItsDone.Models
{
    // https://en.wikipedia.org/wiki/Bust/waist/hip_measurements
    // Bust/waist/hip measurements
    public class VitalStatistics
    {
        public int Id { get; set; }

        public int BustSizeInCm { get; set; }

        public int WaistSizeInCm { get; set; }

        public int HipSizeInCm { get; set; }
    }
}
