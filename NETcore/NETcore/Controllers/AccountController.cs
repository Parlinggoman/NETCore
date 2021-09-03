using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Base;
using NETcore.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETcore.Model;
using System.Net;
using NETcore.ViewModel;
using NETcore.Repository.StaticMethod;


namespace NETcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository repository;
        public AccountController(AccountRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        [HttpPost("Login")]
        public ActionResult Login(LoginVM login)
        {
            try
            {
                //check data by email
                var checkdata = repository.Login(login);
                if (checkdata == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new
                    {
                        status = (int)HttpStatusCode.BadRequest,
                        message = "Email tidak ditemukan"
                    });
                }

                //check password bycrpt
                if (!BCrypt.Net.BCrypt.Verify(login.Password, checkdata.Password))
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new
                    {
                        status = (int)HttpStatusCode.BadRequest,
                        message = "Password Salah"
                    });
                }

                return StatusCode((int)HttpStatusCode.OK, new
                {
                    status = (int)HttpStatusCode.OK,
                    message = "Success Login",
                });

            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message = e.Message
                });
            }
        }
        [HttpPost("SendPasswordResetCode")]
        public ActionResult SendPasswordResetCode(LoginVM loginVM)
        {
            //validating
            if (string.IsNullOrEmpty(loginVM.Email))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new
                {
                    status = (int)HttpStatusCode.BadRequest,
                    message = "Email tidak boleh null atau kosong"
                });
            }

            try
            {
                //check email
                var account = repository.FindByEmail(loginVM.Email);

                if (account == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new
                    {
                        status = (int)HttpStatusCode.BadRequest,
                        message = "Email tidak terdaftar"
                    });
                }

                //Generate OTP 5 Digit
                Random r = new Random();
                int otp = r.Next(10000, 99999);

                //save into database
                repository.SaveResetPassword(account.Email, otp, account.NIK);

                //send otp to email
                EmailSender.SendEmail(loginVM.Email, "Reset Password OTP", "Hello "
                              + loginVM.Email + "<br><br>berikut Kode OTP anda<br><br><b>"
                              + otp + "<b><br><br>Thanks<br>netcore-api.com");

                return StatusCode((int)HttpStatusCode.OK, new
                {
                    status = (int)HttpStatusCode.OK,
                    message = "OTP berhasil dikirim ke email " + loginVM.Email + "."
                });


            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message = e.Message
                });
            }
        }

        [HttpPost("SendPasswordReset")]
        public ActionResult SendPasswordReset(LoginVM loginVM)
        {
            //validating
            if (string.IsNullOrEmpty(loginVM.Email))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new
                {
                    status = (int)HttpStatusCode.BadRequest,
                    message = "Email tidak boleh null atau kosong"
                });
            }

            try
            {
                //check email
                var account = repository.FindByEmail(loginVM.Email);

                if (account == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new
                    {
                        status = (int)HttpStatusCode.BadRequest,
                        message = "Email tidak terdaftar"
                    });
                }

                //Generate Reset password
                //  string resetPassword = repository.GetRandomAlphanumericString(8);
                string resetPassword = System.Guid.NewGuid().ToString();
                string GetDate = System.DateTime.Now.ToString();
                string SubjectEmail = "Reset Password -  " + GetDate;
                //Reset password
                if (repository.ResetPassword(account.NIK, resetPassword))
                {

                    //send password to email
                    EmailSender.SendEmail(loginVM.Email, SubjectEmail, "Hello "
                                  + loginVM.Email + "<br><br>berikut reset password anda, jangan lupa ganti dengan password baru<br><br><b>"
                                  + resetPassword + "<b><br><br>Thanks<br>netcore-api.com");

                    return StatusCode((int)HttpStatusCode.OK, new
                    {
                        status = (int)HttpStatusCode.OK,
                        message = "reset Password berhasil dikirim ke email " + loginVM.Email + "."
                    });
                }

                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message = "Gagal reset password"
                });

            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message = e.Message
                });
            }
        }

        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword(LoginVM loginVM)
        {
            //validating
            if (string.IsNullOrEmpty(loginVM.Email) || string.IsNullOrEmpty(loginVM.NewPassword))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new
                {
                    status = (int)HttpStatusCode.BadRequest,
                    message = "Email dan password tidak boleh null atau kosong"
                });
            }

            //check email
            var account = repository.FindByEmail(loginVM.Email);

            if (account == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new
                {
                    status = (int)HttpStatusCode.BadRequest,
                    message = "Email tidak terdaftar"
                });
            }

            return StatusCode((int)HttpStatusCode.OK, new
            {
                status = (int)HttpStatusCode.OK,
                message = repository.ResetPassword(account.NIK, loginVM.OTP, loginVM.NewPassword)
            });

        }

        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword(LoginVM loginVM)
        {
            //validating
            if (string.IsNullOrEmpty(loginVM.Email) || string.IsNullOrEmpty(loginVM.Password) || string.IsNullOrEmpty(loginVM.NewPassword))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new
                {
                    status = (int)HttpStatusCode.BadRequest,
                    message = "Email dan password tidak boleh null atau kosong"
                });
            }

            //check email
            var account = repository.FindByEmail(loginVM.Email);

            if (account == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new
                {
                    status = (int)HttpStatusCode.BadRequest,
                    message = "Email tidak terdaftar"
                });
            }

            //check password match
            if (!BCrypt.Net.BCrypt.Verify(loginVM.Password, account.Password))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new
                {
                    status = (int)HttpStatusCode.BadRequest,
                    message = "Password Salah"
                });
            }

            //change password
            repository.Update(new Account
            {
                NIK = account.NIK,
                Password = BCrypt.Net.BCrypt.HashPassword(loginVM.NewPassword)
            });

            return StatusCode((int)HttpStatusCode.OK, new
            {
                status = (int)HttpStatusCode.OK,
                message = "ubah password berhasil"
            });

        }

    }
}
