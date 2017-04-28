using System;
using System.Linq.Expressions;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class AddConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var valueType = value.GetType();
            var aExpression = Expression.Variable(valueType);
            var bExpression = Expression.Variable(valueType);
            var resultExpression = Expression.Add(aExpression, bExpression);
            return Expression.Lambda(resultExpression, aExpression, bExpression).Compile().DynamicInvoke(value, System.Convert.ChangeType(parameter, valueType));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}