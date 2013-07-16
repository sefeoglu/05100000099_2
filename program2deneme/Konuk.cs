using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace program2deneme
{
    class Konuk
    {
        private string konukisim;//gerekli saha
        private string konuksoyad;//gerekli saha
        private string dil;//gerekli saha
        public string ozelisim
        {//getter-setter
            get { return konukisim; }
            set { konukisim = value; }
        }
        public string konuksoyisim
        {//getter-setter
            get { return konuksoyad; }
            set { konuksoyad = value; }
        }
        public string dilozellik
        {//getter-setter
            get { return dil; }
            set { dil = value; }
        }
        public Konuk()//yapıcı metot
        { }
        public Konuk(string isim, string soyad, string dili)//yapıcı metot
        {
            konukisim = isim;
            konuksoyad = soyad;
            dil = dili;
        }
        public void Konuk_Oluştur(Konuk konuk, Random Rd)//konuk olusturan metot
        {
            string[] adlar = { "Osman", "Vecdi", "Aybars", "Mustafa", "Cenk", "Özgür", "Serdar", "Hasan", "Okan", "Aylin", "Sinem", "Deniz","Nesrin",//konuk isim listesi
                              "Zeynep","Özge","Ecem" ,"Bahar","Melike","Gizem","Esra"};
            string[] soyad = { "ÜNALIR", "AYTAÇ", "UĞUR", "ERDUR", "ATEŞ", "BAŞAR", "BULUT", "BURSA", "KANTARCI", "ÖREN", "KIVRAK", "UZUN", "GÖKKAYA",//konuk soyad listesi
                              "ERTEN", "YILDIZ", "KAYAN", "TURAN", "ŞİMŞEK", "GÖREL","GEZMİŞ" };
            string[] diller = { "TR", "ENG", "GER", "FRE", "JAB", "CHN", "RUS" };//konuk diller listesi
            int isim = Rd.Next(0, 20);
            int soy = Rd.Next(0, 20);
            int dl = Rd.Next(0, 7);
            konuk.ozelisim = adlar[isim];//konuk bilgileri atama
            konuk.dilozellik = diller[dl];
            konuk.konuksoyisim = soyad[soy];
        }
        public void çoklu_misafirbilgilerioluştur(Konuk[] konuklistesi, int N) //konuklar üreten metot
        {
            int[] a = new int[7];
            Random Rd = new Random();
            for (int i = 0; i < N; i++)//konnuk nesnelerine adres atama
            {
                konuklistesi[i] = new Konuk();
                Konuk_Oluştur(konuklistesi[i], Rd);
            }
            do
            {
                listesıfırlama(a);
                a = arama(konuklistesi, N, a);
                for (int k = 0; k < 7; k++)//listede 1 tane olanları yeniden üretti
                {
                    if (a[k] != 0)
                        Konuk_Oluştur(konuklistesi[a[k] - 1], Rd);
                }
            } while (listesıfırmı(a) == 1);
        }
        public int listesıfırmı(int[] a)//liste sıfırmı kontrolu listede 1 tane olan konuk yoksa
        {
            int bulundu = 0;
            for (int k = 0; k < a.Length; k++)
            {
                if (a[k] != 0)
                    bulundu = 1;
            }
            return bulundu;
        }
        public void yazdır(Konuk misafir)//tek bir konuk yazdırma metotu
        {
            Console.WriteLine("ad: " + misafir.konukisim + "soyad:" + misafir.konuksoyad + "dili:" + misafir.dilozellik);
        }
        public int[] arama(Konuk[] konuklistesi, int liste_uzunlugu, int[] liste)//1 tane olan konukların indisini diziye atar
        {

            int k = 0;
            for (int i = 0; i < liste_uzunlugu; i++)
            {
                int bulundu = 0;
                for (int j = 0; j < liste_uzunlugu; j++)
                {
                    if (konuklistesi[i].dilozellik == konuklistesi[j].dilozellik && i != j)//eşit ise
                    {
                        bulundu = 1;
                        break;
                    }
                }
                if (bulundu == 0)
                {
                    liste[k] = i + 1;
                    k++;
                }
            }
            return liste;
        }
        public void listesıfırlama(int[] a)//dizinin elemanlaırnı sıfırlama yapar
        {
            for (int i = 0; i < 7; i++)
            {
                a[i] = new int();
                a[i] = 0;
            }
        }
    }
}
