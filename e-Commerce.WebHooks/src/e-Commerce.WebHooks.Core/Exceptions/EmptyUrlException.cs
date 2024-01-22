using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Core.Exceptions;

public sealed class EmptyUrlException()
    : CustomException("Url can not be empty");