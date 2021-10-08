using System.Collections.Generic;
using System.Linq;
using Code1st.Data;
using Code1st.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public class SampleData
{
    public static void Initialize(IApplicationBuilder app)
    {
        using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            if(context.Provinces.Any())
            {
                return;
            }

            var provinces = GetProvinces().ToArray();
            context.Provinces.AddRange(provinces);
            context.SaveChanges();

            var cities = getCities(context).ToArray();
            context.Cities.AddRange(cities);
            context.SaveChanges();

        }
    }

    public static List<Province> GetProvinces()
    {
        List<Province> Province = new List<Province>()
        {
            new Province()
            {
                ProvinceCode = "BC",
                ProvinceName = "British Columbia"
            },new Province()
            {
                ProvinceCode = "AB",
                ProvinceName = "Alberta"
            },new Province()
            {
                ProvinceCode = "ON",
                ProvinceName = "Ontario"
            },
        };
        return Province;
    }

    public static List<City> getCities(ApplicationDbContext context)
    {
        List<City> Cities = new List<City>()
        {
            new City()
            {
                CityName = "Vancouver",
                Population = 2,
                Province = context.Provinces.Find("BC").ProvinceCode
            },
            new City()
            {
                CityName = "Burnaby",
                Population = 2,
                Province= context.Provinces.Find("BC").ProvinceCode
            },
            new City()
            {
                CityName = "Victoria",
                Population = 2,
                Province= context.Provinces.Find("BC").ProvinceCode
            },
            new City()
            {
                CityName = "Edmonton",
                Population = 2,
                Province = context.Provinces.Find("AB").ProvinceCode
            },
            new City()
            {
                CityName = "Calgary",
                Population = 2,
                Province = context.Provinces.Find("AB").ProvinceCode
            },
            new City()
            {
                CityName = "Red Deer",
                Population = 2,
                Province = context.Provinces.Find("AB").ProvinceCode
            },
            new City()
            {
                CityName = "Toronto",
                Population = 2,
                Province = context.Provinces.Find("ON").ProvinceCode
            },
            new City()
            {
                CityName = "Ottawa",
                Population = 2,
                Province = context.Provinces.Find("ON").ProvinceCode
            },
            new City()
            {
                CityName = "Waterloo",
                Population = 2,
                Province = context.Provinces.Find("ON").ProvinceCode
            },

        };
        return Cities;
    }
}