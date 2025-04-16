  using AutoGenerator.Conditions;

using AutoMapper;
using LAHJAAPI.Models;
using LAHJAAPI.V1.Validators.Conditions;
using Microsoft.AspNetCore.Mvc;
using V1.DyModels.Dso.Requests;
using V1.DyModels.Dso.ResponseFilters;
using V1.DyModels.VMs;

namespace LAHJAAPI.V1.Validators
{



    public enum SpaceValidatorStates
    {
        IsActive,
        IsSpaceId,
        IsFull,
        IsValid,
        HasName,
        HasRam,
        HasCpu,
        HasDisk,
        HasBandwidth,
        HasToken,
        HasSubscriptionId,
        IsGpuEnabled,
        IsGlobalEnabled,
        IsCountSpces


    }


    public class SpaceValidator : BaseValidator<SpaceResponseFilterDso, SpaceValidatorStates>, ITValidator
    {

        private readonly IConditionChecker _checker;
        public SpaceValidator(IConditionChecker checker) : base(checker)
        {

            _checker = checker;
        }
        protected override void InitializeConditions()
        {


            _provider.Register(
                SpaceValidatorStates.IsActive,
                new LambdaCondition<SpaceRequestDso>(
                    nameof(SpaceValidatorStates.IsActive),

                    context => ValidAactiveResult(context),
                    "Space is not active"
                )
            );


            _provider.Register(
                SpaceValidatorStates.IsFull,
                new LambdaCondition<SpaceRequestDso>(
                    nameof(SpaceValidatorStates.IsFull),
                    context => IsFull(context),
                    "Space is full"
                )
            );


            _provider.Register(SpaceValidatorStates.IsCountSpces,
                new LambdaCondition<string>(
                    nameof(SpaceValidatorStates.IsCountSpces),
                    context => IsAllowedSpaces(context),
                    "Space is not count"
                )
            );




            _provider.Register(SpaceValidatorStates.HasToken,
                new LambdaCondition<SpaceRequestDso>(
                    nameof(SpaceValidatorStates.HasToken),
                    context => IsToken(context),
                    "Space is not global"
                )
            );



            _provider.Register(SpaceValidatorStates.IsSpaceId,
                new LambdaCondition<string>(
                    nameof(SpaceValidatorStates.IsSpaceId),
                    context => ISpaceId(context),
                    "Space is not valid"
                )
            );




        }


        private bool ISpaceId(string spaceId)
        {
            if (spaceId != "")
            {
                var result = _checker.Injector.Context.Set<Space>()
                    .Any(x => x.Id == spaceId);

                return result;
            }
            else
            {
                return false;

            }



        }
        private bool IsAllowedSpaces(string subId)
        {
            var spaces = _checker.Injector.Context.Set<Space>()
                .Where(x => x.SubscriptionId == subId)
                .ToList();

            var result = _checker.Injector.Context.Set<Subscription>()
               .Any(sub => sub.AllowedSpaces < spaces.Count);

            return result;
          
           
            // return _checker.Check(SubscriptionValidatorStates.IsIsAllowedSpaces,count, subId);

          //  return _checker.Check(SubscriptionValidatorStates.IsAllowedRequests, new object[] { count, subId });



        }

        private bool IsToken(SpaceRequestDso context)
        {
            if (context.IsGlobal == true)
            {
                return true;
            }
            return false;
        }



        private async Task<ConditionResult> ValidAactiveResult(SpaceRequestDso context)
        {



            if (!await _checker.CheckAsync(SubscriptionValidatorStates.IsActive, context.SubscriptionId))

                return new ConditionResult(false, new ProblemDetails
                {
                    Title = "Create space",
                    Detail = "No Ative ",
                    Status = 603

                });


           if (IsAllowedSpaces(context.SubscriptionId))


                  return new ConditionResult(true, null, "succful");
                
               
           return new ConditionResult(false, new ProblemDetails
                    {
                        Title = "Create space",
                        Detail = "You have exhausted all allowed subscription space",
                        Status = 602

                    });
               


            


    
                     


        }

        private bool IsActive(SpaceRequestDso context)
        {
            var result = _checker.Check(SubscriptionValidatorStates.IsActive, context.SubscriptionId);

            if (context.IsGlobal == true && result)

            {
                return true;
            }
            return false;
        }


        private bool IsFull(SpaceRequestDso context)
        {

            var conditions = new List<Func<SpaceRequestDso, bool>>
    {
        c => c.IsGlobal == true,
        c => !string.IsNullOrWhiteSpace(c.Name),
        c => c.Ram.HasValue && c.Ram > 0,
        c => c.CpuCores.HasValue && c.CpuCores > 0,
        c => c.DiskSpace.HasValue && c.DiskSpace > 0,
        c => c.Bandwidth.HasValue && c.Bandwidth > 0,
        c => IsToken(context),
     
        c => c.IsGpu == true,
       
        };


            return conditions.All(condition => condition(context));
        }

        private (bool isFull, List<string> failedConditions) IsFullerror(SpaceRequestDso context)
        {
            var failedConditions = new List<string>();

            var conditions = new List<(Func<SpaceRequestDso, bool> condition, string errorMessage)>
    {
        (c => c.IsGlobal == true, "Space must be global"),
       // (c => _checker.Check(SubscriptionValidatorStates.IsActive, c.Subscription), "Subscription must be active"),
        (c => !string.IsNullOrWhiteSpace(c.Name), "Name is required"),
        (c => c.Ram.HasValue && c.Ram > 0, "RAM must be greater than 0"),
        (c => c.CpuCores.HasValue && c.CpuCores > 0, "CPU cores must be greater than 0"),
        (c => c.DiskSpace.HasValue && c.DiskSpace > 0, "Disk space must be greater than 0"),
        (c => c.Bandwidth.HasValue && c.Bandwidth > 0, "Bandwidth must be greater than 0"),
        (c => !string.IsNullOrWhiteSpace(c.Token), "Token is required"),
        (c => !string.IsNullOrWhiteSpace(c.SubscriptionId), "Subscription ID is required"),
        (c => c.IsGpu == true, "GPU must be enabled")
    };



            foreach (var (condition, errorMessage) in conditions)
            {
                if (!condition(context))
                {
                    failedConditions.Add(errorMessage);
                }
            }

            return (failedConditions.Count == 0, failedConditions);
        }


        //private bool IsFull(SpaceResponseFilterDso context)
        //{

        //        return false;
        //    }
        //    return true;
        //}
    }
    //private async Task<ConditionResult> IsFullAndErorr(RequestRequestDso? context)
    //{




    //    if (await _checker.CheckAsync(SpaceValidatorStates.IsSpaceId, context.SpaceId))

    //        return new ConditionResult(false, new ProblemDetails
    //        {
    //            Title = "Create space",
    //            Detail = "This session has removed ",
    //            Status = 603

    //        });


    //    else if (!await ValidAactiveSeesion(context.ServiceId))


    //        return new ConditionResult(false, new ProblemDetails
    //        {
    //            Title = "Create space",
    //            Detail = $"This space id {context.SpaceId} not in subscription.",
    //            Status = 603

    //        });

    //    else
    //    {
    //        var result3 = await _checker.CheckAndResultAsync(ServiceValidatorStates.IsIsServiceIdAndResult, context.ServiceId);
    //        if (result3.Success is true)
    //        {
    //            return new ConditionResult(true, result3.Result, "susssc");

    //        }
    //        else
    //        {
    //            return new ConditionResult(false, new ProblemDetails
    //            {
    //                Title = "Create space",
    //                Detail = "This service not found",
    //                Status = 603

    //            });

    //        }
    //    }










    

}