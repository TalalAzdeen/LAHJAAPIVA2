using AutoGenerator;
using AutoGenerator.Helper.Translation;
using LAHJAAPI.Models;
using AutoGenerator.Config;
using System;

namespace V1.DyModels.Dto.Build.Responses
{
    public class AdvertisementResponseBuildDto : ITBuildDto
    {
        /// <summary>
        /// Id property for DTO.
        /// </summary>
        public String? Id { get; set; }
        public TranslationData? Title { get; set; } = new();
        public TranslationData? Description { get; set; } = new();
        /// <summary>
        /// Image property for DTO.
        /// </summary>
        public String? Image { get; set; }
        /// <summary>
        /// Active property for DTO.
        /// </summary>
        public Boolean Active { get; set; }
        /// <summary>
        /// Url property for DTO.
        /// </summary>
        public String? Url { get; set; }
        public ICollection<AdvertisementTabResponseBuildDto>? AdvertisementTabs { get; set; }
    }
}