using System;
namespace Udemy.Domain.Exception;
public class NotFoundException(string resourceType, string resourceIdentifier) : System.Exception($"{resourceType} bilan {resourceIdentifier} bo'sh emas")
{
}
