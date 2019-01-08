using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubordinatesTree.Models;
using Microsoft.EntityFrameworkCore;

namespace SubordinatesTree.Models
{
    public class SampleData
    {
        

        public static void Initialize(PersonContext context)
        {
            string[] names = {"Петров", "Иванов", "Котов", "Малов", "Тайкин", "Зюбров", "Кимчи", "Юдин", "Карлов", "Маркс",
                                "Милов", "Судин", "Гамов", "Минин", "Самонин"};

            long add_init_branch(long lead, long id, int count) {
            for (int i = 0; i < count; ++i)
                {
                    context.Persons.AddRange(
                    new PersonModel
                    {
                        Name = names[id],
                        LeaderId = lead,
                        PersonId = id,
                    }
                    );
                    context.SaveChanges();
                    id++;
                }
                return id;
            }

            if (!context.Persons.Any())
            {
                long id = 0;
                id = add_init_branch(-1, id, 3);
                id = add_init_branch(0, id, 2);
                id = add_init_branch(1, id, 3);
                id = add_init_branch(2, id, 1);
                id = add_init_branch(3, id, 2);
                id = add_init_branch(id - 1, id, 2);
                id = add_init_branch(id - 1, id, 1);
                id = add_init_branch(8, id, 1);
            }
        }
    }
}

