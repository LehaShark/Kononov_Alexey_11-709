using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam2.Models
{
    public class SampleData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                    new Dish
                    {
                        Name = "Картофель по французски",
                        ShortDcr = "Картофель, сыр, лук, майонез, свинина",
                        Price = 350
                    },
                    new Dish
                    {
                        Name = "Спагетти болоньезе",
                        ShortDcr = "спагетти, сыр, чеснок",
                        Price = 400
                    },
                    new Dish
                    {
                        Name = "Гребешки",
                        ShortDcr = "Морское растение",
                        Price = 100
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
