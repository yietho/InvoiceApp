using InvoiceApp.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}