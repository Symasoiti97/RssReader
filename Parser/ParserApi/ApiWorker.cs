using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parser.ParserApi
{
    abstract class ApiWorker<T> where T : class
    {
        public IApiSetting apiSetting;

        protected bool isActive = false;

        public ApiWorker(IApiSetting apiSetting)
        {
            this.apiSetting = apiSetting;
        }

        public void Start()
        {
            if (isActive == false)
            {
                isActive = true;
                Worker();
            }
        }

        public void Abort()
        {
            isActive = false;
        }

        protected abstract Task Worker();
    }
}
