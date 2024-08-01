namespace CurdApplicationWebApi.RepositoryLayer
{
    public interface IDatabaseFactory
    {
        public IDatabaseAdapter GetDatabase();
    }
}
