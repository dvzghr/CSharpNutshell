# CSharpNutshell
C# features cracked in a nutshell

Covariance

Enables you to use a more derived type than originally specified.
You can assign an instance of IEnumerable<Derived> to a variable of type IEnumerable<Base>.

Contravariance

Enables you to use a more generic (less derived) type than originally specified.
You can assign an instance of IEnumerable<Base> to a variable of type IEnumerable<Derived>.

Invariance

Means that you can use only the type originally specified; so an invariant generic type parameter is neither covariant nor contravariant.
You cannot assign an instance of IEnumerable<Base> to a variable of type IEnumerable<Derived> or vice versa.
