namespace FptQuiz.Model
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public string RoleID { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        public string ResultID { get; set; }
        public Boolean Status { get; set; }
        public string Token { get; set; }
        public User()
        {

        }
    }
}
