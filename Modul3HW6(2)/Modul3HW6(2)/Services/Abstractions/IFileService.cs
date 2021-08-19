namespace Modul3HW6_2_.Services.Abstractions
{
    public interface IFileService
    {
        public void WriteToFile(string value);
        public void MakeBackUp();
    }
}
