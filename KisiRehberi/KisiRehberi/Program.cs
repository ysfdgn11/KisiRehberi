using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Serialization.Formatters;

namespace KisiRehberi
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Kisi> kisiler = new List<Kisi>();
            while (true)
            {
                Console.WriteLine("\n===  KİŞİ REHBERİ  ===");
                Console.WriteLine("1- Kişi Ekle");
                Console.WriteLine("2- Kişileri Listele");
                Console.WriteLine("3- Kişi Güncelle");
                Console.WriteLine("4- Kişi Sil");
                Console.WriteLine("0- Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Kisi yeniKisi = new Kisi();

                        Console.Write("AD: ");
                        yeniKisi.Ad = Console.ReadLine();
                        Console.Write("SOYAD: ");
                        yeniKisi.Soyad = Console.ReadLine();
                        Console.Write("TELEFON: ");
                        yeniKisi.Telefon = Console.ReadLine();
                        kisiler.Add(yeniKisi);
                        Console.WriteLine("Kişi eklendi.");
                        break;

                    case "2":
                        if (kisiler.Count == 0)
                        {
                            Console.WriteLine("Rehberde hiç kişi yok");
                        }
                        else
                        {
                            Console.WriteLine("\n=== Kişi Listesi ===");
                            int index = 1;
                            foreach (Kisi kisi in kisiler)
                            {
                                Console.WriteLine($"{index}. Ad: {kisi.Ad}, Soyad: {kisi.Soyad}, Telefon: {kisi.Telefon}");
                                index++;
                            }
                        }
                        break;

                    case "3":
                        if (kisiler.Count == 0)
                        {
                            Console.WriteLine("Rehberde hiç kişi yok");
                        }
                        else
                        {
                            Console.WriteLine("\n=== Kişi Listesi ===");
                            for (int i = 0; i < kisiler.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Ad: {kisiler[i].Ad}, Soyad: {kisiler[i].Soyad}, Telefon: {kisiler[i].Telefon}");
                            }

                            Console.Write("Güncellenecek Kişi Numarası Giriniz : ");
                            string input = Console.ReadLine();
                            int secilenIndex;

                            if (int.TryParse(input, out secilenIndex) && secilenIndex >= 1 && secilenIndex <= kisiler.Count)
                            {
                                Kisi guncellenecek = kisiler[secilenIndex - 1];

                                Console.Write("Yeni Ad (Boş bırakırsanız değişmez): ");
                                string yeniad = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(yeniad))
                                    guncellenecek.Ad = yeniad;

                                Console.Write("Yeni Soyad (Boş bırakırsanız değişmez): ");
                                string yenisoyad = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(yenisoyad))
                                    guncellenecek.Soyad = yenisoyad;

                                Console.Write("Yeni Telefon (Boş bırakırsanız değişmez): ");
                                string yenitelefon = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(yenitelefon))
                                    guncellenecek.Telefon = yenitelefon;

                                Console.WriteLine("Kişi başarıyla güncellendi.");
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz seçim!");
                            }
                        }
                        break;


                    case "4":
                        if (kisiler.Count == 0)
                        {
                            Console.WriteLine("Rehberde hiç kişi yok.");
                        }
                        else
                        {
                            Console.WriteLine("\n=== Kişi Listesi===");
                            for (int i = 0; i < kisiler.Count; i++)
                            {
                                Console.WriteLine($"{i +  1}. Ad: {kisiler[i].Ad}, Soyad: {kisiler[i].Soyad}, Telefon: {kisiler[i].Telefon}");
                            }
                            Console.Write("Silinecek kişi numarası girin: ");
                            string input = Console.ReadLine();
                            int secilenIndex;

                            if (int.TryParse(input, out secilenIndex) && secilenIndex >= 1 && secilenIndex <= kisiler.Count)
                            {
                                kisiler.RemoveAt(secilenIndex - 1);
                                Console.WriteLine("Kişi başarıyla silindi.");
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz seçim.");
                            }
                                
                                   
                                
                            
                        }

                        break;

                    case "0":
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Yanlış seçim yaptınız!");
                        break;
                }
            }
        }
    }
}
