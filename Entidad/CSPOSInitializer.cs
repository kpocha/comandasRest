using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entidad
{
    public class WebInitializer: IDatabaseInitializer<WebContext>
    {
        public bool nueva=false;
        public void InitializeDatabase(WebContext context)
        {
            bool dbExists;
            dbExists = context.Database.Exists();
            if (dbExists)
            {
                try
                {
                    if (!context.Database.CompatibleWithModel(true))
                    {
                        throw new Exception("La base de datos existe y no es compatible...");
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                context.Database.Create();
                context.SaveChanges();
                nueva = true;
                return;
            }
            return;
        }

       
        public void CreateUser(WebContext context)
        {
            
        }

        protected void Seed(WebContext context)
        
        {

        }
    }
}