# Aplicação para realização de CRUD's de usuários

### Observações:
1. Necessário um banco de dados SQL Server para implementação das tabelas utilizadas pela aplicação
2. Foi utilizado Code First, sendo assim, as migrations serão aplicadas assim que inicar a aplicação.
3. Necessário inserir, como variável de ambiente e na region de ConnectionStrings, uma connectionString responsável pela referência de conexão do banco de dados. Esta variável de ambiente terá o nome de BancoConfitec.
4. Para os métodos de GET, foi utilizado o OData para auxiliar e flexibilizar o consumo dos dados. Sendo assim, pode-se filtrar diretamente na queryString do endpoint e, esse filtro, será repassado diretamente para o banco. Link de como montar o filtro: https://docs.microsoft.com/pt-br/graph/query-parameters
5. Foi utilizado a versão do .NET 5.0 para a implementação da aplicação.
