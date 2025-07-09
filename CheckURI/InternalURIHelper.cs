
using System.Text;

namespace CheckURI
{
	public static class InternalUriHelper
	{
		#region Fields

		static string[] allowedPatterns = new string[]
		{
			".tatneft.ru",
			".tatneft.tatar",
		};

		static readonly Uri[] validUris =
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
			new Uri("ftp://test.tatneft.ru")
		};

		static readonly Uri[] invalidUris =
		{
			new Uri("https://tatneft.ru"),
			new Uri("https://test.tatneft.com"),
			new Uri("https://example.tatneft.tatarr"),
			new Uri("https://google.com"),
			null
		};

		#endregion

		#region Public methods

		public static bool IsAllowed(Uri uri)
		{
			if (uri is null)
				return false;

			foreach (var pattern in allowedPatterns)
			{
				if (uri.Host.EndsWith(pattern))
				{
					return true;
				}
			}

			return false;
		}

		public static void RunTests()
		{
			bool isSucces = true;

			StringBuilder failedTestsBuilder = new("\nFailed tests:\n");

			foreach (var validUri in validUris)
			{
				bool isAllowed = IsAllowed(validUri);
				isSucces &= isAllowed;

				if (!isAllowed)
				{
					AppendUri(validUri);
				}
			}

			foreach (var invalidUri in invalidUris)
			{
				bool isAllowed = IsAllowed(invalidUri);
				isSucces &= !isAllowed;

				if (isAllowed)
				{
					AppendUri(invalidUri);
				}
			}

			string output = $"{nameof(InternalUriHelper)} test result: {isSucces}";
			if (!isSucces)
			{
				output += failedTestsBuilder.ToString().Trim('\n');
			}

			System.Diagnostics.Debug.WriteLine(output);

			void AppendUri(Uri appendingUri) => failedTestsBuilder.Append(appendingUri is null ? "null" : appendingUri.AbsoluteUri);
		}

		#endregion
	}
}