
namespace CheckURI
{
	public static class URIHelper
	{
        static string[] allowedPatterns = new string[]
        {
            ".tatneft.ru",
            ".tatneft.tatar",
        };


        static bool CheckUri(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return false;

            foreach (var pattern in allowedPatterns)
            {
                if (uri.EndsWith(pattern))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

