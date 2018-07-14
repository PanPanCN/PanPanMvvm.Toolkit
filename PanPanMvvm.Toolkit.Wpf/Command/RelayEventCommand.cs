using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PanPanMvvm.Toolkit.Wpf.Command
{
    /// <inheritdoc />
    /// <summary>
    /// 事件绑定命令
    /// </summary>
    public class RelayEventCommand : TriggerAction<DependencyObject>
    {
        /// <summary>
        /// 事件要绑定的命令
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(RelayEventCommand), new PropertyMetadata(null));

        /// <summary>
        /// 绑定命令的参数(保持为空就是事件的参数)
        /// </summary>
        public object CommandParateter
        {
            get => GetValue(CommandParateterProperty);
            set => SetValue(CommandParateterProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandParateter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParateterProperty =
            DependencyProperty.Register("CommandParateter", typeof(object), typeof(RelayEventCommand), new PropertyMetadata(null));

        /// <inheritdoc />
        /// <summary>
        /// 执行事件
        /// </summary>
        /// <param name="parameter">事件参数</param>
        protected override void Invoke(object parameter)
        {
            if (parameter != null)
            {
                parameter = CommandParateter;
            }

            Command?.Execute(parameter);
        }
    }
}
