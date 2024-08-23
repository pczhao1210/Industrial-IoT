﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Azure.IIoT.OpcUa.Publisher.Tests.Services.Asset
{
    using Azure.IIoT.OpcUa.Publisher.Services;
    using Azure.IIoT.OpcUa.Publisher.Testing.Fixtures;
    using Azure.IIoT.OpcUa.Publisher.Testing.Tests;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;

    [Collection(WriteCollection4.Name)]
    public class ConfigurationTest4
    {
        public ConfigurationTest4(AssetServer server, ITestOutputHelper output)
        {
            _server = server;
            _output = output;
        }

        private AssetTests4 GetTests()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            return new AssetTests4(c => new ConfigurationServices(c, _server.Client,
                new PublisherConfig(new ConfigurationBuilder().Build()).ToOptions(),
                _output.BuildLoggerFor<ConfigurationServices>(Logging.Level)),
                _server.GetConnection());
#pragma warning restore CA2000 // Dispose objects before losing scope
        }

        private readonly AssetServer _server;
        private readonly ITestOutputHelper _output;

        [Fact]
        public Task ConfigureDuplicateAssetFailsAsync()
        {
            return GetTests().ConfigureDuplicateAssetFailsAsync();
        }

        [Fact]
        public Task ConfigureAssetFails1Async()
        {
            return GetTests().ConfigureAssetFails1Async();
        }

        [Fact]
        public Task ConfigureWithBadStreamFails1Async()
        {
            return GetTests().ConfigureWithBadStreamFails1Async();
        }

        [Fact]
        public Task ConfigureWithBadStreamFails2Async()
        {
            return GetTests().ConfigureWithBadStreamFails2Async();
        }

        [Fact]
        public Task ConfigureWithBadStreamFails3Async()
        {
            return GetTests().ConfigureWithBadStreamFails3Async();
        }
    }
}
