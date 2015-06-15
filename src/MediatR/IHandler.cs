﻿using System.Threading;

namespace MediatR
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines a handler for a request
    /// </summary>
    /// <typeparam name="TRequest">The type of request being handled</typeparam>
    /// <typeparam name="TResponse">The type of response from the handler</typeparam>
    public interface IRequestHandler<in TRequest, out TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        TResponse Handle(TRequest message);
    }

    /// <summary>
    /// Defines an asynchronous handler for a request
    /// </summary>
    /// <typeparam name="TRequest">The type of request being handled</typeparam>
    /// <typeparam name="TResponse">The type of response from the handler</typeparam>
    public interface IAsyncRequestHandler<in TRequest, TResponse>
        where TRequest : IAsyncRequest<TResponse>
    {
        /// <summary>
        /// Handles an asynchronous request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <returns>A task representing the response from the request</returns>
        Task<TResponse> Handle(TRequest message);
    }

    /// <summary>
    /// Defines a cancellable, asynchronous handler for a request
    /// </summary>
    /// <typeparam name="TRequest">The type of request being handled</typeparam>
    /// <typeparam name="TResponse">The type of response from the handler</typeparam>
    public interface ICancellableAsyncRequestHandler<in TRequest, TResponse>
        where TRequest : ICancellableAsyncRequest<TResponse>
    {
        /// <summary>
        /// Handles a cancellable, asynchronous request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <param name="cancellationToken">A cancellation token</param>
        /// <returns>A task representing the response from the request</returns>
        Task<TResponse> Handle(TRequest message, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Helper class for requests that return a void response
    /// </summary>
    /// <typeparam name="TMessage">The type of void request being handled</typeparam>
    public abstract class RequestHandler<TMessage> : IRequestHandler<TMessage, Unit>
        where TMessage : IRequest
    {
        public Unit Handle(TMessage message)
        {
            HandleCore(message);

            return Unit.Value;
        }

        /// <summary>
        /// Handles a void request
        /// </summary>
        /// <param name="message">The request message</param>
        protected abstract void HandleCore(TMessage message);
    }

    /// <summary>
    /// Helper class for asynchronous requests that return a void response
    /// </summary>
    /// <typeparam name="TMessage">The type of void request being handled</typeparam>
    public abstract class AsyncRequestHandler<TMessage> : IAsyncRequestHandler<TMessage, Unit>
        where TMessage : IAsyncRequest
    {
        public async Task<Unit> Handle(TMessage message)
        {
            await HandleCore(message);

            return Unit.Value;
        }

        /// <summary>
        /// Handles a void request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <returns>A task representing the void response from the request</returns>
        protected abstract Task HandleCore(TMessage message);
    }

    /// <summary>
    /// Helper class for cancellable, asynchronous requests that return a void response
    /// </summary>
    /// <typeparam name="TMessage">The type of void request being handled</typeparam>
    public abstract class CancellableAsyncRequestHandler<TMessage> : ICancellableAsyncRequestHandler<TMessage, Unit>
        where TMessage : ICancellableAsyncRequest
    {
        public async Task<Unit> Handle(TMessage message, CancellationToken cancellationToken)
        {
            await HandleCore(message, cancellationToken);

            return Unit.Value;
        }

        /// <summary>
        /// Handles a void request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <param name="cancellationToken">A cancellation token</param>
        /// <returns>A task representing the void response from the request</returns>
        protected abstract Task HandleCore(TMessage message, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Defines a handler for a notification
    /// </summary>
    /// <typeparam name="TNotification">The type of notification being handled</typeparam>
    public interface INotificationHandler<in TNotification>
        where TNotification : INotification
    {
        /// <summary>
        /// Handles a notification
        /// </summary>
        /// <param name="notification">The notification message</param>
        void Handle(TNotification notification);
    }

    /// <summary>
    /// Defines an asynchronous handler for a notification
    /// </summary>
    /// <typeparam name="TNotification">The type of notification being handled</typeparam>
    public interface IAsyncNotificationHandler<in TNotification>
        where TNotification : IAsyncNotification
    {
        /// <summary>
        /// Handles an asynchronous notification
        /// </summary>
        /// <param name="notification">The notification message</param>
        /// <returns>A task representing handling the notification</returns>
        Task Handle(TNotification notification);
    }

    /// <summary>
    /// Defines a cancellable, asynchronous handler for a notification
    /// </summary>
    /// <typeparam name="TNotification">The type of notification being handled</typeparam>
    public interface ICancellableAsyncNotificationHandler<in TNotification>
        where TNotification : ICancellableAsyncNotification
    {
        /// <summary>
        /// Handles a cancellable, asynchronous notification
        /// </summary>
        /// <param name="notification">The notification message</param>
        /// <param name="cancellationToken">A cancellation token</param>
        /// <returns>A task representing handling the notification</returns>
        Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}