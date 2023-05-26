namespace ASP.Net.Areas.Admin.Models
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public IFormFile[] UploadedFiles { get; set; }
    }
}
