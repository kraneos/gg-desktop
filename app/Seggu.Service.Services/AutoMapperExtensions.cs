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
            where TVM : ViewModel, new()
        {
            return mappingExpression
                .ConstructUsing(rc =>
                {
                    if (rc.Options.Items.ContainsKey("ObjectId"))
                    {
                        var task = new ParseQuery<TVM>().GetAsync((string)rc.Options.Items["ObjectId"]);
                        task.Wait();
                        return task.Result;
                    }
                    else if (((IdParseEntity)rc.SourceValue).ObjectId != null)
                    {
                        var task = new ParseQuery<TVM>().GetAsync(((IdParseEntity)rc.SourceValue).ObjectId);
                        task.Wait();
                        return task.Result;
                    }
                    else
                    {
                        return new TVM();
                    }
                })
                .ForMember(x => x.ObjectId, y => y.ResolveUsing(x =>
                {
                    return x.Context.Options.Items.ContainsKey("ObjectId") ? x.Context.Options.Items["ObjectId"] : ((IdParseEntity)x.Value).ObjectId;
                }))
                .ForMember(x => x.CreatedAt, y => y.Ignore())
                .ForMember(x => x.UpdatedAt, y => y.Ignore())
                .ForMember(x => x.ACL, y =>
                {
                    y.PreCondition(GetObjectIdPreCondition);
                    y.ResolveUsing(GetAcl);
                });
        }

        private static bool GetObjectIdPreCondition(ResolutionContext rc)
        {
            return !rc.Options.Items.ContainsKey("ObjectId") && ((IdParseEntity)rc.SourceValue).ObjectId == null;
        }

        public static IMappingExpression<TViewModel, TParseEntity> GetCommonMappingExpressionToEntity<TViewModel, TParseEntity>(this IMappingExpression<TViewModel, TParseEntity> expression)
            where TParseEntity : IdParseEntity
            where TViewModel : ViewModel
        {
            return expression
                .ForMember(x => x.LocallyUpdatedAt, y => y.MapFrom(x => x.UpdatedAt));
        }

        public static IMappingExpression<TSourceParseEntity, TDestinationParseEntity> GetCommonMappingExpressionEntityToEntity
            <TSourceParseEntity, TDestinationParseEntity>(this IMappingExpression<TSourceParseEntity, TDestinationParseEntity> expression)
            where TSourceParseEntity : IdParseEntity
            where TDestinationParseEntity : IdParseEntity
        {
            return expression;
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
            if (!string.IsNullOrWhiteSpace(objectId))
            {
                var awaitable = new ParseQuery<T>().GetAsync(objectId);
                awaitable.Wait();
                return awaitable.Result;

            }
            else
            {
                return null;
            }
        }

        public static object GetParseObject<T, TVm>(ResolutionContext rc, Func<T, string> predFunc)
            where TVm : ViewModel
            where T : IdParseEntity
        {
            string objectId;

            if (rc.Options.Items.ContainsKey("DbContext"))
            {
                var ctx = (SegguDataModelContext)rc.Options.Items["DbContext"];
                var obj = ctx.Set<T>().Find(((IdParseEntity)rc.SourceValue).Id);
                objectId = predFunc.Invoke(obj);
            }
            else
            {
                objectId = predFunc.Invoke((T)rc.SourceValue);
            }
            return GetParseObject<TVm>(objectId);
        }

        public static object GetParseObject<TVm>(ResolutionContext rc, Func<SegguDataModelContext, string> predFunc)
            where TVm : ViewModel
        {
            var ctx = (SegguDataModelContext)rc.Options.Items["DbContext"];
            var objectId = predFunc.Invoke(ctx);
            return GetParseObject<TVm>(objectId);
        }

        public static void AssignOptions<T, TVM>(ResolutionContext rc, IMappingOperationOptions<T, TVM> opts)
        {
            foreach (var item in rc.Options.Items)
            {
                opts.Items.Add(item);
            }
        }
    }
}
