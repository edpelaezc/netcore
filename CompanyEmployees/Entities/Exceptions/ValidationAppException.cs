using System;
namespace Entities.Exceptions
{
	public sealed class ValidationAppException : Exception
	{
		public IReadOnlyDictionary<string, string[]> Errors { get; }

		public ValidationAppException(IReadOnlyDictionary<string, string[]> errors)
			: base("one or more validation errors ocurred")
		{
			Errors = errors;
		}
	}
}

