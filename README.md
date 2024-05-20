# faxpi-blog-simples

Projeto de Blog Simples

## Instalação da aplicação

**Utilizando Docker:**

**Requisitos mínimos:** docker instalado na maquina.
Acesse a pasta **FaxpiBlogSimples**  onde está localizado o arquivo **docker-compose.yml**
Execute os seguintes comandos utilizando o terminal:

    docker-compose build
Após terminar, execute em seguida:

    docker-compose up
    
Isso ira subir o banco de dados postgres e a aplicação web **faxpiblogsimples.app**.
Para acessar a aplicação utilize a seguinte URL no navegador:http://{Container IP}:8090 ou http://{IP da sua maquina}:5000 , se preferir alterar a porta, acesse o arquivo docker-compose.yml e altere a linha 16.

**Utilizando Visual Studio:**

**Requisitos mínimos**: postgres instalado na maquina.

 1. Defina o projeto **FaxpiBlogSimples.App** como projeto de inicialização.

 2. Altere o arquivo **appsettings.json** localizado no projeto
    **FaxpiBlogSimples.App** para informar o endereço do banco de dados postgres instalado na sua maquina.

 3. Execute o projeto.
