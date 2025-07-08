
namespace CheckURI
{
	public static class URIHelper
	{
        static string[] allowedPatterns = new string[]
        {
            ".tatneft.ru",
            ".tatneft.tatar",
        };


        public static bool CheckUri(Uri uri)
        {
            if (uri is null)
                return false;

            foreach (var pattern in allowedPatterns)
            {
                if (uri.AbsoluteUri.Contains(pattern))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool RunTests()
        {
            // Прямое совпадение
            if (!CheckUri(new Uri("https://test.tatneft.ru")) ||
                !CheckUri(new Uri("https://sub.test.tatneft.ru")) ||
                !CheckUri(new Uri("http://example.tatneft.tatar")))
            {
                return false;
            }

            // С завершающим слешем
            if (!CheckUri(new Uri("https://test.tatneft.ru/")) ||
                !CheckUri(new Uri("https://sub.test.tatneft.ru/path")) ||
                !CheckUri(new Uri("http://example.tatneft.tatar/")))
            {
                return false;
            }

            // Несовпадающие домены
            if (CheckUri(new Uri("https://test.tatneft.com")) || // другой домен
                CheckUri(new Uri("https://example.tateft.tatar"))) // опечатка
            {
                return false;
            }

            // Другой URL
            if (CheckUri(new Uri("https://google.com")))
            {
                return false;
            }

            // Другой протокол
            if (!CheckUri(new Uri("ftp://test.tatneft.ru")))
            {
                return false;
            }

            // Пустой URI
            if (CheckUri(null))
            {
                return false;
            }


            // С параметрами запроса
            if (!CheckUri(new Uri("https://test.tatneft.ru?param=value")) ||
                !CheckUri(new Uri("https://test.tatneft.tatar/?query=123")))
            {
                return false;
            }

            // С указанием порта
            if (!CheckUri(new Uri("https://test.tatneft.ru:8080")) ||
                !CheckUri(new Uri("http://example.tatneft.tatar:1234/path")))
            {
                return false;
            }

            return true;
        }
    }
}

