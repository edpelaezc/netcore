using System;
namespace Entities.Exceptions
{
	public sealed class RefreshTokenBadRequest :BadRequestException
	{
		public RefreshTokenBadRequest() :base("Invalid client request. The tokenDTO has some invalid values.")
		{
		}
	}
}

