using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1.DATA.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hang",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "TenHang", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("b9db8c0c-bf87-4e16-bdd2-a9fee4b14b4a"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8272), null, null, "Adidas", null, null, false },
                    { new Guid("da7a593f-20e5-407e-85c6-4bb0a97f1a73"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8274), null, null, "Nike", null, null, false }
                });

            migrationBuilder.InsertData(
                table: "KhachHang",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "DiaChi", "Email", "GioiTinh", "MatKhau", "NgaySinh", "Sdt", "Ten", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("3f8c0eff-a06a-4b07-a449-8832c622290d"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8325), null, null, "1", "khachhang@gmail.com", true, "123456", new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8323), "1", "a", null, null, false },
                    { new Guid("f572907f-4e58-4ee3-b282-8100a3a2043f"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8329), null, null, "2", "khachhang01@gmail.com", true, "123456", new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8328), "2", "b", null, null, false }
                });

            migrationBuilder.InsertData(
                table: "MaGiamGia",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "Ma", "NgayBatdau", "NgayKetthuc", "PhanTramGiam", "SoLuong", "TrangThai", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("26a26949-1dfc-42cb-a54f-dbdb44d81685"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8349), null, null, "20", new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8347), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), 20, 7, 0, null, null, false },
                    { new Guid("71a005c0-0f56-4068-83e3-9c4cc3196b9b"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8351), null, null, "10", new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8350), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), 10, 13, 0, null, null, false },
                    { new Guid("c76e6a71-f991-4cab-ba0a-9d899f56a4c0"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8345), null, null, "30", new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8340), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), 30, 5, 0, null, null, false }
                });

            migrationBuilder.InsertData(
                table: "MauSac",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "TenMau", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("5e5f7d51-044f-4928-9aac-4a496c629231"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8288), null, null, "Đỏ", null, null, false },
                    { new Guid("7a6c0c50-fb67-44ea-9c62-ad0e0f67ab3c"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8286), null, null, "Xanh", null, null, false },
                    { new Guid("8d364a55-877f-45a5-9408-66afb8ab873f"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8291), null, null, "Trắng", null, null, false },
                    { new Guid("cfa013b0-34dc-44d5-a471-7c49a9ac167d"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8290), null, null, "Đen", null, null, false }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "KichCo", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("2d53402b-696d-4e6e-b95e-fb5f2a99c014"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8107), null, null, 41f, null, null, false },
                    { new Guid("3a218de7-0c55-4b70-a0d8-823195532b66"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8106), null, null, 40f, null, null, false },
                    { new Guid("560cd8d3-52cc-4204-9145-0a142cdac1fd"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8109), null, null, 42f, null, null, false },
                    { new Guid("9297a9b2-5c69-4b52-af99-57bbf137dcf1"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8104), null, null, 39f, null, null, false },
                    { new Guid("9b9a3a86-196e-4fb2-9300-a64784962d59"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8111), null, null, 43f, null, null, false },
                    { new Guid("cd27319d-468d-4189-99a4-b2da273492a3"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8097), null, null, 36f, null, null, false },
                    { new Guid("d43ed236-c9cf-4659-ba0d-f834bb316d39"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8100), null, null, 37f, null, null, false },
                    { new Guid("d6dc21e2-f1be-48ec-8f30-bd6bbc73daec"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8102), null, null, 38f, null, null, false }
                });

            migrationBuilder.InsertData(
                table: "GioHang",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "IdKH", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("87c18de0-9653-408e-9f7d-36b2f5a3d890"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8307), null, null, new Guid("f572907f-4e58-4ee3-b282-8100a3a2043f"), null, null, false },
                    { new Guid("9779e43b-fcfc-40a0-b778-fa6f4757fd55"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8305), null, null, new Guid("3f8c0eff-a06a-4b07-a449-8832c622290d"), null, null, false }
                });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "IdHang", "Ten", "TrangThai", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("01bf8a6c-d89a-4db2-9068-af277be488ae"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8251), null, null, new Guid("b9db8c0c-bf87-4e16-bdd2-a9fee4b14b4a"), "Giay 1", 1, null, null, false },
                    { new Guid("9a1b3786-d0d0-402a-bfd8-10db04f8e6ed"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8254), null, null, new Guid("da7a593f-20e5-407e-85c6-4bb0a97f1a73"), "Giay 2", 1, null, null, false }
                });

            migrationBuilder.InsertData(
                table: "SanphamChitiet",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "GiaBan", "IdMauSac", "IdSP", "MaSPChiTiet", "TenSPChiTiet", "TrangThai", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(7995), null, null, 200000m, new Guid("5e5f7d51-044f-4928-9aac-4a496c629231"), new Guid("9a1b3786-d0d0-402a-bfd8-10db04f8e6ed"), "SP2", "V2", 1, null, null, false },
                    { new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(7985), null, null, 100000m, new Guid("7a6c0c50-fb67-44ea-9c62-ad0e0f67ab3c"), new Guid("01bf8a6c-d89a-4db2-9068-af277be488ae"), "SP1", "V1", 1, null, null, false },
                    { new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8002), null, null, 200000m, new Guid("cfa013b0-34dc-44d5-a471-7c49a9ac167d"), new Guid("9a1b3786-d0d0-402a-bfd8-10db04f8e6ed"), "SP2", "V2", 1, null, null, false },
                    { new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(7998), null, null, 100000m, new Guid("8d364a55-877f-45a5-9408-66afb8ab873f"), new Guid("01bf8a6c-d89a-4db2-9068-af277be488ae"), "SP1", "V1", 1, null, null, false }
                });

            migrationBuilder.InsertData(
                table: "HinhAnh",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "IdSPCT", "LinkAnh", "TrangThai", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("b596d1db-4113-4ed7-99e2-fa96a945d23c"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8237), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), "C:\\Users\\Admin\\OneDrive\\Documents\\Desktop\\Project\\DATN_UD08\\4.CusView\\wwwroot\\img\\PRODUCT\\6.jpg", null, null, null, false },
                    { new Guid("e508ba75-5185-4ef4-b533-2099fff74a84"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8234), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), "C:\\Users\\Admin\\OneDrive\\Documents\\Desktop\\Project\\DATN_UD08\\4.CusView\\wwwroot\\img\\PRODUCT\\5.png", null, null, null, false }
                });

            migrationBuilder.InsertData(
                table: "SizeSanPham",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "DeleteByUserId", "DeleteDate", "IdSanPhamChiTiet", "IdSize", "SoLuong", "UpdateByUserId", "UpdateDate", "isDelete" },
                values: new object[,]
                {
                    { new Guid("0515437f-c4ab-4956-8b65-4f7d183b1620"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8142), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("3a218de7-0c55-4b70-a0d8-823195532b66"), 10, null, null, false },
                    { new Guid("06dd39cf-f6c7-4605-9d4a-b4f764c29c73"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8162), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("9297a9b2-5c69-4b52-af99-57bbf137dcf1"), 5, null, null, false },
                    { new Guid("101c81ee-1ca5-4570-be45-c453527fa9aa"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8174), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("cd27319d-468d-4189-99a4-b2da273492a3"), 10, null, null, false },
                    { new Guid("1030ea99-2996-4537-b301-3ff511199b66"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8189), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("560cd8d3-52cc-4204-9145-0a142cdac1fd"), 5, null, null, false },
                    { new Guid("289ce400-38f1-47fc-a5fc-dbf88bf2582e"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8155), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("d43ed236-c9cf-4659-ba0d-f834bb316d39"), 5, null, null, false },
                    { new Guid("4d38cd83-32ca-415b-8fbe-88b9a23489c5"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8194), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("cd27319d-468d-4189-99a4-b2da273492a3"), 10, null, null, false },
                    { new Guid("507812da-fb24-4429-b50f-c1f5c28d2cc5"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8176), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("d43ed236-c9cf-4659-ba0d-f834bb316d39"), 5, null, null, false },
                    { new Guid("57987315-cc58-4f70-918f-23858dcea978"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8203), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("3a218de7-0c55-4b70-a0d8-823195532b66"), 10, null, null, false },
                    { new Guid("5885a945-5722-4177-8fa7-d26b0dacf980"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8140), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("9297a9b2-5c69-4b52-af99-57bbf137dcf1"), 5, null, null, false },
                    { new Guid("5ee0fa3d-9ab6-490a-83ca-01021103412d"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8127), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("cd27319d-468d-4189-99a4-b2da273492a3"), 10, null, null, false },
                    { new Guid("69d226ff-ad05-477f-8aaf-d4e9c8785233"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8179), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("d6dc21e2-f1be-48ec-8f30-bd6bbc73daec"), 5, null, null, false },
                    { new Guid("69e6c908-ea91-4c4a-86f2-c5cb26ff9ee4"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8211), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("9b9a3a86-196e-4fb2-9300-a64784962d59"), 5, null, null, false },
                    { new Guid("6b5d160a-2812-4c8c-a63d-0a4535990221"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8150), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("9b9a3a86-196e-4fb2-9300-a64784962d59"), 5, null, null, false },
                    { new Guid("7378b6ec-8274-4186-8855-0cafc1ce5881"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8134), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("d43ed236-c9cf-4659-ba0d-f834bb316d39"), 5, null, null, false },
                    { new Guid("75c5f866-2e78-49bb-80bb-fcd9c7d662c8"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8166), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("2d53402b-696d-4e6e-b95e-fb5f2a99c014"), 5, null, null, false },
                    { new Guid("801a3395-42b9-4874-8144-7d98bd15122e"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8201), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("9297a9b2-5c69-4b52-af99-57bbf137dcf1"), 5, null, null, false },
                    { new Guid("a16d0a3a-97e9-4b41-8c6a-54e35cdeaca3"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8158), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("d6dc21e2-f1be-48ec-8f30-bd6bbc73daec"), 5, null, null, false },
                    { new Guid("a18febe6-0a68-44cb-8ca0-1514f5bb6d48"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8147), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("560cd8d3-52cc-4204-9145-0a142cdac1fd"), 5, null, null, false },
                    { new Guid("a8b2d347-1af2-4027-8c6c-f368e567675f"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8152), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("cd27319d-468d-4189-99a4-b2da273492a3"), 10, null, null, false },
                    { new Guid("b172bc46-4292-4013-b327-6b2e3def9513"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8164), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("3a218de7-0c55-4b70-a0d8-823195532b66"), 10, null, null, false },
                    { new Guid("bec142a2-48ab-4785-8295-63a08d7dbf99"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8145), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("2d53402b-696d-4e6e-b95e-fb5f2a99c014"), 5, null, null, false },
                    { new Guid("c5890b6f-463f-4ab3-9dba-cab55b32e929"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8182), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("9297a9b2-5c69-4b52-af99-57bbf137dcf1"), 5, null, null, false },
                    { new Guid("d09fd8b7-8263-4014-91d8-63ea9470a8de"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8137), null, null, new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"), new Guid("d6dc21e2-f1be-48ec-8f30-bd6bbc73daec"), 5, null, null, false },
                    { new Guid("daa1d08d-ec42-4db9-9c91-1ec72a7a7a09"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8186), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("2d53402b-696d-4e6e-b95e-fb5f2a99c014"), 5, null, null, false },
                    { new Guid("df277b8d-c5d0-4f62-9df1-9b60a896f634"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8191), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("9b9a3a86-196e-4fb2-9300-a64784962d59"), 5, null, null, false },
                    { new Guid("e0e5863b-7ae4-47d5-9a96-4c0f732af3f0"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8206), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("2d53402b-696d-4e6e-b95e-fb5f2a99c014"), 5, null, null, false },
                    { new Guid("e1cff87b-abd8-4bf0-a7ce-199bd2716fc0"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8209), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("560cd8d3-52cc-4204-9145-0a142cdac1fd"), 5, null, null, false },
                    { new Guid("ec43012e-0ca2-4379-bccf-abd59824b300"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8184), null, null, new Guid("ec94662b-535d-4599-b462-9951c727be51"), new Guid("3a218de7-0c55-4b70-a0d8-823195532b66"), 10, null, null, false },
                    { new Guid("efc5ffac-f3c6-4c13-a205-51cb97e7a99a"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8196), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("d43ed236-c9cf-4659-ba0d-f834bb316d39"), 5, null, null, false },
                    { new Guid("f10629ff-6d82-462d-9f28-a22ac96ff880"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8199), null, null, new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"), new Guid("d6dc21e2-f1be-48ec-8f30-bd6bbc73daec"), 5, null, null, false },
                    { new Guid("fbad9b0b-0e5a-43a0-8fc9-6aebc586420c"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8169), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("560cd8d3-52cc-4204-9145-0a142cdac1fd"), 5, null, null, false },
                    { new Guid("fe243159-e3d5-4e38-b4d5-875b908b1d73"), new Guid("8bbbf62b-f477-4009-b5d5-1ec7f550f00a"), new DateTime(2023, 7, 1, 1, 7, 5, 908, DateTimeKind.Local).AddTicks(8172), null, null, new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"), new Guid("9b9a3a86-196e-4fb2-9300-a64784962d59"), 5, null, null, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: new Guid("87c18de0-9653-408e-9f7d-36b2f5a3d890"));

            migrationBuilder.DeleteData(
                table: "GioHang",
                keyColumn: "Id",
                keyValue: new Guid("9779e43b-fcfc-40a0-b778-fa6f4757fd55"));

            migrationBuilder.DeleteData(
                table: "HinhAnh",
                keyColumn: "Id",
                keyValue: new Guid("b596d1db-4113-4ed7-99e2-fa96a945d23c"));

            migrationBuilder.DeleteData(
                table: "HinhAnh",
                keyColumn: "Id",
                keyValue: new Guid("e508ba75-5185-4ef4-b533-2099fff74a84"));

            migrationBuilder.DeleteData(
                table: "MaGiamGia",
                keyColumn: "Id",
                keyValue: new Guid("26a26949-1dfc-42cb-a54f-dbdb44d81685"));

            migrationBuilder.DeleteData(
                table: "MaGiamGia",
                keyColumn: "Id",
                keyValue: new Guid("71a005c0-0f56-4068-83e3-9c4cc3196b9b"));

            migrationBuilder.DeleteData(
                table: "MaGiamGia",
                keyColumn: "Id",
                keyValue: new Guid("c76e6a71-f991-4cab-ba0a-9d899f56a4c0"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("0515437f-c4ab-4956-8b65-4f7d183b1620"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("06dd39cf-f6c7-4605-9d4a-b4f764c29c73"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("101c81ee-1ca5-4570-be45-c453527fa9aa"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("1030ea99-2996-4537-b301-3ff511199b66"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("289ce400-38f1-47fc-a5fc-dbf88bf2582e"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("4d38cd83-32ca-415b-8fbe-88b9a23489c5"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("507812da-fb24-4429-b50f-c1f5c28d2cc5"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("57987315-cc58-4f70-918f-23858dcea978"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("5885a945-5722-4177-8fa7-d26b0dacf980"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("5ee0fa3d-9ab6-490a-83ca-01021103412d"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("69d226ff-ad05-477f-8aaf-d4e9c8785233"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("69e6c908-ea91-4c4a-86f2-c5cb26ff9ee4"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("6b5d160a-2812-4c8c-a63d-0a4535990221"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("7378b6ec-8274-4186-8855-0cafc1ce5881"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("75c5f866-2e78-49bb-80bb-fcd9c7d662c8"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("801a3395-42b9-4874-8144-7d98bd15122e"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("a16d0a3a-97e9-4b41-8c6a-54e35cdeaca3"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("a18febe6-0a68-44cb-8ca0-1514f5bb6d48"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("a8b2d347-1af2-4027-8c6c-f368e567675f"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("b172bc46-4292-4013-b327-6b2e3def9513"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("bec142a2-48ab-4785-8295-63a08d7dbf99"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("c5890b6f-463f-4ab3-9dba-cab55b32e929"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("d09fd8b7-8263-4014-91d8-63ea9470a8de"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("daa1d08d-ec42-4db9-9c91-1ec72a7a7a09"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("df277b8d-c5d0-4f62-9df1-9b60a896f634"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("e0e5863b-7ae4-47d5-9a96-4c0f732af3f0"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("e1cff87b-abd8-4bf0-a7ce-199bd2716fc0"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("ec43012e-0ca2-4379-bccf-abd59824b300"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("efc5ffac-f3c6-4c13-a205-51cb97e7a99a"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("f10629ff-6d82-462d-9f28-a22ac96ff880"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("fbad9b0b-0e5a-43a0-8fc9-6aebc586420c"));

            migrationBuilder.DeleteData(
                table: "SizeSanPham",
                keyColumn: "Id",
                keyValue: new Guid("fe243159-e3d5-4e38-b4d5-875b908b1d73"));

            migrationBuilder.DeleteData(
                table: "KhachHang",
                keyColumn: "Id",
                keyValue: new Guid("3f8c0eff-a06a-4b07-a449-8832c622290d"));

            migrationBuilder.DeleteData(
                table: "KhachHang",
                keyColumn: "Id",
                keyValue: new Guid("f572907f-4e58-4ee3-b282-8100a3a2043f"));

            migrationBuilder.DeleteData(
                table: "SanphamChitiet",
                keyColumn: "Id",
                keyValue: new Guid("51a13afd-08d1-4a20-a0e0-fb4447bd215d"));

            migrationBuilder.DeleteData(
                table: "SanphamChitiet",
                keyColumn: "Id",
                keyValue: new Guid("7aaf5675-683d-4608-9534-ea737a4247b3"));

            migrationBuilder.DeleteData(
                table: "SanphamChitiet",
                keyColumn: "Id",
                keyValue: new Guid("bcb53bdb-2f7e-4026-a5a3-09ff834562ad"));

            migrationBuilder.DeleteData(
                table: "SanphamChitiet",
                keyColumn: "Id",
                keyValue: new Guid("ec94662b-535d-4599-b462-9951c727be51"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("2d53402b-696d-4e6e-b95e-fb5f2a99c014"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("3a218de7-0c55-4b70-a0d8-823195532b66"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("560cd8d3-52cc-4204-9145-0a142cdac1fd"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("9297a9b2-5c69-4b52-af99-57bbf137dcf1"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("9b9a3a86-196e-4fb2-9300-a64784962d59"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("cd27319d-468d-4189-99a4-b2da273492a3"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("d43ed236-c9cf-4659-ba0d-f834bb316d39"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: new Guid("d6dc21e2-f1be-48ec-8f30-bd6bbc73daec"));

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "Id",
                keyValue: new Guid("5e5f7d51-044f-4928-9aac-4a496c629231"));

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "Id",
                keyValue: new Guid("7a6c0c50-fb67-44ea-9c62-ad0e0f67ab3c"));

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "Id",
                keyValue: new Guid("8d364a55-877f-45a5-9408-66afb8ab873f"));

            migrationBuilder.DeleteData(
                table: "MauSac",
                keyColumn: "Id",
                keyValue: new Guid("cfa013b0-34dc-44d5-a471-7c49a9ac167d"));

            migrationBuilder.DeleteData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: new Guid("01bf8a6c-d89a-4db2-9068-af277be488ae"));

            migrationBuilder.DeleteData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: new Guid("9a1b3786-d0d0-402a-bfd8-10db04f8e6ed"));

            migrationBuilder.DeleteData(
                table: "Hang",
                keyColumn: "Id",
                keyValue: new Guid("b9db8c0c-bf87-4e16-bdd2-a9fee4b14b4a"));

            migrationBuilder.DeleteData(
                table: "Hang",
                keyColumn: "Id",
                keyValue: new Guid("da7a593f-20e5-407e-85c6-4bb0a97f1a73"));
        }
    }
}
