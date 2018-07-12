using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//在 .NET 4.0 中使用 .NET 4.5 中新增的特性（CallerMemberNameAttribute/CallerFilePathAttribute/CallerLineNumberAttribute）
// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    /// <inheritdoc />
    /// <summary>
    /// 调用方名称
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public class CallerMemberNameAttribute : Attribute { }

    /// <inheritdoc />
    /// <summary>
    /// 代码文件路径
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public class CallerFilePathAttribute : Attribute { }

    /// <inheritdoc />
    /// <summary>
    /// 代码行数
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public class CallerLineNumberAttribute : Attribute { }
}
