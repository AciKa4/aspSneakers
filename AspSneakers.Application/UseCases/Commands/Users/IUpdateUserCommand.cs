﻿using AspSneakers.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.Commands.Users
{
    public interface IUpdateUserCommand : ICommand<UserDto>
    {
    }
}
