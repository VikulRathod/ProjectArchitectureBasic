using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using VHaaSh.API.Client.Infrastructure;

namespace VHaaSh.API.Client
{
    public abstract class BaseHttpClient
    {
        protected HttpClient ServiceClient;

        protected BaseHttpClient()
        {
            ServiceClient = Create(AppConfig.WebApiEndPointAddress);
        }

        protected BaseHttpClient(string apiAddress)
        {
            ServiceClient = Create(apiAddress);
        }

        public static HttpClient Create(string apiAddress)
        {
            var handler = new WebRequestHandler
            {
                AllowAutoRedirect = false,
                UseProxy = false,
                Credentials = CredentialCache.DefaultNetworkCredentials
            };

            var client = AppConfig.WebApiUsesWindowsAuthentication
                ? new HttpClient(handler)
                : new HttpClient();

            client.BaseAddress = new Uri(apiAddress);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.JsonHttpHeader));
            client.Timeout = AppConfig.ClientTimeOut;

            return client;
        }
    }
}