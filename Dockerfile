# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Install Google Chrome
#!/bin/bash
RUN apt-get update \
&& apt-get install -y wget curl unzip gnupg \
&& curl -ksS -o - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
&& echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list \
&& apt-get update \
&& apt-get -yqq install google-chrome-stable \
&& apt-get clean \
&& rm -rf /var/lib/apt/lists/*
# Copy the entire project to the container
COPY . ./
# Restore the dependencies
RUN dotnet restore

# Build the project
RUN dotnet build --configuration Debug --no-restore

WORKDIR /app/FrameWork_ThanhLM10/bin/Debug/net6.0
# Set the entry point for the container (replace YourTestProject.dll with the actual name of your test project)
ENTRYPOINT ["dotnet", "test", "--filter" ,"TestCategory=smoke", "SeleniumCSharp.dll"]