using Counselor.Data;
using Counselor.Models;
using Microsoft.EntityFrameworkCore;

namespace Counselor.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Check if there are any blogs already
            if (await context.Blogs.AnyAsync())
            {
                return; // Database has been seeded
            }

            // Seed sample blogs
            var blogs = new List<Blog>
            {
                new Blog
                {
                    Title = "Understanding Mental Health in Today's World",
                    Summary = "Mental health is as important as physical health. Learn about the importance of mental wellness and how to maintain it.",
                    Content = "<p>Mental health is an essential part of overall well-being. It affects how we think, feel, and act. In today's fast-paced world, taking care of our mental health has become more important than ever.</p>" +
                              "<h3>Why Mental Health Matters</h3>" +
                              "<p>Good mental health helps you cope with stress, relate to others, and make healthy choices. It's important at every stage of life, from childhood through adulthood.</p>" +
                              "<h3>Tips for Better Mental Health</h3>" +
                              "<ul><li>Stay physically active</li><li>Connect with others</li><li>Get enough sleep</li><li>Practice mindfulness</li><li>Seek professional help when needed</li></ul>",
                    Author = "Dr. Sarah Johnson",
                    PublishedDate = DateTime.Now.AddDays(-10),
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-10)
                },
                new Blog
                {
                    Title = "Coping with Anxiety: Practical Strategies",
                    Summary = "Anxiety is a common mental health challenge. Discover practical strategies to manage and reduce anxiety in your daily life.",
                    Content = "<p>Anxiety is a normal response to stress, but when it becomes overwhelming, it can interfere with daily life. Here are some practical strategies to help manage anxiety.</p>" +
                              "<h3>Breathing Techniques</h3>" +
                              "<p>Deep breathing exercises can help calm your nervous system and reduce anxiety symptoms.</p>" +
                              "<h3>Grounding Exercises</h3>" +
                              "<p>The 5-4-3-2-1 technique can help bring you back to the present moment when anxiety strikes.</p>",
                    Author = "Dr. Michael Chen",
                    PublishedDate = DateTime.Now.AddDays(-5),
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-5)
                },
                new Blog
                {
                    Title = "The Benefits of Couples Counseling",
                    Summary = "Couples counseling can strengthen relationships and improve communication. Learn how it can help your relationship thrive.",
                    Content = "<p>Couples counseling provides a safe space for partners to work through challenges and strengthen their relationship.</p>" +
                              "<h3>When to Seek Couples Counseling</h3>" +
                              "<p>Consider couples counseling when you're experiencing communication difficulties, frequent conflicts, or feeling disconnected from your partner.</p>" +
                              "<h3>What to Expect</h3>" +
                              "<p>A trained therapist will help you identify patterns, improve communication, and develop healthier relationship dynamics.</p>",
                    Author = "Dr. Emily Rodriguez",
                    PublishedDate = DateTime.Now.AddDays(-3),
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-3)
                }
            };

            await context.Blogs.AddRangeAsync(blogs);
            await context.SaveChangesAsync();
        }
    }
}
