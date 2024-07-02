using UserService.Data;
using UserService.Models;

namespace UserService.XObjects.SeedScripts
{
    public static class SeedDataExtension
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            #region Country
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new Roles { RoleName = "Admin" });
                context.Roles.AddRange(new Roles { RoleName = "PersonalUser" });
            }
            #endregion

            #region Country
            if (!context.Countries.Any())
            {
                context.Countries.AddRange(new Countries{ CountryName = "Afghanistan" });
                context.Countries.AddRange(new Countries{ CountryName = "Albania" });
                context.Countries.AddRange(new Countries{ CountryName = "Algeria" });
                context.Countries.AddRange(new Countries{ CountryName = "Andorra" });
                context.Countries.AddRange(new Countries{ CountryName = "Angola" });
                context.Countries.AddRange(new Countries{ CountryName = "Antigua and Barbuda" });
                context.Countries.AddRange(new Countries{ CountryName = "Argentina" });
                context.Countries.AddRange(new Countries{ CountryName = "Armenia" });
                context.Countries.AddRange(new Countries{ CountryName = "Australia" });
                context.Countries.AddRange(new Countries{ CountryName = "Austria" });
                context.Countries.AddRange(new Countries{ CountryName = "Azerbaijan" });
                context.Countries.AddRange(new Countries{ CountryName = "Bahamas" });
                context.Countries.AddRange(new Countries{ CountryName = "Bahrain" });
                context.Countries.AddRange(new Countries{ CountryName = "Bangladesh" });
                context.Countries.AddRange(new Countries{ CountryName = "Barbados" });
                context.Countries.AddRange(new Countries{ CountryName = "Belarus" });
                context.Countries.AddRange(new Countries{ CountryName = "Belgium" });
                context.Countries.AddRange(new Countries{ CountryName = "Belize" });
                context.Countries.AddRange(new Countries{ CountryName = "Benin" });
                context.Countries.AddRange(new Countries{ CountryName = "Bhutan" });
                context.Countries.AddRange(new Countries{ CountryName = "Bolivia" });
                context.Countries.AddRange(new Countries{ CountryName = "Bosnia and Herzegovina" });
                context.Countries.AddRange(new Countries{ CountryName = "Botswana" });
                context.Countries.AddRange(new Countries{ CountryName = "Brazil" });
                context.Countries.AddRange(new Countries{ CountryName = "Brunei" });
                context.Countries.AddRange(new Countries{ CountryName = "Bulgaria" });
                context.Countries.AddRange(new Countries{ CountryName = "Burkina Faso" });
                context.Countries.AddRange(new Countries{ CountryName = "Burundi" });
                context.Countries.AddRange(new Countries{ CountryName = "Cabo Verde" });
                context.Countries.AddRange(new Countries{ CountryName = "Cambodia" });
                context.Countries.AddRange(new Countries{ CountryName = "Cameroon" });
                context.Countries.AddRange(new Countries{ CountryName = "Canada" });
                context.Countries.AddRange(new Countries{ CountryName = "Central African Republic" });
                context.Countries.AddRange(new Countries{ CountryName = "Chad" });
                context.Countries.AddRange(new Countries{ CountryName = "Chile" });
                context.Countries.AddRange(new Countries{ CountryName = "China" });
                context.Countries.AddRange(new Countries{ CountryName = "Colombia" });
                context.Countries.AddRange(new Countries{ CountryName = "Comoros" });
                context.Countries.AddRange(new Countries{ CountryName = "Congo" });
                context.Countries.AddRange(new Countries{ CountryName = "Costa Rica" });
                context.Countries.AddRange(new Countries{ CountryName = "Croatia" });
                context.Countries.AddRange(new Countries{ CountryName = "Cuba" });
                context.Countries.AddRange(new Countries{ CountryName = "Cyprus" });
                context.Countries.AddRange(new Countries{ CountryName = "Czechia" });
                context.Countries.AddRange(new Countries{ CountryName = "Denmark" });
                context.Countries.AddRange(new Countries{ CountryName = "Djibouti" });
                context.Countries.AddRange(new Countries{ CountryName = "Dominica" });
                context.Countries.AddRange(new Countries{ CountryName = "Dominican Republic" });
                context.Countries.AddRange(new Countries{ CountryName = "East Timor" });
                context.Countries.AddRange(new Countries{ CountryName = "Ecuador" });
                context.Countries.AddRange(new Countries{ CountryName = "Egypt" });
                context.Countries.AddRange(new Countries{ CountryName = "El Salvador" });
                context.Countries.AddRange(new Countries{ CountryName = "Equatorial Guinea" });
                context.Countries.AddRange(new Countries{ CountryName = "Eritrea" });
                context.Countries.AddRange(new Countries{ CountryName = "Estonia" });
                context.Countries.AddRange(new Countries{ CountryName = "Eswatini" });
                context.Countries.AddRange(new Countries{ CountryName = "Ethiopia" });
                context.Countries.AddRange(new Countries{ CountryName = "Fiji" });
                context.Countries.AddRange(new Countries{ CountryName = "Finland" });
                context.Countries.AddRange(new Countries{ CountryName = "France" });
                context.Countries.AddRange(new Countries{ CountryName = "Gabon" });
                context.Countries.AddRange(new Countries{ CountryName = "Gambia" });
                context.Countries.AddRange(new Countries{ CountryName = "Georgia" });
                context.Countries.AddRange(new Countries{ CountryName = "Germany" });
                context.Countries.AddRange(new Countries{ CountryName = "Ghana" });
                context.Countries.AddRange(new Countries{ CountryName = "Greece" });
                context.Countries.AddRange(new Countries{ CountryName = "Grenada" });
                context.Countries.AddRange(new Countries{ CountryName = "Guatemala" });
                context.Countries.AddRange(new Countries{ CountryName = "Guinea" });
                context.Countries.AddRange(new Countries{ CountryName = "Guinea-Bissau" });
                context.Countries.AddRange(new Countries{ CountryName = "Guyana" });
                context.Countries.AddRange(new Countries{ CountryName = "Haiti" });
                context.Countries.AddRange(new Countries{ CountryName = "Honduras" });
                context.Countries.AddRange(new Countries{ CountryName = "Hungary" });
                context.Countries.AddRange(new Countries{ CountryName = "Iceland" });
                context.Countries.AddRange(new Countries{ CountryName = "India" });
                context.Countries.AddRange(new Countries{ CountryName = "Indonesia" });
                context.Countries.AddRange(new Countries{ CountryName = "Iran" });
                context.Countries.AddRange(new Countries{ CountryName = "Iraq" });
                context.Countries.AddRange(new Countries{ CountryName = "Ireland" });
                context.Countries.AddRange(new Countries{ CountryName = "Israel" });
                context.Countries.AddRange(new Countries{ CountryName = "Italy" });
                context.Countries.AddRange(new Countries{ CountryName = "Ivory Coast" });
                context.Countries.AddRange(new Countries{ CountryName = "Jamaica" });
                context.Countries.AddRange(new Countries{ CountryName = "Japan" });
                context.Countries.AddRange(new Countries{ CountryName = "Jordan" });
                context.Countries.AddRange(new Countries{ CountryName = "Kazakhstan" });
                context.Countries.AddRange(new Countries{ CountryName = "Kenya" });
                context.Countries.AddRange(new Countries{ CountryName = "Kiribati" });
                context.Countries.AddRange(new Countries{ CountryName = "Kosovo" });
                context.Countries.AddRange(new Countries{ CountryName = "Kuwait" });
                context.Countries.AddRange(new Countries{ CountryName = "Kyrgyzstan" });
                context.Countries.AddRange(new Countries{ CountryName = "Laos" });
                context.Countries.AddRange(new Countries{ CountryName = "Latvia" });
                context.Countries.AddRange(new Countries{ CountryName = "Lebanon" });
                context.Countries.AddRange(new Countries{ CountryName = "Lesotho" });
                context.Countries.AddRange(new Countries{ CountryName = "Liberia" });
                context.Countries.AddRange(new Countries{ CountryName = "Libya" });
                context.Countries.AddRange(new Countries{ CountryName = "Liechtenstein" });
                context.Countries.AddRange(new Countries{ CountryName = "Lithuania" });
                context.Countries.AddRange(new Countries{ CountryName = "Luxembourg" });
                context.Countries.AddRange(new Countries{ CountryName = "Madagascar" });
                context.Countries.AddRange(new Countries{ CountryName = "Malawi" });
                context.Countries.AddRange(new Countries{ CountryName = "Malaysia" });
                context.Countries.AddRange(new Countries{ CountryName = "Maldives" });
                context.Countries.AddRange(new Countries{ CountryName = "Mali" });
                context.Countries.AddRange(new Countries{ CountryName = "Malta" });
                context.Countries.AddRange(new Countries{ CountryName = "Marshall Islands" });
                context.Countries.AddRange(new Countries{ CountryName = "Mauritania" });
                context.Countries.AddRange(new Countries{ CountryName = "Mauritius" });
                context.Countries.AddRange(new Countries{ CountryName = "Mexico" });
                context.Countries.AddRange(new Countries{ CountryName = "Micronesia" });
                context.Countries.AddRange(new Countries{ CountryName = "Moldova" });
                context.Countries.AddRange(new Countries{ CountryName = "Monaco" });
                context.Countries.AddRange(new Countries{ CountryName = "Mongolia" });
                context.Countries.AddRange(new Countries{ CountryName = "Montenegro" });
                context.Countries.AddRange(new Countries{ CountryName = "Morocco" });
                context.Countries.AddRange(new Countries{ CountryName = "Mozambique" });
                context.Countries.AddRange(new Countries{ CountryName = "Myanmar" });
                context.Countries.AddRange(new Countries{ CountryName = "Namibia" });
                context.Countries.AddRange(new Countries{ CountryName = "Nauru" });
                context.Countries.AddRange(new Countries{ CountryName = "Nepal" });
                context.Countries.AddRange(new Countries{ CountryName = "Netherlands" });
                context.Countries.AddRange(new Countries{ CountryName = "New Zealand" });
                context.Countries.AddRange(new Countries{ CountryName = "Nicaragua" });
                context.Countries.AddRange(new Countries{ CountryName = "Niger" });
                context.Countries.AddRange(new Countries{ CountryName = "Nigeria" });
                context.Countries.AddRange(new Countries{ CountryName = "North Korea" });
                context.Countries.AddRange(new Countries{ CountryName = "North Macedonia" });
                context.Countries.AddRange(new Countries{ CountryName = "Norway" });
                context.Countries.AddRange(new Countries{ CountryName = "Oman" });
                context.Countries.AddRange(new Countries{ CountryName = "Pakistan" });
                context.Countries.AddRange(new Countries{ CountryName = "Palau" });
                context.Countries.AddRange(new Countries{ CountryName = "Palestine" });
                context.Countries.AddRange(new Countries{ CountryName = "Panama" });
                context.Countries.AddRange(new Countries{ CountryName = "Papua New Guinea" });
                context.Countries.AddRange(new Countries{ CountryName = "Paraguay" });
                context.Countries.AddRange(new Countries{ CountryName = "Peru" });
                context.Countries.AddRange(new Countries{ CountryName = "Philippines" });
                context.Countries.AddRange(new Countries{ CountryName = "Poland" });
                context.Countries.AddRange(new Countries{ CountryName = "Portugal" });
                context.Countries.AddRange(new Countries{ CountryName = "Qatar" });
                context.Countries.AddRange(new Countries{ CountryName = "Romania" });
                context.Countries.AddRange(new Countries{ CountryName = "Russia" });
                context.Countries.AddRange(new Countries{ CountryName = "Rwanda" });
                context.Countries.AddRange(new Countries{ CountryName = "Saint Kitts and Nevis" });
                context.Countries.AddRange(new Countries{ CountryName = "Saint Lucia" });
                context.Countries.AddRange(new Countries{ CountryName = "Saint Vincent and the Grenadines" });
                context.Countries.AddRange(new Countries{ CountryName = "Samoa" });
                context.Countries.AddRange(new Countries{ CountryName = "San Marino" });
                context.Countries.AddRange(new Countries{ CountryName = "Sao Tome and Principe" });
                context.Countries.AddRange(new Countries{ CountryName = "Saudi Arabia" });
                context.Countries.AddRange(new Countries{ CountryName = "Senegal" });
                context.Countries.AddRange(new Countries{ CountryName = "Serbia" });
                context.Countries.AddRange(new Countries{ CountryName = "Seychelles" });
                context.Countries.AddRange(new Countries{ CountryName = "Sierra Leone" });
                context.Countries.AddRange(new Countries{ CountryName = "Singapore" });
                context.Countries.AddRange(new Countries{ CountryName = "Slovakia" });
                context.Countries.AddRange(new Countries{ CountryName = "Slovenia" });
                context.Countries.AddRange(new Countries{ CountryName = "Solomon Islands" });
                context.Countries.AddRange(new Countries{ CountryName = "Somalia" });
                context.Countries.AddRange(new Countries{ CountryName = "South Africa" });
                context.Countries.AddRange(new Countries{ CountryName = "South Korea" });
                context.Countries.AddRange(new Countries{ CountryName = "South Sudan" });
                context.Countries.AddRange(new Countries{ CountryName = "Spain" });
                context.Countries.AddRange(new Countries{ CountryName = "Sri Lanka" });
                context.Countries.AddRange(new Countries{ CountryName = "Sudan" });
                context.Countries.AddRange(new Countries{ CountryName = "Suriname" });
                context.Countries.AddRange(new Countries{ CountryName = "Sweden" });
                context.Countries.AddRange(new Countries{ CountryName = "Switzerland" });
                context.Countries.AddRange(new Countries{ CountryName = "Syria" });
                context.Countries.AddRange(new Countries{ CountryName = "Taiwan" });
                context.Countries.AddRange(new Countries{ CountryName = "Tajikistan" });
                context.Countries.AddRange(new Countries{ CountryName = "Tanzania" });
                context.Countries.AddRange(new Countries{ CountryName = "Thailand" });
                context.Countries.AddRange(new Countries{ CountryName = "Togo" });
                context.Countries.AddRange(new Countries{ CountryName = "Tonga" });
                context.Countries.AddRange(new Countries{ CountryName = "Trinidad and Tobago" });
                context.Countries.AddRange(new Countries{ CountryName = "Tunisia" });
                context.Countries.AddRange(new Countries{ CountryName = "Turkey" });
                context.Countries.AddRange(new Countries{ CountryName = "Turkmenistan" });
                context.Countries.AddRange(new Countries{ CountryName = "Tuvalu" });
                context.Countries.AddRange(new Countries{ CountryName = "Uganda" });
                context.Countries.AddRange(new Countries{ CountryName = "Ukraine" });
                context.Countries.AddRange(new Countries{ CountryName = "United Arab Emirates" });
                context.Countries.AddRange(new Countries{ CountryName = "United Kingdom" });
                context.Countries.AddRange(new Countries{ CountryName = "United States" });
                context.Countries.AddRange(new Countries{ CountryName = "Uruguay" });
                context.Countries.AddRange(new Countries{ CountryName = "Uzbekistan" });
                context.Countries.AddRange(new Countries{ CountryName = "Vanuatu" });
                context.Countries.AddRange(new Countries{ CountryName = "Vatican City" });
                context.Countries.AddRange(new Countries{ CountryName = "Venezuela" });
                context.Countries.AddRange(new Countries{ CountryName = "Vietnam" });
                context.Countries.AddRange(new Countries{ CountryName = "Yemen" });
                context.Countries.AddRange(new Countries{ CountryName = "Zambia" });
                context.Countries.AddRange(new Countries{ CountryName = "Zimbabwe" });
                context.SaveChanges();
            }
            #endregion

            #region States
            if (!context.States.Any())
            {
                // States for Afghanistan (Line 1)
                context.States.AddRange(new States{ StateName = "Kabul", CountryId = 1 });
                context.States.AddRange(new States{ StateName = "Herat", CountryId = 1 });

                // States for Albania (Line 2)
                context.States.AddRange(new States{ StateName = "Tirana", CountryId = 2 });
                context.States.AddRange(new States{ StateName = "Durrës", CountryId = 2 });

                // States for Algeria (Line 3)
                context.States.AddRange(new States{ StateName = "Algiers", CountryId = 3 });
                context.States.AddRange(new States{ StateName = "Oran", CountryId = 3 });

                // States for Andorra (Line 4)
                context.States.AddRange(new States{ StateName = "Andorra la Vella", CountryId = 4 });
                context.States.AddRange(new States{ StateName = "Escaldes-Engordany", CountryId = 4 });

                // States for Angola (Line 5)
                context.States.AddRange(new States{ StateName = "Luanda", CountryId = 5 });
                context.States.AddRange(new States{ StateName = "Huambo", CountryId = 5 });

                // States for Antigua and Barbuda (Line 6)
                context.States.AddRange(new States{ StateName = "Saint John's", CountryId = 6 });
                context.States.AddRange(new States{ StateName = "Barbuda", CountryId = 6 });

                // States for Argentina (Line 7)
                context.States.AddRange(new States{ StateName = "Buenos Aires", CountryId = 7 });
                context.States.AddRange(new States{ StateName = "Córdoba", CountryId = 7 });

                // States for Armenia (Line 8)
                context.States.AddRange(new States{ StateName = "Yerevan", CountryId = 8 });
                context.States.AddRange(new States{ StateName = "Gyumri", CountryId = 8 });

                // States for Australia (Line 9)
                context.States.AddRange(new States{ StateName = "New South Wales", CountryId = 9 });
                context.States.AddRange(new States{ StateName = "Victoria", CountryId = 9 });

                // States for Austria (Line 10)
                context.States.AddRange(new States{ StateName = "Vienna", CountryId = 10 });
                context.States.AddRange(new States{ StateName = "Salzburg", CountryId = 10 });

                // States for Azerbaijan (Line 11)
                context.States.AddRange(new States{ StateName = "Baku", CountryId = 11 });
                context.States.AddRange(new States{ StateName = "Ganja", CountryId = 11 });

                // States for Bahamas (Line 12)
                context.States.AddRange(new States{ StateName = "Nassau", CountryId = 12 });
                context.States.AddRange(new States{ StateName = "Freeport", CountryId = 12 });

                // States for Bahrain (Line 13)
                context.States.AddRange(new States{ StateName = "Capital Governorate", CountryId = 13 });
                context.States.AddRange(new States{ StateName = "Muharraq Governorate", CountryId = 13 });

                // States for Bangladesh (Line 14)
                context.States.AddRange(new States{ StateName = "Dhaka", CountryId = 14 });
                context.States.AddRange(new States{ StateName = "Chittagong", CountryId = 14 });

                // States for Barbados (Line 15)
                context.States.AddRange(new States{ StateName = "Saint Michael", CountryId = 15 });
                context.States.AddRange(new States{ StateName = "Christ Church", CountryId = 15 });

                // States for Belarus (Line 16)
                context.States.AddRange(new States{ StateName = "Minsk Region", CountryId = 16 });
                context.States.AddRange(new States{ StateName = "Gomel Region", CountryId = 16 });

                // States for Belgium (Line 17)
                context.States.AddRange(new States{ StateName = "Flanders", CountryId = 17 });
                context.States.AddRange(new States{ StateName = "Wallonia", CountryId = 17 });

                // States for Belize (Line 18)
                context.States.AddRange(new States{ StateName = "Belize District", CountryId = 18 });
                context.States.AddRange(new States{ StateName = "Cayo District", CountryId = 18 });

                // States for Benin (Line 19)
                context.States.AddRange(new States{ StateName = "Littoral", CountryId = 19 });
                context.States.AddRange(new States{ StateName = "Atlantique", CountryId = 19 });

                // States for Bhutan (Line 20)
                context.States.AddRange(new States{ StateName = "Thimphu", CountryId = 20 });
                context.States.AddRange(new States{ StateName = "Punakha", CountryId = 20 });

                // States for Bolivia (Line 21)
                context.States.AddRange(new States{ StateName = "La Paz", CountryId = 21 });
                context.States.AddRange(new States{ StateName = "Santa Cruz", CountryId = 21 });

                // States for Bosnia and Herzegovina (Line 22)
                context.States.AddRange(new States{ StateName = "Federation of Bosnia and Herzegovina", CountryId = 22 });
                context.States.AddRange(new States{ StateName = "Republika Srpska", CountryId = 22 });

                // States for Botswana (Line 23)
                context.States.AddRange(new States{ StateName = "Gaborone", CountryId = 23 });
                context.States.AddRange(new States{ StateName = "Francistown", CountryId = 23 });

                // States for Brazil (Line 24)
                context.States.AddRange(new States{ StateName = "São Paulo", CountryId = 24 });
                context.States.AddRange(new States{ StateName = "Rio de Janeiro", CountryId = 24 });

                // States for Brunei (Line 25)
                context.States.AddRange(new States{ StateName = "Brunei-Muara", CountryId = 25 });
                context.States.AddRange(new States{ StateName = "Tutong", CountryId = 25 });

                // States for Bulgaria (Line 26)
                context.States.AddRange(new States{ StateName = "Sofia", CountryId = 26 });
                context.States.AddRange(new States{ StateName = "Plovdiv", CountryId = 26 });

                // States for Burkina Faso (Line 27)
                context.States.AddRange(new States{ StateName = "Centre", CountryId = 27 });
                context.States.AddRange(new States{ StateName = "Hauts-Bassins", CountryId = 27 });

                // States for Burundi (Line 28)
                context.States.AddRange(new States{ StateName = "Bujumbura Mairie", CountryId = 28 });
                context.States.AddRange(new States{ StateName = "Gitega", CountryId = 28 });

                // States for Cabo Verde (Line 29)
                context.States.AddRange(new States{ StateName = "Santiago", CountryId = 29 });
                context.States.AddRange(new States{ StateName = "São Vicente", CountryId = 29 });

                // States for Cambodia (Line 30)
                context.States.AddRange(new States{ StateName = "Phnom Penh", CountryId = 30 });
                context.States.AddRange(new States{ StateName = "Siem Reap", CountryId = 30 });

                // States for Cameroon (Line 31)
                context.States.AddRange(new States{ StateName = "Centre", CountryId = 31 });
                context.States.AddRange(new States{ StateName = "Littoral", CountryId = 31 });

                // States for Canada (Line 32)
                context.States.AddRange(new States{ StateName = "Ontario", CountryId = 32 });
                context.States.AddRange(new States{ StateName = "Quebec", CountryId = 32 });

                // States for Central African Republic (Line 33)
                context.States.AddRange(new States{ StateName = "Bangui", CountryId = 33 });
                context.States.AddRange(new States{ StateName = "Bamingui-Bangoran", CountryId = 33 });

                // States for Chad (Line 34)
                context.States.AddRange(new States{ StateName = "N'Djamena", CountryId = 34 });
                context.States.AddRange(new States{ StateName = "Hadjer-Lamis", CountryId = 34 });

                // States for Chile (Line 35)
                context.States.AddRange(new States{ StateName = "Santiago Metropolitan", CountryId = 35 });
                context.States.AddRange(new States{ StateName = "Valparaíso", CountryId = 35 });

                // States for China (Line 36)
                context.States.AddRange(new States{ StateName = "Guangdong", CountryId = 36 });
                context.States.AddRange(new States{ StateName = "Shandong", CountryId = 36 });

                // States for Colombia (Line 37)
                context.States.AddRange(new States{ StateName = "Cundinamarca", CountryId = 37 });
                context.States.AddRange(new States{ StateName = "Antioquia", CountryId = 37 });

                // States for Comoros (Line 38)
                context.States.AddRange(new States{ StateName = "Grande Comore", CountryId = 38 });
                context.States.AddRange(new States{ StateName = "Anjouan", CountryId = 38 });

                // States for Congo (Brazzaville) (Line 39)
                context.States.AddRange(new States{ StateName = "Brazzaville", CountryId = 39 });
                context.States.AddRange(new States{ StateName = "Pointe-Noire", CountryId = 39 });

                // States for Costa Rica (Line 41)
                context.States.AddRange(new States{ StateName = "San José", CountryId = 40 });
                context.States.AddRange(new States{ StateName = "Alajuela", CountryId = 40 });

                // States for Croatia (Line 43)
                context.States.AddRange(new States{ StateName = "Zagreb", CountryId = 41 });
                context.States.AddRange(new States{ StateName = "Split-Dalmatia", CountryId = 41 });

                // States for Cuba (Line 44)
                context.States.AddRange(new States{ StateName = "Havana", CountryId = 42 });
                context.States.AddRange(new States{ StateName = "Santiago de Cuba", CountryId = 42 });

                // States for Cyprus (Line 45)
                context.States.AddRange(new States{ StateName = "Nicosia", CountryId = 43 });
                context.States.AddRange(new States{ StateName = "Limassol", CountryId = 43 });

                // States for Czech Republic (Line 46)
                context.States.AddRange(new States{ StateName = "Prague", CountryId = 44 });
                context.States.AddRange(new States{ StateName = "Central Bohemia", CountryId = 44 });

                // States for Denmark (Line 47)
                context.States.AddRange(new States{ StateName = "Capital Region of Denmark", CountryId = 45 });
                context.States.AddRange(new States{ StateName = "Region of Southern Denmark", CountryId = 45 });

                // States for Djibouti (Line 48)
                context.States.AddRange(new States{ StateName = "Djibouti City", CountryId = 46 });
                context.States.AddRange(new States{ StateName = "Ali Sabieh", CountryId = 46 });

                // States for Dominica (Line 49)
                context.States.AddRange(new States{ StateName = "Saint Andrew Parish", CountryId = 47 });
                context.States.AddRange(new States{ StateName = "Saint David Parish", CountryId = 47 });

                // States for Dominican Republic (Line 50)
                context.States.AddRange(new States{ StateName = "Santo Domingo", CountryId = 48 });
                context.States.AddRange(new States{ StateName = "Santiago", CountryId = 48 });

                // States for East Timor (Timor-Leste) (Line 51)
                context.States.AddRange(new States{ StateName = "Dili", CountryId = 49 });
                context.States.AddRange(new States{ StateName = "Baucau", CountryId = 49 });

                // States for Ecuador (Line 52)
                context.States.AddRange(new States{ StateName = "Pichincha", CountryId = 50 });
                context.States.AddRange(new States{ StateName = "Guayas", CountryId = 50 });

                // States for Egypt (Line 53)
                context.States.AddRange(new States{ StateName = "Cairo", CountryId = 51 });
                context.States.AddRange(new States{ StateName = "Alexandria", CountryId = 51 });

                // States for El Salvador (Line 54)
                context.States.AddRange(new States{ StateName = "San Salvador", CountryId = 52 });
                context.States.AddRange(new States{ StateName = "Santa Ana", CountryId = 52 });

                // States for Equatorial Guinea (Line 55)
                context.States.AddRange(new States{ StateName = "Litoral", CountryId = 53 });
                context.States.AddRange(new States{ StateName = "Bioko Norte", CountryId = 53 });

                // States for Eritrea (Line 56)
                context.States.AddRange(new States{ StateName = "Maekel", CountryId = 54 });
                context.States.AddRange(new States{ StateName = "Debub", CountryId = 54 });

                // States for Estonia (Line 57)
                context.States.AddRange(new States{ StateName = "Harju County", CountryId = 55 });
                context.States.AddRange(new States{ StateName = "Tartu County", CountryId = 55 });

                // States for Eswatini (Line 58)
                context.States.AddRange(new States{ StateName = "Hhohho", CountryId = 56 });
                context.States.AddRange(new States{ StateName = "Manzini", CountryId = 56 });

                // States for Ethiopia (Line 59)
                context.States.AddRange(new States{ StateName = "Addis Ababa", CountryId = 57 });
                context.States.AddRange(new States{ StateName = "Oromia", CountryId = 57 });

                // States for Fiji (Line 60)
                context.States.AddRange(new States{ StateName = "Central Division", CountryId = 58 });
                context.States.AddRange(new States{ StateName = "Western Division", CountryId = 58 });

                // States for Finland (Line 61)
                context.States.AddRange(new States{ StateName = "Uusimaa", CountryId = 59 });
                context.States.AddRange(new States{ StateName = "Pirkanmaa", CountryId = 59 });

                // States for France (Line 62)
                context.States.AddRange(new States{ StateName = "Île-de-France", CountryId = 60 });
                context.States.AddRange(new States{ StateName = "Auvergne-Rhône-Alpes", CountryId = 60 });

                // States for Gabon (Line 63)
                context.States.AddRange(new States{ StateName = "Estuaire", CountryId = 61 });
                context.States.AddRange(new States{ StateName = "Haut-Ogooué", CountryId = 61 });

                // States for Gambia (Line 64)
                context.States.AddRange(new States{ StateName = "Banjul", CountryId = 62 });
                context.States.AddRange(new States{ StateName = "Upper River", CountryId = 62 });

                // States for Georgia (Line 65)
                context.States.AddRange(new States{ StateName = "Tbilisi", CountryId = 63 });
                context.States.AddRange(new States{ StateName = "Kakheti", CountryId = 63 });

                // States for Germany (Line 66)
                context.States.AddRange(new States{ StateName = "North Rhine-Westphalia", CountryId = 64 });
                context.States.AddRange(new States{ StateName = "Bavaria", CountryId = 64 });

                // States for Ghana (Line 67)
                context.States.AddRange(new States{ StateName = "Greater Accra", CountryId = 65 });
                context.States.AddRange(new States{ StateName = "Ashanti", CountryId = 65 });

                // States for Greece (Line 68)
                context.States.AddRange(new States{ StateName = "Attica", CountryId = 66 });
                context.States.AddRange(new States{ StateName = "Central Macedonia", CountryId = 66 });

                // States for Grenada (Line 69)
                context.States.AddRange(new States{ StateName = "Saint George", CountryId = 67 });
                context.States.AddRange(new States{ StateName = "Saint Andrew", CountryId = 67 });

                // States for Guatemala (Line 70)
                context.States.AddRange(new States{ StateName = "Guatemala Department", CountryId = 68 });
                context.States.AddRange(new States{ StateName = "Quetzaltenango", CountryId = 68 });

                // States for Guinea (Line 71)
                context.States.AddRange(new States{ StateName = "Conakry", CountryId = 69 });
                context.States.AddRange(new States{ StateName = "Labe", CountryId = 69 });

                // States for Guinea-Bissau (Line 72)
                context.States.AddRange(new States{ StateName = "Bissau", CountryId = 70 });
                context.States.AddRange(new States{ StateName = "Bolama", CountryId = 70 });

                // States for Guyana (Line 73)
                context.States.AddRange(new States{ StateName = "Demerara-Mahaica", CountryId = 71 });
                context.States.AddRange(new States{ StateName = "Essequibo Islands-West Demerara", CountryId = 71 });

                // States for Haiti (Line 74)
                context.States.AddRange(new States{ StateName = "Ouest", CountryId = 72 });
                context.States.AddRange(new States{ StateName = "Nord", CountryId = 72 });

                // States for Honduras (Line 75)
                context.States.AddRange(new States{ StateName = "Francisco Morazán", CountryId = 73 });
                context.States.AddRange(new States{ StateName = "Cortés", CountryId = 73 });


                // States for Hungary (Line 77)
                context.States.AddRange(new States{ StateName = "Budapest", CountryId = 74 });
                context.States.AddRange(new States{ StateName = "Pest County", CountryId = 74 });

                // States for Iceland (Line 78)
                context.States.AddRange(new States{ StateName = "Capital Region", CountryId = 75 });
                context.States.AddRange(new States{ StateName = "Southern Peninsula", CountryId = 75 });

                // States for Indonesia (Line 77)
                context.States.AddRange(new States{ StateName = "West Java", CountryId = 77 });
                context.States.AddRange(new States{ StateName = "East Java", CountryId = 77 });

                // States for Iran (Line 78)
                context.States.AddRange(new States{ StateName = "Tehran", CountryId = 78 });
                context.States.AddRange(new States{ StateName = "Isfahan", CountryId = 78 });

                // States for Iraq (Line 79)
                context.States.AddRange(new States{ StateName = "Baghdad", CountryId = 79 });
                context.States.AddRange(new States{ StateName = "Nineveh", CountryId = 79 });

                // States for Ireland (Line 80)
                context.States.AddRange(new States{ StateName = "Leinster", CountryId = 80 });
                context.States.AddRange(new States{ StateName = "Munster", CountryId = 80 });

                // States for Israel (Line 81)
                context.States.AddRange(new States{ StateName = "Tel Aviv District", CountryId = 81 });
                context.States.AddRange(new States{ StateName = "Jerusalem District", CountryId = 81 });

                // States for Italy (Line 82)
                context.States.AddRange(new States{ StateName = "Lazio", CountryId = 82 });
                context.States.AddRange(new States{ StateName = "Lombardy", CountryId = 82 });

                // States for Jamaica (Line 83)
                context.States.AddRange(new States{ StateName = "Kingston", CountryId = 83 });
                context.States.AddRange(new States{ StateName = "Saint Andrew", CountryId = 83 });

                // States for Japan (Line 84)
                context.States.AddRange(new States{ StateName = "Tokyo", CountryId = 84 });
                context.States.AddRange(new States{ StateName = "Osaka", CountryId = 84 });

                // States for Jordan (Line 85)
                context.States.AddRange(new States{ StateName = "Amman", CountryId = 85 });
                context.States.AddRange(new States{ StateName = "Irbid", CountryId = 85 });

                // States for Kazakhstan (Line 86)
                context.States.AddRange(new States{ StateName = "Almaty", CountryId = 86 });
                context.States.AddRange(new States{ StateName = "Nur-Sultan", CountryId = 86 });

                // States for Kenya (Line 87)
                context.States.AddRange(new States{ StateName = "Nairobi", CountryId = 87 });
                context.States.AddRange(new States{ StateName = "Mombasa", CountryId = 87 });

                // States for Kiribati (Line 88)
                context.States.AddRange(new States{ StateName = "Gilbert Islands", CountryId = 88 });
                context.States.AddRange(new States{ StateName = "Line Islands", CountryId = 88 });

                // States for Kosovo (Line 89)
                context.States.AddRange(new States{ StateName = "Pristina", CountryId = 89 });
                context.States.AddRange(new States{ StateName = "Prizren", CountryId = 89 });

                // States for Kuwait (Line 90)
                context.States.AddRange(new States{ StateName = "Al Asimah", CountryId = 90 });
                context.States.AddRange(new States{ StateName = "Hawalli", CountryId = 90 });

                // States for Kyrgyzstan (Line 91)
                context.States.AddRange(new States{ StateName = "Chuy Region", CountryId = 91 });
                context.States.AddRange(new States{ StateName = "Osh Region", CountryId = 91 });

                // States for Laos (Line 92)
                context.States.AddRange(new States{ StateName = "Vientiane Prefecture", CountryId = 92 });
                context.States.AddRange(new States{ StateName = "Savannakhet", CountryId = 92 });

                // States for Latvia (Line 93)
                context.States.AddRange(new States{ StateName = "Riga", CountryId = 93 });
                context.States.AddRange(new States{ StateName = "Daugavpils", CountryId = 93 });

                // States for Lebanon (Line 94)
                context.States.AddRange(new States{ StateName = "Mount Lebanon Governorate", CountryId = 94 });
                context.States.AddRange(new States{ StateName = "Beirut Governorate", CountryId = 94 });

                // States for Lesotho (Line 95)
                context.States.AddRange(new States{ StateName = "Maseru", CountryId = 95 });
                context.States.AddRange(new States{ StateName = "Mafeteng", CountryId = 95 });

                // States for Liberia (Line 96)
                context.States.AddRange(new States{ StateName = "Montserrado", CountryId = 96 });
                context.States.AddRange(new States{ StateName = "Nimba", CountryId = 96 });

                // States for Libya (Line 97)
                context.States.AddRange(new States{ StateName = "Tripoli", CountryId = 97 });
                context.States.AddRange(new States{ StateName = "Benghazi", CountryId = 97 });

                // States for Liechtenstein (Line 98)
                context.States.AddRange(new States{ StateName = "Balzers", CountryId = 98 });
                context.States.AddRange(new States{ StateName = "Vaduz", CountryId = 98 });

                // States for Lithuania (Line 99)
                context.States.AddRange(new States{ StateName = "Vilnius", CountryId = 99 });
                context.States.AddRange(new States{ StateName = "Kaunas", CountryId = 99 });

                // States for Luxembourg (Line 100)
                context.States.AddRange(new States{ StateName = "Luxembourg District", CountryId = 100 });
                context.States.AddRange(new States{ StateName = "Diekirch District", CountryId = 100 });

                // States for Madagascar (Line 101)
                context.States.AddRange(new States{ StateName = "Analamanga", CountryId = 101 });
                context.States.AddRange(new States{ StateName = "Atsinanana", CountryId = 101 });

                // States for Malawi (Line 102)
                context.States.AddRange(new States{ StateName = "Central Region", CountryId = 102 });
                context.States.AddRange(new States{ StateName = "Southern Region", CountryId = 102 });

                // States for Malaysia (Line 103)
                context.States.AddRange(new States{ StateName = "Selangor", CountryId = 103 });
                context.States.AddRange(new States{ StateName = "Johor", CountryId = 103 });

                // States for Maldives (Line 104)
                context.States.AddRange(new States{ StateName = "Malé", CountryId = 104 });
                context.States.AddRange(new States{ StateName = "Addu Atoll", CountryId = 104 });

                // States for Mali (Line 105)
                context.States.AddRange(new States{ StateName = "Bamako", CountryId = 105 });
                context.States.AddRange(new States{ StateName = "Kayes", CountryId = 105 });

                // States for Malta (Line 106)
                context.States.AddRange(new States{ StateName = "Northern Region", CountryId = 106 });
                context.States.AddRange(new States{ StateName = "Southern Region", CountryId = 106 });

                // States for Marshall Islands (Line 107)
                context.States.AddRange(new States{ StateName = "Majuro Atoll", CountryId = 107 });
                context.States.AddRange(new States{ StateName = "Kwajalein Atoll", CountryId = 107 });

                // States for Mauritania (Line 108)
                context.States.AddRange(new States{ StateName = "Nouakchott", CountryId = 108 });
                context.States.AddRange(new States{ StateName = "Guidimaka", CountryId = 108 });

                // States for Mauritius (Line 109)
                context.States.AddRange(new States{ StateName = "Port Louis", CountryId = 109 });
                context.States.AddRange(new States{ StateName = "Plaines Wilhems", CountryId = 109 });

                // States for Mexico (Line 110)
                context.States.AddRange(new States{ StateName = "Mexico City", CountryId = 110 });
                context.States.AddRange(new States{ StateName = "Jalisco", CountryId = 110 });

                // States for Micronesia (Line 111)
                context.States.AddRange(new States{ StateName = "Pohnpei", CountryId = 111 });
                context.States.AddRange(new States{ StateName = "Chuuk", CountryId = 111 });

                // States for Moldova (Line 112)
                context.States.AddRange(new States{ StateName = "Chișinău", CountryId = 112 });
                context.States.AddRange(new States{ StateName = "Tiraspol", CountryId = 112 });

                // States for Monaco (Line 113)
                context.States.AddRange(new States{ StateName = "Monaco", CountryId = 113 });

                // States for Mongolia (Line 114)
                context.States.AddRange(new States{ StateName = "Ulaanbaatar", CountryId = 114 });
                context.States.AddRange(new States{ StateName = "Darkhan", CountryId = 114 });

                // States for Montenegro (Line 115)
                context.States.AddRange(new States{ StateName = "Podgorica", CountryId = 115 });
                context.States.AddRange(new States{ StateName = "Nikšić", CountryId = 115 });

                // States for Morocco (Line 116)
                context.States.AddRange(new States{ StateName = "Casablanca-Settat", CountryId = 116 });
                context.States.AddRange(new States{ StateName = "Fès-Meknès", CountryId = 116 });

                // States for Mozambique (Line 117)
                context.States.AddRange(new States{ StateName = "Maputo City", CountryId = 117 });
                context.States.AddRange(new States{ StateName = "Nampula", CountryId = 117 });

                // States for Myanmar (Line 118)
                context.States.AddRange(new States{ StateName = "Yangon", CountryId = 118 });
                context.States.AddRange(new States{ StateName = "Mandalay", CountryId = 118 });

                // States for Namibia (Line 119)
                context.States.AddRange(new States{ StateName = "Khomas", CountryId = 119 });
                context.States.AddRange(new States{ StateName = "Erongo", CountryId = 119 });

                // States for Nauru (Line 120)
                context.States.AddRange(new States{ StateName = "Yaren", CountryId = 120 });

                // States for Nepal (Line 121)
                context.States.AddRange(new States{ StateName = "Bagmati Pradesh", CountryId = 121 });
                context.States.AddRange(new States{ StateName = "Gandaki Pradesh", CountryId = 121 });

                // States for Netherlands (Line 122)
                context.States.AddRange(new States{ StateName = "North Holland", CountryId = 122 });
                context.States.AddRange(new States{ StateName = "South Holland", CountryId = 122 });

                // States for New Zealand (Line 123)
                context.States.AddRange(new States{ StateName = "Auckland Region", CountryId = 123 });
                context.States.AddRange(new States{ StateName = "Canterbury Region", CountryId = 123 });

                // States for Nicaragua (Line 124)
                context.States.AddRange(new States{ StateName = "Managua", CountryId = 124 });
                context.States.AddRange(new States{ StateName = "León", CountryId = 124 });

                // States for Niger (Line 125)
                context.States.AddRange(new States{ StateName = "Niamey", CountryId = 125 });
                context.States.AddRange(new States{ StateName = "Tahoua", CountryId = 125 });

                // States for Nigeria (Line 126)
                context.States.AddRange(new States{ StateName = "Lagos", CountryId = 126 });
                context.States.AddRange(new States{ StateName = "Kano", CountryId = 126 });

                // States for North Korea (Line 127)
                context.States.AddRange(new States{ StateName = "Pyongyang", CountryId = 127 });
                context.States.AddRange(new States{ StateName = "Hamhung", CountryId = 127 });

                // States for North Macedonia (Line 128)
                context.States.AddRange(new States{ StateName = "Skopje", CountryId = 128 });
                context.States.AddRange(new States{ StateName = "Bitola", CountryId = 128 });

                // States for Norway (Line 129)
                context.States.AddRange(new States{ StateName = "Oslo", CountryId = 129 });
                context.States.AddRange(new States{ StateName = "Bergen", CountryId = 129 });

                // States for Oman (Line 130)
                context.States.AddRange(new States{ StateName = "Muscat", CountryId = 130 });
                context.States.AddRange(new States{ StateName = "Salalah", CountryId = 130 });

                // States for Pakistan (Line 131)
                context.States.AddRange(new States{ StateName = "Punjab", CountryId = 131 });
                context.States.AddRange(new States{ StateName = "Sindh", CountryId = 131 });

                // States for Palau (Line 132)
                context.States.AddRange(new States{ StateName = "Ngerulmud", CountryId = 132 });
                context.States.AddRange(new States{ StateName = "Koror", CountryId = 132 });

                // States for Palestine (Line 133)
                context.States.AddRange(new States{ StateName = "West Bank", CountryId = 133 });
                context.States.AddRange(new States{ StateName = "Gaza Strip", CountryId = 133 });

                // States for Panama (Line 134)
                context.States.AddRange(new States{ StateName = "Panamá", CountryId = 134 });
                context.States.AddRange(new States{ StateName = "Colón", CountryId = 134 });

                // States for Papua New Guinea (Line 135)
                context.States.AddRange(new States{ StateName = "National Capital District", CountryId = 135 });
                context.States.AddRange(new States{ StateName = "Morobe", CountryId = 135 });

                // States for Paraguay (Line 136)
                context.States.AddRange(new States{ StateName = "Central Department", CountryId = 136 });
                context.States.AddRange(new States{ StateName = "Ñeembucú", CountryId = 136 });

                // States for Peru (Line 137)
                context.States.AddRange(new States{ StateName = "Lima", CountryId = 137 });
                context.States.AddRange(new States{ StateName = "Cusco", CountryId = 137 });

                // States for Philippines (Line 138)
                context.States.AddRange(new States{ StateName = "Metro Manila", CountryId = 138 });
                context.States.AddRange(new States{ StateName = "Calabarzon", CountryId = 138 });

                // States for Poland (Line 139)
                context.States.AddRange(new States{ StateName = "Masovian Voivodeship", CountryId = 139 });
                context.States.AddRange(new States{ StateName = "Lesser Poland Voivodeship", CountryId = 139 });

                // States for Portugal (Line 140)
                context.States.AddRange(new States{ StateName = "Lisbon", CountryId = 140 });
                context.States.AddRange(new States{ StateName = "Porto", CountryId = 140 });

                // States for Qatar (Line 141)
                context.States.AddRange(new States{ StateName = "Doha", CountryId = 141 });

                // States for Romania (Line 142)
                context.States.AddRange(new States{ StateName = "Bucharest", CountryId = 142 });
                context.States.AddRange(new States{ StateName = "Cluj-Napoca", CountryId = 142 });

                // States for Russia (Line 143)
                context.States.AddRange(new States{ StateName = "Moscow", CountryId = 143 });
                context.States.AddRange(new States{ StateName = "Saint Petersburg", CountryId = 143 });

                // States for Rwanda (Line 144)
                context.States.AddRange(new States{ StateName = "Kigali", CountryId = 144 });
                context.States.AddRange(new States{ StateName = "Eastern Province", CountryId = 144 });

                // States for Saint Kitts and Nevis (Line 145)
                context.States.AddRange(new States{ StateName = "Saint George Basseterre Parish", CountryId = 145 });
                context.States.AddRange(new States{ StateName = "Saint John Capisterre Parish", CountryId = 145 });

                // States for Saint Lucia (Line 146)
                context.States.AddRange(new States{ StateName = "Castries", CountryId = 146 });
                context.States.AddRange(new States{ StateName = "Gros Islet", CountryId = 146 });

                // States for Saint Vincent and the Grenadines (Line 147)
                context.States.AddRange(new States{ StateName = "Saint George Parish", CountryId = 147 });
                context.States.AddRange(new States{ StateName = "Charlotte Parish", CountryId = 147 });

                // States for Samoa (Line 148)
                context.States.AddRange(new States{ StateName = "Tuamasaga", CountryId = 148 });
                context.States.AddRange(new States{ StateName = "A'ana", CountryId = 148 });

                // States for San Marino (Line 149)
                context.States.AddRange(new States{ StateName = "San Marino", CountryId = 149 });

                // States for São Tomé and Príncipe (Line 150)
                context.States.AddRange(new States{ StateName = "São Tomé Province", CountryId = 150 });
                context.States.AddRange(new States{ StateName = "Príncipe Province", CountryId = 150 });

                // States for Saudi Arabia (Line 151)
                context.States.AddRange(new States{ StateName = "Riyadh", CountryId = 151 });
                context.States.AddRange(new States{ StateName = "Mecca", CountryId = 151 });

                // States for Senegal (Line 152)
                context.States.AddRange(new States{ StateName = "Dakar", CountryId = 152 });
                context.States.AddRange(new States{ StateName = "Thiès", CountryId = 152 });

                // States for Serbia (Line 153)
                context.States.AddRange(new States{ StateName = "Belgrade", CountryId = 153 });
                context.States.AddRange(new States{ StateName = "Novi Sad", CountryId = 153 });

                // States for Seychelles (Line 154)
                context.States.AddRange(new States{ StateName = "La Digue", CountryId = 154 });
                context.States.AddRange(new States{ StateName = "Praslin", CountryId = 154 });

                // States for Sierra Leone (Line 155)
                context.States.AddRange(new States{ StateName = "Western Area", CountryId = 155 });
                context.States.AddRange(new States{ StateName = "Northern Province", CountryId = 155 });

                // States for Singapore (Line 156)
                context.States.AddRange(new States{ StateName = "Central Region", CountryId = 156 });

                // States for Slovakia (Line 157)
                context.States.AddRange(new States{ StateName = "Bratislava Region", CountryId = 157 });
                context.States.AddRange(new States{ StateName = "Nitra Region", CountryId = 157 });

                // States for Slovenia (Line 158)
                context.States.AddRange(new States{ StateName = "Ljubljana", CountryId = 158 });
                context.States.AddRange(new States{ StateName = "Maribor", CountryId = 158 });

                // States for Solomon Islands (Line 159)
                context.States.AddRange(new States{ StateName = "Guadalcanal Province", CountryId = 159 });
                context.States.AddRange(new States{ StateName = "Malaita Province", CountryId = 159 });

                // States for Somalia (Line 160)
                context.States.AddRange(new States{ StateName = "Banadir", CountryId = 160 });
                context.States.AddRange(new States{ StateName = "Puntland", CountryId = 160 });

                // States for South Africa (Line 161)
                context.States.AddRange(new States{ StateName = "Gauteng", CountryId = 161 });
                context.States.AddRange(new States{ StateName = "KwaZulu-Natal", CountryId = 161 });

                // States for South Korea (Line 162)
                context.States.AddRange(new States{ StateName = "Seoul", CountryId = 162 });
                context.States.AddRange(new States{ StateName = "Busan", CountryId = 162 });

                // States for South Sudan (Line 163)
                context.States.AddRange(new States{ StateName = "Central Equatoria", CountryId = 163 });
                context.States.AddRange(new States{ StateName = "Northern Bahr el Ghazal", CountryId = 163 });

                // States for Spain (Line 164)
                context.States.AddRange(new States{ StateName = "Community of Madrid", CountryId = 164 });
                context.States.AddRange(new States{ StateName = "Catalonia", CountryId = 164 });

                // States for Sri Lanka (Line 165)
                context.States.AddRange(new States{ StateName = "Western Province", CountryId = 165 });
                context.States.AddRange(new States{ StateName = "Central Province", CountryId = 165 });

                // States for Sudan (Line 166)
                context.States.AddRange(new States{ StateName = "Khartoum", CountryId = 166 });
                context.States.AddRange(new States{ StateName = "Gezira", CountryId = 166 });

                // States for Suriname (Line 167)
                context.States.AddRange(new States{ StateName = "Paramaribo", CountryId = 167 });
                context.States.AddRange(new States{ StateName = "Nickerie", CountryId = 167 });

                // States for Sweden (Line 168)
                context.States.AddRange(new States{ StateName = "Stockholm County", CountryId = 168 });
                context.States.AddRange(new States{ StateName = "Västra Götaland County", CountryId = 168 });

                // States for Switzerland (Line 169)
                context.States.AddRange(new States{ StateName = "Zürich", CountryId = 169 });
                context.States.AddRange(new States{ StateName = "Geneva", CountryId = 169 });

                // States for Syria (Line 170)
                context.States.AddRange(new States{ StateName = "Damascus", CountryId = 170 });
                context.States.AddRange(new States{ StateName = "Aleppo", CountryId = 170 });

                // States for Taiwan (Line 171)
                context.States.AddRange(new States{ StateName = "Taipei", CountryId = 171 });
                context.States.AddRange(new States{ StateName = "New Taipei", CountryId = 171 });

                // States for Tajikistan (Line 172)
                context.States.AddRange(new States{ StateName = "Districts of Republican Subordination", CountryId = 172 });
                context.States.AddRange(new States{ StateName = "Khatlon Region", CountryId = 172 });

                // States for Tanzania (Line 173)
                context.States.AddRange(new States{ StateName = "Dar es Salaam", CountryId = 173 });
                context.States.AddRange(new States{ StateName = "Mwanza", CountryId = 173 });

                // States for Thailand (Line 174)
                context.States.AddRange(new States{ StateName = "Bangkok", CountryId = 174 });
                context.States.AddRange(new States{ StateName = "Chiang Mai", CountryId = 174 });

                // States for Timor-Leste (Line 175)
                context.States.AddRange(new States{ StateName = "Dili", CountryId = 175 });

                // States for Togo (Line 176)
                context.States.AddRange(new States{ StateName = "Maritime", CountryId = 176 });
                context.States.AddRange(new States{ StateName = "Plateaux", CountryId = 176 });

                // States for Tonga (Line 177)
                context.States.AddRange(new States{ StateName = "Tongatapu", CountryId = 177 });
                context.States.AddRange(new States{ StateName = "Vava'u", CountryId = 177 });

                // States for Trinidad and Tobago (Line 178)
                context.States.AddRange(new States{ StateName = "San Fernando", CountryId = 178 });
                context.States.AddRange(new States{ StateName = "Chaguanas", CountryId = 178 });

                // States for Tunisia (Line 179)
                context.States.AddRange(new States{ StateName = "Tunis", CountryId = 179 });
                context.States.AddRange(new States{ StateName = "Sfax", CountryId = 179 });

                // States for Turkey (Line 180)
                context.States.AddRange(new States{ StateName = "Istanbul", CountryId = 180 });
                context.States.AddRange(new States{ StateName = "Ankara", CountryId = 180 });

                // States for Turkmenistan (Line 181)
                context.States.AddRange(new States{ StateName = "Ahal Region", CountryId = 181 });
                context.States.AddRange(new States{ StateName = "Balkan Region", CountryId = 181 });

                // States for Tuvalu (Line 182)
                context.States.AddRange(new States{ StateName = "Funafuti", CountryId = 182 });

                // States for Uganda (Line 183)
                context.States.AddRange(new States{ StateName = "Central Region", CountryId = 183 });
                context.States.AddRange(new States{ StateName = "Eastern Region", CountryId = 183 });

                // States for Ukraine (Line 184)
                context.States.AddRange(new States{ StateName = "Kyiv", CountryId = 184 });
                context.States.AddRange(new States{ StateName = "Kharkiv", CountryId = 184 });

                // States for United Arab Emirates (Line 185)
                context.States.AddRange(new States{ StateName = "Dubai", CountryId = 185 });
                context.States.AddRange(new States{ StateName = "Abu Dhabi", CountryId = 185 });

                // States for United Kingdom (Line 186)
                context.States.AddRange(new States{ StateName = "England", CountryId = 186 });
                context.States.AddRange(new States{ StateName = "Scotland", CountryId = 186 });

                // States for United States (Line 187)
                context.States.AddRange(new States{ StateName = "California", CountryId = 187 });
                context.States.AddRange(new States{ StateName = "Texas", CountryId = 187 });

                // States for Uruguay (Line 188)
                context.States.AddRange(new States{ StateName = "Montevideo", CountryId = 188 });
                context.States.AddRange(new States{ StateName = "Canelones", CountryId = 188 });

                // States for Uzbekistan (Line 189)
                context.States.AddRange(new States{ StateName = "Tashkent", CountryId = 189 });
                context.States.AddRange(new States{ StateName = "Namangan", CountryId = 189 });

                // States for Vanuatu (Line 190)
                context.States.AddRange(new States{ StateName = "Shefa", CountryId = 190 });
                context.States.AddRange(new States{ StateName = "Tafea", CountryId = 190 });

                // States for Vatican City (Line 191)
                context.States.AddRange(new States{ StateName = "Vatican City", CountryId = 191 });

                // States for Venezuela (Line 192)
                context.States.AddRange(new States{ StateName = "Capital District", CountryId = 192 });
                context.States.AddRange(new States{ StateName = "Zulia", CountryId = 192 });

                // States for Vietnam (Line 193)
                context.States.AddRange(new States{ StateName = "Hanoi", CountryId = 193 });
                context.States.AddRange(new States{ StateName = "Ho Chi Minh City", CountryId = 193 });

                // States for Yemen (Line 194)
                context.States.AddRange(new States{ StateName = "Sana'a", CountryId = 194 });
                context.States.AddRange(new States{ StateName = "Aden", CountryId = 194 });

                // States for Zambia (Line 195)
                context.States.AddRange(new States{ StateName = "Lusaka", CountryId = 195 });
                context.States.AddRange(new States{ StateName = "Copperbelt Province", CountryId = 195 });

                // States for Zimbabwe (Line 196)
                context.States.AddRange(new States{ StateName = "Harare", CountryId = 196 });
                context.States.AddRange(new States{ StateName = "Bulawayo", CountryId = 196 });

                //States for India
                context.States.AddRange(new States{ StateName = "Andaman and Nicobar Islands", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Andhra Pradesh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Arunachal Pradesh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Assam", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Bihar", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Chandigarh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Chhattisgarh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Dadra and Nagar Haveli and Daman and Diu", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Delhi", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Goa", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Gujarat", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Haryana", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Himachal Pradesh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Jammu and Kashmir", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Jharkhand", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Karnataka", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Kerala", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Ladakh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Lakshadweep", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Madhya Pradesh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Maharashtra", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Manipur", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Meghalaya", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Mizoram", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Nagaland", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Odisha", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Puducherry", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Punjab", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Rajasthan", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Sikkim", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Tamil Nadu", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Telangana", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Tripura", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Uttar Pradesh", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "Uttarakhand", CountryId = 76 });
                context.States.AddRange(new States{ StateName = "West Bengal", CountryId = 76 });
                context.SaveChanges();
            }
            #endregion
        }
    }
}
