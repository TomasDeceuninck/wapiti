echo +----------------------------------+
echo + Post environment creation script +
echo +----------------------------------+
echo
echo Registering the Microsoft feeds
echo -------------------------------
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
sudo DEBIAN_FRONTEND=noninteractive mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
wget -q https://packages.microsoft.com/config/debian/9/prod.list
sudo DEBIAN_FRONTEND=noninteractive mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
sudo DEBIAN_FRONTEND=noninteractive chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
sudo DEBIAN_FRONTEND=noninteractive chown root:root /etc/apt/sources.list.d/microsoft-prod.list
echo
echo Installing .Net Core 3.0
echo ------------------------
sudo DEBIAN_FRONTEND=noninteractive apt-get update -y
sudo DEBIAN_FRONTEND=noninteractive apt-get install apt-transport-https -y
sudo DEBIAN_FRONTEND=noninteractive apt-get update -y
sudo DEBIAN_FRONTEND=noninteractive apt-get install dotnet-sdk-3.0 -y
echo
echo Installing PowerShell
echo ---------------------
dotnet tool install --global PowerShell
