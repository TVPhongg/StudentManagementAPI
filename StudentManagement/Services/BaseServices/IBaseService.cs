namespace StudentManagement.Services.BaseServices
{
    public interface IBaseService<T, TDto>
        where T : class
        where TDto : class
    {
        Task<T> Create(TDto model);
        Task<T> Update(int Id, TDto model);
        Task<int> Delete(int Id);
        Task<TDto> GetById(int Id);
    }
}
