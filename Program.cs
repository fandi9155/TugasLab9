using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tugasLab9
{

    class Program
    {

        static void Main(string[] args)
        {
            List<Karyawan> karyawan = new List<Karyawan>();

            KaryawanTetap karyawanTetap = new KaryawanTetap();
            karyawanTetap.NIK = "1121";
            karyawanTetap.Nama = "agustian";
            karyawanTetap.GajiBulanan = 9000000;

            KaryawanHarian karyawanHarian = new KaryawanHarian();
            karyawanHarian.NIK = "2111";
            karyawanHarian.Nama = "Dimastian";
            karyawanHarian.UpahPerJam = 85000;
            karyawanHarian.JumlahJamKerja = 5;

            Sales sales = new Sales();
            sales.NIK = "2131";
            sales.Nama = "Basir alhidaya";
            sales.JumlahPenjualan = 7;
            sales.Komisi = 60000;

            karyawan.Add(karyawanTetap);
            karyawan.Add(karyawanHarian);
            karyawan.Add(sales);

            Menu(karyawan);
        }

        static void Menu(List<Karyawan> karyawan)
        {
            bool status = true;

            do
            {
                Console.Clear();
                Console.WriteLine("");

                Console.WriteLine("Silahkan Pilih: ");
                Console.WriteLine("1. Tambah Data\n");
                Console.WriteLine("2. Hapus Data \n");
                Console.WriteLine("3. Tampilkan Data \n");
                Console.WriteLine("4. Keluar \n");

                Console.WriteLine("");

            InvalidOption:
                string opt;
                Console.Write("Masukkan Pilihan [1-4]: ");
                opt = Console.ReadLine();


                if (opt == "1")
                {
                    TambahData(karyawan);
                    BalikMenu();
                }
                else if (opt == "2")
                {
                    HapusData(karyawan);
                    BalikMenu();
                }
                else if (opt == "3")
                {
                    TampilkanData(karyawan);
                    BalikMenu();
                }
                else if (opt == "4")
                {
                    Console.WriteLine("Terima Kasih");
                    Thread.Sleep(2000);
                    status = false;
                }
                else
                {
                    Console.WriteLine("Pilihan tidak ada");
                    goto InvalidOption;
                }

            } while (status);
        }

        static void TambahData(List<Karyawan> karyawan)
        {
            Console.Clear();

            Console.WriteLine("=====================================");
            Console.WriteLine("========== TAMBAH KARYAWAN ==========");
            Console.WriteLine("=====================================");
            Console.WriteLine("\nSilahkan Pilih Jenis Karyawan: ");
            Console.WriteLine("1. Karyawan Tetap \n");
            Console.WriteLine("2. Karyawan Harian \n");
            Console.WriteLine("3. Sales");

        InvalidOption:
            string opt;
            Console.Write("Masukkan Pilihan [1-3]: ");
            opt = Console.ReadLine();

            Console.WriteLine();

            if (opt == "1")
            {

                KaryawanTetap karyawanTetap = new KaryawanTetap();


                Console.WriteLine("Tambah Karyawan Tetap");

                Console.Write("Masukkan NIK \t\t: ");
                karyawanTetap.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t: ");
                karyawanTetap.Nama = Console.ReadLine();

                Console.Write("Masukkan Gaji Bulanan \t: ");
                karyawanTetap.GajiBulanan = Convert.ToDouble(Console.ReadLine());

                // Menambahkan Data
                karyawan.Add(karyawanTetap);

            }
            else if (opt == "2")
            {
                KaryawanHarian karyawanHarian = new KaryawanHarian();


                Console.WriteLine("Tambah Karyawan Harian");

                Console.Write("Masukkan NIK \t\t: ");
                karyawanHarian.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t: ");
                karyawanHarian.Nama = Console.ReadLine();

                Console.Write("Masukkan Upah per Jam \t: ");
                karyawanHarian.UpahPerJam = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan Jam Kerja \t: ");
                karyawanHarian.JumlahJamKerja = Convert.ToDouble(Console.ReadLine());

                karyawan.Add(karyawanHarian);

            }
            else if (opt == "3")
            {
                Sales sales = new Sales();

                Console.WriteLine("Tambah Karyawan Harian");

                Console.Write("Masukkan NIK \t\t: ");
                sales.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t: ");
                sales.Nama = Console.ReadLine();

                Console.Write("Masukkan Jml Penjualan \t: ");
                sales.JumlahPenjualan = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan Komisi \t: ");
                sales.Komisi = Convert.ToDouble(Console.ReadLine());

                karyawan.Add(sales);
            }
            else
            {
                Console.WriteLine("Pilihan tidak ada, silahkan masukkan lagi");
                goto InvalidOption;
            }
        }

        static void HapusData(List<Karyawan> karyawan)
        {
            Console.Clear();

            Console.WriteLine("=====================================");
            Console.WriteLine("======== HAPUS DATA KARYAWAN ========");
            Console.WriteLine("=====================================");

            bool found = true;

            string nik;
            Console.Write("\nMasukkan NIK Karyawan: ");
            nik = Console.ReadLine();

            for (int i = 0; i < karyawan.Count; i++)
            {
                if (karyawan[i].NIK == nik)
                {
                    karyawan.Remove(karyawan[i]);
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }
            }

            if (!found)
            {
                Console.WriteLine("Data tidak dengan NIK = {0} tidak ditemukan", nik);
            }
            else
            {
                Console.WriteLine("Data dengan NIK = {0} berhasil dihapus", nik);
            }
        }

        static void TampilkanData(List<Karyawan> karyawan)
        {

            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine(" NO | NIK / NAMA\t\t | Gaji\t\t |");
            Console.WriteLine("==================================================");
            for (int i = 0; i < karyawan.Count; i++)
            {

                Console.WriteLine(" {0}. | {1} {2} \t\t | {3} \t |", i + 1, karyawan[i].NIK, karyawan[i].Nama, karyawan[i].Gaji());
            }


        }

        static void BalikMenu()
        {
            Console.WriteLine("\nTekan P untuk kembali ke menu awal");
            Console.ReadKey();
        }
    }
}