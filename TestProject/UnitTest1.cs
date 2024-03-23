using Dentist_cabinet.Controllers;
using Dentist_cabinet.Data;
using Dentist_cabinet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject
{
    [TestFixture]
    public class DoctorTest
    {
        private DbContextOptions<Dentist_cabinetContext> GetDbContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<Dentist_cabinetContext>()
                .UseInMemoryDatabase("TestDatabase")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Test]
        public async Task Index_ReturnViewWithListOfDoctors()
        {
            var options = GetDbContextOptions();
            using (var context = new Dentist_cabinetContext(options))
            {
                context.Doctor.Add(new Doctor { Id = 1, Name = "Petar", LastName = "Petrov", Experience = "много", Speciality = "Зъботехник", Phone = "0123456789" });
                context.SaveChanges();
            }
            using (var context = new Dentist_cabinetContext(options))
            {
                var controller = new DoctorsController(context);


                var result = await controller.Index();

                // Assert
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }

        [Test]
        public async Task Delete_ReturnsRedirectToActionResult()
        {
            var options = GetDbContextOptions();
            using (var context = new Dentist_cabinetContext(options))
            {
                context.Doctor.Add(new Doctor { Id = 1, Name = "Petar", LastName = "Petrov", Experience = "много", Speciality = "Зъботехник", Phone = "0123456789" });
                context.SaveChanges();
            }
            using (var context = new Dentist_cabinetContext(options))
            {
                var controller = new DoctorsController(context);


                var result = await controller.DeleteConfirmed(1);

                // Assert
                Assert.IsInstanceOf<RedirectToActionResult>(result);
            }
        }

        [Test]
        public async Task Edit_ReturnsRedirectToActionResult()
        {
            var options = GetDbContextOptions();
            using (var context = new Dentist_cabinetContext(options))
            {
                context.Doctor.Add(new Doctor { Id = 1, Name = "Petar", LastName = "Petrov", Experience = "много", Speciality = "Зъботехник", Phone = "0123456789" });
                context.SaveChanges();
            }
            using (var context = new Dentist_cabinetContext(options))
            {
                var controller = new DoctorsController(context);


                var result = await controller.Edit(1);

                // Assert
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }

        [Test]
        public async Task Create_ReturnsRedirectToActionResult()
        {
            var options = GetDbContextOptions();
            var Doctor = new Doctor { Id = 1, Name = "Petar", LastName = "Petrov", Experience = "много", Speciality = "Зъботехник", Phone = "0123456789" };
            using (var context = new Dentist_cabinetContext(options))
            {
                var controller = new DoctorsController(context);
                var result = await controller.Create(Doctor);
                // Assert
                Assert.IsInstanceOf<RedirectToActionResult>(result);
            }
        }

        [Test]
        public async Task Details_ReturnsRedirectToActionResult()
        {
            var options = GetDbContextOptions();
            using (var context = new Dentist_cabinetContext(options))
            {
                context.Doctor.Add(new Doctor { Id = 1, Name = "Petar", LastName = "Petrov", Experience = "много", Speciality = "Зъботехник", Phone = "0123456789" });
                context.SaveChanges();
            }
            using (var context = new Dentist_cabinetContext(options))
            {
                var controller = new DoctorsController(context);


                var result = await controller.Details(1);

                // Assert
                Assert.IsInstanceOf<ViewResult>(result);
            }
        }
    }
}