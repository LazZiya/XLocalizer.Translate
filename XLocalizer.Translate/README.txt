﻿XLocalizer.Translate

Instructions to use this package :

- Install one or more of the below translation services
  - XLocalizer.Translate.GoogleTranslate
  - XLocalizer.Translate.YandexTranslate
  - XLocalizer.Translate.MyMemoryTranslate
  - XLocalizer.Translate.SystranTranslate
  - XLocalizer.Translate.IBMWatsonTranslate

Register the trasnlation service in startup:
 - Services.AddHttpClient<ITranslationService, GoogleTranslationService>();

Repository: https://github.com/LazZiya/XLocalizer.Translate
Docs: https://docs.ziyad.info/en/XLocalizer/v1.0/translate-services.md
