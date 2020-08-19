﻿using CustomModelBinderApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomModelBinderApp.Infrastructure
{
    public class EventModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder binder = new EventModelBinder();

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Event) ? binder : null;
        }
    }
}