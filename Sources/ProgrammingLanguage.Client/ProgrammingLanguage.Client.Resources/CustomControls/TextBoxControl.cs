using System.Windows;
using System.Windows.Controls;

namespace ProgrammingLanguage.Client.Resources.CustomControls
{
    [TemplatePart(Name = TextBoxPart, Type = typeof(TextBox))]
    public class TextBoxControl : TextBox
    {
        #region Constants
        private const string TextBoxPart = "PART_TextBox";
        #endregion

        #region DependencyProperty
        public object WatermarkContent
        {
            get { return (object)GetValue(WatermarkContentProperty); }
            set { SetValue(WatermarkContentProperty, value); }
        }
        public static readonly DependencyProperty WatermarkContentProperty =
            DependencyProperty.Register("WatermarkContent", typeof(string), typeof(TextBoxControl), new PropertyMetadata(string.Empty));
        #endregion
    }
}