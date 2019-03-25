# Calculadora de Juros

[![Build Status](https://circleci.com/gh/diegoleonardo/teste-calculadora.svg?style=svg)](https://circleci.com/gh/diegoleonardo/teste-calculadora)

Esse é um projeto de teste que realiza o cálculo de juros composto, recebendo valores inteiros como parametros:
 - valorinicial
 - meses

O retorno é o resultado no tipo decimal com duas casas após a vírgula.
Ela está acessível através da url:
https://teste-calculadora.herokuapp.com/api/calculadora/calculajuros?valorinicial={valorinicial}&meses={meses}

Obs: O valor percentual dos juros está fixo em 1%.

# Execução
Para executar o projeto, basta clona-lo e rodar o comando dotnet run no projeto web,
ou usar o Dockerfile (forma mais recomandada).

# Swagger
Esse projeto possue API descrita através da seguinte url:
https://teste-calculadora.herokuapp.com/swagger
