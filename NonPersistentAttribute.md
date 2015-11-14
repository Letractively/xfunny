# Introdução #

NonPersistentAttribute é a classe do tipo atributo do XFunny.

**Namespace:** XFunny.QAccess

**Assembly:** XFunny.dll

# Hierarquia #

<a href='Hidden comment: * System.Object'></a>
  * System.Object
    * System.Attribute
      * NonPersistentAttribute

# Detalhes #

A classe NonPersistentAttribute contém o atributo que informa para o XFunny quais propriedades que não serão campos na tabela criada na base de dados.
suportar:
  * Propriedades que não serão campos;
  * Propriedades que não serão persistidas.

### Código C# ###
```
[AttributeUsage(AttributeTargets.Class|AttributeTargets.Property|AttributeTargets.Field|AttributeTargets.Interface)]
public sealed class NonPersistentAttribute : Attribute
```

[XFunny](XFunny.md)/[NonPersistentAttribute](NonPersistentAttribute.md)

