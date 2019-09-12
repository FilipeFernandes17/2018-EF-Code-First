using BlogDemo.DAL;
using BlogDemo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo
{
    class Program
    {
        //Full Demo @
        //https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                //Display all the blogs from the db
                var allBlogs = db.Blogs.ToList();
                Console.WriteLine($"There are {allBlogs.Count} blogs in the database.");
                foreach (var item in allBlogs)
                    Console.WriteLine(item.Name);

                //TODO: Get the user to choose a blog and then add a post to that blog.
                Console.WriteLine($"Choose one of {allBlogs.Count} blogs in the database.");
                foreach (var item in allBlogs)
                    Console.WriteLine(item.Name);
                var choice = Console.ReadLine();
                Console.Write("Enter a name for a new Blog: ");
                var newname = Console.ReadLine();
                Console.Write("Enter new Blog: ");
                var blogtext = Console.ReadLine();

                var newblog = new Blog { Name = newname };
                db.Blogs.Add(newblog);
                db.SaveChanges();



            }
        }
    }
    namespace Entities
    {
        // TODO: 2) Follow up by making changes to the entities and trying out Database Migrations
        //      (as discussed in the MSDN demo linked to Program.cs)

        public class Blog
        {
            public int BlogID { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Post> Posts { get; set; }
        }
        public class Post
        {

            public int PostID { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
            public int BlogID { get; set; }

            public virtual Blog Blog { get; set; }
        }


    }
    namespace DAL
    {
        public class BloggingContext : DbContext
        {
            public BloggingContext() : base("name=BlogDb")
            {

            }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
    }

}
