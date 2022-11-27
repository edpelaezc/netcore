using System;
namespace Entities.Exceptions
{
    public sealed class MaxAgeRangeBadRequestException : BadRequestException
	{
		public MaxAgeRangeBadRequestException() : base("Max age can't be less than min age.")
		{
		}
	}
}

