FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# *************************************************************
# * Uncomment this section to use RUN instructions to install *
# * any needed dependencies after executing "apt-get update". *
# * See https://docs.docker.com/engine/reference/builder/#run *
# *************************************************************
ENV DEBIAN_FRONTEND=noninteractive
RUN apt-get update -y \
   #&& apt-get -y install --no-reccomends <your-package-list-here> \
   && dotnet tool install --global PowerShell \
   #
   # Clean up
   && apt-get autoremove -y \
   && apt-get clean -y \
   && rm -rf /var/lib/apt/lists/*
ENV DEBIAN_FRONTEND=dialog