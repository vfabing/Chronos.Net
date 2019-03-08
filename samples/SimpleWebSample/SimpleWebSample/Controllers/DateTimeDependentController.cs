using Chronos.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleWebSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeDependentController : ControllerBase
    {
        private IDateTimeProvider _dateTimeProvider;
        public DateTimeDependentController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        private static string[] _productList = { "Apples", "Bananas", "Strawberries" };
        private TimeSpan _storeOpen = new TimeSpan(8, 0, 0);
        private TimeSpan _storeClose = new TimeSpan(19, 0, 0);

        [HttpGet]
        public ActionResult<string[]> GetProductsIfStoreIsOpen()
        {
            // Do not use `var now = DateTime.Now;` if you don't want to be dependent on system time and have testable code. Instead use
            var now = _dateTimeProvider.Now;

            if (now.Hour >= _storeOpen.Hours && now.Hour < _storeClose.Hours)
            {
                return _productList;
            }
            else
            {
                return new string[] { "store is not opened" };
            }
        }
    }
}