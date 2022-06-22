namespace ProgrammingLanguage.Client.Resources.Brushes
{
    public static class BrushKey
    {
        #region ctor
        static BrushKey()
        {
            var fields = typeof(BrushKey).GetFields();
            foreach (var field in fields)
            {
                field.SetValue(null, $"Brush_{field.Name}");
            }
        }
        #endregion

        #region BrushKeys
        public static readonly string MainLightBrush;
        #endregion
    }
}