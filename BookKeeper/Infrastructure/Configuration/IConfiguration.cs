namespace BookKeeper.Data.Infrastructure.Configuration
{
    public interface IConfiguration<TModel> where TModel : class
    {
        void Save();
        TModel Load();
    }
}
