using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ARSOS.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePlanned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumberOfSeats = table.Column<short>(type: "smallint", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUserIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUserIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripPlan_City_FromCityId",
                        column: x => x.FromCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripPlan_City_ToCityId",
                        column: x => x.ToCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TripPlanRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfSeats = table.Column<short>(type: "smallint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUserIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUserIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPlanRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripPlanRequest_TripPlan_TripId",
                        column: x => x.TripId,
                        principalTable: "TripPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("020b48c5-dd05-428e-a160-c5a0109bdf12"), "City-150" },
                    { new Guid("0253ba15-7f99-4087-b42b-bd1ac0e57503"), "City-185" },
                    { new Guid("02794c02-5e1e-4843-92ed-07a3189e82be"), "City-51" },
                    { new Guid("03dea48b-ab18-42a6-8dab-e003280508de"), "City-30" },
                    { new Guid("049bb20b-ee91-41d0-a0ae-2414fa5222c1"), "City-195" },
                    { new Guid("04dd46fa-a64c-478c-8bcb-d5830a373f0d"), "City-105" },
                    { new Guid("053bafa5-146c-4ddc-8674-1f4480892284"), "City-34" },
                    { new Guid("05c422fc-a55d-459f-8cbb-98db4c3606c6"), "City-130" },
                    { new Guid("070f741d-fefd-43de-89e8-e83f95b285c3"), "City-48" },
                    { new Guid("07c66830-94aa-4ced-b87d-e8c8defab428"), "City-7" },
                    { new Guid("09e949b1-78b6-4c4d-af21-5845439f14eb"), "City-35" },
                    { new Guid("0a7037b1-7762-48ca-9403-e75e8aba5134"), "City-137" },
                    { new Guid("0b577d44-82ea-42e7-aa75-e145554c0ce7"), "City-45" },
                    { new Guid("0cffa918-bc4b-4ec9-88e5-a181224c5e8a"), "City-29" },
                    { new Guid("0daee2eb-b3e6-4219-94dd-c0381d3bffec"), "City-183" },
                    { new Guid("0ddd57f7-6f47-4cea-914c-f78cc0c4fbc7"), "City-181" },
                    { new Guid("0f338a07-9634-4b92-93ee-f29eed6d345e"), "City-175" },
                    { new Guid("0fb98c9a-742d-4b62-9092-161608da596d"), "City-31" },
                    { new Guid("10d653c6-a297-45bb-9fc0-c4e7e30a108d"), "City-173" },
                    { new Guid("13b79484-9907-4b78-80db-e8b2f69a96e9"), "City-40" },
                    { new Guid("1738578d-4cea-4911-b109-32c582bb46c2"), "City-0" },
                    { new Guid("17462054-98ee-4109-9891-411899d85d5c"), "City-53" },
                    { new Guid("17988d78-b6a8-4132-8dab-f5bbc60a7e5c"), "City-193" },
                    { new Guid("1afe0cfe-8259-4f72-ba22-a2d06c5c52b7"), "City-101" },
                    { new Guid("1b9920fc-634b-4cc6-baca-1a029be1fd2d"), "City-111" },
                    { new Guid("20975fe9-2072-4b58-b4c0-d9e9df3d7cc7"), "City-2" },
                    { new Guid("244692c2-a84e-48ab-9e0d-3cb207d428dc"), "City-124" },
                    { new Guid("29a0e08f-e598-46b6-9d71-2075ddc35eb8"), "City-135" },
                    { new Guid("2a048a86-b34a-45d4-9ebc-bd6676c33a21"), "City-23" },
                    { new Guid("2be7ae5d-7547-4b6b-ac3b-97914276099a"), "City-149" },
                    { new Guid("2d247d0c-5bfe-4b30-86cc-40a999e37b17"), "City-125" },
                    { new Guid("2e392b26-1642-4e06-91de-d4bc969b5f19"), "City-126" },
                    { new Guid("308ca966-1f35-4302-a513-826f6104a21e"), "City-142" },
                    { new Guid("32a40b7d-3a0d-4625-9fba-f1897d55e67b"), "City-87" },
                    { new Guid("35849715-8138-45b3-95f4-5b3767afb6bd"), "City-95" },
                    { new Guid("367a7cdb-99bc-4165-8698-29b11133967c"), "City-61" },
                    { new Guid("39c8a18a-2c7e-4919-b161-60f1cad13816"), "City-39" },
                    { new Guid("3a99578e-68d6-4980-8eec-5950091bbb62"), "City-54" },
                    { new Guid("3c200fd9-dacb-4018-9ea6-29498587ee0f"), "City-9" },
                    { new Guid("3d4a430d-6d0c-4331-a338-33ffbf389b6c"), "City-158" },
                    { new Guid("3e241892-e8af-43ae-871c-d56c688c50dc"), "City-140" },
                    { new Guid("40d6522a-b35c-4e00-abd1-70069c437fd1"), "City-13" },
                    { new Guid("4159e8d7-8686-4907-9b05-387390d7f05a"), "City-59" },
                    { new Guid("423ed105-f574-4fc6-8afb-9b997110b5c8"), "City-104" },
                    { new Guid("43b5c8c0-8e53-4e27-9263-ffa573c74e82"), "City-136" },
                    { new Guid("44ff6c3f-22b2-4f0e-b758-c36e902364de"), "City-22" },
                    { new Guid("459c229d-c6ab-492a-b028-0b19a7aaa97f"), "City-3" },
                    { new Guid("45c73bdf-3a0b-4036-8aba-d384485d5ea3"), "City-100" },
                    { new Guid("48607860-76da-41ec-aeb0-517b641f27e2"), "City-94" },
                    { new Guid("48d4ae85-a497-4c0c-bbe1-a1924390831a"), "City-166" },
                    { new Guid("4b46b18c-a74a-41b3-ba2c-0c7b34d72bdf"), "City-76" },
                    { new Guid("4cfbb04f-eab5-41ce-9830-5458322dc73e"), "City-106" },
                    { new Guid("4f325369-3b96-428a-b778-a341367f0646"), "City-128" },
                    { new Guid("501c118a-2baa-49d4-98ef-10ec558e6963"), "City-97" },
                    { new Guid("50e602fc-502f-4d5b-9f93-8518db376fec"), "City-115" },
                    { new Guid("52e7e48b-29b7-4c99-98c6-4375c890ba17"), "City-58" },
                    { new Guid("54622d1f-a26d-43fd-8d32-bedbd37d14fd"), "City-89" },
                    { new Guid("55061b5b-3e7a-4332-a4b4-2e3523512e11"), "City-189" },
                    { new Guid("56525faf-1d88-419e-948c-53e13759c3bf"), "City-96" },
                    { new Guid("56c8beb6-4d7b-4c02-803f-6c3f0f100722"), "City-170" },
                    { new Guid("5721430e-d8a1-44aa-b25f-9eb5d76072a5"), "City-190" },
                    { new Guid("5ac56bd8-09b6-4f78-bcbb-9bee7a118bb6"), "City-46" },
                    { new Guid("5b89146b-f5d5-46bf-b3bf-d182cc50672e"), "City-148" },
                    { new Guid("5e490b9e-ff4b-4472-ab11-5ffd19c6b848"), "City-144" },
                    { new Guid("5e7e564a-3731-43d5-b6ec-3cfc8a743fe2"), "City-38" },
                    { new Guid("5eb9439a-6e7c-4298-a849-0aa1a0fc2a5b"), "City-41" },
                    { new Guid("6016ac5e-ec8f-40f3-a938-7a2d0f744db9"), "City-117" },
                    { new Guid("6107ccd0-c767-4e35-9b05-7a59b0f16523"), "City-168" },
                    { new Guid("620d97fa-198f-45a2-b7e5-8f000cad9e36"), "City-198" },
                    { new Guid("637df89b-4e72-477c-a5a7-63a7c2e20417"), "City-98" },
                    { new Guid("658ea75b-7c36-4288-99c8-d4829d67b7a4"), "City-138" },
                    { new Guid("66c5caa3-5306-45f4-9de9-13645082a691"), "City-8" },
                    { new Guid("6713c6a4-0f12-4834-a833-c8c8653fb3a9"), "City-120" },
                    { new Guid("695b98c5-4c98-4159-9acf-393ff90e2246"), "City-171" },
                    { new Guid("6a4f0154-bede-4423-924a-885c91fcae35"), "City-66" },
                    { new Guid("6a6ce1e8-240d-42c4-b621-433579079741"), "City-133" },
                    { new Guid("6a6de670-3c89-4eb2-97b7-b8d2e5123d6d"), "City-27" },
                    { new Guid("6b16e28b-8194-4052-9991-80dc53de90fa"), "City-37" },
                    { new Guid("6b222e79-cb80-4446-99cc-3a7eb818b9f3"), "City-57" },
                    { new Guid("6d7a3d44-cb34-4a2b-9844-d89bf5e0abea"), "City-25" },
                    { new Guid("6d8b2a70-addf-48b0-ab43-0e0204db547d"), "City-36" },
                    { new Guid("6f2a4e41-0ca0-49c0-9529-dee121ee16be"), "City-80" },
                    { new Guid("6f3e5bc1-9b10-4155-ae06-09a55bcf13f0"), "City-42" },
                    { new Guid("708f0bb8-1569-4acb-b6b3-ee7dab8d9ecb"), "City-50" },
                    { new Guid("717d4112-2f24-44c4-9961-52447178a8b6"), "City-56" },
                    { new Guid("7194057e-c4c4-42d8-a72a-04de2ecc73ff"), "City-21" },
                    { new Guid("72e5da4d-1a4b-430e-b3d6-6b2615f8d987"), "City-143" },
                    { new Guid("73df021c-5e6c-4b40-832c-92f1c92b7e46"), "City-18" },
                    { new Guid("74f40b5e-2c88-43b9-9ab5-91266be7e7ad"), "City-72" },
                    { new Guid("757d4e31-cc59-4d76-8cd6-68ee936ee321"), "City-11" },
                    { new Guid("75b03669-7ff0-4ad3-ba63-abbe0b218d75"), "City-86" },
                    { new Guid("7797bfb2-82eb-4cc1-bc56-2121ca2631aa"), "City-155" },
                    { new Guid("77b0c612-79e4-4b96-8afc-9772bb0651bb"), "City-191" },
                    { new Guid("7a663c93-9138-47a4-b5ef-b6e51f0217fd"), "City-167" },
                    { new Guid("7c4ea8b0-aaf0-470f-83c2-a6d537d3b509"), "City-49" },
                    { new Guid("7cac8c97-9a50-4a56-afdb-ccae1cf78c65"), "City-110" },
                    { new Guid("7d045d05-3bbc-4f7d-b1d7-79f8dcf05b09"), "City-92" },
                    { new Guid("7e811493-86c4-4ed1-940b-f85e30878097"), "City-77" },
                    { new Guid("7f71ff03-63f0-47c2-952c-1e0945e4b344"), "City-70" },
                    { new Guid("80a26550-f60b-4a28-a6c3-6b15aa2b4bc0"), "City-102" },
                    { new Guid("8105cc68-9c03-47fb-be7f-258bb9738279"), "City-121" },
                    { new Guid("82305772-f305-43ae-bb3b-f1202776a812"), "City-196" },
                    { new Guid("82a4c8d8-c31a-4a80-a6a1-7cb45b425f0a"), "City-134" },
                    { new Guid("83abb108-7ba8-4654-ada6-15269b7444f3"), "City-4" },
                    { new Guid("844e5240-888c-40d4-9cbd-abb5cdbb469c"), "City-55" },
                    { new Guid("850fb5ac-b5a5-496b-8f45-e4d840f22c35"), "City-180" },
                    { new Guid("85807125-a9b6-4fca-a15d-36f243eea1ff"), "City-82" },
                    { new Guid("8717fb34-814e-42c4-87f3-b1d5569573fe"), "City-119" },
                    { new Guid("8c15658f-6f3f-4345-8887-8b858bec8f1d"), "City-141" },
                    { new Guid("8c740d1c-b14b-4613-bc88-a5ce843f63b8"), "City-146" },
                    { new Guid("91ffc99a-8666-4eca-b52b-fdf249ba783c"), "City-32" },
                    { new Guid("93bdb02e-8a27-4c23-98d3-154c6d5043f8"), "City-14" },
                    { new Guid("93e6ff64-749a-4ae3-acc2-fe922c5d5499"), "City-172" },
                    { new Guid("96de619a-2c85-4cc7-a117-d305b5377087"), "City-127" },
                    { new Guid("9aafc901-f364-4672-b3e1-72048adefc43"), "City-64" },
                    { new Guid("9afb3fea-a699-4c79-9bcf-d76754f42e95"), "City-163" },
                    { new Guid("9bed34f6-a6a9-42b6-8b73-ccda94177f1f"), "City-93" },
                    { new Guid("9d740c63-1ad4-43e7-a4b8-f9c485b0b8d3"), "City-152" },
                    { new Guid("a4166de6-3090-44b3-9090-344d87e8b396"), "City-109" },
                    { new Guid("a452bff5-05a3-4c31-8a75-d55d4aceeb9e"), "City-20" },
                    { new Guid("a4877475-38e3-4b32-a88b-eb8d03f984e2"), "City-15" },
                    { new Guid("a4dd8975-a40d-4f14-99d7-5169412642ac"), "City-62" },
                    { new Guid("a5654624-586f-455d-b157-062f309e8145"), "City-179" },
                    { new Guid("a5e7b391-0ee3-4c7d-9475-d38d8eb45c1e"), "City-63" },
                    { new Guid("a707d25d-ca5a-4b46-8c6d-ca846eb9ad5b"), "City-17" },
                    { new Guid("a7851f9f-d173-4cb6-ab71-8420ccc47b43"), "City-169" },
                    { new Guid("a7acbe8d-6581-4213-a14b-dd9f65213e7f"), "City-154" },
                    { new Guid("a7aff055-32f4-4c89-b973-91846731a9ff"), "City-107" },
                    { new Guid("aa438830-1586-43fd-b15a-a2a9028f739c"), "City-88" },
                    { new Guid("b1d8a0c0-a3db-48ea-958a-cdf1b97e95c8"), "City-122" },
                    { new Guid("b3e2ade9-4bdd-4da8-91c2-3168ec2fa387"), "City-176" },
                    { new Guid("b4ff9a29-d963-48a5-bd56-e74ec054874c"), "City-6" },
                    { new Guid("b78d4bee-440a-41dd-9c9b-2ff8ea809c4f"), "City-123" },
                    { new Guid("b864728b-e2ff-448e-8cd4-7d8bff0975c5"), "City-156" },
                    { new Guid("b94c3c49-0eff-4f22-9d21-c45894edc1ce"), "City-81" },
                    { new Guid("b98dd4ea-054a-450d-97f9-916519ed7f37"), "City-85" },
                    { new Guid("ba38dd1b-02bc-4dac-9104-f94cef480447"), "City-60" },
                    { new Guid("bb0b41b5-cc67-4f94-928f-e4832754ee4c"), "City-67" },
                    { new Guid("bbefdf57-6daa-4a14-b5d8-932f622e4f44"), "City-47" },
                    { new Guid("bc639d49-420a-4748-a938-b41c896b012d"), "City-161" },
                    { new Guid("bcaf3f76-f723-490a-a667-44ec173afead"), "City-164" },
                    { new Guid("be2e5aa8-8a43-4a95-a303-37eb4405287d"), "City-188" },
                    { new Guid("be7ef447-2afa-40f2-81af-e67c8315a997"), "City-112" },
                    { new Guid("be8cb903-5338-4a35-be77-bc7e09cf8380"), "City-44" },
                    { new Guid("c139c29c-c4e4-4449-bc42-373711d310dc"), "City-159" },
                    { new Guid("c28e108a-1fac-442d-b6ac-6b799f694470"), "City-78" },
                    { new Guid("c499e2f4-3717-48e6-ad09-b2888e3440ea"), "City-157" },
                    { new Guid("c526adc9-b878-4b20-b53a-6d394b4987b9"), "City-182" },
                    { new Guid("c542dce4-94e1-4cd7-92f8-ab44536a1a97"), "City-74" },
                    { new Guid("c5459159-d74c-4fd6-b597-7d9ac6156987"), "City-131" },
                    { new Guid("c647cc26-b59a-48b6-8d66-ccabf9a48eab"), "City-162" },
                    { new Guid("c7e519ac-47b9-4e0a-bde9-fe3fa0ecfb52"), "City-99" },
                    { new Guid("c8d98f34-bb12-4fcf-9d7d-53e68c8b8c32"), "City-192" },
                    { new Guid("c9163178-9e0b-4678-be6d-7b02a9c9ea56"), "City-177" },
                    { new Guid("c9ec1526-769e-4bf3-b188-f3658081426b"), "City-186" },
                    { new Guid("cf51a87d-07ca-405a-997f-b2b81968a697"), "City-108" },
                    { new Guid("cfc98f2a-e350-452e-b187-e5bad540b8e3"), "City-145" },
                    { new Guid("d18c6a53-28a9-4f00-a625-a0eb24e21d55"), "City-194" },
                    { new Guid("d1db1e06-ddb5-4530-9e99-71917a833554"), "City-153" },
                    { new Guid("d508f25b-ae1a-4c22-9e99-cc2bbb9b8301"), "City-68" },
                    { new Guid("d671a0ec-cf47-4b1a-aab8-22d6483889b6"), "City-132" },
                    { new Guid("d69c8b51-8bdb-4fdd-ac1c-726ceb7585ee"), "City-118" },
                    { new Guid("d6dda941-bde4-4190-b2d8-4dc385fd1305"), "City-151" },
                    { new Guid("d8847565-48c5-4c53-8150-0d131c7ee108"), "City-69" },
                    { new Guid("d94a92b1-06d4-4750-96be-cb8ee72e7377"), "City-147" },
                    { new Guid("da164fb2-74e3-40d0-a0c4-45933bf3e305"), "City-26" },
                    { new Guid("da7302a5-d904-4f58-b8ea-8c4c4fa02834"), "City-12" },
                    { new Guid("db247f3d-bff2-421b-a429-35af1ffb5c91"), "City-10" },
                    { new Guid("dc8b74ca-9fde-4265-a724-dae246107a2f"), "City-83" },
                    { new Guid("de1db5a8-1e1c-4efa-8b66-cd2a5ee020eb"), "City-52" },
                    { new Guid("e0039304-4268-4f2e-9e6c-56361949c82d"), "City-5" },
                    { new Guid("e0bb51a5-ec8d-4338-b9b4-ad3e795d2e17"), "City-90" },
                    { new Guid("e13d9785-f422-4457-ab19-20522dd08d98"), "City-184" },
                    { new Guid("e153cf0b-74d9-4351-a75f-85c5ff29d128"), "City-28" },
                    { new Guid("e16e5dc1-90a1-4fef-a3e1-40a2fd0a7b69"), "City-16" },
                    { new Guid("e3482441-312d-4a07-bec7-456579a17f99"), "City-84" },
                    { new Guid("e37ef719-6789-4a9b-88b7-555fe6721f5e"), "City-160" },
                    { new Guid("e56770f1-1860-4749-8daa-09fbc2347cd1"), "City-113" },
                    { new Guid("e60aa296-b2e9-4dfb-9a7f-bbb73b75a02a"), "City-103" },
                    { new Guid("e67a81f7-7b24-43fc-b91d-88fcda1cece2"), "City-24" },
                    { new Guid("e68496ec-c237-4d0c-8c6a-037f319774a2"), "City-43" },
                    { new Guid("e7be02da-c483-4755-8184-5512310e1e73"), "City-174" },
                    { new Guid("e85f1fc4-998b-4796-ba24-b57265702c5b"), "City-139" },
                    { new Guid("e9848bca-6baf-45e9-99b7-67aede246418"), "City-75" },
                    { new Guid("eb41cf64-ba63-4aba-8429-749bbf64fd0d"), "City-91" },
                    { new Guid("eb7f701b-00c5-43e0-bf18-29ea4dc1263f"), "City-73" },
                    { new Guid("ee1fe3ae-1b01-41c0-b7cf-22e51de587e8"), "City-1" },
                    { new Guid("f455d68a-3db0-41f9-9616-6cc9327314a1"), "City-129" },
                    { new Guid("f52135d7-0b66-4aeb-aeec-f3e4171e0660"), "City-116" },
                    { new Guid("f5440356-16c5-44f3-b190-6d998735f95f"), "City-65" },
                    { new Guid("f5862e7f-344d-4304-93b5-4d8964daabbb"), "City-199" },
                    { new Guid("f8414a3f-7760-48cb-880f-1a67ada1d9e2"), "City-33" },
                    { new Guid("f9de72c5-b56a-4c73-a38f-5dc30cbff983"), "City-114" },
                    { new Guid("f9f3d4bb-db78-4fe9-92d9-c161b06d3d64"), "City-165" },
                    { new Guid("fba5eff5-ce1f-4761-a0be-5d74bbd2f4f1"), "City-79" },
                    { new Guid("fbfa480a-9e55-4df6-aed7-eb2878288edf"), "City-178" },
                    { new Guid("fc64f966-f4b9-4d3a-9645-049252f34fe1"), "City-19" },
                    { new Guid("fe743d97-eba8-4226-9649-81ddd60e0216"), "City-187" },
                    { new Guid("febd3d5e-294a-4afb-ab64-79839df930c4"), "City-71" },
                    { new Guid("ff7eb555-0a56-4798-9596-bb9b505ecd9d"), "City-197" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripPlan_FromCityId",
                table: "TripPlan",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPlan_ToCityId",
                table: "TripPlan",
                column: "ToCityId");

            migrationBuilder.CreateIndex(
                name: "IX_TripPlanRequest_TripId",
                table: "TripPlanRequest",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripPlanRequest");

            migrationBuilder.DropTable(
                name: "TripPlan");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
