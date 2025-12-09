using NHibernate;
using Infrastructure.NHibernate;

namespace Infrastructure.CP
{
    public class SessionCPNHibernate
    {
        private ISession session;

        public SessionCPNHibernate(ISession session)
        {
            this.session = session;
        }

        // Métodos de ejemplo para la sesión
        public ISession GetSession()
        {
            return session;
        }
    }
}
