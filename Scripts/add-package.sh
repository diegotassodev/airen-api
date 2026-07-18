#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(cd "$SCRIPT_DIR/.." && pwd)"
cd "$PROJECT_ROOT"

packages=(
  "AutoMapper|12.0.1"
  "AutoMapper.Extensions.Microsoft.DependencyInjection|12.0.1"
  "Microsoft.AspNetCore.OpenApi|10.0.9"
  "Microsoft.EntityFrameworkCore|10.0.9"
  "Microsoft.EntityFrameworkCore.Proxies|10.0.9"
  "Microsoft.EntityFrameworkCore.SqlServer|10.0.9"
  "Microsoft.EntityFrameworkCore.Tools|10.0.9"
  "Pomelo.EntityFrameworkCore.MySql|10.0.0"
)

for package_spec in "${packages[@]}"; do
  IFS='|' read -r package version <<< "$package_spec"
  echo "Adicionando $package ($version)..."
  dotnet add package "$package" --version "$version"
done

echo "Todos os pacotes foram adicionados ao projeto."
