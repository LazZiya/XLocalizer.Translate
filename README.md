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
Some translation services requires API keys, for all details visit: [DOCS.Ziyad.info](http://docs.ziyad.info)

Goto your project and add the keys to user secrets:
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
services.AddSingleton<ITranslator, IBMWatsonStringTranslator>();
services.AddHttpClient<ITranslator, GoogleTranslateStringTranslator>();
services.AddHttpClient<ITranslator, YandexTranslateStringTranslator>();
services.AddHttpClient<ITranslator, MyMemoryTranslateStringTranslator>();
services.AddHttpClient<ITranslator, SystranTranslateStringTranslator>();
````

6. Inject one or all services:
````cs
public class IndexModel : PageModel
{
    private readonly ITranslator _translator;
    
    public IndexModel(ITranslator translator)
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
