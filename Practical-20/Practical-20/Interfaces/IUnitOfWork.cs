namespace Practical_20.Interfaces
{
    public interface IUnitOfWork 
    {
        IStudentRepository StudentRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
