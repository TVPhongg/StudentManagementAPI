using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DTOs.StudentDTOs;
using StudentManagement.Services.StudentServices;

namespace StudentManagement.Controllers
{
    /*
     mã trạng thái http:
       - 1xx: thông tin
       - 2xx: thành công
       - 3xx: chuyển hướng - clinet phải thực hiện hành động bổ sung để hoàn thành yêu cầu
       - 4xx: Lỗi từ client , đưa ra request kh hợp lệ
       - 5xx: Lỗi server
     */

    /*
     * Http là giao thức truyền tải dữ liệu trên internet.
     Http request method(action verb)
       - Http Get : retrieve info or data from the server. 
       - Http Post : data is sent to the server for processing.
       - Http Put: update or replace a resource on the server.
       - Http Patch: update or replace a resource partial modifications on the server.
       - Http Delete : remove a resource from the server. 
     */
    /*
     ModelState.Isvalid : kiểm tra tính hợp lệ của dữ liệu được gửi từ client đến server
    http request gửi đến server: model binding(bind dữ liệu từ request đucợ ánh xạ vào tham số của action)
      -> validation: dữ liệu sau đó được ktra tính hợp lệ dựa trên các thuộc tính validation được áp dụng trong model
      và kq của quá trình validation này sẽ được lưu trong modelstate
     */

    /*
     Các thuộc tính như [FromForm], [FromRoute],... được sử dụng để chỉ định rõ nơi mà asp.net sẽ lấy
     dữ liệu để model binding, kiểm soát rõ ràng cách dữ liệu được lấy từ request và ánh xạ vào tham số pthuc
     - [FromForm]: dữ liệu lấy từ form data trong request body -> thường sd với yêu cầu POST khi DL được gửi dưới dạng form
     - [FromRoute]: dữ liệu lấy từ route data -> sd để ánh xạ các tham số URL đến các tham số phương thức(/users/5)
     - [FromQuery] : dữ liệu được lấy từ query string của URL
        (/search?name=John&age=30 : model binding lấy giá trị John và 30 từ query string và ánh xạ chúng vào tham số)
     - [FromBody]: dữ liệu lấy từ body của request -> yêu cầu POST hoặc PUT khi được gửi dưới dạng JSON. 
     - [FromHeader]: dữ liệu lấy từ http header
     - [FromServices]: tham số lấy từ dịch vụ dependency injection container.  
     */
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentsController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        /// <summary>
        /// Lấy sinh viên theo id
        /// </summary>
        /// <param name="Id">Id khách hàng</param>
        /// <returns> true: lấy danh sách thành công / false: lấy danh sách thất bại </returns>

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentId(int Id)
        {
            var std = await _studentServices.GetStudentId(Id);
            if (std == null)
                return BadRequest("cannot find student");
            return Ok(std);

        }

        /// <summary>
        /// Thêm mới sinh viên
        /// </summary>
        /// <param name="request"> Đối tượng cần thêm mới</param>
        /// <returns> true: thêm mới thành công / false: thêm mới thất bại</returns>  

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var std = await _studentServices.CreateStudent(request);
            return Ok(std);
        }


        /// <summary>
        /// Cập nhật sinh viên
        /// </summary>
        /// <param name="Id">Id của sinh viên cần cập nhật</param>
        /// <param name="request"> Cập nhật đối tượng sinh viên </param>
        /// <returns> true: cập nhật thành công, false: cập nhật thất bại</returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute]int Id, [FromForm]StudentDTO request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var std = await _studentServices.UpdateStudent(Id, request);
            if (std == null)
                return NotFound("Cannot find a student");
            return Ok(std);
        }


        /// <summary>
        /// Xóa sinh viên
        /// </summary>
        /// <param name="Id"> Id sinh viên</param>
        /// <returns>true: xóa thành công / false: xóa thất bại</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  
            var std = await _studentServices.DeleteStudent(Id);
            if (std == 0)
                return NotFound("Cannot find student id");
            return Ok();
        }
    }
}
