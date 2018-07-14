using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using PanPan.MVVM;
using PanPan.MVVM.Command;

namespace MyApp.Wpf.Demo.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private string _tipText;

        public MainWindowViewModel()
        {
            ConfirmCommand = new RelayCommand(m =>
            {
                MessageBox.Show("ConfirmCommand");
            });

            MouseMoveCommand = new RelayCommand<MouseEventArgs>(e =>
            {
                var point = e.GetPosition(e.Device.Target);
                var left = "左键放开";
                var mid = "中键放开";
                var right = "右键放开";

                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    left = "左键按下";
                }

                if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    mid = "中键按下";
                }

                if (e.RightButton == MouseButtonState.Pressed)
                {
                    right = "右键按下";
                }

                TipText = $"当前鼠标位置  X:{point.X}  Y:{point.Y}  当前鼠标状态:{left} {mid}  {right}";
            });
        }

        public string TipText
        {
            get => _tipText;
            set => Set(ref _tipText, value);
        }

        /// <summary>
        /// 确定命令
        /// </summary>
        public ICommand ConfirmCommand { get; set; }

        public ICommand MouseMoveCommand { get; set; }
    }
}
