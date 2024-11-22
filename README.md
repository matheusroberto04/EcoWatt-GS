#**INTEGRANTES**

98207 - Lucca Rinaldi Valladão de Freitas

98624 - Eduardo Foncesca Finardi

551808 - Ricardo Yuri Gonçalves Domingues

550776 - Angélica Ferreira de Matos Melo

98581 - Matheus Roberto Aparecido de Medeiros Carvalho Pereira de Souza

#**Explicação da arquitetura**

*Monolítica, pois utiliza-se uma abordagem mais simples, além de que existe uma facilidade na manutenção, pois o código esta tudo em um único projeto e também existe uma certa rapidez no desenvolvimento*

#**Desing Patterns utilizados**

- [ ] Repository Pattern

#**Instruções para rodar a API**

## ENDPOINTS

`GET` /usuário
Listagem de todos os usuários cadastrados

`Nome`

`Email`

`Senha`

`CEP`

**Códigos de status**

`200` sucesso

`GET` /usuário/{id}

Sistema retorna os detalhes do usuário com o `id` informado.

**Códigos de status**
`200` sucesso

`404` id não encontrado

---

`POST` /usuário

Cadastra um novo usuário
`200` sucesso
`404` id não encontrado

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Nome|String|✅|Inserir um nome curto para identificar o novo usuario.
|Email|String|✅|Adicionar o email.
|Senha|String|✅|Inserir uma senha.
|CEP|String|✅|Inserir um CEP.

---
`DELETE` /usuário/{id}

Apaga o usuário através do `id` informado.

**Códigos de status**

`204` Apagado com sucesso

`404` Id não encontrado 

---

`PUT` /usuário/{id} 

Atualiza o cadastro com o `id` informado.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Nome|String|✅|Inserir um nome curto para identificar o novo usuario.
|Email|String|✅|Adicionar o email.
|Senha|String|✅|Inserir uma senha.
|CEP|String|✅|Inserir um CEP.

**Códigos de status**

`200` Alterado com sucesso.

`404` Id não encontrado.

`400` validação falhou.

---

**Schema**

```js
{
    "usuarioId": 1,
    "Nome": "Cleiton Rasta",
    "email": "robeerson@gmail.com"
    "senha": "234",
    "CEP": "45687954"
}
```

### Eletrodomesticos

`GET` /eletrodomesticos
Lista todos eletrodomesticos

´Eletrodomesticos Id´

´Nome do eletrodomestico´

`200` sucesso

---

`GET` /eletrodomesticos/{id}

Sistema retorna os detalhes do eletrodomestico com o `id` informado.

**Códigos de status**

`200` sucesso
`404` id não encontrado

---
`POST` /eletrodomesticos

Adiciona um novo eletrodomestico no sistema do EcoWatt.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Nome aparelho|String|✅|Cria um novo eletrodomestico.
|Valor do consumo|Int|✅|Adiciona um valor de consumo do eletrodomestico.
|Categoria|String|✅|Adiciona uma categoria do eletrodomestico.
|Modelo|String|✅|Adiciona o modelo do eletrodomestico.

**Códigos de status**

`201` Criado com sucesso
`400` Validação falhou

---

`DELETE` /eletrodomesticos/{id}

Apaga o eletrodomestico atraves do `id` informado.

**Códigos de status**

`204` Apagado com sucesso
`404` Id não encontrado 

---

`PUT` /eletrodomesticos/{id} 

Altera a consultoria com o `id` informado.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Nome aparelho|String|✅|Atualiza um novo eletrodomestico.
|Valor do consumo|Int|✅|Atualiza um valor de consumo do eletrodomestico.
|Categoria|String|✅|Atualiza uma categoria do eletrodomestico.
|Modelo|String|✅|Atualiza o modelo do eletrodomestico.

**Códigos de status**

`200` Alterado com sucesso.
`404` Id não encontrado.
`400` validação falhou.

---

**Schema**

```js
{
    "eletrodomesticoId": 1,
    "Nome": "Iphone 13 Pro Max",
    "Valor_consumo": 15,
    "categoria": "Celular",
    "model": "13 Pro Max"
}
```
### Consumo

`GET` /consumo
Lista todos os consumos

´Consumo Id´

`200` sucesso

---

`GET` /consumo/{id}

Sistema retorna os detalhes dos consumos com o `id` informado.

**Códigos de status**

`200` sucesso
`404` id não encontrado

---
`POST` /consumo

Adiciona um novo consumo no sistema do EcoWatt.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Data consumo|DateTime|✅|Cria uma nova data do consumo.
|Hora consumo|String|✅|Adiciona uma hora ao consumo do eletrodomestico.
|Quantidade Watts|Int|✅|Adiciona uma quantidade de Watts gerada pelo eletrodomestico.

**Códigos de status**

`201` Criado com sucesso
`400` Validação falhou

---

`DELETE` /consumo/{id}

Apaga o consumo atraves do `id` informado.

**Códigos de status**

`204` Apagado com sucesso
`404` Id não encontrado 

---

`PUT` /consumo/{id} 

Altera o consumo com o `id` informado.

| Campo | Tipo | Obrigatório | Descrição
|-------|------|:-------------:|-----------
|Data consumo|DateTime|✅|Atualiza uma nova data do consumo.
|Hora consumo|String|✅|Atualiza uma hora ao consumo do eletrodomestico.
|Quantidade Watts|Int|✅|Atualiza uma quantidade de Watts gerada pelo eletrodomestico.

**Códigos de status**

`200` Alterado com sucesso.
`404` Id não encontrado.
`400` validação falhou.

---

**Schema**

```js
{
    "consumoId": 1,
    "data_Consumo": "2024-12-31",
    "hora_Consumo": 15,
    "quantidade_Watts": 15
}
```



