using System;

namespace XLocalizer.Translate
{
    /// <summary>
    /// Interface to provide translation services
    /// </summary>
    public interface IStringTranslatorFactory
    {
        /// <summary>
        /// Create new IStringTranslator based on the default IStringTranslator type defined in startup
        /// </summary>
        /// <returns></returns>
        IStringTranslator Create();

        /// <summary>
        /// Create new IStringTranslator based on type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IStringTranslator Create(Type type);

        /// <summary>
        /// Create new IStringTranslator based on TTranslator type
        /// </summary>
        /// <returns></returns>
        IStringTranslator Create<TTranslator>()
            where TTranslator : IStringTranslator;

        /// <summary>
        /// Create new IStringTranslator based on ServiceName property
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        IStringTranslator Create(string serviceName);

        /// <summary>
        /// Get all trasnlation services names
        /// </summary>
        /// <returns></returns>
        string[] ServiceNames();
    }
}
