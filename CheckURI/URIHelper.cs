
using System.Text;

namespace CheckURI
{
	public static class InternalUriHelper
	{
		#region Fields

		static string[] allowedPatterns = new string[]
		{
			"tatneft.ru",
			"tatneft.tatar",
		};

		private static readonly Uri[] validUris =
		{
			new Uri("https://test.tatneft.ru"),
			new Uri("https://sub.test.tatneft.ru"),
			new Uri("http://example.tatneft.tatar"),
			new Uri("https://test.tatneft.ru/"),
			new Uri("https://sub.test.tatneft.ru/path"),
			new Uri("http://example.tatneft.tatar/"),
			new Uri("https://test.tatneft.ru?param=value"),
			new Uri("https://test.tatneft.tatar/?query=123"),
			new Uri("https://test.tatneft.ru:8080"),
			new Uri("http://example.tatneft.tatar:1234/path"),
            new Uri("https://tatneft.ru"),
            new Uri("ftp://test.tatneft.ru")
        };

		private static readonly Uri[] invalidUris =
		{
			new Uri("https://test.tatneft.com"),
			new Uri("https://example.tatneft.tatarr"),
			new Uri("https://google.com"),
		};

        #endregion

        #region Private methods

		private static bool CheckAndPrint(Uri checkingUri, StringBuilder stringBuilder)
		{
            bool result = IsAllowed(checkingUri);
            stringBuilder.Append(result);
            stringBuilder.Append(": ");
            stringBuilder.AppendLine(checkingUri.ToString());
            return result;
        }

        #endregion

        #region Public methods

        public static bool IsAllowed(Uri uri)
		{
			if (uri is null)
				return false;

			foreach (var pattern in allowedPatterns)
			{
				if (uri.Host == pattern || uri.Host.EndsWith('.' + pattern))
				{
					return true;
				}
			}

			return false;
		}

		public static bool RunTests()
		{
			StringBuilder stringBuilder = new();
			bool isSucces = true;

            stringBuilder.Append(typeof(InternalUriHelper).Name);
            stringBuilder.AppendLine(" RunTests()");

            stringBuilder.AppendLine("Result | Test");

            stringBuilder.AppendLine("\nValidUris:");
            foreach (var validUri in validUris)
			{
				isSucces = isSucces && CheckAndPrint(validUri, stringBuilder);
			}

            stringBuilder.AppendLine("\nInvalidUris:");
            foreach (var invalidUri in invalidUris)
			{
                isSucces = isSucces && !CheckAndPrint(invalidUri, stringBuilder);
            }

			stringBuilder.Append('\n');
			stringBuilder.Append(typeof(InternalUriHelper).Name);
            stringBuilder.Append(" test result: ");
            stringBuilder.Append(isSucces);

			System.Diagnostics.Debug.WriteLine(stringBuilder.ToString());

			return isSucces;
        }

		#endregion
	}
}

