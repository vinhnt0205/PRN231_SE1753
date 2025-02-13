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
                Title = "Lập trình C#",
                MetaDescription = "C sharp là ngôn ngữ lập trình cấp cao...",
                IsPublished = true
            });
            blogpost.Add(new BlogPost
            {
                BlogPostId = 2,
                Title = "Môn học PRN231",
                MetaDescription = "Môn học chuyên về Web API",
                IsPublished = true
            });
            blogpost.Add(new BlogPost
            {
                BlogPostId = 3,
                Title = "Ngôn ngứ PHP",
                MetaDescription = "Ngôn ngữ lập trình web server-side",
                IsPublished = false
            });

            blogs.Add(new Blog
            {
                BlogId = 1,
                BlogName = "Ngôn ngữ lập trình",
                BlogDescription = "Blog chuyên về ngôn ngữ lập trình phổ dụng",
                BlogPosts = blogpost
            });

            return Ok(blogs);
        }
    }
}
