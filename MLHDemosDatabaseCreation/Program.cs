using MLHDemosDatabaseCreation.Data;
using System;
using System.IO;

namespace MLHDemosDatabaseCreation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // for this we can delete an old one if it exists in your code
            string dbName = "database.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }

            // Run Some data Seeding

            using (var dbContext = new DatabaseContext())
            {
                //Ensure database is created before you do any actions on it.
                dbContext.Database.EnsureCreated();

                // seed some data
                //if (!dbContext.Any())
                //{
                //    dbContext.Blogs.AddRange(new Blog[]
                //        {
                //             new

                //             new Blog{ BlogId=3, Title="Blog 3", SubTitle="Blog 3 subtitle" }
                //        });
                //    dbContext.SaveChanges();
                //}
                //foreach (var blog in dbContext.Blogs)
                //{
                //    Console.WriteLine($"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}");
                //}
            }
            Console.ReadLine();
        }
    }
}