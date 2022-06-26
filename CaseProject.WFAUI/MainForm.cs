using CaseProject.Business.Services.Abstract;
using CaseProject.Business.Services.Concrete;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CaseProject.WFAUI
{
    public partial class MainForm : Form
    {
        private const int MaximumMetinUzunluk = 1000;
        private const int TimerSaniyeBilgi = 3;
        private readonly IRandomTextService _randomTextService;
        private readonly IWordService _wordService;
        private PeriodicTimer periodicTimer;

        public MainForm(IRandomTextService randomTextService, IWordService wordService)
        {
            _randomTextService = randomTextService;
            _wordService = wordService;
           
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            //Kontrol işlemleri başarılı değilse işlemlerin başlamasına izin verilmemektedir.
            var kontrol = MetinUzunlukKontrol(txtRastgeleMetinUzunluk.Text);
            if (!kontrol)
                return;

            //Form elemanlarını kontrol etme işlemleri
            FormElemanlarininAktifPasifIslemleri(true);

            periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(TimerSaniyeBilgi));

            bool periodicWhileSuccess = true;
            //işlem iptal edilene kadar 3 sn aralıkla işlemlere devam et.
            while (await periodicTimer.WaitForNextTickAsync() && periodicWhileSuccess)
            {
                string rastgeleMetin = RastgeleMetinOlustur();

                txtOlusturulanRandomDeger.Text = rastgeleMetin;
                var result = await _wordService.AddRandomTextAsync(rastgeleMetin);
                if (!result.IsSuccess)
                {
                    periodicWhileSuccess = false;//işlem hatalı olursa işlemlere devam etmesini engellemek amacıyla oluşturulmuştur.
                    MessageBox.Show($"'{rastgeleMetin}' bilgisi eklenirken hata oluştu. Detay: {result.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            FormElemanlarininAktifPasifIslemleri(false);
            periodicTimer.Dispose();
        }

        private string RastgeleMetinOlustur()
        {
            int rastgeleMetinUzunluk = Convert.ToInt32(txtRastgeleMetinUzunluk.Text);
            var rastgeleMetin = _randomTextService.RastgeleMetinOlustur(rastgeleMetinUzunluk);
            rastgeleMetin = _randomTextService.MetninBasHarfiniBuyut(rastgeleMetin);
            return rastgeleMetin;
        }
        private bool MetinUzunlukKontrol(string girilenDeger)
        {
            try
            {
                Regex regex = new Regex(@"^\d+$");

                if (!regex.IsMatch(girilenDeger))
                {
                    MessageBox.Show("Rastgele oluşturulacak metin uzunluğu bilgisine sadece sayı girilebilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (Convert.ToInt32(girilenDeger) > MaximumMetinUzunluk)
                {
                    MessageBox.Show("Rastgele oluşturulacak metin uzunluğu bilgisine girilen sayı çok büyük, lütfen geçerli bir değer giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Rastgele oluşturulacak metin uzunluğu bilgisine ait bilgiler kontrol edilirken beklenmedik bir hata oluştu. Detay:{exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void FormElemanlarininAktifPasifIslemleri(bool isEnabled)
        {
            txtRastgeleMetinUzunluk.Enabled = !isEnabled;
            btnStart.Enabled = !isEnabled;
            btnStop.Enabled = isEnabled;
            txtOlusturulanRandomDeger.Text = isEnabled ? "" : "Oluşturlacak Rastgele Metin Buraya Yazılacaktır.";

            if (!isEnabled)
            {
                btnStart.Focus();
                txtOlusturulanRandomDeger.Enabled = false;
            }
            else
            {
                btnStop.Focus();
                txtOlusturulanRandomDeger.Enabled = true;
            }
        }
    }
}