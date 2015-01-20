@echo off

cd projects
msbuild Epicycle.Physics.net35.sln /t:Clean,Build /p:Configuration=Debug
msbuild Epicycle.Physics.net35.sln /t:Clean,Build /p:Configuration=Release
msbuild Epicycle.Physics.net40.sln /t:Clean,Build /p:Configuration=Debug
msbuild Epicycle.Physics.net40.sln /t:Clean,Build /p:Configuration=Release
msbuild Epicycle.Physics.net45.sln /t:Clean,Build /p:Configuration=Debug
msbuild Epicycle.Physics.net45.sln /t:Clean,Build /p:Configuration=Release

pause
