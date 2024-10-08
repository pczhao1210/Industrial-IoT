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
    public class BrowseTests
    {
        public BrowseTests(FileSystemServer server)
        {
            _server = server;
        }

        private BrowseTests<ConnectionModel> GetTests()
        {
            return new BrowseTests<ConnectionModel>(
                () => new FileSystemServices<ConnectionModel>(_server.Client,
                    new PublisherConfig(new ConfigurationBuilder().Build()).ToOptions()),
                _server.GetConnection(), _server.TempPath);
        }

        private readonly FileSystemServer _server;

        [Fact]
        public Task GetFileSystemsTest1Async()
        {
            return GetTests().GetFileSystemsTest1Async();
        }

        [Fact]
        public Task GetDirectoriesTest1Async()
        {
            return GetTests().GetDirectoriesTest1Async();
        }

        [Fact]
        public Task GetDirectoriesTest2Async()
        {
            return GetTests().GetDirectoriesTest2Async();
        }

        [Fact]
        public Task GetDirectoriesTest3Async()
        {
            return GetTests().GetDirectoriesTest3Async();
        }

        [Fact]
        public Task GetDirectoriesTest4Async()
        {
            return GetTests().GetDirectoriesTest4Async();
        }

        [Fact]
        public Task GetDirectoriesTest5Async()
        {
            return GetTests().GetDirectoriesTest5Async();
        }

        [Fact]
        public Task GetDirectoriesTest6Async()
        {
            return GetTests().GetDirectoriesTest6Async();
        }

        [Fact]
        public Task GetFilesTest1Async()
        {
            return GetTests().GetFilesTest1Async();
        }

        [Fact]
        public Task GetFilesTest2Async()
        {
            return GetTests().GetFilesTest2Async();
        }

        [Fact]
        public Task GetFilesTest3Async()
        {
            return GetTests().GetFilesTest3Async();
        }

        [Fact]
        public Task GetFilesTest4Async()
        {
            return GetTests().GetFilesTest4Async();
        }

        [Fact]
        public Task GetFilesTest5Async()
        {
            return GetTests().GetFilesTest5Async();
        }

        [Fact]
        public Task GetFilesTest6Async()
        {
            return GetTests().GetFilesTest6Async();
        }
    }
}
