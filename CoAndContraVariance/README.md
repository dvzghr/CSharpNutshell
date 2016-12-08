Covariance

Enables you to use a more derived type than originally specified.
You can assign an instance of IEnumerable of Derived to a variable of type IEnumerable of Base.

Contravariance

Enables you to use a more generic (less derived) type than originally specified.
You can assign an instance of IEnumerable of Base to a variable of type IEnumerable of Derived.

Invariance

Means that you can use only the type originally specified; so an invariant generic type parameter is neither covariant nor contravariant.
You cannot assign an instance of IEnumerable of Base to a variable of type IEnumerable of Derived or vice versa.
