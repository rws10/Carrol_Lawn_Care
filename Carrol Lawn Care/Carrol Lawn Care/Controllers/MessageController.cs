﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SomeProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        [ChildActionOnly]
        public ActionResult TempMessage()
        {
            return PartialView();
        }
    }
}