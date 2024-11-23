Este é um sistema de gestão desenvolvido com ASP.NET Core para cadastro de usuários, dispositivos e configurações. A aplicação utiliza a arquitetura MVC (Model-View-Controller) para organizar e estruturar o código de maneira eficiente.

## VINICIUS LORENZETTI RM:553121
## JOAO PEDRO FONTANA RM:553343
## MARCELO GALI RM: 553654
## Funcionalidades

1. **Cadastro de Usuário**
   - Permite que o administrador registre novos usuários no sistema.
   - Campos: IdUsuario, Nome, Email, Telefone, Endereco, DataCriacao.

2. **Cadastro de Dispositivo**
   - Cadastro de novos dispositivos com informações como IdUsuario, TipoDispositivo, DataInstalacao.

3. **Cadastro de Configuração**
   - Criação de configuração de alerta de cortes de energia com informações como IdConfiguracao, IdUsuario, LimiteAlerta, HorarioCorteInicio, HorarioCorteFim, Preferencias.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework principal para desenvolvimento web.
- **Bootstrap**: Framework CSS para garantir um design responsivo.
- **MVC (Model-View-Controller)**: Arquitetura utilizada para organizar a aplicação.
- **HTML5**: Marcação semântica para a interface do usuário.
- **CSS**: Estilização da interface.

## Estrutura do Projeto

O projeto está estruturado conforme o padrão MVC (Model-View-Controller):

- **Model**: Contém as classes de dados e regras de negócios (ViewModels).
- **View**: Contém os arquivos de interface do usuário (HTML, Razor).
- **Controller**: Lógica de controle para a interação entre o modelo e a visualização.

## Endpoints da API

### 1. Cadastro de Usuário

- **Endpoint**: /Usuario/Cadastrar
- **Método HTTP**: POST
- **Descrição**: Este endpoint permite o cadastro de novos usuários.
- **Campos esperados no corpo da requisição**:
- Nome: Nome do usuário.
- Email: Email do usuário.
- Telefone: Telefone de contato.
- Endereco: Endereço do usuário.

- **Exemplo de requisição**:
```json
{
"Nome": "Carlos Silva",
"Email": "carlos.silva@email.com",
"Telefone": "1234-5678",
"Endereco": "Rua das Flores, 123"
}
```

### 2. Cadastro de Dispositivo

- **Endpoint**: /Dispositivo/Cadastrar
- **Método HTTP**: POST
- **Descrição**: Este endpoint permite o cadastro de novos dispositivos.
- **Campos esperados no corpo da requisição**:
- IdUsuario: ID do usuário associado ao dispositivo.
- TipoDispositivo: Tipo do dispositivo.
- DataInstalacao: Data de instalação do dispositivo.

- **Exemplo de requisição**:
```json
{
"IdUsuario": 1,
"TipoDispositivo": "Roteador",
"DataInstalacao": "2023-10-01"
}
```

### 3. Cadastro de Configuração

- **Endpoint**: /Configuracao/Cadastrar
- **Método HTTP**: POST
- **Descrição**: Este endpoint permite a criação de configurações para alertas de cortes de energia.
- **Campos esperados no corpo da requisição**:
- IdUsuario: ID do usuário.
- LimiteAlerta: Limite que aciona o alerta.
- HorarioCorteInicio: Horário inicial para o alerta.
- HorarioCorteFim: Horário final do alerta.
- Preferencias: Preferências de notificação.

- **Exemplo de requisição**:
```json
{
"IdUsuario": 1,
"LimiteAlerta": 5,
"HorarioCorteInicio": "18:00",
"HorarioCorteFim": "20:00",
"Preferencias": "Email"
}
