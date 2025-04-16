using AutoGenerator;
using AutoGenerator.Helper.Translation;
using LAHJAAPI.Models;
using System;

namespace V1.DyModels.VMs
{
    /// <summary>
    /// Space  property for VM Update.
    /// </summary>
    public class SpaceUpdateVM : ITVM
    {
     
        public string? Id { get; set; }
     
        public String? Name { get; set; }
      
        public String? Description { get; set; }
       
        public Nullable<Int32> Ram { get; set; }
         
        public Nullable<Int32> CpuCores { get; set; }
       
        public Nullable<Single> DiskSpace { get; set; }
       
        public Nullable<Boolean> IsGpu { get; set; }
    
        public Nullable<Boolean> IsGlobal { get; set; }
       
        public Nullable<Single> Bandwidth { get; set; }
      
    }
}