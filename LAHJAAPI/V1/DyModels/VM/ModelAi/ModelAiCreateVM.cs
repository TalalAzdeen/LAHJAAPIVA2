using AutoGenerator;
using AutoGenerator.Helper.Translation;
using LAHJAAPI.Models;
using System;

namespace V1.DyModels.VMs
{
    /// <summary>
    /// ModelAi  property for VM Create.
    /// </summary>
    public class ModelAiCreateVM : ITVM
    {
        //
        public TranslationData? Name { get; set; }
        ///
        public String? Token { get; set; }
        ///
        public String? AbsolutePath { get; set; }
        //
        public TranslationData? Category { get; set; }
        //
        public TranslationData? Language { get; set; }
        //
        public bool? IsStandard { get; set; }
        //
        public TranslationData? Gender { get; set; }
        //
        public TranslationData? Dialect { get; set; }
        ///
        public String? Type { get; set; }
        ///
        public String? ModelGatewayId { get; set; }
        //public ModelGatewayCreateVM? ModelGateway { get; set; }
        ////
        //public List<ServiceCreateVM>? Services { get; set; }
        ////
        //public List<UserModelAiCreateVM>? UserModelAis { get; set; }
    }
}