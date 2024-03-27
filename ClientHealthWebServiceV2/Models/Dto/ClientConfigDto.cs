namespace ClientHealthWebServiceV2.Models.Configuration
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ClientConfigDto
    {
        [JsonProperty("WebService")]
        public WebServiceJson WebService { get; set; } = new WebServiceJson();

        [JsonProperty("LocalFiles")]
        public LocalFilesJson LocalFiles { get; set; } = new LocalFilesJson();

        [JsonProperty("Client")]
        public List<ClientJson> Client { get; set; } = new List<ClientJson> { };

        [JsonProperty("ClientInstallProperty")]
        public List<string> ClientInstallProperty { get; set; } = new List<string> { };

        [JsonProperty("Log")]
        public List<LogJson> Log { get; set; } = new List<LogJson> { };

        [JsonProperty("Option")]
        public List<OptionJson> Option { get; set; } = new List<OptionJson> { };

        [JsonProperty("Service")]
        public List<ServiceJson> Service { get; set; } = new List<ServiceJson> { };

        [JsonProperty("Remediation")]
        public List<RemediationJson> Remediation { get; set; } = new List<RemediationJson> { };
    }

    public class LocalFilesJson
    {
        [JsonProperty("_comment")]
        public string Comment { get; set; } = "Path locally on computer for temporary files and local clienthealth.log if LocalLogFile=\"True\"";
        [JsonProperty("Value")]
        public string? Value { get; set; }

    }
    public class WebServiceJson
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("Value")]
        public string? Value { get; set; }

        [JsonProperty("Enable")]
        public string? Enable { get; set; }
    }
    public class ClientJson
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("Value")]
        public string? Value { get; set; }

        [JsonProperty("Enable")]
        public string? Enable { get; set; }
    }

    public class LogJson
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("Share")]
        public string? Share { get; set; }

        [JsonProperty("Level")]
        public string? Level { get; set; }

        [JsonProperty("MaxLogHistory")]
        public string? MaxLogHistory { get; set; }

        [JsonProperty("LocalLogFile")]
        public string? LocalLogFile { get; set; }

        [JsonProperty("Enable")]
        public string? Enable { get; set; }

        [JsonProperty("Value")]
        public string? Value { get; set; }

        [JsonProperty("Comment")]
        public string? Comment { get; set; } = "Valid time formats: ClientLocal / UTC";
    }

    public class OptionJson
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("Enable")]
        public string? Enable { get; set; }

        [JsonProperty("Fix")]
        public string? Fix { get; set; }

        [JsonProperty("Value")]
        public string? Value { get; set; }

        [JsonProperty("Days")]
        public string? Days { get; set; }

        [JsonProperty("Share")]
        public string? Share { get; set; }
    }

    public class ServiceJson
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("StartupType")]
        public string? StartupType { get; set; }

        [JsonProperty("State")]
        public string? State { get; set; }

        [JsonProperty("Uptime")]
        public string? Uptime { get; set; }
    }

    public class RemediationJson
    {
        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Fix")]
        public string? Fix { get; set; }

        [JsonProperty("Days")]
        public string? Days { get; set; }
    }
}
