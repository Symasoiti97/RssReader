using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parser.ParserApi
{
    class ApiWorkerJson<T> : ApiWorker<T> where T : class
    {
        private IApiJson<T> apiJson;

        public event Action<object, T> EventStart;
        public event Action<object> EventAbort;

        public ApiWorkerJson(IApiJson<T> apiJson, IApiSetting apiSetting) : base(apiSetting)
        {
            this.apiJson = apiJson;
        }

        #region[WorkerJson]
        protected override async Task Worker()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;

                while (isActive)
                {
                    var reader = await webClient.DownloadStringTaskAsync(apiSetting.Url);

                    JObject json = JObject.Parse(reader);

                    var list = apiJson.GetJson(json);

                    EventStart?.Invoke(this, list);

                    await Task.Delay(300000);
                }
            }

            EventAbort?.Invoke(this);
        }
        #endregion
    }
}
