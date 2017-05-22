using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class AddConverter : IValueConverter
    {
        private static readonly ConcurrentDictionary<Type, Delegate> CompileDelegates = new ConcurrentDictionary<Type, Delegate>();

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var valueType = value.GetType();
            Delegate compileDelegate;
            if (!CompileDelegates.TryGetValue(valueType, out compileDelegate))
            {
                var aExpression = Expression.Variable(valueType);
                var bExpression = Expression.Variable(valueType);
                var resultExpression = Expression.Add(aExpression, bExpression);
                compileDelegate = Expression.Lambda(resultExpression, aExpression, bExpression).Compile();
                CompileDelegates.TryAdd(valueType, compileDelegate);
            }
            return compileDelegate.DynamicInvoke(value, System.Convert.ChangeType(parameter, valueType));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}