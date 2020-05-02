using Microsoft.AspNetCore.Mvc.ModelBinding;
using ReserveProject.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;

namespace ReserveProject.Shared.PagingAndFilter
{
    public static class QueryPaging
    {
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, IPagedQuery request)
         where TSource : class
        {
            if (request == null)
                return source;
            if (request.Page < 0 || request.PageSize < 0)
            {
                return source;
            }
            //default
            var page = request.Page ?? 1;
            var pageSize = request.PageSize ?? 25;

            return source.Skip(pageSize * (page - 1)).Take(pageSize);
        }


        public static IQueryable<TSource> Filter<TSource>(this IQueryable<TSource> source, FilterModel filterModel) where TSource : class
        {
            if (filterModel.FilterModelObject.FilterItems == null || filterModel.FilterModelObject.FilterItems.Count() == 0)
                return source;

            var query = new FilterInitializer().ConstructAndExpressionTree<TSource>(filterModel);
            return source.Where(query);
        }

        public static IQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source, SortModel sortModel) where TSource : class
        {
            if (sortModel.Items == null || sortModel.Items.Count() == 0)
                return source;
            var sortArray = sortModel.Items.Select(x => x.ToString()).ToArray();
            return source.OrderBy(string.Join(", ", sortArray));
        }
    }

    public interface IPagedQuery
    {
        int? PageSize { get; set; }

        int? Page { get; set; }
    }

    public interface ISearchableQuery
    {
        string SearchQuery { get; set; }
    }

    public interface IFilterable
    {
        FilterModel FilterModel { get; set; }
    }

    public interface ISortable
    {
        SortModel SortModel { get; set; }
    }

    public enum Comparison
    {
        Equal,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        NotEqual,
        Contains,
        StartsWith,
        EndsWith
    }
    public enum FilterLogic
    {

        And = 0,
        Or = 1

    }
    public class FilterItem
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public Comparison Comparison { get; set; }
    }

    public class FilterModel
    {
        public string Json { get; set; }

        [BindNever]
        public FilterModelObject FilterModelObject
        {
            get
            {
                if (string.IsNullOrEmpty(Json)) return new FilterModelObject();
                return Serializer.As<FilterModelObject>(Json);
            }
        }

    }

    public class FilterModelObject
    {
        [BindNever]
        public List<FilterItem> FilterItems { get; set; } = new List<FilterItem>();
        [BindNever]
        public FilterLogic FilterLogic { get; set; }
    }

    public class SortModel
    {
        public string Json { get; set; }

        [BindNever]
        public List<SortItem> Items
        {
            get
            {
                if (string.IsNullOrEmpty(Json)) return new List<SortItem>();
                return Serializer.As<List<SortItem>>(Json);
            }
        }
    }

    public class SortItem
    {
        public string SortBy { get; set; }
        public bool Desc { get; set; }

        public override string ToString()
        {
            if (Desc) return SortBy + " desc";
            return SortBy;
        }
    }

    public class FilterInitializer
    {
        public Expression<Func<T, bool>> ConstructAndExpressionTree<T>(FilterModel filterModel)
        {
            if (filterModel.FilterModelObject.FilterItems.Count == 0)
                return null;
            ExpressionRetriever expressionRetriever = new ExpressionRetriever();
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp;
            if (filterModel.FilterModelObject.FilterItems.Count == 1)
            {
                exp = expressionRetriever.GetExpression<T>(param, filterModel.FilterModelObject.FilterItems[0]);
            }
            else
            {
                exp = expressionRetriever.GetExpression<T>(param, filterModel.FilterModelObject.FilterItems[0]);
                for (int i = 1; i < filterModel.FilterModelObject.FilterItems.Count; i++)
                {
                    if (filterModel.FilterModelObject.FilterLogic == FilterLogic.Or)
                        exp = Expression.Or(exp, expressionRetriever.GetExpression<T>(param, filterModel.FilterModelObject.FilterItems[i]));
                    else
                        exp = Expression.And(exp, expressionRetriever.GetExpression<T>(param, filterModel.FilterModelObject.FilterItems[i]));

                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }
    }

    public class ExpressionRetriever
    {
        private MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        private MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        private MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        public Expression GetExpression<T>(ParameterExpression param, FilterItem filter)
        {
            var member = Expression.Property(param, filter.PropertyName);
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var converter = TypeDescriptor.GetConverter(propertyType); // 1

            if (!converter.CanConvertFrom(typeof(string))) // 2
                throw new NotSupportedException();

            var propertyValue = converter.ConvertFromInvariantString(filter.Value.ToString()); // 3
            var constant = Expression.Constant(propertyValue);
            var valueExpression = Expression.Convert(constant, propertyType); // 4




            //MemberExpression member = Expression.Property(param, filter.PropertyName);
            //ConstantExpression constant = Expression.Constant(filter.Value);
            switch (filter.Comparison)
            {
                case Comparison.Equal:
                    return Expression.Equal(member, valueExpression);
                case Comparison.GreaterThan:
                    return Expression.GreaterThan(member, valueExpression);
                case Comparison.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, valueExpression);
                case Comparison.LessThan:
                    return Expression.LessThan(member, valueExpression);
                case Comparison.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, valueExpression);
                case Comparison.NotEqual:
                    return Expression.NotEqual(member, valueExpression);
                case Comparison.Contains:
                    return Expression.Call(member, containsMethod, valueExpression);
                case Comparison.StartsWith:
                    return Expression.Call(member, startsWithMethod, valueExpression);
                case Comparison.EndsWith:
                    return Expression.Call(member, endsWithMethod, valueExpression);
                default:
                    return null;
            }
        }

    }
}
