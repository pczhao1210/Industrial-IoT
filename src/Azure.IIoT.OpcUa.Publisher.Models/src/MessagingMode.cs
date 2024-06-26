﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Azure.IIoT.OpcUa.Publisher.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Message modes
    /// </summary>
    [DataContract]
    public enum MessagingMode
    {
        /// <summary>
        /// Standard pub sub mode cloud message mode (default)
        /// </summary>
        [EnumMember(Value = "PubSub")]
        PubSub,

        /// <summary>
        /// Monitored item sample mode
        /// </summary>
        [EnumMember(Value = "Samples")]
        Samples,

        /// <summary>
        /// Network and dataset messages fully featured
        /// </summary>
        [EnumMember(Value = "FullNetworkMessages")]
        FullNetworkMessages,

        /// <summary>
        /// Monitored item sample full mode
        /// </summary>
        [EnumMember(Value = "FullSamples")]
        FullSamples,

        /// <summary>
        /// Messages without network message header.
        /// </summary>
        [EnumMember(Value = "DataSetMessages")]
        DataSetMessages,

        /// <summary>
        /// Single Message without network message header.
        /// </summary>
        [EnumMember(Value = "SingleDataSetMessage")]
        SingleDataSetMessage,

        /// <summary>
        /// Datasets are pure key value pairs without headers
        /// </summary>
        [EnumMember(Value = "DataSets")]
        DataSets,

        /// <summary>
        /// Single data set without headers
        /// </summary>
        [EnumMember(Value = "SingleDataSet")]
        SingleDataSet,

        /// <summary>
        /// Datasets with raw values
        /// </summary>
        [EnumMember(Value = "RawDataSets")]
        RawDataSets,

        /// <summary>
        /// Single data set raw values
        /// </summary>
        [EnumMember(Value = "SingleRawDataSet")]
        SingleRawDataSet
    }
}
