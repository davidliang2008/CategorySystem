using DL.CategorySystem.Domain.Categories;
using System.Collections.Generic;
using System.Linq;

namespace DL.CategorySystem.Persistence.EFCore
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>
            {
                new Category("Guitars", "guitars", 1, new List<Category>
                    {
                        new Category("Acoustic Guitars", "acoustic-guitars", 1, new List<Category>
                            {
                                new Category("6 String Acoustic Guitars", "6-string-acoustic-guitars", 1),
                                new Category("12 String Acoustic gutiars", "12-string-acoustic-guitars", 2),
                                new Category("Left Handed Acoustic Gutiars", "left-handed-acoustic-guitars", 3),
                                new Category("Travel & Mini Acoustic guitars", "travel-and-mini-acoustic-guitars", 4)
                            }),
                        new Category("Classical & Nylon Guitars", "classical-and-nylon-guitars", 2, new List<Category>
                            {
                                new Category("Flamenco Guitars", "flamenco-guitars", 1),
                                new Category("Left Handed Classical & Nylon Guitars", "left-handed-classical-and-nylon-guitars", 2)
                            }),
                        new Category("Electric Guitars", "electric-guitars", 3, new List<Category>
                            {
                                new Category("Solid Body Electric Guitars", "solid-body-electric-guitars", 1),
                                new Category("Semi-Hollow Electric Guitars", "semi-hollow-electric-guitars", 2),
                                new Category("Left Handed Electric guitars", "left-handed-electirc-guitars", 3)
                            })
                    }),
                new Category("Bass", "bass", 2, new List<Category>
                    {
                        new Category("Acoustic Bass", "acoustic-bass", 1),
                        new Category("Electric Bass", "electric-bass", 2),
                        new Category("Electric Upright Bass", "electric-upright-bass", 3)
                    }),
                new Category("Amps & Effects", "amps-and-effects", 3, new List<Category>
                    {
                        new Category("Amplifiers", "amplifiers", 1),
                        new Category("Effects", "effects", 2)
                    }),
                new Category("Drums", "drums", 4, new List<Category>
                    {
                        new Category("Acoustic Drums", "acoustic-drums", 1),
                        new Category("Electric Drums", "electric-drums", 2)
                    })
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
