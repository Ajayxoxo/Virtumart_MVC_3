using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Virtumart_MVC_3.Migrations
{
    /// <inheritdoc />
    public partial class UpdateuserInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrls_ProductInfos_ProductInfoProductId",
                table: "ImageUrls");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrls_productinfo_ProductId",
                table: "ImageUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageUrls",
                table: "ImageUrls");

            migrationBuilder.RenameTable(
                name: "ImageUrls",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "imageurl",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "imageurl",
                newName: "imageid");

            migrationBuilder.RenameColumn(
                name: "ImageUrlPath",
                table: "imageurl",
                newName: "imageurl");

            migrationBuilder.RenameIndex(
                name: "IX_ImageUrls_ProductInfoProductId",
                table: "imageurl",
                newName: "IX_imageurl_ProductInfoProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageUrls_ProductId",
                table: "imageurl",
                newName: "IX_imageurl_productid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_imageurl",
                table: "imageurl",
                column: "imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_imageurl_ProductInfos_ProductInfoProductId",
                table: "imageurl",
                column: "ProductInfoProductId",
                principalTable: "ProductInfos",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_imageurl_productinfo_productid",
                table: "imageurl",
                column: "productid",
                principalTable: "productinfo",
                principalColumn: "productid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imageurl_ProductInfos_ProductInfoProductId",
                table: "imageurl");

            migrationBuilder.DropForeignKey(
                name: "FK_imageurl_productinfo_productid",
                table: "imageurl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_imageurl",
                table: "imageurl");

            migrationBuilder.RenameTable(
                name: "imageurl",
                newName: "ImageUrls");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "ImageUrls",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "imageid",
                table: "ImageUrls",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "ImageUrls",
                newName: "ImageUrlPath");

            migrationBuilder.RenameIndex(
                name: "IX_imageurl_ProductInfoProductId",
                table: "ImageUrls",
                newName: "IX_ImageUrls_ProductInfoProductId");

            migrationBuilder.RenameIndex(
                name: "IX_imageurl_productid",
                table: "ImageUrls",
                newName: "IX_ImageUrls_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageUrls",
                table: "ImageUrls",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrls_ProductInfos_ProductInfoProductId",
                table: "ImageUrls",
                column: "ProductInfoProductId",
                principalTable: "ProductInfos",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrls_productinfo_ProductId",
                table: "ImageUrls",
                column: "ProductId",
                principalTable: "productinfo",
                principalColumn: "productid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
