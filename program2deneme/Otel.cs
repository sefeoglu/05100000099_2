using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace program2deneme
{
    class Otel : Konuk
    {
        public Konuk[] konuklist;//sahalar
        private int sayısı;//"
        private string isimi;//""
        private int kalacak;//""
        private int eklenek;//""
        public int eklecekozl//ayarlama getter setter
        {
            get { return eklenek; }
            set { eklenek = value; }
        }
        public string isimayar//ayarlama getter setter
        {
            get { return isimi; }
            set { isimi = value; }
        }
        public int sayı_ayar//ayarlama getter setter
        {
            get { return sayısı; }
            set { sayısı = value; }
        }
        public int kalacak_ayar//ayarlama getter setter
        {
            get { return kalacak; }
            set { kalacak = value; }
        }
        public Otel(int kap)//yapıcı
        {
            konuklist = new Konuk[kap];
            for (int i = 0; i < kap; i++)
            {
                konuklist[i] = new Konuk();
            }
        }
        public Otel(int say, string ad, int kalan, Konuk[] kalacaklistesi, int ekleneceklersay, Konuk[] liste, int kap)//yapıcı
        {
            sayısı = say;
            isimi = ad;
            kalacak = kalan;
            Konuk[] konuklist = new Konuk[kap];
            for (int i = 0; i < kap; i++)
            {
                konuklist[i] = new Konuk();
                konuklist[i] = liste[i];
            }
        }
        public Otel()//yapıcı
        { }
        public int Otelbilgilerialma(Otel[] otellistesi, int sayı)//otelbiilgileirni kullanıcıdan alan metot
        {
            int toplam = 0;
            int kap;
            for (int i = 0; i < sayı; i++)//otel sayısı kadar döner
            {
                Console.Write("\n\t\t{0}.Otel Kontejanını Giriniz:", i + 1);
                kap = Convert.ToInt32(Console.ReadLine());
                otellistesi[i] = new Otel(kap);
                otellistesi[i].kalacak_ayar = kap;
                toplam += kap;
                Console.Write("\t\t{0}.Otel İsmini Giriniz:", i + 1);
                otellistesi[i].isimayar = Console.ReadLine();
            }
            return toplam;//toplam kontejanı döndürür
        }
        public void oteleyerleştirme(Otel[] Otellistesi, int toplam, int N, Konuk[] konuklistesi, int otelsayısı)//otele konukların yerleşmesi işlemini yapar
        {
            int k = 0;
            float yüzde = (float)N * 100 / toplam;//yüzdelik oranı bulur
            for (int i = 0; i < otelsayısı; i++)
            {
                for (int j = 0; j < Math.Floor(yüzde * Otellistesi[i].kalacak_ayar / 100); j++)
                {
                    Otellistesi[i].konuklist[j] = konuklistesi[k];
                    Otellistesi[i].eklecekozl++;
                    k++;
                    N--;
                    yazdir(Otellistesi[i].konuklist[j]);
                }
            }
            if (N > 0)//artan konukları büyükten küçüge dogru atar teker teker
            {
                int i = 0;
                Otellistesi = mevcuda_goresıralama(Otellistesi, otelsayısı);
                while (N != 0)
                {
                    if (Otellistesi[i].eklecekozl < Otellistesi[i].kalacak_ayar)
                    {
                        Otellistesi[i].konuklist[Otellistesi[i].eklenek] = konuklistesi[k];
                        Otellistesi[i].eklecekozl++;
                        N--;
                    }
                    k++;
                    i++;
                }
            }
            sonlistededüzen(Otellistesi, Otellistesi.Length);//dili gözeterek listeler
        }
        public Otel[] mevcuda_goresıralama(Otel[] oteller, int otelsayısı)
        {
            Otel gecici;
            for (int i = 0; i < otelsayısı; i++)
            {
                for (int j = 0; j < otelsayısı; j++)
                {
                    if (oteller[i].kalacak_ayar < oteller[j].kalacak_ayar)
                    {
                        gecici = oteller[i];
                        oteller[i] = oteller[j];
                        oteller[j] = gecici;
                    }
                }
            }
            return oteller;
        }
        public void yazdir(Konuk a)
        {
            if (a != null)
                Console.WriteLine("Bilgileri:" + a.ozelisim + "  " + a.konuksoyisim + "  " + a.dilozellik);
        }
        public void sonlistededüzen(Otel[] otellistesi, int otelsayısı)//otel listesini dile göre düzenleme 
        {
            Console.WriteLine("\t*************Yüzdelik Orana Göre Ayarlanmış Liste*************");
            topluyazdır(otellistesi);//% ye göre liste

            int[] liste = new int[7];
            listesıfırlama(liste);
            for (int i = 0; i < otelsayısı; i++)//dili ayarlamak için
            {
                liste = arama(otellistesi[i].konuklist, otellistesi[i].eklecekozl, liste);//otelde 1 tane o dilden olanları tutan dizi indisini tutuyor
                if (listesıfırmı(liste) != 0)//liste bos degilse
                {
                    for (int k = 0; k < 7; k++)//listedekiler otellere atılır
                    {
                        if (liste[k] != 0)//dizinin o elemanı dolu ise
                        {
                            listeyeatma(otellistesi[i].konuklist[liste[k] - 1], i, otellistesi, liste[k], otelsayısı);
                        }
                    }
                    listesıfırlama(liste);//dizi sıfırlanır yeni işlem için
                }
            }
            Console.WriteLine("\t**************Dile Göre Ayarlanmış Liste**********");
            topluyazdır(otellistesi);//son liste yazılır
        }
        public void listeyeatma(Konuk misafir, int otelno, Otel[] otelistesi, int indis, int otelsayısı)//otellere 1 basına kalan konuklar atanır :D
        {
            int bul = 0;
            for (int i = 0; i < otelsayısı; i++)
            {
                for (int j = 0; j < otelistesi[i].eklecekozl; j++)
                {
                    bul = 0; /*dilleri aynı ise*/
                    if (otelistesi[i].konuklist[j].dilozellik == otelistesi[otelno].konuklist[indis-1].dilozellik && otelno != i)//bulunur sa gerekli işlemler yapılır
                    {
                        if (otelistesi[i].eklecekozl == otelistesi[i].kalacak_ayar && otelistesi[otelno].eklecekozl < otelistesi[otelno].kalacak_ayar)
                        {
                            otelistesi[otelno].konuklist[otelistesi[otelno].eklecekozl] = otelistesi[i].konuklist[j];
                            otelistesi[otelno].eklecekozl++;
                            bul = 1;
                            listeyersonhal(otelistesi[i], j);
                        }
                        if (otelistesi[i].eklecekozl < otelistesi[i].kalacak_ayar)//otelde yer var ise
                        {
                            otelistesi[i].konuklist[otelistesi[i].eklecekozl] = otelistesi[otelno].konuklist[indis-1];
                            otelistesi[i].eklecekozl++;
                            bul = 1;
                            listeyersonhal(otelistesi[otelno], indis-1);
                        }
                    }
                    if (bul != 0) break;
                }
                if (bul != 0) break;
            }
        }
        public void topluyazdır(Otel[] otellistesi)//toplu olarak yazdırma işlemi yapılır
        {
            for (int i = 0; i < otellistesi.Length; i++)
            {
                Console.WriteLine("otel için konuk listesi:" + (i + 1) + "." + otellistesi[i].isimayar + " oteli");
                for (int j = 0; j < otellistesi[i].eklecekozl; j++)
                {
                    if (otellistesi[i].konuklist[j] != null)
                        yazdir(otellistesi[i].konuklist[j]);
                }
                Console.WriteLine("****************************");
            }
        }
        public void listeyersonhal(Otel a, int konukindis)//listede kaydırma işlemi yapılır çıkarma işleminden sonra
        {
            if (konukindis < a.eklecekozl - 1)
                for (int i = konukindis + 1; i < a.eklecekozl; i++)
                    a.konuklist[i - 1] = a.konuklist[i];
            a.eklecekozl--;
        }
    }
}