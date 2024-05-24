using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.DBcontext;
using StudentManagement.Services.StudentServices;

var builder = WebApplication.CreateBuilder(args);


//connection string for connect to database
builder.Services.AddDbContext<StudentManagementContext>(
       options => options.UseSqlServer("name=ConnectionStrings:StudentManagementConn"));


// Add services to the container
/* Vòng đời của dependency injection
   - transient: tạo đối tượng mới mỗi khi được yêu cầu -> thời gian ngắn -> dv kh lưu trạng thái
   - scope: tạo đối tượng cho mỗi request -> trong 1 request -> dv lưu trạng thái trong suốt 1 request(contextDB)
   - sigleton: tạo đối tượng một lần duy nhất -> suốt vòng đời ứng dụng -> dv lưu trạng thái chung trong toàn bộ ứng dụng(logging, caching)
*/
builder.Services.AddScoped<StudentManagementContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<IStudentServices, StudentServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
