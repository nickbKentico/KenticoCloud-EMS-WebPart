
# KenticoCloud-EMS-WebPart
A web part for [Kentico](https://www.kentico.com) that adds [Kentico Cloud](https://kenticocloud.com/) content to your web site.

## Installation
 1. Download the latest package from [Release](https://github.com/nickbKentico/KenticoCloud-EMS-WebPart/releases)
 2. In Kentico, go to the Sites application
 3. Select "Import sites or objects"
 4. Upload the package and import it (don't forget to check the "Import code files" checkbox)
 5. Now you are ready to use it in the Pages application
 
## Contributing
  1. Read the [contribution guidelines](https://github.com/nickbKentico/KenticoCloud-EMS-WebPart/blob/master/CONTRIBUTING.md)
  2. Enable the [continuous integration](https://docs.kentico.com/display/K10/Setting+up+continuous+integration) module
  3. Serialize all objects to disk
  4. Open a command prompt
  5. Navigate to the root of your project (where the .sln file is)
  6. Fork this repo
  7. Init a git repo and fetch the web part
  
        git init
        git remote add origin https://github.com/owner/repo.git
        git fetch
        git checkout origin/master -ft
  8. Open Kentico Solution in Visual Studio
  9. Add Exisiting Project to Solution (choose KenticoCloudHelpers.csproj)
  10. Add referance to Kentico Cloud Helpers to CMS project
  11. Build Kentico Helper Project (not entire solution)
  12. Restore DB data
  
        Kentico\CMS\bin\ContinuousIntegration.exe -r

  13. Within Kentico Admin interface, navigate to Modules->Kentico Cloud->Settings-Add New Setting Key.  Add a Key with the Displaname and code name of 'KenticoCloudProjectId' the type of: Text and save.  Now you can entire in your Prject ID from the Settings Applicaion under the Kentico Cloud heading.
  14. Make changes
  15. Use combination of `git add`, `git commit` and `git push` to transfer your changes to GitHub
  
        git status
        git commit -a -m "Fixed XY"
        git push

  16. Submit a pull request
