# Netcap Diagnostic Tool

> **This tool is provided as a sample, as-is and without any support and warranty. When used in production please be aware that it is invasive and should be used with care.**

The Netcap tool is designed to help diagnose interop issues with OPC UA servers that OPC Publisher connects to and which the normal logs of OPC Publisher fail to diagnose.
To support diagnosis, Netcap collects network traces remotely from a OPC Publisher deployment and then makes the traces available for download and analysis. It is implemented as a sidecar to OPC Publisher that must be running in the same network as OPC Publisher (and see the same endpoints).

> Netcap can only diagnose OPC Publisher versions 2.9.10 or higher!

The Netcap tool has three modes of operation:

1. **Install Mode**: Allows installation of Netcap on a remote Azure IoT Edge device as side car of a running OPC Publisher module. Installation provisions a storage account and container registry in the same resource group as the IoT Hub the device is connected to, then builds and deploys Netcap to the IoT Edge device. If installed with an output path (`-o`) it will also download the network traces (.pcap files) during the capture session and then remove the Netcap module from the IoT Edge device once capture is cancelled (key press).
2. **Remote Mode**: Netcap connects to the OPC Publisher and starts to capture tcp dumps filtered to the OPC Publisher IP addresses. The capture traces are chunked to (by default) 5 minutes or 100 MB whichever is reached first, and then the traces are uploaded. There will not be gaps between traces. This happens as long as the Netcap module is deployed.
3. **Proxy Mode**: Netcap captures traces on a different network than OPC Publisher is connected to, e.g. the host network. It then exposes a remote API to allow the OPC Publisher side car to retrieve and upload the traces.
4. **Uninstall Mode**: Removes the Netcap module from the IoT Edge device. This leaves the storage account and container registry in place which must can be removed in Cleanup mode.

Installation and un-installation require administrator rights to the subscription in which the Azure IoT Hub resides that OPC Publisher is connected to. Rights must include access to the Azure IoT Hub resource as well as the permission to create storage and container registry resources in the same resource group as the IoT Hub instance. If you do not have permissions to create resources in the subscription and/or resource group, you must build Netcap and deploy it manually.

## Getting started

In the `src` sub folder run

``` bash
dotnet run -- install -o <output-folder>
```

or if you want to use docker you can also run

``` bash
docker build -t netcap .
docker run -it -v <output-folder-on-your-host>:/tmp netcap install -d -o /tmp
```

> Do not forget to specify the `-d` option to force authorizing with Azure Resource Manager (ARM) using the device code flow.

Follow the instructions to select a OPC Publisher you want to diagnose. When you are done, cancel capture by pressing any key. The folder you specified now contains the key set logs and a capture file (`capture.pcap`) which you can open in Wireshark. In the `Preferences` view under `Edit` select the page for the OPC UA protocol. You must enter the port of the OPC UA server there. You can consult the session `*.log` file you are interested in the download folder. The file name starts with the port number (or the log contains it).

You can also provide the key set to decrypt encrypted traffic which is the corresponding `*.txt` file with the same name as the `*.log` file (requires Wireshark 4.3 RC builds). Once saved, you can filter the traces using the `opcua` filter in the filter edit box on the main screen. Tip: right click on the traces and you can select the OPC UA protocol configuration directly from there.

## Advanced install options

For installation and un-installation you might want to narrow down where Netcap looks for OPC Publisher deployments it should consider presenting to you. Use the `-s` option to specify the subscription. If you are working in multiple tenants, specify the tenant ID using the `-t` command line option.

During installation the Netcap tool is built using the deployed Azure Container Registry (ACR) instance using the source found in the main branch of this repository. If you want to use a different branch, you must specify this branch using the `-b` option during installation.

All captured files are stored in the storage account provisioned during installation. The storage account contains sensitive data that must be handled with care, e.g. in addition to the OPC Publisher configuration it also contains key/token material that can be used in Wireshark 4.3 to decrypt secure channel communication inside the network traces.
