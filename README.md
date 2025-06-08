# 🗂️ Padrão Repository em C# com Persistência em JSON

Este repositório apresenta uma série de implementações do **Padrão Repository**, utilizando a linguagem **C#** e persistência de dados em **arquivos JSON** com `System.Text.Json`.

O conteúdo foi estruturado com base em exemplos educacionais e práticos, cobrindo desde repositórios simples até abordagens mais complexas com consultas, filtros, relacionamentos e uso de memória.

---

## 🎯 Objetivos

- Entender o funcionamento do padrão Repository
- Aplicar boas práticas de separação de responsabilidades
- Implementar repositórios específicos, genéricos e especializados
- Utilizar persistência em arquivos `.json`
- Trabalhar com entidades relacionadas
- Criar consultas customizadas e filtros

---

## 📚 Conteúdo do Projeto

### ✅ Repositórios Específicos
- **Catálogo de Produtos**  
  Repositório para a entidade `Produto` com persistência em `produtos.json`.

### ✅ Repositórios Genéricos
- **Biblioteca de Músicas**  
  Uso de `GenericJsonRepository` para gerenciar músicas com a interface `IEntidade`.

### ✅ Repositório Especializado
- **Catálogo de Filmes com Filtro por Gênero**  
  Herança de repositório genérico + método `ObterPorGenero`.

### ✅ Relacionamentos
- **Funcionários e Departamentos**  
  Modelagem de relacionamento via `DepartamentoId`.

### ✅ Consultas com Filtros
- **Pacientes por Faixa Etária**  
  Cálculo de idade e busca por faixa usando `DateTime`.

### ✅ Repositório em Memória
- **Inventário de Equipamentos de TI**  
  CRUD em memória para testes rápidos com `List<T>` interna.

### ✅ Hierarquia de Tipos
- **Sistema de Pedidos de Restaurante**  
  Uso de classe base `ItemCardapio` com subclasses `Prato` e `Bebida`.

### ✅ Refatoração com Repositório Genérico
- **Gerenciador de Arquivos Digitais**  
  Refatoração para herdar de `GenericJsonRepository` e remover duplicações.

### ✅ Enum e Consultas por Status
- **Sistema de Reservas de Hotel**  
  Uso de enum `StatusReserva` e filtro por status da reserva.

### ✅ Aplicação Completa
- **Plataforma de Cursos Online**  
  Exemplo completo com entidade `CursoOnline`, repositório especializado e `CatalogoCursosService` com lógica de negócios para evitar duplicações.

---

## 🧱 Estrutura Usada Para Pastas

```
/Projeto/
├── Entidades/               # Todas as entidades como Produto, Musica, Filme, etc.
├── Interfaces/              # IEntidade, IRepository<T>, repositórios especializados
├── Implementacoes/          # Repositórios genéricos e especializados, serviços
├── Tests/                   # (Opcional) Testes unitários
└── Program.cs               # Ponto de entrada dos exemplos ou app de demonstração
```

---

## 🧪 Execução

### Pré-requisitos
- [.NET 6.0 ou superior](https://dotnet.microsoft.com/download)

## 👨‍🏫 Créditos

Baseado em materiais didáticos e exercícios propostos com foco em arquitetura limpa e boas práticas em C#.

## 🖊 Feito Por 

Pablo Emanuel Cechim Lima
Tawan Vitor Silva de Oliveira 
