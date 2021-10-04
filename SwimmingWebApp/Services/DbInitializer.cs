using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwimmingWebApp.DAL.Data;
using SwimmingWebApp.DAL.Entities;

namespace SwimmingWebApp.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя fir4air@gmail.com
                var user = new ApplicationUser
                {
                    Email = "fir4air@gmail.com",
                    UserName = "fir4air@gmail.com"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя aymikhailov@outlook.com
                var admin = new ApplicationUser
                {
                    Email = "aymikhailov@outlook.com",
                    UserName = "aymikhailov@outlook.com"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("aymikhailov@outlook.com");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия пловцов
            if (!context.Swimmers.Any())
            {
                context.Swimmers.AddRange(
                new List<Swimmer>
                {
                    new Swimmer {FullName = "Иванов Иван", DateOfBirth = new DateTime (2001, 11, 06), Rank = "КМС"},
                    new Swimmer {FullName = "Смирнова Елена", DateOfBirth = new DateTime (2003, 07, 06), Rank = "I"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия тренировок
            if (!context.Trainings.Any())
            {
                context.Trainings.AddRange(
                new List<Training>
                {
                    new Training { TrainingDate = new DateTime (2021, 02, 06), TrainingVolume = 5300, KeyAssignment = "4 x 200 м вольным стилем", KeyAssignmentBestTime = "1:57,06", Feeling = "Удовлетворительное", SwimmerId = 1 },
                    new Training { TrainingDate = new DateTime (2021, 02, 07), TrainingVolume = 4700, KeyAssignment = "2 x 400 м вольным стилем", KeyAssignmentBestTime = "3:52,12", Feeling = "Отличное", SwimmerId = 1 },
                    new Training { TrainingDate = new DateTime (2021, 02, 06), TrainingVolume = 4500, KeyAssignment = "4 x 50 м брассом", KeyAssignmentBestTime = "32,15", Feeling = "Удовлетворительное", SwimmerId = 2 },
                    new Training { TrainingDate = new DateTime (2021, 02, 07), TrainingVolume = 3900, KeyAssignment = "2 x 100 м брассом", KeyAssignmentBestTime = "1:06,06", Feeling = "Неудовлетворительное", SwimmerId = 2 }
                });
                await context.SaveChangesAsync();
            }

            if (!context.Results.Any())
            {
                context.Results.AddRange(
                new List<Result>
                {
                    new Result { Date = new DateTime (2021, 03, 07), Place = "Минск", Distance = "200 м вольным стилем", Time = "1:56,02", SwimmerId = 1 },
                    new Result { Date = new DateTime (2021, 03, 08), Place = "Рим", Distance = "50 м брассом", Time = "31,05", SwimmerId = 2 }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
