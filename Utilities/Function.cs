namespace WebApplication1.Utilities
{
    public class Function
    {
        public static string? TittleGenerationAlias(string tittle)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(tittle);
        }
    }
}
