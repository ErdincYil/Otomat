namespace Otomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] urunler = new string[50];
            int[] fiyat = new int[50];
            int UrunSayisi = 3;
            int GunSonuSatıs = 0;

            urunler[0] = "Fanta"; fiyat[0] = 40;
            urunler[1] = "Kola"; fiyat[1] = 40;
            urunler[2] = "Çikolata"; fiyat[2] = 30;

            while (true)
            {
                Console.WriteLine("1-Müşteri Ekranı");
                Console.WriteLine("2-Admin Paneli");
                Console.WriteLine("3-Çıkış");
                int ModSecim = Convert.ToInt32(Console.ReadLine());

                if (ModSecim == 1)
                {
                    for (int i = 0; i < UrunSayisi; i++)
                    {
                        Console.WriteLine((i + 1) + "-" + urunler[i] + "-" + fiyat[i] + "TL");
                    }
                    int UrunSecimi = Convert.ToInt32(Console.ReadLine());
                    if (UrunSecimi > 0 && UrunSecimi <= UrunSayisi)
                    {
                        int index = UrunSecimi - 1;
                        int UrunFiyati = fiyat[index];

                        Console.WriteLine("Yatırılacak Para:");
                        int YatirilanPara = Convert.ToInt32(Console.ReadLine());
                        while (true)
                        {
                            if (YatirilanPara == UrunFiyati)
                            {
                                Console.WriteLine("Afiyet Olsun");
                                GunSonuSatıs += UrunFiyati;
                                break;
                            }
                            else if (YatirilanPara > UrunFiyati)
                            {
                                int ParaUstu = YatirilanPara - UrunFiyati;
                                Console.WriteLine("Afiyet Olsun Para Üstünü Almayı Unutmayın Para Üstünüz:" + ParaUstu);
                                GunSonuSatıs += UrunFiyati;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Yetersiz Bakiye");
                                Console.WriteLine("Para Yatırmak İçin 1, Para İadesi İçin 2'ye Basın.");
                                int OdemeSecim = Convert.ToInt32(Console.ReadLine());

                                if (OdemeSecim == 1)
                                {
                                    Console.WriteLine("Yatırılacak Tutarı Girin:");
                                    int yatan = Convert.ToInt32(Console.ReadLine());
                                    YatirilanPara += yatan;
                                }
                                else if (OdemeSecim == 2)
                                {
                                    int iade = YatirilanPara;
                                    Console.WriteLine("Para İadeniz Yapılıyor:" + iade);
                                    break;

                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Geçersiz Ürün Numarası");
                    }
                }
                else if (ModSecim == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("1-Ekle");
                        Console.WriteLine("2-Güncelle");
                        Console.WriteLine("3-Sil");
                        Console.WriteLine("4-Listele");
                        Console.WriteLine("0-Geri");
                        int AdminSecim = Convert.ToInt32(Console.ReadLine());

                        if (AdminSecim == 1)
                        {
                            if (UrunSayisi < 50)
                            {
                                Console.Write("Yeni ürün adı: ");
                                urunler[UrunSayisi] = Console.ReadLine();
                                Console.Write("Yeni ürün fiyatı: ");
                                fiyat[UrunSayisi] = Convert.ToInt32(Console.ReadLine());
                                UrunSayisi++;
                            }
                            else
                            {
                                Console.WriteLine("Makine kapasitesi dolu");
                            }
                        }
                        else if (AdminSecim == 2)
                        {
                            for (int i = 0; i < UrunSayisi; i++)
                                Console.WriteLine((i + 1) + ". " + urunler[i] + " - " + fiyat[i] + " TL");

                            Console.Write("Güncellenecek ürün numarası: ");
                            int guncelIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (guncelIndex >= 0 && guncelIndex < UrunSayisi)
                            {
                                Console.Write("Yeni ad: ");
                                urunler[guncelIndex] = Console.ReadLine();
                                Console.Write("Yeni fiyat: ");
                                fiyat[guncelIndex] = Convert.ToInt32(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz numara");
                            }
                        }
                        else if (AdminSecim == 3)
                        {
                            for (int i = 0; i < UrunSayisi; i++)
                                Console.WriteLine((i + 1) + ". " + urunler[i] + " - " + fiyat[i] + " TL");

                            Console.Write("Silinecek ürün numarası: ");
                            int silIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (silIndex >= 0 && silIndex < UrunSayisi)
                            {
                                for (int i = silIndex; i < UrunSayisi - 1; i++)
                                {
                                    urunler[i] = urunler[i + 1];
                                    fiyat[i] = fiyat[i + 1];
                                }
                                UrunSayisi--;
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz numara");
                            }
                        }
                        else if (AdminSecim == 4)
                        {
                            for (int i = 0; i < UrunSayisi; i++)
                                Console.WriteLine((i + 1) + ". " + urunler[i] + " - " + fiyat[i] + " TL");
                            Console.WriteLine("Gün sonu satış: " + GunSonuSatıs + " TL");
                        }
                        else if (AdminSecim == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Lütfen Geçerli Bir Tercih Yapınız");
                        }
                    }
                }
                else if (ModSecim == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Lütfen Geçerli Bir Seçim Yapınız");
                }
            }
        }
    }
}
