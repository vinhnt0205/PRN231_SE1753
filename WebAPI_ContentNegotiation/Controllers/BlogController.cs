using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ContentNegotiation.Models;

namespace WebAPI_ContentNegotiation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = new List<Blog>();
            var blogpost = new List<BlogPost>();
            blogpost.Add(new BlogPost
            {
                BlogPostId = 1,
                Title = "Lập trình C# - HE172280",
                MetaDescription = "C sharp là ngôn ngữ lập trình cấp cao...",
                IsPublished = true
            });
            blogpost.Add(new BlogPost
            {
                BlogPostId = 2,
                Title = "Môn học PRN231 - HE172280",
                MetaDescription = "Môn học chuyên về Web API",
                IsPublished = true
            });
            blogpost.Add(new BlogPost
            {
                BlogPostId = 3,
                Title = "Ngôn ngứ PHP - HE172280",
                MetaDescription = "Ngôn ngữ lập trình web server-side",
                IsPublished = false
            });

            blogs.Add(new Blog
            {
                BlogId = 1,
                BlogName = "Ngôn ngữ lập trình - HE172280",
                BlogDescription = "Blog chuyên về ngôn ngữ lập trình phổ dụng",
                BlogPosts = blogpost
            });
            Func<BlogPost, bool> func = (BlogPost post) => post.IsPublished;
            
            return Ok(blogs);
        }

        private IEnumerable<BlogPost> Where(IEnumerable<BlogPost> source ,Func<BlogPost, bool> func)
        {
            IEnumerable<BlogPost> result = new List<BlogPost>();
            foreach(var item in source)
            {
                if(func(item))
                {
                    result.Append(item);
                }
            }
            return result;
        }
    }
}
