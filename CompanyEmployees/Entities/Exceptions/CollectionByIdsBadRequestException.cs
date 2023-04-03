namespace Entities.Exceptions;

public sealed class CollectionByIdsBadRequestException : BadRequestException
{
	public CollectionByIdsBadRequestException()
		: base("Collection count mismatch comparing to ids.")
	{
	}
}
