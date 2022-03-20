using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO Members 
                (
                    FirstName, 
                    LastName, 
                    DateOfBirth, 
                    Email, 
                    Address, 
                    City, 
                    Country, 
                    ZipCode
                )
                VALUES 
                ( 
                 'Emma', 
                 'Dunham', 
                 '31 Mar 1980', 
                 'emma.dunham@vtgrafix.gov', 
                 '76 Sherman Road', 
                 'Hastings', 
                 'Aruba', 
                 '06830'
                ),
                (
                 'Ivan', 
                 'Risley', 
                 '09 Aug 1958', 
                 'ivan.risley@nitrosystems.co', 
                 '18 Hartswood Road', 
                 'Stanford', 
                 'Algeria', 
                 '04346'
                ), 
                (
                 'Rikki', 
                 'Paquette', 
                 '18 Sep 1963', 
                 'rikki.paquette@anaplex.xyz', 
                 '56 Canal Street', 
                 'London', 
                 'Iceland', 
                 '16935' 
                ),
                ( 
                 'Roman', 
                 'Bourne', 
                 '14 Aug 1979', 
                 'roman.bourne@baramax.co', 
                 '55 Wooster Road', 
                 'Adelaide', 
                 'Eritrea', 
                 '46446' 
                ), 
                (
                 'Lyn', 
                 'Chapman', 
                 '12 May 1955', 
                 'lyn.chapman@loopsys.xyz', 
                 '31 Bramble Lane', 
                 'Auckland', 
                 'Netherlands', 
                 '45893' 
                ), 
                (
                 'Rosie', 
                 'Finn', 
                 '15 Feb 1981', 
                 'rosie.finn@sealine.co', 
                 '42 Walford Way', 
                 'Beaverton', 
                 'France', 
                 '10697' 
                ),
                ( 
                 'Cedric', 
                 'Webster', 
                 '18 May 1956', 
                 'cedric.webster@solexis.co', 
                 '38 Colwood Place', 
                 'Wilmington', 
                 'Guatemala', 
                 '01521' 
                ), 
                (
                 'Rosanne', 
                 'Starck', 
                 '16 Jan 1989', 
                 'rosanne.starck@dalserve.org', 
                 '50 Hunt Street', 
                 'Cardiff', 
                 'Tanzania, United Republic of', 
                 '65339' 
                ), 
                (
                 'Emma', 
                 'Young', 
                 '14 Aug 1976', 
                 'emma.young@terralabs.info', 
                 '22 Clarendon Street', 
                 'Portsmouth', 
                 'Guernsey', 
                 '02285' 
                ),
                ( 
                 'Stan', 
                 'Milling', 
                 '22 Sep 1953', 
                 'stan.milling@corerobotics.gov', 
                 '85 Golden Lane', 
                 'Medford', 
                 'Nigeria', 
                 '29916' 
                ), 
                (
                 'Jenette', 
                 'Oldman', 
                 '16 May 1985', 
                 'jenette.oldman@hivemind.biz', 
                 '50 Mount Street', 
                 'Woodville', 
                 'Puerto Rico', 
                 '47870' 
                ), 
                (
                 'Max', 
                 'Hyder', 
                 '13 Dec 1954', 
                 'max.hyder@polycore.gov', 
                 '30 Buckley Street', 
                 'Tacoma', 
                 'Latvia', 
                 '73729' 
                ),
                ( 
                 'Juliana', 
                 'Kelsey', 
                 '03 Jan 1982', 
                 'juliana.kelsey@grafixmedia.xyz', 
                 '26 Mercer Street', 
                 'Hobart', 
                 'Hong Kong', 
                 '98550'
                ),
                (
                 'Adam', 
                 'Hollis', 
                 '06 Aug 1985', 
                 'adam.hollis@triosys.co', 
                 '64 Bramble Lane', 
                 'Adelaide', 
                 'Malta', 
                 '50998'
                ),
                ( 
                 'Alexis', 
                 'Brandt', 
                 '12 Sep 1971', 
                 'alexis.brandt@terralabs.gov', 
                 '52 Orchard Road', 
                 'Boston', 
                 'Norfolk Island', 
                 '56707' 
                ), 
                (
                 'Travis', 
                 'Cappel', 
                 '12 Mar 1955', 
                 'travis.cappel@ulogica.gov', 
                 '42 Glenn Drive', 
                 'Toledo', 
                 'Nicaragua', 
                 '54985' 
                ),
                ( 
                 'Layla', 
                 'Flinn', 
                 '18 May 1976', 
                 'layla.flinn@seelogic.club', 
                 '89 Rivington Street', 
                 'Lancaster', 
                 'Congo', 
                 '40390' 
                ),
                ( 
                 'Raylene', 
                 'Sager', 
                 '03 Sep 1968', 
                 'raylene.sager@infratouch.net', 
                 '87 Coleman Avenue', 
                 'Durham', 
                 'Guyana', 
                 '85733' 
                ),
                (
                 'Chloe', 
                 'Turner', 
                 '13 Sep 1989', 
                 'chloe.turner@playtech.mobi', 
                 '73 Robinson Street', 
                 'Wilmington', 
                 'Zambia', 
                 '82963' 
                ),
                ( 
                 'Roman', 
                 'Porras', 
                 '24 Jan 1978', 
                 'roman.porras@mediadime.xyz', 
                 '45 Windsor Avenue', 
                 'Sheffield', 
                 'Zimbabwe', 
                 '05706' 
                )"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Members");
        }
    }
}