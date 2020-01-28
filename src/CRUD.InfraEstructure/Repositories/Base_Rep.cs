using CRUD.InfraEstructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.InfraEstructure.Repositories
{
    public class Base_Rep
    {
        protected readonly Context CTX;

        public Base_Rep(Context _CTX)
        {
            CTX = _CTX;
        }

    }
}
