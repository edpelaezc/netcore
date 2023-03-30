using System;
namespace Shared.DataTransferObjects;

public record TokenDTO(string AccessToken, string RefreshToken);

