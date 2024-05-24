using AutoMapper;
using StudentManagement.Data.DBcontext;

namespace StudentManagement.Services.BaseServices
{
    public abstract class BaseService<T, TDto> : IBaseService<T, TDto>
        where TDto : class
        where T : class
    {
        private readonly IMapper _mapper;
        public readonly StudentManagementContext _studentManagementContext;

        // sử dụng dependency injection thông qua constructor
        public BaseService(IMapper mapper, StudentManagementContext studentManagementContext)
        {
            _mapper = mapper;
            _studentManagementContext = studentManagementContext;
        }

        //async, await: sử dụng bất đồng bộ, có thể thực hiện nhiều công việc
        //mà không cần chờ đợi công việc trước hoàn thành
        public async Task<T> Create(TDto model)
        {
            //sử dụng mapper để chuyển đổi DTO sang thực thể
            var modelToCreate = _mapper.Map<TDto, T>(model);

            //thêm thực thể
            await _studentManagementContext.AddAsync(modelToCreate);

            //lưu thay đổi vào CSDL
            await _studentManagementContext.SaveChangesAsync();

            //trả về thực thể vừa được tạo
            return modelToCreate;
        }

        public async Task<int> Delete(int Id)
        {
            var objId = await _studentManagementContext.Set<T>().FindAsync(Id);
            if (objId == null)
            {
                throw new Exception($"cannot find an object with {Id}");
            }
            _studentManagementContext.Set<T>().Remove(objId);
            return await _studentManagementContext.SaveChangesAsync();         
        }

        public async Task<TDto> GetById(int Id)
        {
            var objId = await _studentManagementContext.Set<T>().FindAsync(Id);
            if (objId == null)
                throw new Exception($"cannot find an object with {Id}");
            var modelToGetById = _mapper.Map<TDto>(objId);
            return modelToGetById;
        }

        public async Task<T> Update(int Id, TDto model)
        {
            var objId = await _studentManagementContext.Set<T>().FindAsync(Id);
            if (objId == null)
                throw new Exception($"cannot find an object with {Id}");
            var modelToUpdate = _mapper.Map<TDto, T>(model, objId);
            _studentManagementContext.Update(modelToUpdate);
            await _studentManagementContext.SaveChangesAsync();
            return modelToUpdate;
        }
    }
}
