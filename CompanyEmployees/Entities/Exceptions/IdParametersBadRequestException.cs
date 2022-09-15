using System;
namespace Entities.Exceptions
{
	public sealed class IdParametersBadRequestException : BadRequestException
	{
		public IdParametersBadRequestException() : base("Parameters ids is null")
		{
		}
	}
}

