@echo off

rmdir NuGetPackage /s /q
mkdir NuGetPackage
mkdir NuGetPackage\Epicycle.Physics-cs.0.1.0.0
mkdir NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib

copy package.nuspec NuGetPackage\Epicycle.Physics-cs.0.1.0.0\Epicycle.Physics-cs.0.1.0.0.nuspec
copy README.md NuGetPackage\Epicycle.Physics-cs.0.1.0.0\README.md
copy LICENSE NuGetPackage\Epicycle.Physics-cs.0.1.0.0\LICENSE

xcopy bin\net35\Release\Epicycle.Physics_cs.dll NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net35\
xcopy bin\net35\Release\Epicycle.Physics_cs.pdb NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net35\
xcopy bin\net35\Release\Epicycle.Physics_cs.xml NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net35\
xcopy bin\net40\Release\Epicycle.Physics_cs.dll NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net40\
xcopy bin\net40\Release\Epicycle.Physics_cs.pdb NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net40\
xcopy bin\net40\Release\Epicycle.Physics_cs.xml NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net40\
xcopy bin\net45\Release\Epicycle.Physics_cs.dll NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net45\
xcopy bin\net45\Release\Epicycle.Physics_cs.pdb NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net45\
xcopy bin\net45\Release\Epicycle.Physics_cs.xml NuGetPackage\Epicycle.Physics-cs.0.1.0.0\lib\net45\

pause