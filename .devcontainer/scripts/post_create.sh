#!/usr/bin/env bash

dotnet restore
dotnet tool restore
dotnet dev-certs https

pnpm install
pnpm build
