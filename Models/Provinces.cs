using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Code1st.Models
{
    public class Province
    {
        [Key]
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}