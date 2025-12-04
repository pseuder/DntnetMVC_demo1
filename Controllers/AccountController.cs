using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // 1. 顯示登入頁面 (GET)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // 2. 處理登入請求 (POST)
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // 驗證資料格式是否正確 (例如是否為空)
            if (ModelState.IsValid)
            {
                // 模擬資料庫驗證：帳號 admin / 密碼 1234
                if (model.Username == "admin" && model.Password == "1234")
                {
                    // 登入成功，將使用者名稱存入 Session
                    HttpContext.Session.SetString("User", model.Username);

                    // 導向回首頁
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // 帳密錯誤，加入錯誤訊息到 Model
                    ModelState.AddModelError("", "帳號或密碼錯誤");
                }
            }

            // 如果驗證失敗，返回原本的 View 並顯示錯誤
            return View(model);
        }

        // 3. 登出
        public IActionResult Logout()
        {
            // 清除 Session
            HttpContext.Session.Clear();

            // 導向回登入頁
            return RedirectToAction("Login");
        }
    }
}
