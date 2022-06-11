﻿using AspSneakers.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.Queries.Categories
{
    public interface IFindCategoryQuery : IQuery<int,CategoryDto>
    {
    }
}
