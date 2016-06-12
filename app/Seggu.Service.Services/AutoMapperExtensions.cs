using AutoMapper;
using Parse;
using Seggu.Domain;
using Seggu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seggu.Data;

namespace Seggu.Service.Services
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TE, TVM> GetCommonMappingExpressionToVM<TE, TVM>(this IMappingExpression<TE, TVM> mappingExpression)
            where TE : IdParseEntity
            where TVM : ViewModel
        {
            return mappingExpression
                .ForMember(x => x.CreatedAt, y => y.Ignore())
                .ForMember(x => x.UpdatedAt, y => y.Ignore())
                .ForMember(x => x.ACL, y => y.ResolveUsing(GetAcl));
        }

        public static IMappingExpression<TViewModel, TParseEntity> GetCommonMappingExpressionToEntity<TViewModel, TParseEntity>(this IMappingExpression<TViewModel, TParseEntity> expression)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            return expression
                .ForMember(x => x.LocallyUpdatedAt, y => y.MapFrom(x => x.UpdatedAt));
        }

        private static object GetAcl(ResolutionResult res)
        {
            var setting = (Setting)res.Context.Options.Items["Setting"];
            var operation = (string)res.Context.Options.Items["HttpMethod"];
            if (operation == "POST")
            {
                var acl = new ParseACL(ParseUser.CurrentUser);
                acl.PublicReadAccess = false;
                acl.PublicWriteAccess = false;
                acl.SetRoleReadAccess(setting.ClientsRole, true);
                acl.SetRoleReadAccess(setting.UserRole, true);
                acl.SetRoleWriteAccess(setting.ClientsRole, true);
                acl.SetRoleWriteAccess(setting.UserRole, true);
                return acl;
            }
            else
            {
                return null;
            }
        }

        public static void SetOptions<TSource, TDestination>(
            IMappingOperationOptions<TSource, TDestination> options,
            Setting setting,
            SegguDataModelContext context,
            string method)
        {
            options.Items["Setting"] = setting;
            options.Items["DbContext"] = context;
            options.Items["HttpMethod"] = method;
        }

        public static object ResolveWithOptions(ResolutionResult res, Func<SegguDataModelContext, Setting, string, ResolutionResult, object> predicate)
        {
            var setting = (Setting)res.Context.Options.Items["Setting"];
            var context = (SegguDataModelContext)res.Context.Options.Items["DbContext"];
            var method = (string)res.Context.Options.Items["HttpMethod"];
            return predicate(context, setting, method, res);
        }

        public static T GetParseObject<T>(string objectId) where T : ViewModel
        {
            var awaitable = new ParseQuery<T>().GetAsync(objectId);
            awaitable.Wait();
            return awaitable.Result;
        }
    }
}
