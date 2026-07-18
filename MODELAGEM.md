
## 📖 Classe Personagem

```c#
Classe Personagem

// Identificação
- int Id
- string Nome
- string? NomeOriginal
- string? Biografia
- DateTime DataNascimento
- bool EstaVivo

// Relacionamentos
- Potentia Potentia
- ICollection<Versao> Versoes

- ICollection<Afiliacao> Afiliacoes
  
- ICollection<Parentesco> Parentes
``` 

## 👨‍👩‍👧 Classe Parentesco

```cs
Classe Parentesco

// Identificação
- int Id

// Relacionamentos

- int IdPersonagem [FK]
- Personagem Personagem
  
- int IdParente [FK]
- Personagem Parente

// Informações
- TipoParentesco TipoParentesco
  
enum TipoParentesco {
    Pai,
    Mae,
    Filho,
    Filha,
    Irmao,
    Irma,
    Primo,
    Prima,
    Tio,
    Tia,
    Esposa,
    Marido,
    Mestre,
    Aprendiz
};
```

## ⚡ Classe Potentia

```cs
Classe Potentia

// Identificação
- int Id
- string? Nome

// Informações
- string? Descricao
- string? LinkMusica

// Relacionamentos
- ICollection<Habilidade> Habilidades
  
- int IdPersonagem [FK]
- Personagem Personagem 
```

## 🧬 Classe Habilidades

```cs
Classe Habilidade

// Identificação
- int Id
- string Nome

// Informações
- string Descricao
  
- int idPotentia [FK]
- Potentia Potentia
```

## 🎭 Classe Versao

```cs
Classe Versao

// Identificação
- int Id
- string? Nome

// Aparência
- string? Genero
- string? UrlImagem

// Cronologia
- int IdadeInicial
- int? IdadeFinal

// Informações
- string? Descricao
- string? Personalidade

// Relacionamentos
- int IdPersonagem [FK]
- Personagem Personagem 
  
- ICollection<Tecnica> Tecnicas
- ICollection<Hobby> Hobbies
  
- ICollection<Volume> Volumes
  
public enum Genero {
    Masculino,
    Feminino,
    NaoBinario,
    GeneroFluido,
    Poligenero,
    Outro,
    NaoInformado
}
``` 

## 🎮 Classe Hobby

```cs
Classe Hobby

// Identificação
- int Id
- string Nome

// Informações
- string? Descricao
  
// Relacionamentos
- int IdVersao [FK]
- Versao Versao
```

## 🗡 Classe Tecnica

```cs
Classe Tecnica

// Identificação
- int Id
- string Nome

// Informações
- string? Descricao
- string? Categoria
  
// Relacionamentos
- int IdVersao [FK]
- Versao Versao
```

## 🏛 Afiliacao

```cs
Classe Afiliacao

// Identificação
- int Id
- string? Nome

// Informações
- string? Descricao
```

## 📚 Volumes

```cs
Classe Volume

// Identificação
- int Id
- int Numero
- string? Nome

// Informações
- DateTime? DataLancamento
- string? MensagemVolume
- string UrlCapa

// Relacionamentos
- ICollection<Capitulo> Capitulos
```

## 📄 Capitulo

```cs
Classe Capitulo

// Identificação
- int Id
- int Numero
- string? Titulo

// Informações
- string? Resumo
- int NumeroPaginas

```

```bash
📖 Personagem
    │
    ├── ⚡ Potentia
    │      └── 🧬 Habilidades
    │
    ├── 🎭 Versões
    │      ├── 🗡 Técnicas
    │      ├── 🎮 Hobbies
    │      └── 📚 Volumes
    │
    ├── 🏛 Afiliações
    │
    └── 👨‍👩‍👧 Parentescos

📚 Volume
    └── 📄 Capítulos
````