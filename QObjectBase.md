# Introdução #

QObjectBase é a classe de persistência do XFunny.

**Namespace:** XFunny.QAccess

**Assembly:** XFunny.dll

# Hierarquia #

<a href='Hidden comment: * System.Object'></a>
  * System.Object
    * QObjectBase

# Detalhes #

A classe QObjectBase é utilizada para persistência de dados. Quando uma classe herda a QObjectBase ela passa a suportar:
  * Persistência na Base de dados;
  * Criação do identificador único OCod (_Object Code_);
  * Suporta deleção do objeto;

### Código C# ###
```
public abstract class QObjectBase : IObject, IDisposable
```

[XFunny](XFunny.md)/[QObjectBase](QObjectBase.md)

