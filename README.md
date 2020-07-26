# XLocalizer.Translate
Auto translation support pack for [XLocalizer](https://github.com/LazZiya/XLocalizer)

## Install
Install from nuget:
````
PM > Install-Package XLocalizer.Translate
````

Additionally install one or more translation service from nuget as well:
````
PM > Install-Package XLocalizer.Translate.GoogleTranslate
PM > Install-Package XLocalizer.Translate.YadexTranslate
PM > Install-Package XLocalizer.Translate.MyMemoryTranslate
PM > Install-Package XLocalizer.Translate.SystranTranslate
PM > Install-Package XLocalizer.Translate.IBMWatsonTranslate
````

## Usage
The current package uses [RapidApi](https://rapidapi.com/collection/translation-apis) to access free translation services that dosen't require a credit card for subscription. 
So before using this package you will need create an application key in RapidApi, see [RapidAPI Quick Start Guide](https://docs.rapidapi.com/docs/basics-creating-a-project), then subscribe to one of more of below translation services.

1. [Create RapidAPI key](https://docs.rapidapi.com/v2.0/docs/keys)
 
2. Subscribe to translation services, you can go with the free plans :)
   - [Google Translate](https://rapidapi.com/googlecloud/api/google-translate1/pricing)
   - [MyMemory](https://rapidapi.com/translated/api/mymemory-translation-memory/pricing)
   - [SYSTRAN.io](https://rapidapi.com/systran/api/systran-io-translation-and-nlp)
   - [Yandex Translate](https://tech.yandex.com/translate/)
   - [IBM Watson Language Translate](https://cloud.ibm.com/catalog/services/language-translator)

3. Goto your project and add the keys to user secrets:
> Right click on the project name and select Manage User Secrets
#### Google Translate, MyMemory, SYSTRAN.io via RapidApi Secrets:
````json
{
  "XLocalizer.Translate": {
    "RapidApiKey": "xxx-rapid-api-key-xxx"
  }
}
````
#### Yandex Translate Secrets:
````json
{
  "XLocalizer.Translate": {
    "YandexTranslateApiKey": "xxx-yandex-translate-api-key-xxx"
  }
}
````

### IBM Watson Language Translate Secrets:
````json
{
  "XLocalizer.Translate": {
    "IBMWatsonTranslateApiKey": "xxx-imb-watson-cloud-api-key-xxx",
    "IBMWatsonTranslateServiceUrl": "https// ibm-service-instance-url",
    "IBMWatsonTranslateServiceVersionDate": "ibm-service-version-date"
  }
}
````

4. Register one or more services in startup:
````cs
services.AddSingleton<IStringTranslator, IBMWatsonStringTranslator>();
services.AddHttpClient<IStringTranslator, GoogleTranslateStringTranslator>();
services.AddHttpClient<IStringTranslator, YandexTranslateStringTranslator>();
services.AddHttpClient<IStringTranslator, MyMemoryTranslateStringTranslator>();
services.AddHttpClient<IStringTranslator, SystranTranslateStringTranslator>();
````

6. Inject one or all services:
````cs
public class IndexModel : PageModel
{
    private readonly IStringTranslator _translator;
    
    public IndexModel(IStringTranslator translator)
    {
        _translator = translator;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        var transResult = await _translator.TranslateAsync("en", "tr", "Hello world!", text);
    }
}
````

The translation result is an object of type [`TranslationResult`](https://github.com/LazZiya/XLocalizer.Translate/blob/master/XLocalizer.Translate/TranslationResult.cs).

Sample result for "Welcome" translation:
````
{ text: "Hoşgeldiniz", statusCode: 200, target: "tr", source: "en"}
````

## Extending Translation Services
If you want to add more services just implement the interface `ITranslator` and register it in startup.
