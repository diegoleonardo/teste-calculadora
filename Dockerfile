# Build image
FROM microsoft/dotnet:2.2-sdk AS builder
WORKDIR /sln

COPY ./src/Calculadora.Core/Calculadora.Core.csproj  ./src/Calculadora.Core/Calculadora.Core.csproj
COPY ./src/Calculadora.WebApi/Calculadora.WebApi.csproj  ./src/Calculadora.WebApi/Calculadora.WebApi.csproj
COPY ./testes/Calculadora.Testes/Calculadora.Testes.csproj  ./testes/Calculadora.Testes/Calculadora.Testes.csproj
COPY ./testes/Calculadora.TestesIntegracao/Calculadora.TestesIntegracao.csproj ./testes/Calculadora.TestesIntegracao/Calculadora.TestesIntegracao.csproj

RUN dotnet restore ./src/Calculadora.Core/Calculadora.Core.csproj
RUN dotnet restore ./src/Calculadora.WebApi/Calculadora.WebApi.csproj
RUN dotnet restore ./testes/Calculadora.Testes/Calculadora.Testes.csproj
RUN dotnet restore ./testes/Calculadora.TestesIntegracao/Calculadora.TestesIntegracao.csproj

COPY ./testes ./testes
COPY ./src ./src

RUN dotnet build ./src/Calculadora.WebApi/Calculadora.WebApi.csproj -c Release --no-restore

RUN dotnet test ./testes/Calculadora.Testes/Calculadora.Testes.csproj

RUN dotnet test ./testes/Calculadora.TestesIntegracao/Calculadora.TestesIntegracao.csproj

RUN dotnet publish ./src/Calculadora.WebApi/Calculadora.WebApi.csproj -c Release -o "../../dist" --no-restore

#App image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=builder /sln/dist .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Calculadora.WebApi.dll