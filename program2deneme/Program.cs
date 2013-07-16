using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace program2deneme
{
    class Program//Tüm Hakları Saklıdır. Şefika EFEOĞLU 05100000099
    {
        static void Main(string[] args)//program sınıfımız
        {
            char cevap;
            do
            {
                Console.Beep(1988, 15);//bipleme
                Console.WriteLine("\t\tOtel Rezervasyon Programına Hoş Geldiniz!!!!");
                Console.Write("\t\tOtel Sayısını Giriniz:");
                Konuk konukerişim = new Konuk();
                int otelsayısı = Convert.ToInt32(Console.ReadLine());
                Otel[] Otellistesi = new Otel[otelsayısı];//oteller dizisi
                int toplam = 0;
                Otel erisimnesnesi = new Otel(15);//erişim nesnesi
                toplam = erisimnesnesi.Otelbilgilerialma(Otellistesi, otelsayısı);
                int N;
                do
                {
                    Console.Beep(1988, 15);//bipleme
                    Console.WriteLine("\t\tKonferans'a Gelecek Olan Konuk Sayısını Giriniz");
                    N = Convert.ToInt32(Console.ReadLine());
                } while (N > toplam || N < 2);
                Konuk[] konuklistesi = new Konuk[N];
                konukerişim.çoklu_misafirbilgilerioluştur(konuklistesi, N);//konuk üretimi yapar
                erisimnesnesi.oteleyerleştirme(Otellistesi, toplam, N, konuklistesi, otelsayısı);//konukları yerleştirir
                Console.Beep(1988, 15);//bipleme
                Console.WriteLine("Yeni işlelem yapmak ister misiniz?(Cevap : evet için (E/e) hayır için (H/h) !!");
                Console.Beep(1988, 15);//bipledi
                cevap = Convert.ToChar(Console.ReadLine());
            } while (cevap == 'E' || cevap == 'e');
            Console.WriteLine("\t\t******************Şefika EFEOĞLU*********05100000099***************");
            Console.ReadKey();
        }
    }
}
