﻿using System;
using OpenCqrs.Exceptions;

namespace OpenCqrs.Dependencies
{
    public class HandlerResolver : IHandlerResolver
    {
        private readonly IResolver _resolver;

        public HandlerResolver(IResolver resolver)
        {
            _resolver = resolver;
        }

        public THandler ResolveHandler<THandler>()
        {
            var handler = _resolver.Resolve<THandler>();

            if (handler == null)
                throw new HandlerNotFoundException(typeof(THandler));

            return handler;
        }
    }
}