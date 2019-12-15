#!/bin/bash
dotnet clean
dotnet build /p:DebugType=Full
dotnet minicover instrument --workdir ../ --assemblies Calculator.ConsoleApp.Tests/**/bin/**/*.dll --sources Calculator.ConsoleApp/**/*.cs --sources Calculator.ConsoleApp/**/**/*.cs

dotnet minicover reset --workdir ../

dotnet test --no-build
dotnet minicover uninstrument --workdir ../
dotnet minicover report --workdir ../ --threshold 70