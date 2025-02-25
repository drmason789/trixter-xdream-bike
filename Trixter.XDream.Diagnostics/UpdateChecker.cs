using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Linq;
using System.Text.Json;


namespace Trixter.XDream.Diagnostics
{

    class UpdateChecker
    {
        private const string githubUrlPattern = "https://api.github.com/repos/{0}/releases";
        private readonly string githubRepoUrl;

        public class ReleaseInfo
        {
            /// <summary>
            /// Release from the tagname.
            /// </summary>
            public Version Release { get; }

            /// <summary>
            /// The name of the release.
            /// </summary>
            public string ReleaseName { get; }

            /// <summary>
            /// The published date of the release.
            /// </summary>
            public DateTime PublishedAt { get; }

            public ReleaseInfo(Version release, string releaseName, DateTime publishedAt)
            {
                Release = release;
                ReleaseName = releaseName;
                PublishedAt = publishedAt;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repo">The github repo, username/reponame</param>
        /// <exception cref="ArgumentException"></exception>
        public UpdateChecker(string repo)
        {
            if(string.IsNullOrEmpty(repo))
                throw new ArgumentException(nameof(repo));
                      
            this.githubRepoUrl = string.Format(githubUrlPattern, repo);
        }

        /// <summary>
        /// Determine if an update exists for the current release.
        /// </summary>
        /// <param name="currentRelease">Optional current release. If not supplied, the version from the executing assembly is used.</param>
        /// <returns></returns>
        public async Task<bool> UpdateExists(Version currentRelease=null)
        {
            var latestRelease = await GetLatestRelease(currentRelease);
            return latestRelease!=null;
        }

        /// <summary>
        /// Get the latest release.
        /// </summary>
        /// <param name="currentRelease">Optional current release. If not supplied, the version from the executing assembly is used.</param>
        /// <returns></returns>
        public async Task<ReleaseInfo> GetLatestRelease(Version currentRelease=null)
        {
            if (currentRelease == null)
                currentRelease = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            var releases = await GetReleases();

            var newRelease = releases.Where(release => release.Release > currentRelease).OrderByDescending(release=>release.Release).FirstOrDefault();

            return newRelease;
        }

        /// <summary>
        /// Get all releases.
        /// </summary>
        /// <returns></returns>
        public async Task<ReleaseInfo[]> GetReleases()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "request");
                                
                var response = await client.GetStringAsync(this.githubRepoUrl);
                var releases = JsonDocument.Parse(response).RootElement;

                var releaseList = new List<ReleaseInfo>();

                foreach (var release in releases.EnumerateArray())
                {
                    var releaseVersionString = release.GetProperty("tag_name").GetString();
                    if (Version.TryParse(releaseVersionString, out var releaseVersion))
                    {
                        var releaseName = release.GetProperty("name").GetString();
                        var publishedAt = release.GetProperty("published_at").GetDateTime();
                        releaseList.Add(new ReleaseInfo(releaseVersion, releaseName, publishedAt));
                    }
                }

                return releaseList.OrderByDescending(r => r.Release).ToArray();
            }
        }
    }



}
