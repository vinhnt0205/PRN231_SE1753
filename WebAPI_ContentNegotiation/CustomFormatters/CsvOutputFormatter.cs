using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using WebAPI_ContentNegotiation.Models;

namespace WebAPI_ContentNegotiation.CustomFormatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
        }
        protected override bool CanWriteType(System.Type type)
        {
            return typeof(IEnumerable<Blog>).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var blog = context.Object as IEnumerable<Blog>;
            await using(var writer = new StreamWriter(response.Body, selectedEncoding))
            {
                foreach(var item in blog)
                {
                    await writer.WriteLineAsync($"BlogId: {item.BlogId}, BlogName: {item.BlogName}, BlogDescription: {item.BlogDescription}");
                    foreach(var post in item.BlogPosts)
                    {
                        await writer.WriteLineAsync($"\tBlogPostId: {post.BlogPostId}, Title: {post.Title}, MetaDescription: {post.MetaDescription}, IsPublished: {post.IsPublished}");
                    }
                }
            }
        }
    }
}
