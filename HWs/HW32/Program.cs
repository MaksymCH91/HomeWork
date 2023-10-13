using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.Intrinsics.X86;


namespace HW32
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=MAXIM_PC;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using (var context = new MyDbContext(options))
            {
                try
                {
                    //// Insert data
                    var newData = new Person { Name = "Maksym", Surname = "Chornokon" };
                    context.Persons.Add(newData);
                    context.SaveChanges();

                    // Update data
                    var dataToUpdate = context.Persons.Find(3);
                    if (dataToUpdate != null)
                    {
                        dataToUpdate.Name = "UpdatedName";
                        dataToUpdate.Surname = "UpdatedSurname";
                        context.SaveChanges();
                    }
                    //// creating of delated id - not work????
                    //var newData = new Person { Id = 1, Name = "NewName", Surname = "NewSurname" };
                    //context.Persons.Add(newData);
                    //context.SaveChanges(); 

                    // Delete data
                    //var dataToDelete = context.Persons.Find(8);
                    //if (dataToDelete != null)
                    //{
                    //    context.Persons.Remove(dataToDelete);
                    //    context.SaveChanges();
                    //}

                    // Select data
                    ;
                    var allData = context.Persons.ToList();
                    foreach (var item in allData)
                    {
                        Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Surname: {item.Surname}");
                    }
                    var personsWithUpdatedName = context.Persons.Where(p => p.Name == "UpdatedName").ToList();
                    Console.WriteLine("write all elements with name=UpdatedName");
                    foreach (var item in personsWithUpdatedName)
                    {
                        Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Surname: {item.Surname}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
