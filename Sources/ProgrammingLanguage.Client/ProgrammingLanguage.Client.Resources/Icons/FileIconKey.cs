namespace ProgrammingLanguage.Client.Resources.Icons
{
    public static class FileIconKey
    {
        #region ctor
        static FileIconKey()
        {
            var fieldInfos = typeof(FileIconKey).GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                fieldInfo.SetValue(null, $"{fieldInfo.Name}");
            }
        }
        #endregion

        #region Constants
        public static readonly string MinusSmall;
        public static readonly string CloseWindowSmall;
        public static readonly string EditSmall;
        #endregion
    }
}