namespace Broker.Common.AppMetaData
{
    public static class Router
    {
        public const string SignleRoute = "/{id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class AuthenticationAndAuthorization
        {
            public const string module = Rule + "AuthenticationAndAuthorization/";
            public static class ApplicationUserRouting
            {
                public const string Prefix = module + "User";
                public const string Create = Prefix + "/Create";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetByID = Prefix + SignleRoute;
                public const string Edit = Prefix + "/Edit";
                public const string Delete = Prefix + "/{id}";
                public const string ChangePassword = Prefix + "/Change-Password";
            }
            public static class Authentication
            {
                public const string Prefix = module + "Authentication";
                public const string SignIn = Prefix + "/SignIn";
                public const string RefreshToken = Prefix + "/Refresh-Token";
                public const string ValidateToken = Prefix + "/Validate-Token";
                public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
                public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";
                public const string ConfirmResetPasswordCode = Prefix + "/ConfirmResetPasswordCode";
                public const string ResetPassword = Prefix + "/ResetPassword";

            }
            public static class AuthorizationRouting
            {
                public const string Prefix = module + "AuthorizationRouting";
                public const string Roles = Prefix + "/Roles";
                public const string Claims = Prefix + "/Claims";
                public const string Create = Roles + "/Create";
                public const string Edit = Roles + "/Edit";
                public const string Delete = Roles + "/Delete/{id}";
                public const string RoleList = Roles + "/Role-List";
                public const string GetRoleById = Roles + "/Role-By-Id/{id}";
                public const string ManageUserRoles = Roles + "/Manage-User-Roles/{userId}";
                public const string ManageUserClaims = Claims + "/Manage-User-Claims/{userId}";
                public const string UpdateUserRoles = Roles + "/Update-User-Roles";
                public const string UpdateUserClaims = Claims + "/Update-User-Claims";
                public const string ManageRoleClaims = Claims + "/Manage-Role-Claims/{roleId}";
                public const string UpdateRoleClaims = Claims + "/Update-Role-Claims";
            }
            public static class EmailsRoute
            {
                public const string Prefix = module + "EmailsRoute";
                public const string SendEmail = Prefix + "/SendEmail";
            }

        }


        public static class Plans
        {
            public const string module = Rule + "Plans/";
            public static class ConcernedPartiesRouting
            {
                public const string Prefix = module + "ConcernedPartiesRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string GetMaxId = Prefix + "/MaxId";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class ManagementRouting
            {
                public const string Prefix = module + "ManagementRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }

            public static class ReviewRouting
            {
                public const string Prefix = module + "ReviewRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }

            public static class FirstlyDataRouting
            {
                public const string Prefix = module + "FirstlyDataRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class ReviewTopicRouting
            {
                public const string Prefix = module + "ReviewTopicRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }


            public static class PlansRouting
            {
                public const string Prefix = module + "PlansRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string GetMaxId = Prefix + "/MaxId";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class IndicatorRouting
            {
                public const string Prefix = module + "IndicatorRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string GetMaxId = Prefix + "/MaxId";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class IndicatorDetailsRouting
            {
                public const string Prefix = module + "IndicatorDetailsRouting";
                public const string GetByIndicatorId = Prefix + "/Get-By-Indicator-Id/{id}";
                public const string GetById = Prefix + "/{id}";
                public const string GetMaxId = Prefix + "/MaxId";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class IndicatorsCategoriesRouting
            {
                public const string Prefix = module + "IndicatorsCategoriesRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string GetMaxId = Prefix + "/MaxId";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class FilesRouting
            {
                public const string Prefix = module + "FilesRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class SystemLogsRouting
            {
                public const string Prefix = module + "SystemLogsRouting";
                public const string Paginated = Prefix + "/Paginated";
            }

            public static class ReviewPointsRouting
            {
                public const string Prefix = module + "ReviewPointsRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string GetMaxId = Prefix + "/MaxId";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }

            public static class PointCommentsRouting
            {
                public const string Prefix = module + "PointCommentsRouting";
                public const string Paginated = Prefix + "/Paginated/{pointId}";
                public const string GetById = Prefix + "/{id}";
                public const string GetMaxId = Prefix + "/MaxId";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }

            public static class UserPointRouting
            {
                public const string Prefix = module + "UserPointRouting";
                public const string GetUsersByPointId = Prefix + "/Users/{pointId}";
                public const string Add = Prefix + "/Add";
                public const string Delete = Prefix + "/Delete-User-From-Point";
            }
            public static class ProcedureRouting
            {
                public const string Prefix = module + "ProcedureRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }

            public static class ProcedureDetailsRouting
            {
                public const string Prefix = module + "ProcedureDetailsRouting";
                public const string Paginated = Prefix + "/Paginated";
                public const string GetById = Prefix + "/{id}";
                public const string Add = Prefix + "/Add";
                public const string Update = Prefix + "/Update";
                public const string Delete = Prefix + "/{id}";
            }
            public static class BranchRouting
            {
                public const string Prefix = module + "BranchRouting";
                public const string Paginated = Prefix + "/Paginated";
            }


        }
    }
}
