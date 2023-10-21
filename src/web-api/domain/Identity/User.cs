using Business.Interface;
using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using shared.Util;
namespace Business.Identity
{
	public class User : IUser
	{
		private readonly IHttpContextAccessor? _httpContextAccessor;
		private readonly ClaimsPrincipal UserClaim;
		public User(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			UserClaim = _httpContextAccessor!.HttpContext.User;

			if (Verify.IsNull(UserClaim))
				throw new InvalidOperationException();
		}

		public string UserId => UserClaim.FindFirst(ClaimTypes.NameIdentifier)!.Value;
		public string Email => UserClaim.FindFirst(ClaimTypes.Email)!.Value  ;
		public string UserName => UserClaim.Identity!.Name ?? string.Empty;
		public int? IdAgencia
		{
			get
			{
				if (_httpContextAccessor is not null)
				{
					var claim = _httpContextAccessor.HttpContext.User.FindFirst(nameof(Usuario.IdOrganizacao)) ?? default;
					return string.IsNullOrEmpty(claim?.Value) ? default : int.Parse(claim.Value);
				}
				else
					return null;
			}
		}
	}
}
