using System.Text.RegularExpressions;

namespace Shared.Util
{
	public static class StringExtensions
	{
		public static string? RemoverMascara(this string? str)
		{
			return str != null ? Regex.Replace(str, @"[^\d]", string.Empty) : str;
		}


		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}
	}
}
