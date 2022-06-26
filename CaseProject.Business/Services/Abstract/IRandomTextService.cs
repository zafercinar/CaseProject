namespace CaseProject.Business.Services.Abstract
{
    public interface IRandomTextService
    {
        string RastgeleMetinOlustur(int rastgeleMetinUzunluk);

        string MetninBasHarfiniBuyut(string metin);
    }
}
