using AngleSharp.Dom.Html;

namespace Parser.Pars
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
