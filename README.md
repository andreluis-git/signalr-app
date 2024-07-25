# signalr-app

Estudo prático da aplicação do SignalR para criação de chat.

## Poc.ChatService
Web aplication com a implementação do SignalR Service.

## Poc.ChatConsoleApp
Console aplication com o SignalR Client integrada para comunicação via chat utilizando o serviço disponível no Poc.ChatService

## poc.chatapp
Client web desenvolvido em React com o SignalR Client integrada para comunicação via chat utilizando o serviço disponível no Poc.ChatService

# Getting started

Pré-requisitos:
```
node v22.3.0
dotnet v8.0
```

Baixe o projeto em uma pasta local:
```
git clone https://github.com/andreluis-git/signalr-app.git
```

Com o terminal aberto na pasta onde foi baixado o projeto execute os seguintes comandos para rodar cada aplicação:
Poc.ChatService
```
dotnet run --project ./signalr-app/Poc.ChatService/ --launch-profile "http"
```

poc.chatapp
```
cd signalr-app/poc.chatapp
npm i
npm run dev
```
Após rodar o comando basta acessar a url: http://localhost:3000

*Caso queira rodar também a aplicação console, em um novo terminal, acesse a pasta onde baixou os projetos e execute o comando:
Poc.ChatConsoleApp
```
dotnet run --project ./signalr-app/Poc.ChatService/ --launch-profile "http"
```



