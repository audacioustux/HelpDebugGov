FROM mcr.microsoft.com/devcontainers/dotnet:7.0

SHELL ["/bin/bash", "--login", "-c"]
RUN echo "source /usr/local/share/nvm/nvm.sh" >> ~/.bashrc
RUN nvm install node
RUN npm install -g pnpm
