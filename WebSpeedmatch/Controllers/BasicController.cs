using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Infrastructure.CP;
using Infrastructure.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace WebSpeedmatch.Controllers
{
    public class BasicController:Controller
    {
        private NHibernate.ISession sessionInside;

        protected SessionCPNHibernate session;

        protected BasicController()
        {
        }

        protected void SessionInitialize()
        {
            if (session == null)
            {
                sessionInside = NHibernateHelper.GetSession();
                session = new SessionCPNHibernate(sessionInside);
            }
        }

        protected void SessionClose()
        {
            if (session != null && sessionInside.IsOpen)
            {
                sessionInside.Close();
                sessionInside.Dispose();
                session = null;
            }
        }
    }
}


