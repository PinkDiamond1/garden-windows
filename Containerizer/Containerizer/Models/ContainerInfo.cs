﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IronFrame;
using Newtonsoft.Json;

namespace Containerizer.Models
{
    // From the Garden API:
    //type ContainerInfo struct {
    //    State         string                 // Either "active" or "stopped".
    //    Events        []string               // List of events that occurred for the container. It currently includes only "oom" (Out Of Memory) event if it occurred.
    //    HostIP        string                 // The IP address of the gateway which controls the host side of the container's virtual ethernet pair.
    //    ContainerIP   string                 // The IP address of the container side of the container's virtual ethernet pair.
    //    ExternalIP    string                 //
    //    ContainerPath string                 // The path to the directory holding the container's files (both its control scripts and filesystem).
    //    ProcessIDs    []uint32               // List of running processes.
    //    MemoryStat    ContainerMemoryStat    //
    //    CPUStat       ContainerCPUStat       //
    //    DiskStat      ContainerDiskStat      //
    //    BandwidthStat ContainerBandwidthStat //
    //    Properties    Properties             // List of properties defined for the container.
    //    MappedPorts   []PortMapping          //
    //}
    //
    //type PortMapping struct {
    //    HostPort      uint32
    //    ContainerPort uint32
    //}

    public class PortMappingApiModel
    {
        public int HostPort;
        public int ContainerPort;
    }

    public class Error
    {
        [JsonProperty("Message")]
        public string Message;
    }

    public class ContainerInfo
    {
        public ContainerInfo()
        {
            MappedPorts = new List<PortMappingApiModel>();
            Properties = new Dictionary<string, string>();
        }

        public List<PortMappingApiModel> MappedPorts;
        public Dictionary<string, string> Properties;
        public string ExternalIP;
        public string ContainerIP;
    }


    public class ContainerMetricsApiModel
    {
        public ContainerMemoryStatApiModel MemoryStat { get; set; }
        public ContainerCPUStatApiModel CPUStat { get; set; }
        public ContainerDiskApiModel DiskStat { get; set; }
    }

    public class ContainerDiskApiModel
    {
        public ulong TotalBytesUsed;
        public ulong ExclusiveBytesUsed;
    }

    public class ContainerMemoryStatApiModel
    {
        [JsonProperty("TotalUsageTowardLimit")]
        public ulong TotalBytesUsed;
    }

    public class ContainerCPUStatApiModel
    {
        public ulong Usage;
    }
}