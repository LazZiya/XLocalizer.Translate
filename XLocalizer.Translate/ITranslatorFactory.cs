using System;

namespace XLocalizer.Translate
{
    /// <summary>
    /// Interface to provide translation services
    /// </summary>
    public interface ITranslatorFactory
    {
        /// <summary>
        /// Create new IStringTranslator based on the default IStringTranslator type defined in startup
        /// </summary>
        /// <returns></returns>
        ITranslator Create();

        /// <summary>
        /// Create new IStringTranslator based on type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ITranslator Create(Type type);

        /// <summary>
        /// Create new IStringTranslator based on TTranslator type
        /// </summary>
        /// <returns></returns>
        ITranslator Create<TTranslator>()
            where TTranslator : ITranslator;

        /// <summary>
        /// Create new IStringTranslator based on ServiceName property
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        ITranslator Create(string serviceName);

        /// <summary>
        /// Get all trasnlation services names
        /// </summary>
        /// <returns></returns>
        string[] ServiceNames();
    }
}
