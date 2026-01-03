command to create solution file
  dotnet new sln -n DigitalWallet

command to create console app
  dotnet new console -n DigitalWallet

command to create 
  dotnet new classlib -n DigitalWallet.Core

commands to add paths to solutions file
  dotnet sln DigitalWallet.sln add Digitalwallet/DigitalWallet.csproj
  dotnet sln DigitalWallet.sln add DigitalWallet.Core/DigitalWallet.Core.csproj


command to add class folder reference to project
  dotnet add Digitalwallet/DigitalWallet.csproj reference DigitalWallet.Core/DigitalWallet.Core.csproj
  