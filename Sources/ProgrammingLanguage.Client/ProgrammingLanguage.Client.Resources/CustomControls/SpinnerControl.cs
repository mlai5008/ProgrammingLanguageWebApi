using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProgrammingLanguage.Client.Resources.CustomControls
{
    public class SpinnerControl : Label
    {
        #region ctor
        static SpinnerControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpinnerControl), new FrameworkPropertyMetadata(typeof(SpinnerControl)));
        }
        #endregion

        #region DependenceProperty
        public double EllipsesDiameter
        {
            get => (double)GetValue(EllipsesDiameterProperty);
            set => SetValue(EllipsesDiameterProperty, value);
        }
        public static readonly DependencyProperty EllipsesDiameterProperty =
            DependencyProperty.Register("EllipsesDiameter", typeof(double), typeof(SpinnerControl), new PropertyMetadata(null));

        public Brush EllipsesFill
        {
            get => (Brush)GetValue(EllipsesFillProperty);
            set => SetValue(EllipsesFillProperty, value);
        }
        public static readonly DependencyProperty EllipsesFillProperty =
            DependencyProperty.Register("EllipsesFill", typeof(Brush), typeof(SpinnerControl), new PropertyMetadata(null));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SpinnerControl), new PropertyMetadata(null));

        public double RingDiameter
        {
            get => (double)GetValue(RingDiameterProperty);
            set => SetValue(RingDiameterProperty, value);
        }
        public static readonly DependencyProperty RingDiameterProperty =
            DependencyProperty.Register("RingDiameter", typeof(double), typeof(SpinnerControl), new PropertyMetadata(null));
        #endregion
    }
}
