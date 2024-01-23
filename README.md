# e-Commerce.WebHooks
W folderze znajduje się skonfigurowany plik docker-compose. 
Dla środowiska w dockerze jest dodany plik appsettings.Docker.json.

### Inicjalizacja
Dane inicjalizujące są w klasie DataInitializer dla namespace e_Commerce.WebHooks.Infrastructure.DAL.Initializer 
lub w pliku InitializationData.json --> obecnie w folderze solucji e-Commerce.WebHooks.Api.
Opcję inicjalizacji danych można włączyć za pomocą przestawienia w pliku appsettings DataInitializer:Enabled.
Miejsce pliku oraz inicjalizację z pliku również konfiguruje się z pliku appsettings.json.

### Endpoints
W projekcie e-Commerce.WebHooks.Api znajduje się plik http z 
przykładowymi wywołaniami endpoint'ów. Obsługa za pomocą wtyczki "REST Client" do 
VisualStudioCode.
Adresy dokumentacji UI.
Swagger -> /swagger
ReDoc -> /redoc

### Baza
W projekcie użyta została baza in-memory z paczki EntityFramework. 
Z tego powodu nie ma migracji oraz konfiguracji connection string.