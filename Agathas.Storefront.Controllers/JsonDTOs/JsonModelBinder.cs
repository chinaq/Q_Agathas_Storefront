﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;

namespace Agathas.Storefront.Controllers.JsonDTOs
{
    /// <summary>
    /// Json模型的Binder
    /// </summary>
    public class JsonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");

            var serializer = new DataContractJsonSerializer(bindingContext.ModelType);
            return serializer.ReadObject(controllerContext.HttpContext.Request.InputStream);
        }
    }
}
