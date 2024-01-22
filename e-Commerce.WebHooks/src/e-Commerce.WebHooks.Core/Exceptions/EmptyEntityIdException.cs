using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Core.Exceptions;

public sealed class EmptyEntityIdException()
    : CustomException("Entity Id can not be empty");