using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PanPanMvvm.Toolkit.Wpf
{
    /// <inheritdoc cref="DependencyObject" />
    /// <summary>
    /// 通知对象
    /// </summary>
    public class ObservableObject : DependencyObject, INotifyPropertyChanged
    {
        /// <inheritdoc />
        /// <summary>
        /// 属性改变事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 获取属性名称
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        /// <returns></returns>
        protected static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (!(propertyExpression.Body is MemberExpression me))
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return me.Member.Name;
        }

        /// <summary>
        /// 通知属性
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 通知属性
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="propertyExpression">属性名称</param>
        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (!(propertyExpression.Body is MemberExpression me))
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(me.Member.Name));
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="field">字段</param>
        /// <param name="newValue">新值</param>
        /// <returns>返回是否设置成功</returns>
        public bool Set<T>(Expression<Func<T>> propertyExpression, ref T field, T newValue)
        {
            if (Equals(field, newValue))
            {
                return false;
            }
            field = newValue;

            if (!(propertyExpression.Body is MemberExpression me))
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            RaisePropertyChanged(me.Member.Name);
            return true;
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="field">字段</param>
        /// <param name="newValue">新值</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>返回是否设置成功</returns>
        public bool Set<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (Equals(field, newValue))
            {
                return false;
            }

            field = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="propertyName">属性名称</param>
        /// <param name="field">字段</param>
        /// <param name="newValue">新值</param>
        /// <returns>返回是否设置成功</returns>
        public bool Set<T>(string propertyName, ref T field, T newValue)
        {
            if (Equals(field, newValue))
            {
                return false;
            }

            field = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
