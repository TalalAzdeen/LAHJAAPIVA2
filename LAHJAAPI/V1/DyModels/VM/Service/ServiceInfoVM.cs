using AutoGenerator;
using AutoGenerator.Helper.Translation;
using LAHJAAPI.Models;
using System;
using V1.DyModels.Dso.Responses;
using V1.DyModels.Dto.Build.Responses;

namespace V1.DyModels.VMs
{
    /// <summary>
    /// Service  property for VM Info.
    /// </summary>
    public class ServiceInfoVM : ITVM
    {
        ///
        public string? Id { get; set; }
      


        public String? Name { get; set; }


        public String? AbsolutePath { get; set; }




        public String? Token { get; set; }


        public String? ModelAiId { get; set; }
        public ICollection<ServiceMethodResponseDso>? ServiceMethods { get; set; }
        public ICollection<UserServiceResponseDso>? UserServices { get; set; }
        public ICollection<RequestResponseDso>? Requests { get; set; }
    }
}