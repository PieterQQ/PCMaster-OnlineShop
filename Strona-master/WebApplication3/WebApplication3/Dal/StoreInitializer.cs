using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebApplication3.Migrations;
using WebApplication3.Models;

namespace WebApplication3.Dal
{
    public class StoreInitializer : MigrateDatabaseToLatestVersion <StoreContext,Configuration>
    {
        //protected override void Seed(StoreContext context)
        //{
        //    SeedStoreDate(context);
        //    base.Seed(context);
        //}
        public StoreInitializer()
        {

        }
        public static void SeedStoreDate(StoreContext context)
        {
            var podzespolIni = new List<podzespoly> {

                new podzespoly { PodzespolyId=1,Name="Procesor", IconFileName="cpu.jpg"},
                new podzespoly { PodzespolyId=2,Name="Grafika", IconFileName="graphiccard.jpg"},
                new podzespoly { PodzespolyId=3,Name="Zasilacz", IconFileName="zasilacz.jpg"},
                new podzespoly { PodzespolyId=4,Name="RAM", IconFileName="ram.jpg"},
                new podzespoly { PodzespolyId=5,Name="Chłodzenie", IconFileName="cooler.jpg"},
                new podzespoly { PodzespolyId=6,Name="Motherboard", IconFileName="plytaglowna.jpg"},
                new podzespoly { PodzespolyId=7,Name="Obudowy", IconFileName="case.jpg"},
                new podzespoly { PodzespolyId=8,Name="Monitor", IconFileName="monitor.jpg"},
                new podzespoly { PodzespolyId=9,Name="Myszka", IconFileName="mickey.jpg"},
                new podzespoly { PodzespolyId=10,Name="Klawiatura", IconFileName="keyboard.jpg"},
                new podzespoly { PodzespolyId=11,Name="Inne", IconFileName="alternative.png"},
                new podzespoly { PodzespolyId=12,Name="Promocje", IconFileName="promos.png"},
                
            };
            podzespolIni.ForEach(g => context.Podzespoly.AddOrUpdate(g));
            context.SaveChanges();
            var Podzespolini = new List<Podzespol>
            {
                new Podzespol {PodzespolId=1,NazwaPodzespolu="MSI 1080",Producent="MSI",IsBestseller=true,DateAdded= new DateTime(2010,03,16),Price=1999,ConvertFileName="1.jpg",PodzespolyId=2,Description="Bądź gotowy do gry z GeForce® GTX. Karty graficzne GeForce GTX są najbardziej zaawansowanymi kartami, jakie kiedykolwiek stworzono. Odkryj bezprecedensową wydajność, energooszczędność oraz wrażenia jakie dostarczą gry nowej generacji. Odkryj wydajność, która pozwala na swobodne generowanie światów wirtualnej rzeczywistości (VR). Dzięki technologiom NVIDIA VRWorks™ karta graficzna może zaoferować użytkownikom najniższe opóźnienia oraz kompatybilność w trybie plug-and-play ze wszystkimi najważniejszymi, dostępnymi na rynku zestawami gogli VR. Za sprawą dźwięku VR, implementacji fizyki i emulacji dotyku w środowisku VR, będziesz mógł dosłownie słyszeć i czuć każdą chwilę. Najnowsze technologie gamingowe Układy graficzne bazujące na architekturze Pascal zostały skonstruowane tak , aby sprostać wymaganiom kolejnych generacji wyświetlaczy, w tym urządzeń VR, ekranów ultra-wysokiej rozdzielczości i systemów wielomonitorowych. Dzięki technologii NVIDIA GameWorks ™, nowe układy podczas rozgrywki i odtwarzania materiałów wideo o wysokiej, kinowej jakości są w stanie generować wyjątkowo płynny obraz. Dodatkowo w nowych procesorach graficznych zaimplementowano rewolucyjną funkcję, która pozwala na 360-stopniowe przechwytywanie obrazu."},
                new Podzespol {PodzespolId=2,NazwaPodzespolu="AMG Ryzen",Producent="AMD",IsBestseller=false,DateAdded= new DateTime(2019,02,15),Price=1450,ConvertFileName="2.jpg",PodzespolyId=1,Description="OPIS PROCESOREA RYZEN" },
                new Podzespol {PodzespolId=3,NazwaPodzespolu="RAM 8GB",Producent="Corsair",IsBestseller=true,DateAdded= new DateTime(2019,01,15),Price=200,ConvertFileName="3.jpg",PodzespolyId=4,Description="OPIS RAM CORSAIR 8GB"},
                new Podzespol {PodzespolId=4,NazwaPodzespolu="RAM 16GB",Producent="GOODRAM",IsBestseller=true,DateAdded= new DateTime(2019,01,10),Price=100,ConvertFileName="4.jpg",PodzespolyId=4,Description="OPIS RAM GOODRAM 16GB"},
                        new Podzespol {PodzespolId=5,NazwaPodzespolu="Samsung 24in",Producent="Samsung",IsBestseller=true,DateAdded= new DateTime(2010,03,16),Price=399,ConvertFileName="5.jpg",PodzespolyId=8,Description="OPIS MONITORA SAMSUNG 24CALE"},
                new Podzespol {PodzespolId=6,NazwaPodzespolu="Steelseries Rival 100",Producent="Steelseries",IsBestseller=false,DateAdded= new DateTime(2019,02,15),Price=150,ConvertFileName="6.jpg",PodzespolyId=9,Description="OPIS MYSZKI RIVAL 100" },
                new Podzespol {PodzespolId=7,NazwaPodzespolu="Genesis thor 200",Producent="Genesis",IsBestseller=false,DateAdded= new DateTime(2020,03,16),Price=200,ConvertFileName="7.jpg",PodzespolyId=10,Description="OPIS KLAWIATURY GENESIS THOR 200"},
                new Podzespol {PodzespolId=8,NazwaPodzespolu="Obudowa Zelman 100",Producent="Zelman",IsBestseller=true,DateAdded= new DateTime(2019,01,10),Price=150,ConvertFileName="8.jpg",PodzespolyId=7,Description="OPIS OBUDOWY ZALMAN 100"}
            };
            Podzespolini.ForEach(a => context.Podzespol.AddOrUpdate(a));
            context.SaveChanges();
        }
        public static void InitializeIdentityForEF(StoreContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@pcmaster.pl";
            const string password = "password1";
            const string roleName = "Admin";


            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UserData = new UserData() };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}