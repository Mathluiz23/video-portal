# Projeto Portal de Vídeos

# Orientações

<details>
  <summary><strong>‼️ Executar Projeto</strong></summary><br />

1. Clone o repositório

- Use o comando: `git clone git@github.com:Mathluiz23/video-portal.git`.
- Entre na pasta do repositório que você acabou de clonar:
  - `cd git@github.com:Mathluiz23/video-portal.git`

2. Instale as dependências

- Entre na pasta `src/`.
- Execute o comando: `dotnet restore`.
</details>

<details>
  <summary><strong>🛠 Testes</strong></summary><br />

### Executando todos os testes

Para executar os testes com o .NET, execute o comando dentro do diretório do seu projeto `src/<project>` ou de seus testes `src/<project>.Test`!

```
dotnet test
```

### Executando um teste específico

Para executar um teste específico, basta executar o comando `dotnet test --filter Name~TestMethod1`.

</details>

# O Projeto

Este projeto consiste na criação de uma api que controla um portal de vídeos.

## Estrutura

## 1 - Models

<details>
  <summary>Implementado os Models</summary>
  <br />

Criado um arquivo para cada `Model` na pasta `src/video-portal/Models`. Todos com _namespace_ `video_portal.Models`.

  <details>
    <summary> Model <code>Channel</code></summary>
    <br />
    
Channel contém os campos:
- `ChannelId`: Chave primária (int)
- `ChannelName`: string
- `ChannelDescription`: string (anulável)
- `Url`: string

Cada canal tem vários vídeos e várias pessoas usuárias. A propriedade de navegação para `Video` chama `Videos` e para `User` é `Owners`.

  </details>

  <details>
    <summary>Model <code>Comment</code></summary>
    <br />
    
Comment contém os campos:
- `CommentId`: Chave primária (int)
- `CommentText`: string
- `VideoId`: chave estrangeira para vídeos
- `UserId`: chave estrangeira para pessoas usuárias

Cada commentário pertence a um vídeo e a uma pessoa usuária.

  </details>

  <details>
    <summary>Model <code>User</code></summary>
    <br />
    
User contém os campos:
- `UserId`: Chave primária (int)
- `Username`: string
- `Email`: string

Cada pessoa usuária tem vários canais. A propriedade de navegação para `Channel` se chama `Channels`.
Cada pessoa usuária tem vários comentários. A propriedade de navegação para `Comment` se chama `Comments`.

  </details>

  <details>
    <summary>Model <code>Video</code></summary>
    <br />
    
Vídeo contém os campos:
- `VideoId`: Chave primária (int)
- `Title`: string
- `Description`: string (anulável)
- `Url`: string
- `ChannelId`: chave estrangeira para `Channel`

Cada vídeo tem vários comentários. A propriedade de navegação para `Comment` se chama `Comments`.

  </details>
</details>

## 2 - Implementado Context de banco de dados

<details>
  <summary>O contexto contém todos os <i>Models</i> da aplicação</summary>
  <br />

Criado `override` do método `OnConfiguring` para o contexto se conectar ao seu banco de dados local.

> Caso você queira executar este projeto para testar localmente, em `/src` foi criado o arquivo docker-compose.yml com um banco SqlServer. Poderá usar essa base, tenha o Docker e o docker-compose instalado na sua máquina!

> Você pode criar as tabelas do banco de dados atráves do comando `dotnet ef database update`. Caso você execute esse comando, certifique-se de que o CLI do Entity Framework esteja instalado na sua máquina!

</details>

## 3 - Implementando repositório

<details>
  <summary>Implementando interface <code>IVideoPortalRepository</code></summary>
  <br />

Implementado repositório em `src/video-portal/Repository/VideoPortalRepository.cs` através do contexto.

Os métodos implementados foram:

- `GetVideoById`
- `GetVideos`
- `GetChannelById`
- `GetChannels`
- `GetVideosByChannelId`
- `GetCommentsByVideoId`
- `DeleteChannel`
  - Deletar apenas se o canal não tiver vídeos. Caso tenha uma exceção, irá lançar um `InvalidOperationException`.
- `AddVideoToChannel`
  - Caso o canal ou o vídeo não existam, uma exceção do tipo `InvalidOperationException` será lançada.

</details>

## 4 - Teste listagem de vídeo

<details>
  <summary> Criada a função <code>ShouldReturnAVideoList</code> para testar endpoint </summary>
  <br />

Teste realiza uma requisição `GET` para o endpoint `api/video` e verifica se o retorno condiz com a lista de vídeos recebida como parâmetro.

</details>

## 5 - Teste a listagem do canal

<details>
  <summary> Criada a função <code>ShouldReturnAChannelWithVideos</code> para testar endpoint </summary>
  <br />

Teste realiza uma requisição `GET` para o endpoint `/api/channel/{id}/video` utilizando o `Channel` recebido como parâmetro e verifica se o retorno condiz com a lista de vídeos recebida como parâmetro.

</details>
