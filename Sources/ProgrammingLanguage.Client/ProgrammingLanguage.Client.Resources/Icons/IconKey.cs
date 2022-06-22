namespace ProgrammingLanguage.Client.Resources.Icons
{
    public static class IconKey
    {
        #region IconsKeys
        public static readonly string CloseWindowSmall;
        public static readonly string MinusSmall;
        public static readonly string EditSmall;
        #endregion

        #region ctor
        static IconKey()
        {
            var fieldInfos = typeof(IconKey).GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                fieldInfo.SetValue(null, $"Icon_{fieldInfo.Name}");
            }
        }
        #endregion

        #region Methods
        // IconKeyToControlTemplateConverter converter is responsible for getting of icon template resource key by IconKey.GetTemplateKey method
        public static string GetTemplateKey(string iconKey)
        {
            return "CTemplate_" + iconKey;
        }
        #endregion
    }
}