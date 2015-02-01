# payments

##Building payments

payments can likely be built using many tools, but the tested configuration is:

(Credits: Thanks [Scott Hanselman] and [Randy Bacon])

- VS 2013 Update 4
  - MSIs (I found this easier to install by downloading from the web site)
     - [Visual Studio Tools for NodeJS] (this installs Node and NPM, you could install Node a different way)

  - Extensions (these were easier to install in VS via Tools/Extensions and Updates...):
     - Web Essentials for VS 2013 Update 4
     - [Task Runner Explorer]
     - [Package Intellisense] (bower/npm intellisense) from command line
     - [Grunt Launcher]
  
- Command line installs (I opened Powershell but used the posh-git shell that Github for Windows shipped)
  - Bower
     - npm install -g bower
  
  - Grunt CLI
     - npm install -g grunt-cli
  
  - Gulp
     - npm install -g gulp
  
*Notes*

.weconfig file shuts off JSCS execution on .js files

[Package Intellisense]:https://visualstudiogallery.msdn.microsoft.com/65748cdb-4087-497e-a394-2e3449c8e61e
[Grunt Launcher]:https://visualstudiogallery.msdn.microsoft.com/dcbc5325-79ef-4b72-960e-0a51ee33a0ff
[Task Runner Explorer]:https://visualstudiogallery.msdn.microsoft.com/8e1b4368-4afb-467a-bc13-9650572db708
[Visual Studio Tools for NodeJS]:http://nodejstools.codeplex.com/
[Randy Bacon]:http://www.baconapplications.com/running-bower-grunt-in-visual-studio-2013/
[Scott Hanselman]:http://www.hanselman.com/blog/IntroducingGulpGruntBowerAndNpmSupportForVisualStudio.aspx