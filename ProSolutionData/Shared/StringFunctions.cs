namespace ProSolutionData.Shared
{
    public static class StringFunctions
    {
        public static string URLDecode(string url)
        {
            url = url.Replace("%2F", "/");
            url = url.Replace("|", "/");

            return url;
        }
    }
}
