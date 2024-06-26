﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Azure.IIoT.OpcUa.Publisher
{
    using System;
    using System.IO;

    /// <summary>
    /// Interface for utilities provider for published nodes file.
    /// </summary>
    public interface IStorageProvider
    {
        /// <summary>
        /// Occurs when published nodes file is changed.
        /// </summary>
        event EventHandler<FileSystemEventArgs> Changed;

        /// <summary>
        /// Get last write time of published nodes file.
        /// </summary>
        DateTime GetLastWriteTime();

        /// <summary>
        /// Read content of published nodes file as string.
        /// </summary>
        string ReadContent();

        /// <summary>
        /// Write new content to published nodes file
        /// </summary>
        /// <param name="content"> Content to be written. </param>
        /// <param name="disableRaisingEvents"> If set FileSystemWatcher
        /// notifications will be disabled while updating the file.</param>
        void WriteContent(string content, bool disableRaisingEvents = false);
    }
}
