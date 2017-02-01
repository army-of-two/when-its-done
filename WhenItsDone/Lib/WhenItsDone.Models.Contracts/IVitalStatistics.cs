namespace WhenItsDone.Models.Contracts
{
    // https://en.wikipedia.org/wiki/Bust/waist/hip_measurements
    // Bust/waist/hip measurements a.k.a. vital statistics ( according to wikipedia )
    public interface IVitalStatistics : IDbModel
    {
        int BustSizeInCm { get; set; }

        int WaistSizeInCm { get; set; }

        int HipSizeInCm { get; set; }
    }
}
