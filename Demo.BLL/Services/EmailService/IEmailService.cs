﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.IdentityModel;

namespace Demo.BLL.Services.EmailService
{
    public interface IEmailService
    {
        public void SendEmail(Email email);
    }
}
