# MeetingPlanerAPI

API Rest Desenvolvida com C# para integração com front-end do agendador de reuniões.

-----------------------------
# Instruções

Para rodar o projeto C#, basta clonar o repositório e abrir o arquivo .sln com o Visual Studio 2022, no qual o mesmo foi programado.
Além disso é necessário que se faça um setup local de um banco de dados MySql, para tal utilizei esse tutorial:

https://www.alura.com.br/artigos/mysql-do-download-e-instalacao-ate-sua-primeira-tabela#download-do-mysql
(é importante ressaltar que no meu caso, coloquei a senha do localhost como admin123, e como já está configurado assim 
no AppSettings do projeto recomendo fazer o mesmo).

Além disso, o repositório conta com um pasta **data** com um arquivo **MySqlData.sql** dentro, esse arquivo conta com os schemas e tabelas já populadas com
os dados que utilizei durante o desenvolvimento, para importar basta seguir este tutorial:
https://dev.mysql.com/doc/workbench/en/wb-admin-export-import-management.html

----------------------------
# A Solução

Para resolver a questão proposta escolhi por dividir as responsabilidades entre as reuniões em sí (no código chamo de meetings) e os locais das reuniões (locations)
para tal desenhei um esquema do banco no MySQL Workbench.

![image](https://user-images.githubusercontent.com/40584329/200055449-78ef04c1-c9a1-4534-b2b5-6fd9a2a329ae.png)



A escolha foi feita pensando na implementação do front-end, como havia pensado em implementar um menu que poderia ser facilmente alterável atráves do banco de dados
preferi por separar as duas ideias, podendo assim buscar os locais primeiro e, após a escolha do usuário através dos menus, buscar as reuniões depois,
Para alteração, exclusão e edição de reuniões utilizei um token único para cada, tendo acesso aos mesmos no frontend para rodar as operações descritas no MeetingsController.cs 
(Buscar, adicionar, editar e excluir).

----------------------------
# Avisos

 - Para que o front-end funcione corretamente é imprescindível que o back-end esteja funcionando, portanto disponibilizei também alguns arquivos do 
   Postman, também na pasta *data*, com nome de *Postman* se forem necessários.
 - A chave de conexão para o banco MySQL Local se encontra no arquivo AppSettings.json, caso haja alguma necessidade de trocar as configurações
   
----------------------------

# Tecnologias, Escolhas, Aprendizados

Para o desenvolvimento desse projeto usei das seguintes tecnologias, bibliotecas e arquiteturas, pontuarei o motivo de escolha de algumas:
  - MySql: Apesar de ter experiência com SQL, nunca tinha me envolvido com o MySQL em especifíco, foi um bom aprendizado, o aplicativo Desktop dele é ótimo
  - Dapper: A biblioteca que eu mais tenho costume para mexer com banco de dados, intuitiva e facilita a inserção de paramêtros das Queries SQL no código
  - Arquitetura em camadas (Controller-Service-Repository): Utilizo por acreditar ser uma boa forma de separar as responsabilidades do código, principalmente quando se trata de API's Rest, 
  nesse caso, o projeot ainda conta com camada exclusivas para objetos de retorno (Entities e DTOs) já que por muitas vezes temos projetos com muitos arquivos de pouco acesso.
  - Principios SOLID: Aqui principalmente fica a questão de inversão de dependências, algo que é facilitado pela arquitetura escolhida, utilizando a Injeção de depêndencia para desacoplar classes de implementações de outras classes.
  - Padrão Transient: devido a baixa carga do programa e por não haver necessidade de manter o escopo entre chamadas optei pelo Transient, que cria um escopo novo, e destroi ele após usar, para cada requisição feita.
  - C#.
  - ASP.NET
  - .NET Core

 ## O que eu mudaria:
  - Sinto que por muitas vezes o código se repete quando há a passagem dos dados entre as camadas, talvez a implementação de um Mapper, ajudaria a deixar o    código mais enxuto.
  - Colocaria autenticação.
  - Adicionar a possibilidade do usuário mudar a reunião de local e sala.
  - Inclusão de Testes Unitários com XUnit (não se fez muito necessário, já que a camada de business conta com pouquissima lógica)
  - Implementação de uma lógica mais robusta para conexão com banco de dados, removendo a necessidade de funções estáticas.

# Obrigado!

Muito obrigado por ler até aqui, aproveita e confere meus outros projetos também! ;D
  
