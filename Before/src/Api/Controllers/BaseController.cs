using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public BaseController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected new IActionResult Ok()    //'new' keyword is to surpress the compiler warning, as the Ok() method in the Controller class is not virtual.
        {
            _unitOfWork.Commit();
            return base.Ok();
        }

        protected IActionResult Ok<T>(T result)
        {
            _unitOfWork.Commit();
            return base.Ok(result);
        }

        protected IActionResult Error(string errorMessage)
        {
            //Error does not commit changes
            return BadRequest(errorMessage);
        }
    }
}
