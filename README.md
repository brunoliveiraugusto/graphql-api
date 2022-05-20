# GraphQL API
Projeto com finalidade de definir a combinação de números necessária para atingir o alvo definido com base em uma sequência de números.

### Sobre o projeto:
O Projeto foi desenvolvido utilizando .Net 5.0, bibliotecas auxiliares como GraphQL para requisições HTTP, banco de dados em memória para armazenamento do histórico de chamadas, XUnit para contrução de testes de unidade e algumas bibliotecas auxiliares e padrões de projeto para facilitar o desenvolvimento.

### Execução: 

Para a execução do projeto basta acessar a url https://teste.com.br e seguir os passos abaixo para realizar o consumo das APIS:

1º - Para gerar uma combinação, utilize como base a query abaixo:

```
query {
  combinations(sequence: "[100, 22, 34, 50]", target: 20) {
    combination
  }
}
```

2º - Para consultar o histórico de combinações, utilize como base a query abaixo:

```
query {
  historyCall(start: "10-05-2022", end: "20-05-2022") {
    id,
    date,
    sequence,
    result,
    target
  }
}
```

ATENÇÃO: Como mencionado acima, o banco de dados utilizado para aplicação é em memória, portanto, ao abandonar a sessão e realizar um novo acesso, as informações gravadas anteriormente serão perdidas. A opção por utilizar um banco de dados em memória foi para fins de exemplificação e também para facilitar o deploy da aplicação em um ambiente de núvem gratuíto sem existir a necessidade de disponibilidade de um banco de dados real.