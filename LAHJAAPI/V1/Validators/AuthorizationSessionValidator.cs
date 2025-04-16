//using AutoGenerator.Conditions;
//using LAHJAAPI.V1.Validators;
//using LAHJAAPI.V1.Validators.Conditions;
//using V1.DyModels.Dso.Requests;
//using V1.DyModels.Dso.ResponseFilters;

//namespace ApiCore.Validators
//{
//    public enum AuthorizationSessionValidatorStates
//    {
//        HasSessionToken,
//        HasAuthorizationType,
//        HasStartTime,
//        IsActive,
//        HasUserId,
//        HasEndTime,
//        IsFull,

//        IsFound
//    }

//    public class AuthorizationSessionValidator : BaseValidator<AuthorizationSessionResponseFilterDso, AuthorizationSessionValidatorStates>, ITValidator
//    {
//        public AuthorizationSessionValidator(IConditionChecker checker) : base(checker)
//        {
//        }

//        protected override void InitializeConditions()
//        {
//            _provider.Register(
//                AuthorizationSessionValidatorStates.HasSessionToken,
//                new LambdaCondition<AuthorizationSessionRequestDso>(
//                    nameof(AuthorizationSessionValidatorStates.HasSessionToken),
//                    context => !string.IsNullOrWhiteSpace(context.SessionToken),
//                    "Session Token is required"
//                )
//            );

//            _provider.Register(
//                AuthorizationSessionValidatorStates.HasAuthorizationType,
//                new LambdaCondition<AuthorizationSessionRequestDso>(
//                    nameof(AuthorizationSessionValidatorStates.HasAuthorizationType),
//                    context => !string.IsNullOrWhiteSpace(context.AuthorizationType),
//                    "Authorization Type is required"
//                )
//            );


//            _provider.Register(
//                AuthorizationSessionValidatorStates.HasStartTime,
//                new LambdaCondition<AuthorizationSessionRequestDso>(
//                    nameof(AuthorizationSessionValidatorStates.HasStartTime),
//                    context => context.StartTime != default,
//                    "Start Time is required"
//                )
//            );

//            _provider.Register(
//                AuthorizationSessionValidatorStates.IsActive,
//                new LambdaCondition<AuthorizationSessionRequestDso>(
//                    nameof(AuthorizationSessionValidatorStates.IsActive),
//                    context => context.IsActive,
//                    "Session must be active"
//                )
//            );

//            _provider.Register(
//                AuthorizationSessionValidatorStates.HasUserId,
//                new LambdaCondition<AuthorizationSessionRequestDso>(
//                    nameof(AuthorizationSessionValidatorStates.HasUserId),
//                    context => !string.IsNullOrWhiteSpace(context.UserId),
//                    "User ID is required"
//                )
//            );

//            _provider.Register(
//                AuthorizationSessionValidatorStates.HasEndTime,
//                new LambdaCondition<AuthorizationSessionRequestDso>(
//                    nameof(AuthorizationSessionValidatorStates.HasEndTime),
//                    context => context.EndTime.HasValue,
//                    "End Time is required"
//                )
//            );

//            _provider.Register(
//                AuthorizationSessionValidatorStates.IsFull,
//                new LambdaCondition<AuthorizationSessionRequestDso>(
//                    nameof(AuthorizationSessionValidatorStates.IsFull),
//                    context => IsValidAuthorizationSession(context),
//                    "Authorization session is incomplete"
//                )
//            );
//        }
//        private bool CheckCustomerId(string userId)
//        {
//            return _checker.Check(ApplicationUserValidatorStates.HasCustomerId, userId);
//        }

//        private bool CheckSessionToken(string sessionToken)
//        {
//            return !string.IsNullOrWhiteSpace(sessionToken);
//        }

//        private bool CheckAuthorizationType(string authorizationType)
//        {
//            return !string.IsNullOrWhiteSpace(authorizationType);
//        }
//        private bool IsValidAuthorizationSession(AuthorizationSessionRequestDso context)
//        {
//            var conditions = new List<Func<AuthorizationSessionRequestDso, bool>>
//            {
//                c =>CheckSessionToken(c.SessionToken),
//                c =>CheckAuthorizationType(c.AuthorizationType),
//                c => c.StartTime != default,
//                c => CheckCustomerId(c.UserId),
//                c => c.IsActive,
//                c => c.EndTime.HasValue,
//            };

//            return conditions.All(condition => condition(context));
//        }
//    }
//}
using AutoGenerator.Conditions;
using LAHJAAPI.Data;
using LAHJAAPI.Models;
using LAHJAAPI.V1.Validators;
using LAHJAAPI.V1.Validators.Conditions;
using V1.DyModels.Dso.Requests;
using V1.DyModels.Dso.ResponseFilters;
using V1.DyModels.VMs;

namespace ApiCore.Validators
{
    public enum SessionValidatorStates
    {
        HasSessionToken,
        HasAuthorizationType,
        HasStartTime,
        IsActive,
        HasUserId,
        HasEndTime,
        IsFull,
        IsFound
    }

    public class AuthorizationSessionValidator : BaseValidator<AuthorizationSessionResponseFilterDso, SessionValidatorStates>, ITValidator
    {
        DataContext _context;
        private readonly IConditionChecker _checker;

        public AuthorizationSessionValidator(IConditionChecker checker) : base(checker)
        {
            _context = checker.Injector.Context;
            _checker = checker;
        }

        protected override void InitializeConditions()
        {
            _provider.Register(
                SessionValidatorStates.IsFound,
                new LambdaCondition<AuthorizationSessionFilterVM>(
                    nameof(SessionValidatorStates.IsFound),
                    context => IsFound(context.Id),
                    "Session not found"
                )
            );

            _provider.Register(
                SessionValidatorStates.IsActive,
                new LambdaCondition<AuthorizationSessionFilterVM>(
                    nameof(SessionValidatorStates.IsActive),
                    context => IsActive(context.Id),
                    "Session not active"
                )
            );

            _provider.Register(
                SessionValidatorStates.HasSessionToken,
                new LambdaCondition<AuthorizationSessionRequestDso>(
                    nameof(SessionValidatorStates.HasSessionToken),
                    context => !string.IsNullOrWhiteSpace(context.SessionToken),
                    "Session Token is required"
                )
            );

            _provider.Register(
                SessionValidatorStates.HasAuthorizationType,
                new LambdaCondition<AuthorizationSessionRequestDso>(
                    nameof(SessionValidatorStates.HasAuthorizationType),
                    context => !string.IsNullOrWhiteSpace(context.AuthorizationType),
                    "Authorization Type is required"
                )
            );


            _provider.Register(
                SessionValidatorStates.HasStartTime,
                new LambdaCondition<AuthorizationSessionRequestDso>(
                    nameof(SessionValidatorStates.HasStartTime),
                    context => context.StartTime != default,
                    "Start Time is required"
                )
            );

            _provider.Register(
                SessionValidatorStates.IsActive,
                new LambdaCondition<AuthorizationSessionRequestDso>(
                    nameof(SessionValidatorStates.IsActive),
                    context => context.IsActive,
                    "Session must be active"
                )
            );

            _provider.Register(
                SessionValidatorStates.HasUserId,
                new LambdaCondition<AuthorizationSessionRequestDso>(
                    nameof(SessionValidatorStates.HasUserId),
                    context => !string.IsNullOrWhiteSpace(context.UserId),
                    "User ID is required"
                )
            );

            _provider.Register(
                SessionValidatorStates.HasEndTime,
                new LambdaCondition<AuthorizationSessionRequestDso>(
                    nameof(SessionValidatorStates.HasEndTime),
                    context => context.EndTime.HasValue,
                    "End Time is required"
                )
            );

            _provider.Register(
                SessionValidatorStates.IsFull,
                new LambdaCondition<AuthorizationSessionRequestDso>(
                    nameof(SessionValidatorStates.IsFull),
                    context => IsValidAuthorizationSession(context),
                    "Authorization session is incomplete"
                )
            );
        }
        AuthorizationSession? Session { get; set; } = null;
        private AuthorizationSession? GetSession(string? id)
        {
            if (Session is not null) return Session;
            if (id == null) id = _checker.Injector.UserClaims.SessionId;
            if (string.IsNullOrWhiteSpace(id)) return null;
            return Session = _context.AuthorizationSessions.FirstOrDefault(s => s.Id == id);
        }

        private bool IsFound(string? id)
        {
            return GetSession(id) is not null;
        }


        private bool IsActive(string? id)
        {
            if (!IsFound(id)) return false;
            var session = GetSession(id);
            return session!.IsActive;
        }

        private bool CheckCustomerId(string userId)
        {
            return _checker.Check(ApplicationUserValidatorStates.HasCustomerId, userId);
        }

        private bool CheckSessionToken(string sessionToken)
        {
            return !string.IsNullOrWhiteSpace(sessionToken);
        }

        private bool CheckAuthorizationType(string authorizationType)
        {
            return !string.IsNullOrWhiteSpace(authorizationType);
        }
        private bool IsValidAuthorizationSession(AuthorizationSessionRequestDso context)
        {
            var conditions = new List<Func<AuthorizationSessionRequestDso, bool>>
            {
                c =>CheckSessionToken(c.SessionToken),
                c =>CheckAuthorizationType(c.AuthorizationType),
                c => c.StartTime != default,
                c => CheckCustomerId(c.UserId),
                c => c.IsActive,
                c => c.EndTime.HasValue,
            };

            return conditions.All(condition => condition(context));
        }
    }
}
