using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parser.ParserApi
{
    interface IApiXml<T> where T : class
    {
        T GetXml(XDocument xDocument);
    }
}
