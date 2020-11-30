using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebTrainning_1.Models
{
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category() {CategoryName = "Painting"},
                new Category() { CategoryName = "Music"},
                new Category() { CategoryName = "Literature"},
                new Category() { CategoryName = "Statuary" },
            };
            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<Blog> blogs = new List<Blog>()
            {
                new Blog(){Title="Post Modernism",CategoryId=1,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
                new Blog(){Title="Abstract",CategoryId=1,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
                new Blog(){Title="Rock",CategoryId=2,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
                new Blog(){Title="Classical",CategoryId=2,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
                new Blog(){Title="Cubism",CategoryId=3,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
                new Blog(){Title="New Gen",CategoryId=3,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
                new Blog(){Title="Marble",CategoryId=4,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
                new Blog(){Title="Religious",CategoryId=4,Confirmation=true,HomePage=true,Description="new description",AddTime=DateTime.Now.AddMonths(-25)},
            };

            foreach (var item in blogs)
            {
                context.Blogs.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}