using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskList
{
    public class ViewCellEx : ViewCell
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ViewCellEx), null, propertyChanged: OnCommandPropertyChanged);
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(ViewCellEx), null, propertyChanged: OnCommandParameterPropertyChanged);
        public ICommand Command { get => (ICommand)GetValue(CommandProperty); set => SetValue(CommandProperty, value); }
        public object CommandParameter { get => (ICommand)GetValue(CommandParameterProperty); set => SetValue(CommandParameterProperty, value); }
        private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //Stuff to handle changes, not really required
        }
        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //More stuff to handle changes
        }

        private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        public ViewCellEx()
        {
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                OnTapped();
            };
        }

        override protected void OnTapped()
        {
            if (Command != null)
            {
                var parameter = CommandParameter;
                Command.Execute(parameter);
            }
        }
    }
}
