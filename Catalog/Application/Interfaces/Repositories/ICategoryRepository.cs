namespace Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> IsCategoryUsed(int categoryId);
    }
}
