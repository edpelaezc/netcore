using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Entities.LinkModels;

public record LinkParameters(EmployeeParameters EmployeeParameters, HttpContext Context);
