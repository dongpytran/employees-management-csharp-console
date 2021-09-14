using _14_QLNhanVienPandGListObject;
using _14_QLNhanVienPandGObject;
using _14_QLNhanVienPandGObject.PG1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace _14_QLNhanVienPandG
{
    class Program
    {
        //
        #region XmlFileName
        public static string xmlNhanVienName = "DsNhanVien.xml";
        public static string xmlDonViName = "DsDonVi.xml";
        public static string xmlPhongBanName = "DsPhongBan.xml";
        public static string xmlBangLuongName = "BangLuong.xml";
        #endregion
        //
        #region Global Xml Url Variables
        public static string urlDonViXml = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../XmlData/" + xmlDonViName));
        public static string urlPhongBanXml = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../XmlData/" + xmlPhongBanName));
        public static string urlNhanVienXml = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../XmlData/" + xmlNhanVienName));
        public static string urBangLuongXml = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"../../../XmlData/" + xmlBangLuongName));
        #endregion
        //
        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine();
                Console.WriteLine("***********************************");
                Console.WriteLine("* Nhap vao:                       *");
                Console.WriteLine("* 1. Quan ly thong tin don vi     *");
                Console.WriteLine("* 2. Quan ly thong tin phong ban  *");
                Console.WriteLine("* 3. Quan ly thong tin nhan vien  *");
                Console.WriteLine("* 4. Quan ly bang luong nhan vien *");
                Console.WriteLine("* 0. Thoat                        *");
                Console.WriteLine("***********************************");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        if (urlDonViXml == null)
                        {
                            Console.WriteLine("Nhap/Dan duong dan luu file xml Danh sach Don Vi vao day: ");
                            urlDonViXml = Console.ReadLine();
                        }
                        int donViOption;
                        bool check = false;
                        ListDonVi listDonVi = new ListDonVi();
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("******************************************");
                            Console.WriteLine("* 1. Doc Du Lieu Don Vi Tu File Xml      *");
                            Console.WriteLine("* 2. Xuat du lieu                        *");
                            Console.WriteLine("* 3. Them don vi                         *");
                            Console.WriteLine("* 4. Sua don vi                          *");
                            Console.WriteLine("* 5. Xoa don vi                          *");
                            Console.WriteLine("* 6. Tim kiem don vi                     *");
                            Console.WriteLine("* 7. Thay doi duong dan file xml         *");
                            Console.WriteLine("* 0. Thoat                               *");
                            Console.WriteLine("******************************************");
                            donViOption = Convert.ToInt32(Console.ReadLine());
                            switch (donViOption)
                            {
                                case 1:
                                    try
                                    {
                                        listDonVi.DocFile(urlDonViXml);
                                        Console.WriteLine("Doc danh sach don vi thanh cong!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        listDonVi.DocFile(urlDonViXml);
                                        listDonVi.Xuat();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 3:
                                    try
                                    {
                                        listDonVi.DocFile(urlDonViXml);
                                        check = listDonVi.Them(urlDonViXml);
                                        if (check)
                                        {
                                            Console.WriteLine("Them thong tin don vi thanh cong!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Them thong tin don vi that bai!");
                                        }
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 4:
                                    try
                                    {
                                        listDonVi.DocFile(urlDonViXml);
                                        check = listDonVi.Sua(urlDonViXml);
                                        if (check)
                                        {
                                            Console.WriteLine("Sua thong tin don vi thanh cong!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sua thong tin don vi that bai!");
                                        }
                                    }
                                    catch(Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 5:
                                    try
                                    {
                                        listDonVi.DocFile(urlDonViXml);
                                        check = listDonVi.Xoa(urlDonViXml);
                                        if (check)
                                        {
                                            Console.WriteLine("Xoa thong tin don vi thanh cong!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Xoa thong tin don vi that bai!");
                                        }
                                    }catch(Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    
                                    break;
                                case 6:
                                    
                                    try
                                    {
                                        listDonVi.DocFile(urlDonViXml);
                                        DonVi dv = listDonVi.TimKiem(urlDonViXml);
                                        if (dv != null)
                                        {
                                            Console.WriteLine("Tim thay 1 ket qua: ");
                                            dv.Xuat();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Khong tim thay ket qua nao!");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 7:
                                    Console.WriteLine("Nhap/Dan duong dan luu file xml Danh sach Don Vi vao day: ");
                                    urlDonViXml = Console.ReadLine();
                                    break;
                                default:
                                    break;
                            }
                        } while (donViOption > 0);
                        break;
                    case 2:
                        //Quan Ly Phong Ban Code Here
                        if (urlPhongBanXml == null)
                        {
                            Console.WriteLine("Nhap/Dan duong dan luu file xml Danh sach Phong Ban vao day: ");
                            urlPhongBanXml = Console.ReadLine();
                        }
                        int phongBanOption;
                        ListPhongBan listPhongBan = new ListPhongBan();
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("*********************************************");
                            Console.WriteLine("* 1. Doc Du Lieu Phong Ban Tu File Xml      *");
                            Console.WriteLine("* 2. Xuat du lieu                           *");
                            Console.WriteLine("* 3. Them phong ban                         *");
                            Console.WriteLine("* 4. Sua phong ban                          *");
                            Console.WriteLine("* 5. Xoa phong ban                          *");
                            Console.WriteLine("* 6. Tim kiem phong ban                     *");
                            Console.WriteLine("* 7. Thay doi duong dan file xml            *");
                            Console.WriteLine("* 0. Thoat                                  *");
                            Console.WriteLine("******************************************");
                            phongBanOption = Convert.ToInt32(Console.ReadLine());
                            switch (phongBanOption)
                            {
                                case 1:
                                    try
                                    {
                                        listPhongBan.DocFile(urlPhongBanXml);
                                        Console.WriteLine("Doc danh sach phong ban thanh cong!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        listPhongBan.DocFile(urlPhongBanXml);
                                        listPhongBan.Xuat();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 3:
                                    try
                                    {
                                        check = listPhongBan.Them(urlPhongBanXml);
                                        if (check)
                                        {
                                            Console.WriteLine("Them thong tin phong ban thanh cong!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Them thong tin phong ban that bai!");
                                        }
                                    }
                                    catch(Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }

                                    break;
                                case 4:
                                    try
                                    {
                                        check = listPhongBan.Sua(urlPhongBanXml);
                                        if (check)
                                        {
                                            Console.WriteLine("Sua thong tin phong ban thanh cong!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sua thong tin phong ban that bai!");
                                        }
                                    }
                                    catch(Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 5:
                                    try
                                    {
                                        check = listPhongBan.Xoa(urlPhongBanXml);
                                        if (check)
                                        {
                                            Console.WriteLine("Xoa thong tin phong ban thanh cong!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Xoa thong tin phong ban that bai!");
                                        }
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 6:
                                    try
                                    {
                                        PhongBan pb = listPhongBan.TimKiem(urlPhongBanXml);
                                        if (pb != null)
                                        {
                                            Console.WriteLine("Tim thay 1 ket qua: ");
                                            pb.Xuat();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Khong tim thay ket qua nao!");
                                        }
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 7:
                                    Console.WriteLine("Nhap/Dan duong dan luu file xml Danh sach Phong Ban vao day: ");
                                    urlPhongBanXml = Console.ReadLine();
                                    break;
                                default:
                                    break;
                            }
                        } while (phongBanOption > 0);
                        break;
                    case 3:
                        if (urlNhanVienXml == null)
                        {
                            Console.WriteLine("Nhap/Dan duong dan luu file xml Danh sach Nhan Vien vao day: ");
                            urlNhanVienXml = Console.ReadLine();
                        }
                        int nvOption;
                        ListNhanVien listNv = new ListNhanVien();
                        do
                        {
                            Console.WriteLine("1. Doc Du Lieu Nhan Vien Tu File Xml");
                            Console.WriteLine("2. Xuat du lieu (1, 2, 3)");
                            Console.WriteLine("3. Them Nhan Vien");
                            Console.WriteLine("4. Sua Nhan Vien");
                            Console.WriteLine("5. Xoa Nhan Vien");
                            Console.WriteLine("6. Tim kiem Nhan Vien");
                            Console.WriteLine("7. Dem So Nhan Vien Tung Cong Ty");
                            Console.WriteLine("8. Dem So Nhan Vien Moi Vao Trong Tung Cong Ty");
                            Console.WriteLine("9. Thay doi duong dan file xml");
                            Console.WriteLine("0. Thoat");
                            nvOption = Convert.ToInt32(Console.ReadLine());
                            string manv = "";
                            switch (nvOption) {
                                case 1:
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        Console.WriteLine("Doc danh sach nhan vien thanh cong!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 2:
                                    int xuatOption;
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        do
                                        {
                                            Console.WriteLine("Nhap Kieu Xuat: ");
                                            Console.WriteLine("1. Xuat Ngan Gon Thong Tin Co Ban");
                                            Console.WriteLine("2. Xuat Thong Tin Co Ban Va Ngay Vao Lam");
                                            Console.WriteLine("3. Xuat Day Du Tat Ca Cac Thong Tin Nhan Vien");
                                            Console.WriteLine("0. Thoat");
                                            xuatOption = Convert.ToInt32(Console.ReadLine());
                                            if ((xuatOption == 1 || xuatOption == 2 || xuatOption == 3) && xuatOption != 0)
                                            {
                                                listNv.Xuat(xuatOption);
                                            }
                                        } while (xuatOption > 0);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                   
                                    break;
                                case 3:
                                    int companyOption;
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        do
                                        {
                                            Console.WriteLine("Chon Cong Ty Can Them Nhan Vien: ");
                                            Console.WriteLine("1. Cong Ty P&G 1");
                                            Console.WriteLine("2. Cong Ty P&G 2");
                                            Console.WriteLine("3. Cong Ty P&G 3");
                                            Console.WriteLine("0. Thoat");
                                            companyOption = Convert.ToInt32(Console.ReadLine());

                                            switch (companyOption)
                                            {
                                                case 1:
                                                    int pg1Option;
                                                    do
                                                    {
                                                        Console.WriteLine("1. Them Nhan Vien San Xuat (PG1)");
                                                        Console.WriteLine("2. Them Nhan Vien Kinh Doanh (PG1)");
                                                        Console.WriteLine("3. Them Nhan Vien Quan Ly (PG1)");
                                                        Console.WriteLine("0. Thoat");
                                                        pg1Option = Convert.ToInt32(Console.ReadLine().Trim());
                                                        if (pg1Option == 0)
                                                        {
                                                            break;
                                                        }
                                                        else if (pg1Option != 1 && pg1Option != 2 && pg1Option != 3)
                                                        {
                                                            Console.WriteLine("Lua Chon Khong Dung!");
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                listNv.Them(urlNhanVienXml, pg1Option);
                                                                Console.WriteLine("Them Nhan Vien Thanh Cong!");
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine("Them Nhan Vien That Bai! Loi: {0}", ex.ToString());
                                                            }
                                                        }
                                                    } while (pg1Option > 0);
                                                    break;
                                                case 2:
                                                    //PG2 THEM
                                                    try
                                                    {
                                                        if (listNv.Them(urlNhanVienXml, 4))
                                                        {
                                                            Console.WriteLine("Them Nhan Vien Thanh Cong!");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Them Nhan Vien That Bai!");
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Them Nhan Vien That Bai! Loi: {0}", ex.ToString());
                                                    }

                                                    break;
                                                case 3:
                                                    //PG3 THEM
                                                    try
                                                    {
                                                        if (listNv.Them(urlNhanVienXml, 5))
                                                        {
                                                            Console.WriteLine("Them Nhan Vien Thanh Cong!");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Them Nhan Vien That Bai!");
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Them Nhan Vien That Bai! Loi: {0}", ex.ToString());
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        } while (companyOption > 0);
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 4:
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        Console.WriteLine("Nhap Ma Nhan Vien Can Sua Thong Tin: ");
                                        manv = Console.ReadLine();
                                        listNv.Sua(urlNhanVienXml, manv.Trim());
                                        Console.WriteLine("Sua Thong Tin Nhan Vien thanh cong!");
                                    }
                                    catch(Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    //Sua
                                    break;
                                case 5:
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        listNv.Xoa(urlNhanVienXml);
                                        Console.WriteLine("Xoa Nhan Vien thanh cong!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    //Xoa
                                    break;
                                case 6:
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        Console.WriteLine("Nhap Ma Nhan Vien Muon Tim: ");
                                        manv = Console.ReadLine();
                                        NhanVien nv = listNv.TimKiem(urlNhanVienXml, manv.Trim());
                                        if (nv != null)
                                        {
                                            Console.WriteLine("------------------------------------------");
                                            Console.WriteLine("- Tim thay 1 nhan vien co ma: {0}", manv);
                                            nv.Xuat(2);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Khong Tim Thay Nhan Vien Nao Voi Ma: {0}", manv);
                                        }
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    //Tim
                                    break;
                                case 7:
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        listNv.DemSoNhanVienMoiCty();
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 8:
                                    try
                                    {
                                        listNv.DocFile(urlNhanVienXml);
                                        Console.WriteLine("Nhap Thang Can Xem So Nhan Vien Moi: ");
                                        int thang = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Nhap Nam Can Xem So Nhan Vien Moi: ");
                                        int nam = Convert.ToInt32(Console.ReadLine());
                                        listNv.DemSoNhanVienMoi(thang, nam);
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 9:
                                    Console.WriteLine("Nhap/Dan duong dan luu file xml Danh sach Nhan Vien vao day: ");
                                    urlNhanVienXml = Console.ReadLine();
                                    break;
                                default:
                                    break;
                            }
                        } while (nvOption > 0);
                        break;
                    case 4:
                        if (urlNhanVienXml == null)
                        {
                            Console.WriteLine("Nhap/Dan duong dan luu file xml Danh sach nhan vien vao day: ");
                            urlNhanVienXml = Console.ReadLine();
                        }
                        if (urBangLuongXml == null) {
                            Console.WriteLine("Nhap/Dan duong dan luu file xml Bang Luong vao day: ");
                            urBangLuongXml = Console.ReadLine();
                        }
                        int luongOption;
                        ListLuong bangLuong = new ListLuong();
                        do
                        {
                            Console.WriteLine("1. Xuat Bang Luong Hang Thang Cua Tung Cong Ty");
                            Console.WriteLine("2. Xuat Bang Luong Theo Thang Nam Nhap Vao Cua Ca 3 Cong Ty");
                            Console.WriteLine("3. Xuat Thong Tin Danh Gia Thi Dua Cua Toan Bo Nhan Vien");
                            Console.WriteLine("   , Dem So Nhan Vien Khong Dat \"Nang Luc Tot\"");
                            Console.WriteLine("4. Xuat Cac Nhan Vien Khong La Chien Si Thi Dua (Khong Co Nang Luc Tot)");
                            Console.WriteLine("5. Xuat Thong Tin Top 3 Nhan Vien Moi Cong Ty Co Luong Cao Nhat");
                            Console.WriteLine("6. Thay doi duong dan file xml");
                            Console.WriteLine("0. Thoat");
                            luongOption = Convert.ToInt32(Console.ReadLine());
                            int thangNhapVao;
                            int namNhapVao;
                            switch (luongOption) {
                                case 1:
                                    try
                                    {
                                        bangLuong.DocFile(urBangLuongXml);
                                        Console.WriteLine("Nhap Vao Nam Can Xem Bang Luong: ");
                                        namNhapVao = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Nhap vao thang trong nam {0} can xem Bang Luong: ", namNhapVao);
                                        thangNhapVao = Convert.ToInt32(Console.ReadLine());
                                        bangLuong.XuatBangLuongTrongThang(urBangLuongXml, thangNhapVao, namNhapVao);
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Nhap Vao Nam Can Xem Bang Luong: ");
                                        namNhapVao = Convert.ToInt32(Console.ReadLine());
                                        bangLuong.XuatBangLuongHangThang(urBangLuongXml, namNhapVao);
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Nhap vao nam can xem: ");
                                        namNhapVao = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                        Console.WriteLine("----- Thong Tin Danh Gia Thi Dua Nam: {0} ------", namNhapVao);
                                        Console.WriteLine();
                                        bangLuong.XuatAllThiDua(urBangLuongXml, namNhapVao, urlNhanVienXml, 0);
                                        Console.WriteLine();
                                        bangLuong.DemSoNhanVienKhongCoNangLucTot(namNhapVao);
                                        Console.WriteLine();
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 4:
                                    try
                                    {
                                        Console.WriteLine("Nhap vao nam can xem: ");
                                        namNhapVao = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                        Console.WriteLine("----- Danh Sach Cac Nhan Vien Khong La Chien Si Thi Dua Nam: {0} ------", namNhapVao);
                                        Console.WriteLine();
                                        bangLuong.XuatAllThiDua(urBangLuongXml, namNhapVao, urlNhanVienXml, 1);
                                        Console.WriteLine();
                                    }
                                    catch(Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 5:

                                    try
                                    {
                                        Console.WriteLine("Nhap Vao Nam Can Xem: ");
                                        namNhapVao = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Nhap vao thang trong nam {0} can xem: ", namNhapVao);
                                        thangNhapVao = Convert.ToInt32(Console.ReadLine());
                                        bangLuong.XuatTop3(urBangLuongXml, namNhapVao, thangNhapVao);
                                    }
                                    catch (Exception ex) {
                                        Console.WriteLine("Loi doc file xml, duong dan khong dung! \n" + ex.ToString().Substring(0, 500) + "...");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine("Nhap/Dan duong dan luu file xml Bang Luong vao day: ");
                                    urBangLuongXml = Console.ReadLine();
                                    break;
                                default:
                                    break;
                            }
                        } while (luongOption > 0);
                        break;
                }
            } while (option > 0);
        }
    }
}
