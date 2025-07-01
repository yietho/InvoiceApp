using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Features.Auth.Dto;

public class UserRegisterDto
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}