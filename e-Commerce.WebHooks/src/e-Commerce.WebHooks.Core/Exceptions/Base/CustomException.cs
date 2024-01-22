namespace e_Commerce.WebHooks.Core.Exceptions.Base;

public abstract class CustomException(string message)
    : Exception(message);