#load "nuget:?package=Rocket.Surgery.Cake.Library&version=6.2.1";
// #addin "Cake.AzureStorage"

Task("Default")
    .IsDependentOn("dotnet")
    // .IsDependentOn("Schema")
    ;

// Task("Schema")
//     .WithCriteria(GitVer.BranchName == "master")
//     .WithCriteria(!BuildSystem.IsLocalBuild)
// 	.DoesForEach(GetFiles("**/*.schema.json"), (file) => {
//         Information($"Uploading {file.GetFilename().ToString()}...");
//         var settings = new AzureStorageSettings();
//         settings.AccountName = EnvironmentVariable("SCHEMA_STORAGE_NAME");
//         settings.Key = EnvironmentVariable("SCHEMA_STORAGE_KEY");
//         settings.ContainerName = EnvironmentVariable("SCHEMA_STORAGE_CONTAINER");
//         settings.BlobName = file.GetFilename().ToString();
//         UploadFileToBlob(settings, file.ToString());
//     });

RunTarget(Target);
