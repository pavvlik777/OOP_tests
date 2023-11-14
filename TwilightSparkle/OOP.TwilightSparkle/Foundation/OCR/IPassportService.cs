namespace OOP.TwilightSparkle.Foundation.OCR
{
    public interface IPassportService
    {
        string ReadMachineReadingZoneData(byte[] passportImage);
    }
}