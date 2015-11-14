# Introdução #

AssociationAttribute  é uma classe do tipo atributo do XFunny.

**Namespace:** XFunny.Access

**Assembly:** XFunny.dll

# Hierarquia #

<a href='Hidden comment: * System.Object'></a>
  * System.Object
    * System.Attribute
      * AssociationAttribute

# Detalhes #

A classe AssociationAttribute contém o atributo que informa que a classe que herda o QObjectBase está relacionada com outra de forma explicita. Quando uma classe utiliza esse atributo em suas propriedade o XFunny faz as associações entre as duas classes.

suporta:
  * Associação agregada;
  * Associação composição.

### Código C# ###
```
 [AttributeUsage(AttributeTargets.Property)]
 public class AssociationAttribute: Attribute
```

[XFunny](XFunny.md)/[AssociationAttribute](AssociationAttribute.md)

