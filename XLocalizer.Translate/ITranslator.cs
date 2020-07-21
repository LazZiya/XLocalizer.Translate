using System.Threading.Tasks;

namespace XLocalizer.Translate
{
    /// <summary>
    /// Interface to implement a translation service
    /// </summary>
    public interface ITranslator
    {
        /// <summary>
        /// Service name is reuired for the dropdown list
        /// </summary>
        string ServiceName { get; }

        /// <summary>
        /// Translate method shoudl return an <see cref="TranslationResult"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <returns><see cref="TranslationResult"/></returns>
        Task<TranslationResult> TranslateAsync(string source, string target, string text, string format);

        /// <summary>
        /// Try translate a text value, 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="text"></param>
        /// <param name="translation"></param>
        /// <returns></returns>
        bool TryTranslate(string source, string target, string text, out string translation);
    }
}
