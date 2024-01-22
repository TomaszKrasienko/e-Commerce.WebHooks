using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Core.Exceptions;

public sealed class InvalidTypeNameException()
    :CustomException("Type name can not be null or empty");