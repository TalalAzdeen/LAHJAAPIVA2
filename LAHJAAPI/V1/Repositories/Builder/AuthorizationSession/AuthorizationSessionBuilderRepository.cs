using AutoMapper;
using LAHJAAPI.Data;
using LAHJAAPI.Models;
using V1.Repositories.Base;
using AutoGenerator.Repositories.Builder;
using V1.DyModels.Dto.Build.Requests;
using V1.DyModels.Dto.Build.Responses;
using System;

namespace V1.Repositories.Builder
{
    /// <summary>
    /// AuthorizationSession class property for BuilderRepository.
    /// </summary>
     //
    public class AuthorizationSessionBuilderRepository : BaseBuilderRepository<AuthorizationSession, AuthorizationSessionRequestBuildDto, AuthorizationSessionResponseBuildDto>, IAuthorizationSessionBuilderRepository<AuthorizationSessionRequestBuildDto, AuthorizationSessionResponseBuildDto>
    {
        /// <summary>
        /// Constructor for AuthorizationSessionBuilderRepository.
        /// </summary>
        public AuthorizationSessionBuilderRepository(DataContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) // Initialize  constructor.
        {
        // Initialize necessary fields or call base constructor.
        ///
        /// 
         
        /// 
        }
    //
    // Add additional methods or properties as needed.
    }
}