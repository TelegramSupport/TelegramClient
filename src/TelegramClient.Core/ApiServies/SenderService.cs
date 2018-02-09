﻿namespace TelegramClient.Core.ApiServies
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using log4net;

    using OpenTl.Schema;

    using TelegramClient.Core.ApiServies.Interfaces;
    using TelegramClient.Core.IoC;
    using TelegramClient.Core.Network.Exceptions;
    using TelegramClient.Core.Network.Interfaces;
    using TelegramClient.Core.Network.Recieve.Interfaces;

    [SingleInstance(typeof(ISenderService))]
    internal class SenderService : ISenderService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SenderService));

        public IMtProtoSender Sender { get; set; }

        public IResponseResultGetter ResponseResultGetter { get; set; }

        public Lazy<IConnectApiService> ConnectApiService { get; set; }

        public async Task<TResult> SendRequestAsync<TResult>(IRequest<TResult> methodToExecute, CancellationToken cancellationToken = default(CancellationToken))
        {
            Log.Debug($"Send message of the constructor {methodToExecute}");

            while (true)
            {
                try
                {
                    return (TResult)await SendAndRecieve(methodToExecute, cancellationToken).ConfigureAwait(false);
                }
                catch (BadServerSaltException)
                {
                    return (TResult)await SendAndRecieve(methodToExecute, cancellationToken).ConfigureAwait(false);
                }
                catch (AuthRestartException)
                {
                    await ConnectApiService.Value.ReAuthenticateAsync().ConfigureAwait(false);
                }
                catch (DataCenterMigrationException ex)
                {
                    await ConnectApiService.Value.ReconnectToDcAsync(ex.Dc).ConfigureAwait(false);
                }
            }
        }

        private async Task<object> SendAndRecieve(IObject methodToExecute, CancellationToken cancellationToken)
        {
            (Task sendTask, long mesId) = await Sender.SendWithConfim(methodToExecute, cancellationToken).ConfigureAwait(false);
            
            var response = await ResponseResultGetter.Receive(mesId).ConfigureAwait(false);
            
            await sendTask.ConfigureAwait(false);
            
            return response;
        }
    }
}