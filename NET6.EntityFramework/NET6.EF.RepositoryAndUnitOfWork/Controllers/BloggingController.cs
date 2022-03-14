using Microsoft.AspNetCore.Mvc;
using NET6.EF.Startup;

namespace NET6.EF.RepositoryAndUnitOfWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloggingController : ControllerBase
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public BloggingController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "Get All Blogs")]
        public IEnumerable<Blog> GetBlogs()
        {
            return this._unitOfWork.BlogRepository.GetAll();
        }

        [HttpPost(Name = "Create Blog")]
        public bool CreateBlog(string url)
        {
            this._unitOfWork.BlogRepository.Insert(new Blog()
            {
                Url = url
            });
            this._unitOfWork.BlogRepository.Save();
            return true;
        }

        [HttpDelete(Name = "Delete Blog")]
        public bool DeleteBlog(int id)
        {
            this._unitOfWork.BlogRepository.Delete(id);
            this._unitOfWork.BlogRepository.Save();
            return true;
        }
    }
}