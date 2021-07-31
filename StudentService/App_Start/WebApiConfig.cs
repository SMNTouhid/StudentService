﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiContrib.Formatting.Jsonp;

namespace StudentService
{
    public static class WebApiConfig
    {
        //public class CustomJsonFormatter : JsonMediaTypeFormatter
        //{
        //    public CustomJsonFormatter()
        //    {
        //        this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        //    }
        //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        //    {
        //        base.SetDefaultContentHeaders(type, headers, mediaType);
        //        headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    }
        //}
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //only xml
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            //only json return
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //CamaleCase
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //browser json but header type text/html
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            //config.Formatters.Add(new CustomJsonFormatter());
            //calling asp.net web api service in a cross domain using jQuery ajax
            var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            config.Formatters.Insert(0, jsonpFormatter);

            //cross origin resource sharing asp.net web api
            //EnableCrosAttribute cors = new EnableCrosAttribute("*", "*", "*");
            //config.EnableCors(cors);

        }
    }
}