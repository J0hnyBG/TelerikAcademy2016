using System;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ContentActionResult : BaseActionResult
    {
        public readonly object Model;

        public ContentActionResult(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model)
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
            return this.Model.ToString();
        }
    }

    //public class ContentActionResultWithoutCaching : ContentActionResult
    //{
    //    public ContentActionResultWithoutCaching(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model) 
    //        : base(request, httpResponseFactory, model)
    //    {
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    //    }
    //}

    //public class ContentActionResultWithCors : ContentActionResult
    //{
    //    public ContentActionResultWithCors(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model, string corsSettings)
    //        : base(request, httpResponseFactory, model)
    //    {
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    //    }
    //}

    //public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
    //{
    //    public ContentActionResultWithCorsWithoutCaching(IHttpRequest request, IHttpResponseFactory httpResponseFactory, object model, string corsSettings)
    //        : base(request, httpResponseFactory, model)
    //    {
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
    //        this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
    //    }
    //}
}
