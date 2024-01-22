using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Application.Exceptions;

public sealed class EventAlreadyRegisteredException(string typeName, Guid id)
    : CustomException($"Event with ID: {id} or TypeName: {typeName} already registered");