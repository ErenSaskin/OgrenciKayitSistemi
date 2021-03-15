namespace OgrenciKayitSistemi.Models
{
    public interface IStudentBuilder
    {
        public void BuildMail();
        public void BuildClass();
        public void BuildNumber(int count);
        public Student Result();
    }
}
