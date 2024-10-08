// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Azure.IIoT.OpcUa.Publisher.Tests.Services.FileSystem
{
    using Azure.IIoT.OpcUa.Publisher.Models;
    using Azure.IIoT.OpcUa.Publisher.Services;
    using Azure.IIoT.OpcUa.Publisher.Testing.Fixtures;
    using Azure.IIoT.OpcUa.Publisher.Testing.Tests;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;
    using Xunit;

    [Collection(FileCollection.Name)]
    public class WriteTests
    {
        public WriteTests(FileSystemServer server)
        {
            _server = server;
        }

        private WriteTests<ConnectionModel> GetTests()
        {
            return new WriteTests<ConnectionModel>(
                () => new FileSystemServices<ConnectionModel>(_server.Client,
                    new PublisherConfig(new ConfigurationBuilder().Build()).ToOptions()),
                _server.GetConnection(), _server.TempPath);
        }

        private readonly FileSystemServer _server;

        [Fact]
        public Task WriteFileTest0Async()
        {
            return GetTests().WriteFileTest0Async();
        }

        [Fact]
        public Task WriteFileTest1Async()
        {
            return GetTests().WriteFileTest1Async();
        }

        [Fact]
        public Task WriteFileTest2Async()
        {
            return GetTests().WriteFileTest2Async();
        }

        [Fact]
        public Task AppendFileTest0Async()
        {
            return GetTests().AppendFileTest0Async();
        }

        [Fact]
        public Task AppendFileTest1Async()
        {
            return GetTests().AppendFileTest1Async();
        }

        [Fact]
        public Task AppendFileTest2Async()
        {
            return GetTests().AppendFileTest2Async();
        }
    }
}
