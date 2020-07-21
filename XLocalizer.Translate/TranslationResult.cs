using System.Net;

namespace XLocalizer.Translate
{
    /// <summary>
    /// Translation result
    /// </summary>
    public class TranslationResult
    {
        /// <summary>
        /// The pure translated text result
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// HttpClient response status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Target culture name
        /// Required for filling the relevant text area
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Source culture name
        /// </summary>
        public string Source { get; set; }
    }
}
