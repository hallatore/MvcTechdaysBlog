using System.Data.Entity;
using System.Data.Entity.Infrastructure;

[assembly: WebActivator.PreApplicationStartMethod(typeof(MvcTechdaysBlog.App_Start.EntityFramework_SqlServerCompact), "Start")]

namespace MvcTechdaysBlog.App_Start {
    public static class EntityFramework_SqlServerCompact {
        public static void Start() {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        }
    }
}
