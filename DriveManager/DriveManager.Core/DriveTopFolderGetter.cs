namespace DriveManager.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Http;
    using Google.Apis.Services;

    public class DriveTopFolderGetter
    {
        private static string applicationName = "DriveManager";

        public void GetTopFoldersOf(IConfigurableHttpClientInitializer credentials)
        {
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = applicationName,
            });

            List<File> files = GetFiles(service);
            IEnumerable<File> topFiles = files.Where(o => o.Parents.Any() == false);
        }

        /// <summary>
        /// source: http://www.daimto.com/google-drive-api-c/
        /// </summary>
        private static List<File> GetFiles(DriveService service)
        {

            List<File> files = new List<File>();

            try
            {
                //List all of the files and directories for the current user.  
                // Documentation: https://developers.google.com/drive/v2/reference/files/list
                FilesResource.ListRequest list = service.Files.List();
                list.MaxResults = 1000;
                FileList filesFeed = list.Execute();

                //// Loop through until we arrive at an empty page
                while (filesFeed.Items != null)
                {
                    // Adding each item  to the list.
                    foreach (File item in filesFeed.Items)
                    {
                        files.Add(item);
                    }

                    // We will know we are on the last page when the next page token is
                    // null.
                    // If this is the case, break.
                    if (filesFeed.NextPageToken == null)
                    {
                        break;
                    }

                    // Prepare the next page of results
                    list.PageToken = filesFeed.NextPageToken;

                    // Execute and process the next page request
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex)
            {
                // In the event there is an error with the request.
                Console.WriteLine(ex.Message);
            }
            return files;
        }
    }
}