﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace stocktake_V4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class siixsem_sys_lblPrint_dbEntities : DbContext
    {
        public siixsem_sys_lblPrint_dbEntities()
            : base("name=siixsem_sys_lblPrint_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<isPlus3Months_Result> isPlus3Months(string djGroup)
        {
            var djGroupParameter = djGroup != null ?
                new ObjectParameter("djGroup", djGroup) :
                new ObjectParameter("djGroup", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<isPlus3Months_Result>("isPlus3Months", djGroupParameter);
        }
    
        public virtual ObjectResult<getDjbySerial_Result> getDjbySerial(string serial)
        {
            var serialParameter = serial != null ?
                new ObjectParameter("serial", serial) :
                new ObjectParameter("serial", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDjbySerial_Result>("getDjbySerial", serialParameter);
        }
    }
}
