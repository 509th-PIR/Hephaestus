﻿using AddonBuilder.Utility;
using RestSharp;
using RestSharp.Deserializers;

namespace AddonBuilder.Classes.Updates
{
    class GetLatestVersion
    {
        class GitHubData
        {
            public string TagName { get; set; }
        }

        static string ReleaseVersion { get; set; } = "";

        public static string GetVersionFromGitHub()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/repos/ArmaAchilles/AddonBuilder/releases/latest");

            IRestResponse response = client.Execute<GitHubData>(request);

            if (response.IsSuccessful)
            {
                GitHubData data = new JsonDeserializer().Deserialize<GitHubData>(response);
                ReleaseVersion = data.TagName;
            }
            else
            {
                ConsoleUtil.ShowConsoleErrorMsg("Failed to fetch latest version of Addon Builder!");
            }

            return ReleaseVersion;
        }
    }
}