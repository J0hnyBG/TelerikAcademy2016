using System;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

using Newtonsoft.Json;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class JsonActionResult : BaseActionResult
    {
        public readonly object Model;

        public JsonActionResult(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model)
            : base(request, httpResponseFactory)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            this.Model = model;
        }

        protected override string GetContent()
        {
            return JsonConvert.SerializeObject(this.Model);
        }

        protected override string GetContentType()
        {
            return "application/json";
        }
    }

    //public class JsonActionResultWithCors : JsonActionResult
    //{
    //    public JsonActionResultWithCors(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model, string corsSettings)
    //        : base(request, httpResponseFactory, model)
    //    {
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    //    }
    //}

    //public class JsonActionResultWithoutCaching : JsonActionResult
    //{
    //    public JsonActionResultWithoutCaching(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model)
    //        : base(request, httpResponseFactory, model)
    //    {
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    //    }
    //}

    //public class JsonActionResultWithCorsWithoutCaching : JsonActionResult
    //{
    //    public JsonActionResultWithCorsWithoutCaching(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model, string corsSettings)
    //        : base(request, httpResponseFactory, model)
    //    {
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    //    }
    //}
}
