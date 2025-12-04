using System.ComponentModel.DataAnnotations; // 引用驗證用的命名空間

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        // Required 代表此欄位必填，ErrorMessage 是錯誤訊息
        [Required(ErrorMessage = "請輸入帳號")]
        public string Username { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)] // 讓輸入框變成密碼遮蔽格式
        public string Password { get; set; }
    }
}
