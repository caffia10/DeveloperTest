namespace WebApiTest.Utils
{
    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}