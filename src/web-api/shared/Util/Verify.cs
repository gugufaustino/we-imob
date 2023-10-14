using System.Diagnostics.CodeAnalysis;

namespace shared.Util
{
	public class Verify
	{
		public static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
		public static bool IsNull([NotNullWhen(true)] object? obj) => obj == null;
	}
}
