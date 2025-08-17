#!/bin/sh
git checkout main
git pull -r
git checkout -b day/$1
dotnet new console -n $1
cd $1
dotnet add reference ../Helpers/Helpers.csproj
cd ../tests
dotnet new xunit -n $1tests
cd $1tests
dotnet add reference ../../$1/$1.csproj
dotnet add reference ../../Helpers/Helpers.csproj
dotnet add package Shouldly
dotnet restore
cd ../..
git add .
git commit -m "Add new day $1"
git push --set-upstream origin day/$1