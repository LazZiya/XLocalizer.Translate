using System;
using System.Collections.Generic;
using System.Linq;

namespace XLocalizer.Translate
{
    /// <summary>
    /// Provide translation services
    /// </summary>
    public class TranslatorFactory<TTranslator> : ITranslatorFactory
        where TTranslator : ITranslator
    {
        private readonly IEnumerable<ITranslator> _translators;

        /// <summary>
        /// Create a new instance of TranslationServiceFactory
        /// </summary>
        /// <param name="translators"></param>
        public TranslatorFactory(IEnumerable<ITranslator> translators)
        {
            _translators = translators;
        }

        /// <summary>
        /// Create new IStringTranslator based on the default IStringTranslator type defined in startup
        /// </summary>
        /// <returns></returns>
        public ITranslator Create()
        {
            return _translators.FirstOrDefault(x => x.GetType() == typeof(TTranslator));
        }
    
        /// <summary>
        /// Create new IStringTranslator based on type
        /// </summary>
        /// <returns></returns>
        public ITranslator Create(Type type)
        {
            if (type == null)
                throw new NullReferenceException(nameof(type));
            
            // make sure that we have IStringTranslator
            if (type.GetInterface(typeof(ITranslator).FullName) == null)
                throw new Exception($"The provided type is of type {type.FullName}, but this service must implement {typeof(ITranslator)}");

            return _translators.FirstOrDefault(x => x.GetType() == type);
        }
        
        /// <summary>
        /// Create new IStringTranslator based on the T type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ITranslator Create<T>()
            where T : ITranslator
        {
            return _translators.FirstOrDefault(x => x.GetType() == typeof(TTranslator));
        }

        /// <summary>
        /// Create new IStringTranslator based on service name property
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public ITranslator Create(string serviceName)
        {
            return _translators.FirstOrDefault(x => x.ServiceName == serviceName);
        }

        /// <summary>
        /// Retrive a list of all service names
        /// </summary>
        /// <returns></returns>
        public string[] ServiceNames() =>_translators.Select(x => x.ServiceName).OrderBy(x => x).ToArray();
    }
}
