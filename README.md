# HmzTest API

Esta é uma API RESTful construída para demonstrar operações de gerenciamento de usuários. Com ela, é possível realizar o registro, autenticação, visualização, atualização e exclusão de usuários de forma segura e eficiente.

## Pré-requisitos

- Docker e Docker Compose instalados na sua máquina.
- As portas 8080, 8081 e 1433 devem estar disponíveis.

## Endpoints

### Autenticação e Registro

- `POST /register`: Registra um novo usuário. Espera um JSON com `email` e `password`.
- `POST /login`: Autentica um usuário. Espera um JSON com `email` e `password`.

### Gerenciamento de Usuários

- `GET /users`: Lista todos os usuários. Requer autenticação.
- `GET /users/{id}`: Retorna os detalhes de um usuário específico pelo seu ID. Requer autenticação.
- `PATCH /users/{id}`: Atualiza informações de um usuário específico pelo seu ID. Requer autenticação.
- `DELETE /users/{id}`: Remove um usuário específico pelo seu ID. Requer autenticação.

## Rodando a API

Para executar a API localmente, você precisa ter o Docker e o Docker Compose instalados em sua máquina. Siga os passos abaixo para subir o serviço da API e acessá-la:

1. Clonar o Repositório

```
git clone https://github.com/nalyx1/HmzTest.git
```

2. Navegar para o Diretório do Projeto

```
cd HmzTest
```

3. Inicializar os Contêineres

```
docker compose up --build -d
```

4. Após a inicialização dos contêineres, a API estará acessível através do endereço:

🌐 http://localhost:8080/swagger

## Notas Adicionais

- Acesso Admin Padrão: Utilize as seguintes credenciais de admin para testes iniciais:

```
Email: admin@example.com
Senha: HmzTest123!
```
