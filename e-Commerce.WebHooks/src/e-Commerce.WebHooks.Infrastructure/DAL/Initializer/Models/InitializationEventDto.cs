namespace e_Commerce.WebHooks.Infrastructure.DAL.Initializer.Models;

internal class InitializationEventDto
{
    public Guid Id { get; set; }    
    public string TypeName { get; set; }
    public List<InitializationAddressDto> Addresses { get; set; }
}