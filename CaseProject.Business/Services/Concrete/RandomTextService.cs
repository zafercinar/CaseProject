using CaseProject.Business.Services.Abstract;
using System.Globalization;
using System.Text;

namespace CaseProject.Business.Services.Concrete
{
    public class RandomTextService : IRandomTextService
    {
        /// <summary>
        /// Büyük harflerde eklenebilir.
        /// </summary>
        private const string Alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";

        private readonly Random _random;
        
        public RandomTextService()
        {
            _random = new Random();
        }

        public string MetninBasHarfiniBuyut(string metin)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(metin);
        }
       
        public string RastgeleMetinOlustur(int rastgeleMetinUzunluk)
        {
            var rastgeleMetinBuilder = new StringBuilder();
            for (var i = 0; i < rastgeleMetinUzunluk; i++)
                rastgeleMetinBuilder.Append(Alfabe[_random.Next(Alfabe.Length)]);
            return rastgeleMetinBuilder.ToString();
        }
    }
}
