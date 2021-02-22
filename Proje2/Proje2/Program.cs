using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Proje2
{
    class Program
    {
        public class Musteri
        {
            public String MusteriAdi;
            public int urunSayisi;

            public Musteri()
            {
                MusteriAdi = "";
                urunSayisi = 0;
            }

            public Musteri(String MusteriAdi,int urunSayisi)
            {
                this.MusteriAdi = MusteriAdi;
                this.urunSayisi = urunSayisi;
            }
            public String toString()
            {
                return "Musteri ismi=" + MusteriAdi + " Musterinin Urun Sayisi=" + urunSayisi;
            }
        }
        public static void ArrayListGenerator(String[] musteriIsmi,int[] urunAdeti)
        {
            List<String> musteriisimleri = musteriIsmi.ToList();
            List<int> urunAdetleri = urunAdeti.ToList();
            ArrayList musteriler = new ArrayList();
            Random random_integer = new Random();
            while (musteriisimleri.Count > 0)
            {
                int sayi = random_integer.Next(1, 6);
                if (musteriisimleri.Count < sayi)
                {
                    sayi = musteriisimleri.Count;
                }
                List<Musteri> musteriBilgileri = new List<Musteri>();
                for (int i = 0; i < sayi; i++)
                {
                    musteriBilgileri.Add(new Musteri(musteriisimleri[i], urunAdetleri[i]));
                }
                musteriler.Add(musteriBilgileri);
                musteriisimleri.RemoveRange(0, sayi);
                urunAdetleri.RemoveRange(0, sayi);
            }
            int gListCounter = 0;
            int musteriCounter = 0;
            foreach (List<Musteri> element in musteriler)
            {
                foreach (Musteri eleman in element)
                {
                    Console.WriteLine(eleman.toString());
                    musteriCounter++;
                }
                Console.WriteLine("End of Generic List");
                gListCounter++;
            }
            Console.WriteLine("------------");
            Console.WriteLine("Generic List sayisi= " + gListCounter);
            Console.WriteLine("Ortalama eleman sayisi= " + Convert.ToDouble(musteriCounter)/Convert.ToDouble(gListCounter));
        }
        public static void StackGenerator(String []musteriIsmi, int[] urunAdeti)
        {
            Stack musteriYigiti = new Stack();
            for (int i = 0; i < musteriIsmi.Length; i++)
            {
                musteriYigiti.Push(new Musteri(musteriIsmi[i], urunAdeti[i]));
            }
            int popCount = musteriYigiti.Count;
            for (int k = 0; k < popCount; k++)
            {
                foreach (Musteri element in musteriYigiti)
                {
                    Console.WriteLine(element.toString());
                }
                musteriYigiti.Pop();
                Console.WriteLine("---Pop'd---");
            }
        }
        public static void QueueGenerator(String[] musteriIsmi,int[] urunAdeti)
        {
            Queue<Musteri> musteriQueue = new Queue<Musteri>();
            for (int i = 0; i < musteriIsmi.Length; i++)
            {
                musteriQueue.Enqueue(new Musteri(musteriIsmi[i], urunAdeti[i]));
            }
            int dequeueCount = musteriQueue.Count;
            for (int k = 0; k < dequeueCount; k++)
            {
                foreach (Musteri element in musteriQueue)
                {
                    Console.WriteLine(element.toString());
                }
                musteriQueue.Dequeue();
                Console.WriteLine("---Dequeued---");
            }
        }
        //Urun sayisi azalan;
        public class AzalanPriorityQueue
        {
            private List<Musteri> data;

            public AzalanPriorityQueue()
            {
                this.data = new List<Musteri>();
            }
            public void Ekle(Musteri element)
            {
                data.Add(element);
            }
            public Musteri Sil()
            {
                Musteri max = data[0];
                int maxIndex = 0;
                for(int i=0; i<data.Count; i++)
                {
                    if (data[i].urunSayisi > max.urunSayisi)
                    {
                        max = data[i];
                        maxIndex = i;
                    }
                }
                data.RemoveAt(maxIndex);
                return max;
            }
            public Boolean bosMu()
            {
                if (data.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //Guncellenen
        public static void UpdatedQueueGenerator(String[] musteriIsmi, int[] urunAdeti)
        {
            Queue<Musteri> musteriQueue = new Queue<Musteri>();
            for (int i = 0; i < musteriIsmi.Length; i++)
            {
                musteriQueue.Enqueue(new Musteri(musteriIsmi[i], urunAdeti[i]));
            }
            int dequeueCount = musteriQueue.Count;
            double Kuyruk_islem_suresi = 0;
            double Kuyruk_bekleme_suresi = 0;
            double Kuyruk_toplam_bekleme = 0;
            for (int k = 0; k < dequeueCount; k++)
            {
                Musteri deleted_one = musteriQueue.Dequeue();
                Kuyruk_islem_suresi = Kuyruk_bekleme_suresi + deleted_one.urunSayisi;
                Kuyruk_bekleme_suresi = Kuyruk_islem_suresi;
                Kuyruk_toplam_bekleme += Kuyruk_islem_suresi;
            }
            Console.WriteLine("Kuyrukta ort islem süresi: " + Kuyruk_toplam_bekleme / dequeueCount);
        }
        //Urun sayisi artan;
        public class ArtanPriorityQueue
        {
            private List<Musteri> data;

            public ArtanPriorityQueue()
            {
                this.data = new List<Musteri>();
            }
            public void Ekle(Musteri element)
            {
                data.Add(element);
            }
            public Musteri Sil()
            {
                Musteri min = data[0];
                int minIndex = 0;
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].urunSayisi < min.urunSayisi)
                    {
                        min = data[i];
                        minIndex = i;
                    }
                }
                data.RemoveAt(minIndex);
                return min;
            }
            public Boolean bosMu()
            {
                if (data.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        static void Main(string[] args)
        {
            String[] musteriIsmi = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz" };
            int[] urunAdeti = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15 };
            ArrayListGenerator(musteriIsmi, urunAdeti);
            Console.WriteLine("-----------------");
            StackGenerator(musteriIsmi, urunAdeti);
            Console.WriteLine("-----------------");
            QueueGenerator(musteriIsmi, urunAdeti);
            Console.WriteLine("-----------------");
            AzalanPriorityQueue azalan_oncelikli_kuyruk = new AzalanPriorityQueue();
            for (int i = 0; i < musteriIsmi.Length; i++)
            {
                azalan_oncelikli_kuyruk.Ekle(new Musteri(musteriIsmi[i], urunAdeti[i]));
            }
            while (azalan_oncelikli_kuyruk.bosMu() == false)
            {
                Musteri azalan_deleted_one = azalan_oncelikli_kuyruk.Sil();
                Console.WriteLine("Bu Musteri Kuyruktan ayrildi:\n" + azalan_deleted_one.toString());
            }
            Console.WriteLine("-----------");
            
            ArtanPriorityQueue artan_oncelikli_kuyruk = new ArtanPriorityQueue();
            double bekleyen_musteri = musteriIsmi.Length;
            for (int i=0; i<musteriIsmi.Length; i++)
            {
                artan_oncelikli_kuyruk.Ekle(new Musteri(musteriIsmi[i], urunAdeti[i]));
            }
            double islem_suresi = 0;
            double bekleme_suresi = 0;
            double toplam_bekleme = 0;
            while (artan_oncelikli_kuyruk.bosMu()==false)
            {
                Musteri artan_deleted_one=artan_oncelikli_kuyruk.Sil();
                islem_suresi = bekleme_suresi+artan_deleted_one.urunSayisi;
                bekleme_suresi = islem_suresi;
                toplam_bekleme += islem_suresi;
                Console.WriteLine("Bu Musteri Kuyruktan ayrildi:\n" + artan_deleted_one.toString());
            }
            UpdatedQueueGenerator(musteriIsmi, urunAdeti);
            Console.WriteLine("Artan oncelikli kuyrukta ortalama islem suresi:" + toplam_bekleme / bekleyen_musteri);
            Console.ReadKey();
        }
    }
}
